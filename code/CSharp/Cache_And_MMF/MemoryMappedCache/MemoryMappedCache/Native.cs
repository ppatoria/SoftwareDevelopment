using System;
using System.IO;
using System.Runtime;
using System.Runtime.InteropServices;
using System.Security;
using System.Security.Permissions;
using System.Resources;

namespace MemoryMappedCache
{
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
        internal static readonly IntPtr InvalidHandleValue;
        internal const int PAGE_READONLY = 2;
        internal const int PAGE_READWRITE = 4;
        internal const int PAGE_WRITECOPY = 8;
        internal const int STD_INPUT_HANDLE = -10;
        internal const int STD_OUTPUT_HANDLE = -11;

        // Methods
        static __Native();
        private __Native();
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
        internal static long GetLengthOfFile(IntPtr fileHandle);
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
        public __Res();
        internal static string GetString(string key);
        internal static string GetString(string key, params object[] inserts);
    }

    public sealed class ConsoleUtils
    {
        // Methods
        private ConsoleUtils();
        public static void ClearScreen();
        private static void ClrScrError();

        // Properties
        public static bool EchoInput { get; set; }
    }

    public sealed class Memory
    {
        // Fields
        public static readonly IntPtr Null;

        // Methods
        static Memory();
        private Memory();
        [CLSCompliant(false), SecurityPermission(SecurityAction.LinkDemand, UnmanagedCode=true)]
        public static unsafe byte* Allocate(int numBytes);
        [CLSCompliant(false), SecurityPermission(SecurityAction.LinkDemand, UnmanagedCode=true)]
        public static unsafe void Clear(byte* pBytes, int len);
        [CLSCompliant(false), SecurityPermission(SecurityAction.LinkDemand, UnmanagedCode=true)]
        public static unsafe int Compare(byte* a, byte* b, int numBytes);
        public static int Compare(byte[] a, byte[] b, int numBytes);
        [CLSCompliant(false), SecurityPermission(SecurityAction.LinkDemand, UnmanagedCode=true)]
        public static unsafe void Copy(byte* src, byte* dest, int numBytes);
        [CLSCompliant(false), SecurityPermission(SecurityAction.LinkDemand, UnmanagedCode=true)]
        public static unsafe void Copy(byte* src, byte[] dest, int numBytes);
        [SecurityPermission(SecurityAction.LinkDemand, UnmanagedCode=true)]
        public static void Copy(IntPtr src, IntPtr dest, int numBytes);
        [CLSCompliant(false), SecurityPermission(SecurityAction.LinkDemand, UnmanagedCode=true)]
        public static unsafe void Copy(byte[] src, byte* dest, int numBytes);
        public static void Copy(byte[] src, byte[] dest, int numBytes);
        [CLSCompliant(false), SecurityPermission(SecurityAction.LinkDemand, UnmanagedCode=true)]
        public static unsafe void FillWithGarbage(byte* pBytes, int len);
        [CLSCompliant(false), SecurityPermission(SecurityAction.LinkDemand, UnmanagedCode=true)]
        public static unsafe void Free(byte* pBytes);
        private static unsafe void memcpyimpl(byte* src, byte* dest, int numBytes);
        private static unsafe void memmoveimpl(byte* src, byte* dest, int numBytes);
    }

    public sealed class StreamUtils
    {
        // Methods
        private StreamUtils();
        public static int BlockingRead(Stream input, byte[] bytes, int offset, int count);
        public static long Pump(Stream input, Stream output);
    }

    public sealed class StringHelpers
    {
        // Fields
        private static readonly string[] EmptyStringArray;
        private const int ReverseUsingArrayThreshold = 40;

        // Methods
        static StringHelpers();
        private StringHelpers();
        public static string ReverseOrdinal(string s);
        public static string[] SplitLines(string str);
        public static string[] WrapLine(string line, int lineLength);
    }
}

 

 
