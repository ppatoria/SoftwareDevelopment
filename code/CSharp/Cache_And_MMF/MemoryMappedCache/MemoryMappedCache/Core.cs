using System;
using System.Collections;
using System.IO;
using System.Runtime;
using System.Runtime.InteropServices;
using System.Security;
using System.Security.Permissions;
using System.Resources;
using System.Text;
using System.Runtime.CompilerServices;


namespace MMFCore
{
    [SuppressUnmanagedCodeSecurity]
[SuppressUnmanagedCodeSecurity]
internal sealed class __Native
{
    // Fields
    internal const int ENABLE_ECHO_INPUT = 4;
    internal const int ENABLE_LINE_INPUT = 2;
    internal const int ERROR_FILE_NOT_FOUND = 2;
    internal const int ERROR_PATH_NOT_FOUND = 3;
    internal const int FILE_ATTRIBUTE_NORMAL = 0x80;
    internal const int FORMAT_MESSAGE_ALLOCATE_BUFFER = 0x100;
    internal const int FORMAT_MESSAGE_ARGUMENT_ARRAY = 0x2000;
    internal const int FORMAT_MESSAGE_FROM_HMODULE = 0x800;
    internal const int FORMAT_MESSAGE_FROM_STRING = 0x400;
    internal const int FORMAT_MESSAGE_FROM_SYSTEM = 0x1000;
    internal const int FORMAT_MESSAGE_IGNORE_INSERTS = 0x200;
    internal const int FORMAT_MESSAGE_MAX_WIDTH_MASK = 0xff;
    internal const int GENERIC_ALL = 0x10000000;
    internal const int GENERIC_EXECUTE = 0x20000000;
    internal const int GENERIC_READ = -2147483648;
    internal const int GENERIC_WRITE = 0x40000000;
    internal static readonly IntPtr InvalidHandleValue = new IntPtr(-1);
    internal const int PAGE_READONLY = 2;
    internal const int PAGE_READWRITE = 4;
    internal const int PAGE_WRITECOPY = 8;
    internal const int STD_INPUT_HANDLE = -10;
    internal const int STD_OUTPUT_HANDLE = -11;

    // Methods
    private __Native()
    {
    }

    [DllImport("kernel32", SetLastError=true)]
    internal static extern bool CloseHandle(IntPtr fileHandle);
    [DllImport("kernel32")]
    internal static extern unsafe void CopyMemory(byte* dest, byte* src, int numBytes);
    [DllImport("kernel32", CharSet=CharSet.Auto, SetLastError=true)]
    internal static extern IntPtr CreateFile(string fileName, int dwDesiredAccess, FileShare shareMode, IntPtr lpSecurityAttributes_MustBeZero, int dwCreationDisposition, int dwFlagsAndAttributes, IntPtr hTemplateFile_MustBeZero);
    [DllImport("kernel32", CharSet=CharSet.Auto, SetLastError=true)]
    internal static extern IntPtr CreateFileMapping(IntPtr fileHandle, IntPtr lpSecurityAttributes_MustBeNull, int dwProtect, int maxSizeHi, int maxSizeLo, string name);
    [DllImport("kernel32", SetLastError=true)]
    internal static extern unsafe bool FillConsoleOutputAttribute(IntPtr hConsoleOutput, short wColorAttribute, int numCells, COORD startCoord, int* pNumBytesWritten);
    [DllImport("kernel32", CharSet=CharSet.Auto, SetLastError=true)]
    internal static extern unsafe bool FillConsoleOutputCharacter(IntPtr hConsoleOutput, char character, int nLength, COORD dwWriteCoord, int* pNumCharsWritten);
    [DllImport("kernel32", CharSet=CharSet.Auto)]
    internal static extern int FormatMessage(int flags, string source, int messageID, int languageID, StringBuilder buffer, int bufferSize, IntPtr vaList_MustBeZero);
    [DllImport("kernel32", CharSet=CharSet.Auto)]
    internal static extern int FormatMessage(int flags, string source, int messageID, int languageID, StringBuilder buffer, int bufferSize, string insert0);
    [DllImport("kernel32", SetLastError=true)]
    internal static extern bool GetConsoleMode(IntPtr handle, ref int mode);
    [DllImport("kernel32", SetLastError=true)]
    internal static extern unsafe bool GetConsoleScreenBufferInfo(IntPtr hConsoleOutput, CONSOLE_SCREEN_BUFFER_INFO* lpConsoleScreenBufferInfo);
    [DllImport("kernel32", SetLastError=true)]
    internal static extern int GetFileSize(IntPtr fileHandle, ref int pHi);
    internal static long GetLengthOfFile(IntPtr fileHandle)
    {
        int pHi = 0;
        return (((long) ((ulong) GetFileSize(fileHandle, ref pHi))) | (pHi << 0x20));
    }

    [DllImport("kernel32", SetLastError=true)]
    internal static extern IntPtr GetStdHandle(int nStdHandle);
    [DllImport("kernel32", SetLastError=true)]
    internal static extern unsafe byte* MapViewOfFile(IntPtr mappingHandle, int dwAccess, int fileOffsetHi, int fileOffsetLo, int numBytes);
    [DllImport("kernel32")]
    internal static extern unsafe void MoveMemory(byte* dest, byte* src, int numBytes);
    [DllImport("kernel32", SetLastError=true)]
    internal static extern bool SetConsoleCursorPosition(IntPtr hConsoleOutput, COORD cursorPosition);
    [DllImport("kernel32", SetLastError=true)]
    internal static extern bool SetConsoleMode(IntPtr handle, int mode);
    [DllImport("kernel32", SetLastError=true)]
    internal static extern bool SetEndOfFile(IntPtr fileHandle);
    [DllImport("kernel32", SetLastError=true)]
    internal static extern bool SetFilePointer(IntPtr fileHandle, int lo, ref int hi, SeekOrigin origin);
    [DllImport("kernel32", SetLastError=true)]
    internal static extern unsafe bool UnmapViewOfFile(byte* pMemory);

    // Nested Types
    [StructLayout(LayoutKind.Sequential)]
    internal struct CONSOLE_SCREEN_BUFFER_INFO
    {
        internal __Native.COORD dwSize;
        internal __Native.COORD dwCursorPosition;
        internal short wAttributes;
        internal __Native.SMALL_RECT srWindow;
        internal __Native.COORD dwMaximumWindowSize;
    }

    [StructLayout(LayoutKind.Sequential)]
    internal struct COORD
    {
        internal short X;
        internal short Y;
    }

    [StructLayout(LayoutKind.Sequential)]
    internal struct SMALL_RECT
    {
        internal short Left;
        internal short Top;
        internal short Right;
        internal short Bottom;
    }
}

 

 

internal class __Res
{
    // Fields
    private static ResourceManager _resMgr;
    internal const string Arg_BadEnumValue = "Arg_BadEnumValue";
    internal const string Arg_ConcatDiffStreams = "Arg_ConcatDiffStreams";
    internal const string Arg_ConcatStartAtBeginning = "Arg_ConcatStartAtBeginning";
    internal const string Arg_MustBeLessThanArrayLen = "Arg_MustBeLessThanArrayLen";
    internal const string Arg_NeedReadableStream = "Arg_NeedReadableStream";
    internal const string Arg_OverflowCapacity = "Arg_OverflowCapacity";
    internal const string Arg_ZeroLenByteArray = "Arg_ZeroLenByteArray";
    internal const string ArgOOR_BeyondEndOfStream = "ArgOOR_BeyondEndOfStream";
    internal const string ArgOOR_LengthCapacity = "ArgOOR_LengthCapacity";
    internal const string ArgOOR_MustBeSmallerThanInt32Max = "ArgOOR_MustBeSmallerThanInt32Max";
    internal const string ArgOOR_NeedNonNegNum = "ArgOOR_NeedNonNegNum";
    internal const string InvalidOperation_FreeingMemoryTwice = "InvalidOperation_FreeingMemoryTwice";
    internal const string IO_DirectoryNotFound_Path = "IO_DirectoryNotFound_Path";
    internal const string IO_EndOfStream = "IO_EndOfStream";
    internal const string IO_IONotSeekable = "IO_IONotSeekable";
    internal const string IO_IOSeekAfterStream = "IO_IOSeekAfterStream";
    internal const string IO_IOSeekBeforeStream = "IO_IOSeekBeforeStream";
    internal const string IO_IOSetLengthMidSubstream = "IO_IOSetLengthMidSubstream";
    internal const string IO_MemMapFileLenZero = "IO_MemMapFileLenZero";
    internal const string IO_StreamIsClosed = "IO_StreamIsClosed";
    internal const string NotSupported_StreamNotReadable = "NotSupported_StreamNotReadable";
    internal const string NotSupported_StreamNotWritable = "NotSupported_StreamNotWritable";

    // Methods
    internal static string GetString(string key)
    {
        if (_resMgr == null)
        {
            _resMgr = new ResourceManager("MetalWrench.ToolBox.strings", typeof(__Res).Assembly);
        }
        string str = _resMgr.GetString(key);
        if (str == null)
        {
            throw new ApplicationException("Missing resource from MetalWrench's ToolBox library!  Key: " + key);
        }
        return str;
    }

    internal static string GetString(string key, params object[] inserts)
    {
        return string.Format(GetString(key), inserts);
    }
}

 

 


   public sealed class ConsoleUtils
{
    // Methods
    private ConsoleUtils()
    {
    }

    public static unsafe void ClearScreen()
    {
        __Native.COORD dwWriteCoord = new __Native.COORD();
        IntPtr stdHandle = __Native.GetStdHandle(-11);
        if (stdHandle != __Native.InvalidHandleValue)
        {
            __Native.CONSOLE_SCREEN_BUFFER_INFO console_screen_buffer_info;
            if (!__Native.GetConsoleScreenBufferInfo(stdHandle, &console_screen_buffer_info))
            {
                ClrScrError();
            }
            int nLength = console_screen_buffer_info.dwSize.X * console_screen_buffer_info.dwSize.Y;
            int pNumCharsWritten = 0;
            if (!__Native.FillConsoleOutputCharacter(stdHandle, ' ', nLength, dwWriteCoord, &pNumCharsWritten))
            {
                ClrScrError();
            }
            pNumCharsWritten = 0;
            if (!__Native.FillConsoleOutputAttribute(stdHandle, console_screen_buffer_info.wAttributes, nLength, dwWriteCoord, &pNumCharsWritten))
            {
                ClrScrError();
            }
            if (!__Native.SetConsoleCursorPosition(stdHandle, dwWriteCoord))
            {
                ClrScrError();
            }
        }
    }

    private static void ClrScrError()
    {
        int num = Marshal.GetLastWin32Error();
        throw new IOException(string.Format("Clearing the screen failed.  Error code: 0x{0:x}", num));
    }

    // Properties
    public static bool EchoInput
    {
        get
        {
            IntPtr stdHandle = __Native.GetStdHandle(-10);
            if (stdHandle == __Native.InvalidHandleValue)
            {
                throw new IOException("There is no console handle.");
            }
            int mode = 0;
            if (!__Native.GetConsoleMode(stdHandle, ref mode))
            {
                int num2 = Marshal.GetLastWin32Error();
                throw new IOException(string.Format("Getting the console mode failed.  Error code: 0x{0:x}", num2));
            }
            return ((mode & 4) != 0);
        }
        set
        {
            IntPtr stdHandle = __Native.GetStdHandle(-10);
            if (stdHandle == __Native.InvalidHandleValue)
            {
                throw new IOException("There is no console handle.");
            }
            int mode = 0;
            bool consoleMode = __Native.GetConsoleMode(stdHandle, ref mode);
            if (value)
            {
                mode |= 4;
            }
            else
            {
                mode &= -5;
            }
            if (!__Native.SetConsoleMode(stdHandle, mode))
            {
                int num2 = Marshal.GetLastWin32Error();
                throw new IOException(string.Format("Setting the console mode failed.  Error code: 0x{0:x}", num2));
            }
        }
    }
}

 

 


   public sealed class Memory
{
    // Fields
    public static readonly IntPtr Null = IntPtr.Zero;

    // Methods
    private Memory()
    {
    }

    [CLSCompliant(false), SecurityPermission(SecurityAction.LinkDemand, UnmanagedCode=true)]
    public static unsafe byte* Allocate(int numBytes)
    {
        if (numBytes < 0)
        {
            throw new ArgumentOutOfRangeException("numBytes", __Res.GetString("ArgOOR_NeedNonNegNum"));
        }
        byte* pBytes = (byte*) Marshal.AllocHGlobal((int) (numBytes + 4));
        FillWithGarbage(pBytes, numBytes + 4);
        *((int*) pBytes) = numBytes;
        return (pBytes + 4);
    }

    [CLSCompliant(false), SecurityPermission(SecurityAction.LinkDemand, UnmanagedCode=true)]
    public static unsafe void Clear(byte* pBytes, int len)
    {
        if (len < 0)
        {
            throw new ArgumentOutOfRangeException("len", len, __Res.GetString("ArgOOR_NeedNonNegNum"));
        }
        int num = len >> 3;
        ulong* numPtr = (ulong*) pBytes;
        while (num-- > 0)
        {
            numPtr++;
            numPtr[0] = 0L;
        }
        len &= 7;
        if (len > 0)
        {
            pBytes = (byte*) numPtr;
            while (len-- > 0)
            {
                *(pBytes++) = 0;
            }
        }
    }

    [CLSCompliant(false), SecurityPermission(SecurityAction.LinkDemand, UnmanagedCode=true)]
    public static unsafe int Compare(byte* a, byte* b, int numBytes)
    {
        if (a == null)
        {
            throw new ArgumentNullException("a");
        }
        if (b == null)
        {
            throw new ArgumentNullException("b");
        }
        if (numBytes < 0)
        {
            throw new ArgumentOutOfRangeException("numBytes", numBytes, __Res.GetString("ArgOOR_NeedNonNegNum"));
        }
        int num = 0;
        while ((numBytes-- > 0) && (num == 0))
        {
            num = *(a++) - *(b++);
        }
        return num;
    }

    public static unsafe int Compare(byte[] a, byte[] b, int numBytes)
    {
        if (a == null)
        {
            throw new ArgumentNullException("a");
        }
        if (b == null)
        {
            throw new ArgumentNullException("b");
        }
        if (numBytes < 0)
        {
            throw new ArgumentOutOfRangeException("numBytes", numBytes, __Res.GetString("ArgOOR_NeedNonNegNum"));
        }
        if ((a.Length < numBytes) || (b.Length < numBytes))
        {
            throw new ArgumentException(__Res.GetString("Arg_MustBeLessThanArrayLen"), "numBytes");
        }
        if (numBytes == 0)
        {
            return 0;
        }
        fixed (byte* numRef = a)
        {
            fixed (byte* numRef2 = b)
            {
                return Compare(numRef, numRef2, numBytes);
            }
        }
    }

    [CLSCompliant(false), SecurityPermission(SecurityAction.LinkDemand, UnmanagedCode=true)]
    public static unsafe void Copy(byte* src, byte[] dest, int numBytes)
    {
        if (src == null)
        {
            throw new ArgumentNullException("src");
        }
        if (dest == null)
        {
            throw new ArgumentNullException("dest");
        }
        if (numBytes < 0)
        {
            throw new ArgumentOutOfRangeException("numBytes", numBytes, __Res.GetString("ArgOOR_NeedNonNegNum"));
        }
        if (dest.Length == 0)
        {
            if (numBytes != 0)
            {
                throw new ArgumentException("dest", __Res.GetString("Arg_ZeroLenByteArray"));
            }
        }
        else
        {
            fixed (byte* numRef = dest)
            {
                memmoveimpl(src, numRef, numBytes);
            }
        }
    }

    [SecurityPermission(SecurityAction.LinkDemand, UnmanagedCode=true)]
    public static unsafe void Copy(IntPtr src, IntPtr dest, int numBytes)
    {
        if (src == Null)
        {
            throw new ArgumentNullException("src");
        }
        if (dest == Null)
        {
            throw new ArgumentNullException("dest");
        }
        if (numBytes < 0)
        {
            throw new ArgumentOutOfRangeException("numBytes", numBytes, __Res.GetString("ArgOOR_NeedNonNegNum"));
        }
        byte* numPtr = (byte*) src.ToPointer();
        byte* numPtr2 = (byte*) dest.ToPointer();
        memmoveimpl(numPtr, numPtr2, numBytes);
    }

    [CLSCompliant(false), SecurityPermission(SecurityAction.LinkDemand, UnmanagedCode=true)]
    public static unsafe void Copy(byte* src, byte* dest, int numBytes)
    {
        if (src == null)
        {
            throw new ArgumentNullException("src");
        }
        if (dest == null)
        {
            throw new ArgumentNullException("dest");
        }
        if (numBytes < 0)
        {
            throw new ArgumentOutOfRangeException("numBytes", numBytes, __Res.GetString("ArgOOR_NeedNonNegNum"));
        }
        memmoveimpl(src, dest, numBytes);
    }

    public static void Copy(byte[] src, byte[] dest, int numBytes)
    {
        if (src == null)
        {
            throw new ArgumentNullException("src");
        }
        if (dest == null)
        {
            throw new ArgumentNullException("dest");
        }
        if (numBytes < 0)
        {
            throw new ArgumentOutOfRangeException("numBytes", numBytes, __Res.GetString("ArgOOR_NeedNonNegNum"));
        }
        if ((src.Length < numBytes) || (dest.Length < numBytes))
        {
            throw new ArgumentOutOfRangeException("numBytes", numBytes, __Res.GetString("Arg_MustBeLessThanArrayLen"));
        }
        Buffer.BlockCopy(src, 0, dest, 0, numBytes);
    }

    [CLSCompliant(false), SecurityPermission(SecurityAction.LinkDemand, UnmanagedCode=true)]
    public static unsafe void Copy(byte[] src, byte* dest, int numBytes)
    {
        if (src == null)
        {
            throw new ArgumentNullException("src");
        }
        if (dest == null)
        {
            throw new ArgumentNullException("dest");
        }
        if (numBytes < 0)
        {
            throw new ArgumentOutOfRangeException("numBytes", numBytes, __Res.GetString("ArgOOR_NeedNonNegNum"));
        }
        if (src.Length == 0)
        {
            if (numBytes != 0)
            {
                throw new ArgumentException("src", __Res.GetString("Arg_ZeroLenByteArray"));
            }
        }
        else
        {
            fixed (byte* numRef = src)
            {
                memmoveimpl(numRef, dest, numBytes);
            }
        }
    }

    [CLSCompliant(false), SecurityPermission(SecurityAction.LinkDemand, UnmanagedCode=true)]
    public static unsafe void FillWithGarbage(byte* pBytes, int len)
    {
        if (len < 0)
        {
            throw new ArgumentOutOfRangeException("len", len, __Res.GetString("ArgOOR_NeedNonNegNum"));
        }
        int num = len >> 2;
        uint* numPtr = (uint*) pBytes;
        while (num-- > 0)
        {
            numPtr++;
            numPtr[0] = 0xdeadbeef;
        }
        len &= 3;
        if (len > 0)
        {
            pBytes = (byte*) numPtr;
            while (len-- > 0)
            {
                *(pBytes++) = 0xff;
            }
        }
    }

    [CLSCompliant(false), SecurityPermission(SecurityAction.LinkDemand, UnmanagedCode=true)]
    public static unsafe void Free(byte* pBytes)
    {
        if (pBytes == null)
        {
            throw new ArgumentNullException("pBytes");
        }
        pBytes = (byte*) (((ulong) pBytes) - 4L);
        int len = *((int*) pBytes);
        if (len == -2147483648)
        {
            throw new InvalidOperationException(__Res.GetString("InvalidOperation_FreeingMemoryTwice"));
        }
        FillWithGarbage(pBytes + 4, len);
        *((int*) pBytes) = -2147483648;
        Marshal.FreeHGlobal(new IntPtr((void*) pBytes));
    }

    private static unsafe void memcpyimpl(byte* src, byte* dest, int numBytes)
    {
        int num = numBytes / 8;
        long* numPtr = (long*) src;
        long* numPtr2 = (long*) dest;
        while (num-- > 0)
        {
            numPtr2++;
            numPtr++;
            numPtr2[0] = numPtr[0];
        }
        num = numBytes % 8;
        if (num > 0)
        {
            src = (byte*) numPtr;
            dest = (byte*) numPtr2;
            while (num-- > 0)
            {
                *(dest++) = *(src++);
            }
        }
    }

    private static unsafe void memmoveimpl(byte* src, byte* dest, int numBytes)
    {
        if ((((dest + numBytes) < src) || (dest > (src + numBytes))) || (dest < src))
        {
            memcpyimpl(src, dest, numBytes);
        }
        else
        {
            int index = numBytes / 8;
            if (index < numBytes)
            {
                while ((numBytes % 8) != 0)
                {
                    numBytes--;
                    dest[numBytes] = src[numBytes];
                }
            }
            long* numPtr = (long*) src;
            long* numPtr2 = (long*) dest;
            while (index-- > 0)
            {
                numPtr2[index] = numPtr[index];
            }
        }
    }
}

 

 


   public sealed class StreamUtils
{
    // Methods
    private StreamUtils()
    {
    }

    public static int BlockingRead(Stream input, byte[] bytes, int offset, int count)
    {
        if (input == null)
        {
            throw new ArgumentNullException("input");
        }
        int num = count;
        while (count > 0)
        {
            int num2 = input.Read(bytes, offset, count);
            if (num2 == 0)
            {
                return (num - count);
            }
            count -= num2;
            offset += num2;
        }
        return num;
    }

    public static long Pump(Stream input, Stream output)
    {
        int num;
        if (input == null)
        {
            throw new ArgumentNullException("input");
        }
        if (output == null)
        {
            throw new ArgumentNullException("output");
        }
        MemoryStream stream = input as MemoryStream;
        if ((stream != null) && (stream.Position == 0L))
        {
            stream.WriteTo(output);
            return stream.Length;
        }
        byte[] buffer = new byte[0x1000];
        long num2 = 0L;
        while ((num = input.Read(buffer, 0, 0x1000)) > 0)
        {
            output.Write(buffer, 0, num);
            num2 += num;
        }
        return num2;
    }
}


 


   public sealed class StringHelpers
{
    // Fields
    private static readonly string[] EmptyStringArray = new string[0];
    private const int ReverseUsingArrayThreshold = 40;

    // Methods
    private StringHelpers()
    {
    }

    public static unsafe string ReverseOrdinal(string s)
    {
        if (s == null)
        {
            throw new ArgumentNullException("s");
        }
        string str = string.Copy(s);
        int length = s.Length;
        fixed (char* str2 = ((char*) str))
        {
            char* chPtr = str2 + RuntimeHelpers.OffsetToStringData;
            for (int i = 0; i < (length / 2); i++)
            {
                char ch = chPtr[i];
                chPtr[i] = chPtr[(length - i) - 1];
                chPtr[(length - i) - 1] = ch;
            }
        }
        return str;
    }

    public static string[] SplitLines(string str)
    {
        if (str == null)
        {
            throw new ArgumentNullException("str");
        }
        string[] emptyStringArray = EmptyStringArray;
        int length = 0;
        int startIndex = 0;
        int num3 = 0;
        int num4 = str.Length;
        while ((num3 < num4) || (startIndex < num3))
        {
            if (((num3 == num4) || (str[num3] == '\r')) || (str[num3] == '\n'))
            {
                string str2 = str.Substring(startIndex, num3 - startIndex);
                if (length == emptyStringArray.Length)
                {
                    int num5 = (emptyStringArray.Length < 0x10) ? 0x10 : (emptyStringArray.Length * 2);
                    string[] destinationArray = new string[num5];
                    Array.Copy(emptyStringArray, 0, destinationArray, 0, length);
                    emptyStringArray = destinationArray;
                }
                emptyStringArray[length++] = str2;
                startIndex = num3 + 1;
                if ((((num3 + 1) < num4) && (str[num3] == '\r')) && (str[num3 + 1] == '\n'))
                {
                    startIndex++;
                }
                num3 = startIndex;
            }
            else
            {
                num3++;
            }
        }
        if (length < emptyStringArray.Length)
        {
            string[] strArray3 = new string[length];
            Array.Copy(emptyStringArray, 0, strArray3, 0, length);
            emptyStringArray = strArray3;
        }
        return emptyStringArray;
    }

    public static string[] WrapLine(string line, int lineLength)
    {
        if (lineLength < 0)
        {
            throw new ArgumentOutOfRangeException("lineLength", lineLength, __Res.GetString("ArgOOR_NeedNonNegNum"));
        }
        string[] strArray = line.Split(new char[0]);
        ArrayList list = new ArrayList(line.Length / lineLength);
        int index = 0;
        int num2 = 0;
        while (index < strArray.Length)
        {
            int num3 = 0;
            while ((num3 < lineLength) && (num2 < strArray.Length))
            {
                num3 += strArray[num2].Length + 1;
                num2++;
            }
            if ((num3 >= lineLength) && (index < num2))
            {
                num2--;
            }
            StringBuilder builder = new StringBuilder();
            for (int i = index; i < num2; i++)
            {
                builder.Append(strArray[i]);
                if (!" ".Equals(strArray[i]))
                {
                    builder.Append(' ');
                }
            }
            if (index == num2)
            {
                builder.Append(strArray[index]);
            }
            list.Add(builder.ToString());
            index = num2;
        }
        return (string[]) list.ToArray(typeof(string));
    }
}

 

 

}

 

 
