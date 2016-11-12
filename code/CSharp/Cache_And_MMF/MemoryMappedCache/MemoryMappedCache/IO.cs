using System;
using System.IO;
using System.Runtime;
using System.Runtime.InteropServices;
using System.Security.Permissions;
using System.Text;

namespace MMFCore.IO
{
    internal sealed class __Error
        {
            // Methods
            private __Error()
            {
            }

            private static string LookupWin32Error(int errorCode, string insert)
            {
                StringBuilder buffer = new StringBuilder(0x400);
                int languageID = 0;
                int num2 = __Native.FormatMessage(0x3000, null, errorCode, languageID, buffer, buffer.Capacity, insert);
                return buffer.ToString();
            }

            internal static void WinIOError()
            {
                WinIOError(string.Empty, Marshal.GetLastWin32Error());
            }

            internal static void WinIOError(string str)
            {
                WinIOError(str, Marshal.GetLastWin32Error());
            }

            internal static void WinIOError(string str, int errorCode)
            {
                int hresult = errorCode;
                if ((hresult & 0x80000000L) == 0L)
                {
                    hresult = -2147024896 | errorCode;
                }
                switch (errorCode)
                {
                    case 2:
                        throw new FileNotFoundException(LookupWin32Error(errorCode, str), str);

                    case 3:
                        throw new DirectoryNotFoundException(__Res.GetString("IO_DirectoryNotFound_Path", new object[] { str }));
                }
                throw new IOException(LookupWin32Error(errorCode, str), hresult);
            }
        }

    public sealed class ConcatStream : Stream
{
    // Fields
    private bool _canSeek;
    private Stream _currentStream;
    private long _length1;
    private Stream _stream1;
    private Stream _stream2;

    // Methods
    private ConcatStream()
    {
    }

    public ConcatStream(Stream stream1, Stream stream2)
    {
        if (stream1 == null)
        {
            throw new ArgumentNullException("stream1");
        }
        if (stream2 == null)
        {
            throw new ArgumentNullException("stream2");
        }
        if (stream1 == stream2)
        {
            throw new ArgumentException(__Res.GetString("Arg_ConcatDiffStreams"));
        }
        if (!stream1.CanRead)
        {
            throw new ArgumentException(__Res.GetString("Arg_NeedReadableStream"), "stream1");
        }
        if (!stream2.CanRead)
        {
            throw new ArgumentException(__Res.GetString("Arg_NeedReadableStream"), "stream2");
        }
        if (stream2.CanSeek && (stream2.Position != 0L))
        {
            throw new ArgumentException(__Res.GetString("Arg_ConcatStartAtBeginning"), "stream2");
        }
        this._stream1 = stream1;
        this._stream2 = stream2;
        this._currentStream = this._stream1;
        this._canSeek = stream1.CanSeek && stream2.CanSeek;
        if (stream1.CanSeek)
        {
            this._length1 = stream1.Length;
        }
        else
        {
            this._length1 = -1L;
        }
    }

    public override void Close()
    {
        this._stream1.Close();
        this._stream2.Close();
        this._canSeek = false;
    }

    public override void Flush()
    {
    }

    public override int Read([In, Out] byte[] bytes, int offset, int count)
    {
        int num = this._currentStream.Read(bytes, offset, count);
        if ((num == 0) && (this._currentStream == this._stream1))
        {
            this._currentStream = this._stream2;
            num = this._currentStream.Read(bytes, offset, count);
        }
        return num;
    }

    public override int ReadByte()
    {
        int num = this._currentStream.ReadByte();
        if ((num == -1) && (this._currentStream == this._stream1))
        {
            this._currentStream = this._stream2;
            num = this._currentStream.ReadByte();
        }
        return num;
    }

    public override long Seek(long offset, SeekOrigin origin)
    {
        if (!this._canSeek)
        {
            throw new IOException("IO_IONotSeekable");
        }
        switch (origin)
        {
            case SeekOrigin.Begin:
                if (offset < this._length1)
                {
                    this._currentStream = this._stream1;
                    this._stream2.Position = 0L;
                    this._stream1.Position = offset;
                    return offset;
                }
                this._currentStream = this._stream2;
                this._stream1.Position = this._length1;
                this._stream2.Position = offset - this._length1;
                return offset;

            case SeekOrigin.Current:
            {
                long position = this._currentStream.Position;
                if (((position + offset) >= 0L) || (this._currentStream != this._stream2))
                {
                    if (((position + offset) > this._length1) && (this._currentStream == this._stream1))
                    {
                        this._currentStream = this._stream2;
                        this._stream2.Position = (position + offset) - this._length1;
                        return (position + offset);
                    }
                    this._currentStream.Seek(offset, origin);
                    if (this._currentStream == this._stream1)
                    {
                        return (position + offset);
                    }
                    return ((this._length1 + position) + offset);
                }
                this._currentStream = this._stream1;
                this._stream2.Position = 0L;
                return this._stream1.Seek(offset + position, SeekOrigin.End);
            }
            case SeekOrigin.End:
            {
                long length = this._stream2.Length;
                if (-offset >= length)
                {
                    this._currentStream = this._stream1;
                    this._stream2.Position = 0L;
                    return this._stream1.Seek(offset + length, SeekOrigin.End);
                }
                this._currentStream = this._stream2;
                return (this._currentStream.Seek(offset, origin) + this._length1);
            }
        }
        throw new ArgumentException("Arg_BadEnumValue", "origin");
    }

    public override void SetLength(long length)
    {
        throw new NotSupportedException(__Res.GetString("NotSupported_StreamNotWritable"));
    }

    public override void Write(byte[] bytes, int offset, int count)
    {
        throw new NotSupportedException(__Res.GetString("NotSupported_StreamNotWritable"));
    }

    // Properties
    public override bool CanRead
    {
        get
        {
            return this._currentStream.CanRead;
        }
    }

    public override bool CanSeek
    {
        get
        {
            return this._canSeek;
        }
    }

    public override bool CanWrite
    {
        get
        {
            return false;
        }
    }

    public override long Length
    {
        get
        {
            return (this._stream1.Length + this._stream2.Length);
        }
    }

    public override long Position
    {
        get
        {
            if (this._currentStream == this._stream1)
            {
                return this._stream1.Position;
            }
            return (this._length1 + this._stream2.Position);
        }
        set
        {
            if (!this._canSeek)
            {
                throw new IOException("IO_IONotSeekable");
            }
            if (value < this._length1)
            {
                this._stream1.Position = value;
                if (this._currentStream == this._stream2)
                {
                    this._stream2.Position = 0L;
                    this._currentStream = this._stream1;
                }
            }
            else
            {
                this._stream2.Position = value - this._length1;
                this._currentStream = this._stream2;
            }
        }
    }
}

    public sealed class DirectoryUtils
    {
        // Methods
        private DirectoryUtils()
        {
        }

        public static void CopyDirectory(string src, string dest)
        {
            DirectoryInfo info = new DirectoryInfo(src);
            foreach (FileSystemInfo info2 in info.GetFileSystemInfos())
            {
                string destFileName = Path.Combine(dest, info2.Name);
                if (info2 is FileInfo)
                {
                    File.Copy(info2.FullName, destFileName);
                }
                else
                {
                    Directory.CreateDirectory(destFileName);
                    CopyDirectory(info2.FullName, destFileName);
                }
            }
        }
    }

    public class MemoryMappedFileStream : UnmanagedMemoryStream
    {
        // Fields
        private IntPtr _fileHandle;
        private string _fileName;
        private IntPtr _mappingHandle;

        // Methods
        public MemoryMappedFileStream(string fileName, FileAccess access)
            : this(fileName, access, 0L, 0L, null)
        {
        }

        public unsafe MemoryMappedFileStream(string fileName, FileAccess access, long offsetIntoFile, long length, string optionalMappingName)
        {
            this._fileHandle = __Native.InvalidHandleValue;
            this._mappingHandle = Memory.Null;
            if (fileName == null)
            {
                throw new ArgumentNullException("fileName");
            }
            if (offsetIntoFile < 0L)
            {
                throw new ArgumentOutOfRangeException("offsetInfoFile", __Res.GetString("ArgOOR_NeedNonNegNum"));
            }
            if (length < 0L)
            {
                throw new ArgumentOutOfRangeException("length", __Res.GetString("ArgOOR_NeedNonNegNum"));
            }
            if (length > 0x7fffffffL)
            {
                throw new ArgumentOutOfRangeException("length", length, __Res.GetString("ArgOOR_MustBeSmallerThanInt32Max"));
            }
            string fullPath = Path.GetFullPath(fileName);
            this._fileName = fullPath;
            int dwDesiredAccess = 0;
            int dwProtect = 0;
            FileIOPermissionAccess noAccess = FileIOPermissionAccess.NoAccess;
            bool canRead = (access & FileAccess.Read) != 0;
            bool canWrite = (access & FileAccess.Write) != 0;
            if (canRead)
            {
                dwDesiredAccess = -2147483648;
                dwProtect = 2;
                noAccess = FileIOPermissionAccess.Read;
            }
            if (canWrite)
            {
                dwDesiredAccess |= 0x40000000;
                dwProtect = 4;
                noAccess |= FileIOPermissionAccess.Write;
            }
            new FileIOPermission(noAccess, fullPath).Demand();
            this._fileHandle = __Native.CreateFile(fullPath, dwDesiredAccess, FileShare.ReadWrite, Memory.Null, 4, 0x80, Memory.Null);
            if (this._fileHandle == __Native.InvalidHandleValue)
            {
                __Error.WinIOError(fileName);
            }
            if (__Native.GetLengthOfFile(this._fileHandle) == 0L)
            {
                if (length == 0L)
                {
                    __Native.CloseHandle(this._fileHandle);
                    this._fileHandle = __Native.InvalidHandleValue;
                    throw new ArgumentException(__Res.GetString("IO_MemMapFileLenZero"));
                }
                int hi = (int)(length >> 0x20);
                if (!__Native.SetFilePointer(this._fileHandle, (int)length, ref hi, SeekOrigin.Begin))
                {
                    __Error.WinIOError(fileName);
                }
                if (!__Native.SetEndOfFile(this._fileHandle))
                {
                    __Error.WinIOError(fileName);
                }
                hi = 0;
                __Native.SetFilePointer(this._fileHandle, 0, ref hi, SeekOrigin.Begin);
            }
            this._mappingHandle = __Native.CreateFileMapping(this._fileHandle, Memory.Null, dwProtect, (int)(length >> 0x20), (int)length, optionalMappingName);
            if (this._mappingHandle == Memory.Null)
            {
                __Error.WinIOError(fileName);
            }
            long lengthOfFile = __Native.GetLengthOfFile(this._fileHandle);
            long capacity = lengthOfFile - offsetIntoFile;
            if (length == 0L)
            {
                length = lengthOfFile - offsetIntoFile;
                if (length < 0L)
                {
                    throw new ArgumentOutOfRangeException("length", __Res.GetString("ArgOOR_NeedNonNegNum"));
                }
            }
            byte* mem = __Native.MapViewOfFile(this._mappingHandle, (int)access, (int)(offsetIntoFile >> 0x20), (int)offsetIntoFile, (int)length);
            if (mem == null)
            {
                __Error.WinIOError(fileName);
            }
            base.Init(mem, capacity, length, canRead, canWrite);
        }

        protected override unsafe void Dispose(bool disposing)
        {
            if (this._fileHandle != __Native.InvalidHandleValue)
            {
                if ((base.BasePointer != null) && !__Native.UnmapViewOfFile(base.BasePointer))
                {
                    __Error.WinIOError();
                }
                if (this._mappingHandle != Memory.Null)
                {
                    if (!__Native.CloseHandle(this._mappingHandle))
                    {
                        __Error.WinIOError();
                    }
                    this._mappingHandle = Memory.Null;
                }
                if (!__Native.CloseHandle(this._fileHandle))
                {
                    __Error.WinIOError();
                }
                this._fileHandle = __Native.InvalidHandleValue;
            }
            base.Dispose(disposing);
        }

        ~MemoryMappedFileStream()
        {
            this.Dispose(false);
        }
    }

    public class PassThroughStream : Stream
    {
        // Fields
        private Stream _baseStream;

        // Methods
        protected PassThroughStream(Stream stream)
        {
            if (stream == null)
            {
                throw new ArgumentNullException("stream");
            }
            this._baseStream = stream;
        }

        public override IAsyncResult BeginRead(byte[] bytes, int offset, int count, AsyncCallback callback, object asyncState)
        {
            return this.BaseStream.BeginRead(bytes, offset, count, callback, asyncState);
        }

        public override IAsyncResult BeginWrite(byte[] bytes, int offset, int count, AsyncCallback callback, object asyncState)
        {
            return this.BaseStream.BeginWrite(bytes, offset, count, callback, asyncState);
        }

        public override void Close()
        {
            this.Dispose(true);
            GC.SuppressFinalize(this);
        }

        protected virtual void Dispose(bool disposing)
        {
            this.BaseStream.Close();
        }

        public override int EndRead(IAsyncResult asyncResult)
        {
            return this.BaseStream.EndRead(asyncResult);
        }

        public override void EndWrite(IAsyncResult asyncResult)
        {
            this.BaseStream.EndWrite(asyncResult);
        }

        public override void Flush()
        {
            this.BaseStream.Flush();
        }

        public override int Read([In, Out] byte[] bytes, int offset, int count)
        {
            return this.BaseStream.Read(bytes, offset, count);
        }

        public override int ReadByte()
        {
            return this.BaseStream.ReadByte();
        }

        public override long Seek(long offset, SeekOrigin origin)
        {
            return this.BaseStream.Seek(offset, origin);
        }

        public override void SetLength(long length)
        {
            this.BaseStream.SetLength(length);
        }

        public override void Write(byte[] bytes, int offset, int count)
        {
            this.BaseStream.Write(bytes, offset, count);
        }

        public override void WriteByte(byte value)
        {
            this.BaseStream.WriteByte(value);
        }

        // Properties
        protected Stream BaseStream
        {
            get
            {
                return this._baseStream;
            }
        }

        public override bool CanRead
        {
            get
            {
                return this.BaseStream.CanRead;
            }
        }

        public override bool CanSeek
        {
            get
            {
                return this.BaseStream.CanSeek;
            }
        }

        public override bool CanWrite
        {
            get
            {
                return this.BaseStream.CanWrite;
            }
        }

        public override long Length
        {
            get
            {
                return this.BaseStream.Length;
            }
        }

        public override long Position
        {
            get
            {
                return this.BaseStream.Position;
            }
            set
            {
                this.BaseStream.Position = value;
            }
        }
    }

    public sealed class ReadOnlyStream : PassThroughStream
    {
        // Methods
        public ReadOnlyStream(Stream stream)
            : base(stream)
        {
        }

        public override void Flush()
        {
        }

        public override void SetLength(long length)
        {
            throw new NotSupportedException(__Res.GetString("NotSupported_StreamNotWritable"));
        }

        public override void Write(byte[] bytes, int offset, int count)
        {
            throw new NotSupportedException(__Res.GetString("NotSupported_StreamNotWritable"));
        }

        public override void WriteByte(byte b)
        {
            throw new NotSupportedException(__Res.GetString("NotSupported_StreamNotWritable"));
        }

        // Properties
        public override bool CanWrite
        {
            get
            {
                return false;
            }
        }
    }

    public class Substream : PassThroughStream
    {
        // Fields
        private long _len;
        private long _offset;

        // Methods
        public Substream(Stream stream, long offset, long length)
            : base(stream)
        {
            if (offset < 0L)
            {
                throw new ArgumentOutOfRangeException("offset", offset, __Res.GetString("ArgOOR_NeedNonNegNum"));
            }
            if (length < 0L)
            {
                throw new ArgumentOutOfRangeException("length", length, __Res.GetString("ArgOOR_NeedNonNegNum"));
            }
            if (offset > (stream.Length + 1L))
            {
                throw new ArgumentOutOfRangeException("offset", offset, __Res.GetString("ArgOOR_BeyondEndOfStream"));
            }
            if ((offset + length) > (stream.Length + 1L))
            {
                throw new ArgumentOutOfRangeException("length", length, __Res.GetString("ArgOOR_BeyondEndOfStream"));
            }
            this._offset = offset;
            this._len = length;
            base.BaseStream.Position = this._offset;
        }

        public override int Read([In, Out] byte[] bytes, int offset, int count)
        {
            if ((base.BaseStream.Position + count) > (this._offset + this._len))
            {
                count = (int)((this._offset + this._len) - base.BaseStream.Position);
                if (count == 0)
                {
                    return 0;
                }
            }
            return base.BaseStream.Read(bytes, offset, count);
        }

        public override int ReadByte()
        {
            if ((base.BaseStream.Position + 1L) > (this._offset + this._len))
            {
                return -1;
            }
            return base.BaseStream.ReadByte();
        }

        public override long Seek(long offset, SeekOrigin origin)
        {
            if (origin == SeekOrigin.Begin)
            {
                offset += this._offset;
            }
            if (origin == SeekOrigin.End)
            {
                if (-offset > this._len)
                {
                    throw new IOException(__Res.GetString("IO_IOSeekBeforeStream"));
                }
                origin = SeekOrigin.Begin;
                offset += this._offset + this._len;
            }
            long num = base.BaseStream.Seek(offset, origin);
            if (num < this._offset)
            {
                base.BaseStream.Seek(this._offset, SeekOrigin.Begin);
                throw new IOException(__Res.GetString("IO_IOSeekBeforeStream"));
            }
            if (num > (this._offset + this._len))
            {
                base.BaseStream.Seek(this._offset + this._len, SeekOrigin.Begin);
                throw new IOException(__Res.GetString("IO_IOSeekAfterStream"));
            }
            return (num - this._offset);
        }

        public override void SetLength(long length)
        {
            if ((this._offset + this._len) != base.BaseStream.Length)
            {
                throw new IOException(__Res.GetString("IO_IOSetLengthMidSubstream"));
            }
            base.BaseStream.SetLength(length);
            this._len = length;
        }

        public override void Write(byte[] bytes, int offset, int count)
        {
            base.BaseStream.Write(bytes, offset, count);
        }

        // Properties
        public override long Length
        {
            get
            {
                return this._len;
            }
        }

        public override long Position
        {
            get
            {
                return (base.BaseStream.Position - this._offset);
            }
            set
            {
                base.BaseStream.Position = value + this._offset;
            }
        }
    }

    public class UnclosableStream : PassThroughStream
    {
        // Methods
        public UnclosableStream(Stream stream)
            : base(stream)
        {
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                base.BaseStream.Flush();
            }
        }
    }

    public class UnmanagedMemoryStream : Stream
    {
        // Fields
        private bool _canRead;
        private bool _canWrite;
        private long _capacity;
        private long _len;
        private unsafe byte* _mem;
        private long _pos;

        // Methods
        protected UnmanagedMemoryStream()
        {
        }

        [CLSCompliant(false)]
        public unsafe UnmanagedMemoryStream(byte* pointer, long capacity)
            : this(pointer, capacity, 0L, true)
        {
        }

        [CLSCompliant(false)]
        public unsafe UnmanagedMemoryStream(byte* pointer, long capacity, long length, bool canWrite)
        {
            if (pointer == null)
            {
                throw new ArgumentNullException("pointer");
            }
            if (length < 0L)
            {
                throw new ArgumentOutOfRangeException("length", __Res.GetString("ArgOOR_NeedNonNegNum"));
            }
            if (capacity < 0L)
            {
                throw new ArgumentOutOfRangeException("capacity", __Res.GetString("ArgOOR_NeedNonNegNum"));
            }
            if (length > capacity)
            {
                throw new ArgumentOutOfRangeException("length", __Res.GetString("ArgOOR_LengthCapacity"));
            }
            new SecurityPermission(SecurityPermissionFlag.UnmanagedCode).Demand();
            this.Init(pointer, capacity, length, true, canWrite);
        }

        public unsafe UnmanagedMemoryStream(IntPtr pointer, long capacity, long length, bool canWrite)
        {
            if (pointer == IntPtr.Zero)
            {
                throw new ArgumentNullException("pointer");
            }
            if (length < 0L)
            {
                throw new ArgumentOutOfRangeException("length", __Res.GetString("ArgOOR_NeedNonNegNum"));
            }
            if (capacity < 0L)
            {
                throw new ArgumentOutOfRangeException("capacity", __Res.GetString("ArgOOR_NeedNonNegNum"));
            }
            if (length > capacity)
            {
                throw new ArgumentOutOfRangeException("length", __Res.GetString("ArgOOR_LengthCapacity"));
            }
            new SecurityPermission(SecurityPermissionFlag.UnmanagedCode).Demand();
            this.Init((byte*)pointer.ToPointer(), capacity, length, true, canWrite);
        }

        public override void Close()
        {
            this.Dispose(true);
            GC.SuppressFinalize(this);
        }

        protected virtual unsafe void Dispose(bool disposing)
        {
            this._mem = null;
            this._canRead = false;
            this._canWrite = false;
        }

        public override void Flush()
        {
        }

        [CLSCompliant(false), SecurityPermission(SecurityAction.LinkDemand, UnmanagedCode = true)]
        protected unsafe void Init(byte* mem, long capacity, long length, bool canRead, bool canWrite)
        {
            this._mem = mem;
            this._capacity = capacity;
            this._len = length;
            this._canRead = canRead;
            this._canWrite = canWrite;
        }

        public override unsafe int Read([In, Out] byte[] bytes, int offset, int count)
        {
            if (this._mem == null)
            {
                throw new IOException(__Res.GetString("IO_StreamIsClosed"));
            }
            if (!this._canRead)
            {
                throw new NotSupportedException(__Res.GetString("NotSupported_StreamNotReadable"));
            }
            if (bytes == null)
            {
                throw new ArgumentNullException("bytes");
            }
            int numBytes = count;
            long num2 = this._pos;
            if ((this._len - num2) < count)
            {
                numBytes = (int)(this._len - num2);
            }
            fixed (byte* numRef = bytes)
            {
                Memory.Copy(this._mem + ((byte*)num2), numRef + offset, numBytes);
            }
            this._pos += numBytes;
            return numBytes;
        }

        public override unsafe int ReadByte()
        {
            if (!this._canRead)
            {
                throw new NotSupportedException(__Res.GetString("NotSupported_StreamNotReadable"));
            }
            long num = this._pos;
            if (num == this._len)
            {
                return -1;
            }
            this._pos = num + 1L;
            return this._mem[(int)num];
        }

        public override unsafe long Seek(long offset, SeekOrigin origin)
        {
            if (this._mem == null)
            {
                throw new IOException(__Res.GetString("IO_StreamIsClosed"));
            }
            switch (origin)
            {
                case SeekOrigin.Begin:
                    if (offset < 0L)
                    {
                        throw new IOException(__Res.GetString("IO_IOSeekBeforeStream"));
                    }
                    if (offset > this._len)
                    {
                        throw new IOException(__Res.GetString("IO_IOSeekAfterStream"));
                    }
                    this._pos = offset;
                    break;

                case SeekOrigin.Current:
                    {
                        long num = this._pos + offset;
                        if (num < 0L)
                        {
                            throw new IOException(__Res.GetString("IO_IOSeekBeforeStream"));
                        }
                        if (num > this._len)
                        {
                            throw new IOException(__Res.GetString("IO_IOSeekAfterStream"));
                        }
                        this._pos = num;
                        break;
                    }
                case SeekOrigin.End:
                    if (offset < -this._len)
                    {
                        throw new IOException(__Res.GetString("IO_IOSeekBeforeStream"));
                    }
                    if (offset > 0L)
                    {
                        throw new IOException(__Res.GetString("IO_IOSeekAfterStream"));
                    }
                    this._pos = this._len + offset;
                    break;

                default:
                    throw new IOException(__Res.GetString("Arg_BadEnumValue"));
            }
            return this._pos;
        }

        public override unsafe void SetLength(long length)
        {
            if (this._mem == null)
            {
                throw new IOException(__Res.GetString("IO_StreamIsClosed"));
            }
            if (!this._canWrite)
            {
                throw new NotSupportedException(__Res.GetString("NotSupported_StreamNotWritable"));
            }
            if (length < 0L)
            {
                throw new ArgumentOutOfRangeException("length", __Res.GetString("ArgOOR_NeedNonNegNum"));
            }
            if (length > this._capacity)
            {
                throw new ArgumentOutOfRangeException("length", __Res.GetString("ArgOOR_LengthCapacity"));
            }
            this._len = length;
            if (this._pos > this._len)
            {
                this._pos = this._len;
            }
        }

        public override unsafe void Write(byte[] bytes, int offset, int count)
        {
            if (this._mem == null)
            {
                throw new IOException(__Res.GetString("IO_StreamIsClosed"));
            }
            if (!this._canWrite)
            {
                throw new NotSupportedException(__Res.GetString("NotSupported_StreamNotWritable"));
            }
            if (bytes == null)
            {
                throw new ArgumentNullException("bytes");
            }
            long num = this._pos;
            if ((num + count) > this._capacity)
            {
                throw new ArgumentException(__Res.GetString("Arg_OverflowCapacity"));
            }
            fixed (byte* numRef = bytes)
            {
                Memory.Copy(numRef + offset, this._mem + ((byte*)num), count);
            }
            this._pos = num + count;
            if (num > this._len)
            {
                this._len = num;
            }
        }

        public override unsafe void WriteByte(byte value)
        {
            if (this._mem == null)
            {
                throw new IOException(__Res.GetString("IO_StreamIsClosed"));
            }
            if (!this._canWrite)
            {
                throw new NotSupportedException(__Res.GetString("NotSupported_StreamNotWritable"));
            }
            if ((this._pos + 1L) > this._capacity)
            {
                throw new ArgumentException(__Res.GetString("Arg_OverflowCapacity"));
            }
            long num = this._pos;
            this._mem[(int)num] = value;
            this._pos = num + 1L;
            if (num > this._len)
            {
                this._len = num;
            }
        }

        // Properties
        [CLSCompliant(false)]
        public byte* BasePointer
        {
            [SecurityPermission(SecurityAction.LinkDemand, UnmanagedCode = true)]
            get
            {
                return this._mem;
            }
        }

        public override bool CanRead
        {
            get
            {
                return this._canRead;
            }
        }

        public override bool CanSeek
        {
            get
            {
                return (this._mem != null);
            }
        }

        public override bool CanWrite
        {
            get
            {
                return this._canWrite;
            }
        }

        public long Capacity
        {
            get
            {
                if (this._mem == null)
                {
                    throw new IOException(__Res.GetString("IO_StreamIsClosed"));
                }
                return this._capacity;
            }
        }

        [CLSCompliant(false)]
        public byte* CurrentPointer
        {
            [SecurityPermission(SecurityAction.LinkDemand, UnmanagedCode = true)]
            get
            {
                return (this._mem + ((byte*)this._pos));
            }
        }

        public override long Length
        {
            get
            {
                if (this._mem == null)
                {
                    throw new IOException(__Res.GetString("IO_StreamIsClosed"));
                }
                return this._len;
            }
        }

        public override long Position
        {
            get
            {
                if (this._mem == null)
                {
                    throw new IOException(__Res.GetString("IO_StreamIsClosed"));
                }
                return this._pos;
            }
            set
            {
                if (this._mem == null)
                {
                    throw new IOException(__Res.GetString("IO_StreamIsClosed"));
                }
                if (value < 0L)
                {
                    throw new ArgumentOutOfRangeException("value", __Res.GetString("ArgOOR_NeedNonNegNum"));
                }
                if (value > this._len)
                {
                    throw new IOException(__Res.GetString("IO_IOSeekAfterStream"));
                }
                this._pos = value;
            }
        }
    }

    public sealed class WriteOnlyStream : PassThroughStream
    {
        // Methods
        public WriteOnlyStream(Stream stream)
            : base(stream)
        {
        }

        public override int Read([In, Out] byte[] bytes, int offset, int count)
        {
            throw new NotSupportedException(__Res.GetString("NotSupported_StreamNotReadable"));
        }

        public override int ReadByte()
        {
            throw new NotSupportedException(__Res.GetString("NotSupported_StreamNotReadable"));
        }

        // Properties
        public override bool CanRead
        {
            get
            {
                return false;
            }
        }
    }

}

 

    


 

 
