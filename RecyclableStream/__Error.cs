using System;
using System.Collections.Generic;
using System.Diagnostics.Contracts;
using System.IO;
using System.Runtime.InteropServices;
using System.Text;

namespace RecyclableStream
{
    [Pure]
    internal static class __Error
    {
        internal static void EndOfFile()
        {
            throw new EndOfStreamException("IO_EOF_ReadBeyondEOF");
        }

        internal static void FileNotOpen()
        {
            throw new ObjectDisposedException(null, "ObjectDisposed_FileClosed");
        }

        internal static void StreamIsClosed()
        {
            throw new ObjectDisposedException(null, "ObjectDisposed_StreamClosed");
        }

        internal static void MemoryStreamNotExpandable()
        {
            throw new NotSupportedException("NotSupported_MemStreamNotExpandable");
        }

        internal static void ReaderClosed()
        {
            throw new ObjectDisposedException(null, "ObjectDisposed_ReaderClosed");
        }

        internal static void ReadNotSupported()
        {
            throw new NotSupportedException("NotSupported_UnreadableStream");
        }

        internal static void WrongAsyncResult()
        {
            throw new ArgumentException("Arg_WrongAsyncResult");
        }

        internal static void EndReadCalledTwice()
        {
            // Should ideally be InvalidOperationExc but we can't maitain parity with Stream and FileStream without some work
            throw new ArgumentException("InvalidOperation_EndReadCalledMultiple");
        }

        internal static void EndWriteCalledTwice()
        {
            // Should ideally be InvalidOperationExc but we can't maintain parity with Stream and FileStream without some work
            throw new ArgumentException("InvalidOperation_EndWriteCalledMultiple");
        }

        internal static void WinIOError()
        {
            int errorCode = Marshal.GetLastWin32Error();
            WinIOError(errorCode, String.Empty);
        }

        // After calling GetLastWin32Error(), it clears the last error field,
        // so you must save the HResult and pass it to this method.  This method
        // will determine the appropriate exception to throw dependent on your 
        // error, and depending on the error, insert a string into the message 
        // gotten from the ResourceManager.
        internal static void WinIOError(int errorCode, String str)
        {
            //switch (errorCode)
            //{
            //    case Win32Native.ERROR_FILE_NOT_FOUND:
            //        if (str.Length == 0)
            //            throw new FileNotFoundException("IO_FileNotFound");
            //        else
            //            throw new FileNotFoundException("Format("IO_FileNotFound_FileName, str), str);

            //    case Win32Native.ERROR_PATH_NOT_FOUND:
            //        if (str.Length == 0)
            //            throw new DirectoryNotFoundException("IO_PathNotFound_NoPathName");
            //        else
            //            throw new DirectoryNotFoundException("Format("IO_PathNotFound_Path, str));

            //    case Win32Native.ERROR_ACCESS_DENIED:
            //        if (str.Length == 0)
            //            throw new UnauthorizedAccessException("UnauthorizedAccess_IODenied_NoPathName");
            //        else
            //            throw new UnauthorizedAccessException("Format("UnauthorizedAccess_IODenied_Path, str));

            //    case Win32Native.ERROR_ALREADY_EXISTS:
            //        if (str.Length == 0)
            //            goto default;
            //        throw new IOException("Format("IO_AlreadyExists_Name, str), Win32Native.MakeHRFromErrorCode(errorCode), str);

            //    case Win32Native.ERROR_FILENAME_EXCED_RANGE:
            //        throw new PathTooLongException("Format("IO_PathTooLong_Path, str));

            //    case Win32Native.ERROR_INVALID_DRIVE:
            //        throw new DriveNotFoundException("Format("IO_DriveNotFound_Drive, str));

            //    case Win32Native.ERROR_INVALID_PARAMETER:
            //        throw new IOException(Win32Native.GetMessage(errorCode), Win32Native.MakeHRFromErrorCode(errorCode), str);

            //    case Win32Native.ERROR_SHARING_VIOLATION:
            //        if (str.Length == 0)
            //            throw new IOException("IO_SharingViolation_NoFileName, Win32Native.MakeHRFromErrorCode(errorCode), str);
            //        else
            //            throw new IOException("Format("IO_SharingViolation_File, str), Win32Native.MakeHRFromErrorCode(errorCode), str);

            //    case Win32Native.ERROR_FILE_EXISTS:
            //        if (str.Length == 0)
            //            goto default;
            //        throw new IOException("Format("IO_FileExists_Name, str), Win32Native.MakeHRFromErrorCode(errorCode), str);

            //    case Win32Native.ERROR_OPERATION_ABORTED:
            //        throw new OperationCanceledException();

            //    default:
            //        throw new IOException(Win32Native.GetMessage(errorCode), Win32Native.MakeHRFromErrorCode(errorCode), str);
            //}
        }

        internal static void WriteNotSupported()
        {
            throw new NotSupportedException("NotSupported_UnwritableStream");
        }
    }
}
