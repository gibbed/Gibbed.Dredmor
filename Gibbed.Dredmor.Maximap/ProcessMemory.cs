/* Copyright (c) 2011 Rick (rick 'at' gibbed 'dot' us)
 * 
 * This software is provided 'as-is', without any express or implied
 * warranty. In no event will the authors be held liable for any damages
 * arising from the use of this software.
 * 
 * Permission is granted to anyone to use this software for any purpose,
 * including commercial applications, and to alter it and redistribute it
 * freely, subject to the following restrictions:
 * 
 * 1. The origin of this software must not be misrepresented; you must not
 *    claim that you wrote the original software. If you use this software
 *    in a product, an acknowledgment in the product documentation would
 *    be appreciated but is not required.
 * 
 * 2. Altered source versions must be plainly marked as such, and must not
 *    be misrepresented as being the original software.
 * 
 * 3. This notice may not be removed or altered from any source
 *    distribution.
 */

using System;
using System.Diagnostics;
using System.Runtime.InteropServices;

namespace Gibbed.Dredmor.Maximap
{
    internal class ProcessMemory : IDisposable
    {
        public class NativeException : InvalidOperationException
        {
            public NativeException() :
                base()
            {
            }

            public NativeException(string message)
                : base(message)
            {
            }

            public NativeException(string message, Exception innerException)
                : base(message, innerException)
            {
            }
        }

        #region Win32 Imports / Defines
        protected static class Native
        {
            public static Int32 TRUE = 1;
            public static Int32 FALSE = 0;

            public static IntPtr NULL = (IntPtr)(0);
            public static IntPtr INVALID_HANDLE_VALUE = (IntPtr)(-1);

            public static UInt32 SYNCHRONIZE = 0x00100000;
            public static UInt32 STANDARD_RIGHTS_REQUIRED = 0x000F0000;
            public static UInt32 PROCESS_ALL_ACCESS = STANDARD_RIGHTS_REQUIRED | SYNCHRONIZE | 0xFFF;
            public static UInt32 THREAD_ALL_ACCESS = STANDARD_RIGHTS_REQUIRED | SYNCHRONIZE | 0x3FF;

            [DllImport("kernel32.dll")]
            public static extern UInt32 GetLastError();

            [DllImport("kernel32.dll")]
            public static extern IntPtr OpenProcess(UInt32 dwDesiredAccess, Int32 bInheritHandle, Int32 dwProcessId);

            [DllImport("kernel32.dll")]
            public static extern Int32 ReadProcessMemory(IntPtr hProcess, IntPtr lpBaseAddress, [In, Out] byte[] lpBuffer, UInt32 nSize, out UInt32 lpNumberOfBytesRead);

            [DllImport("kernel32.dll")]
            public static extern Int32 WriteProcessMemory(IntPtr hProcess, IntPtr lpBaseAddress, [In, Out] byte[] lpBuffer, UInt32 nSize, out UInt32 lpNumberOfBytesWritten);

            [DllImport("kernel32.dll")]
            public static extern IntPtr OpenThread(UInt32 dwDesiredAccess, Int32 bInheritHandle, UInt32 dwThreadId);

            [DllImport("kernel32.dll")]
            public static extern UInt32 SuspendThread(IntPtr hThread);

            [DllImport("kernel32.dll")]
            public static extern UInt32 ResumeThread(IntPtr hThread);

            [DllImport("kernel32.dll")]
            public static extern Int32 CloseHandle(IntPtr hObject);
        };
        #endregion

        protected Process Process;
        protected IntPtr Handle;

        public UInt32 MainModuleAddress { get { return (UInt32)this.Process.MainModule.BaseAddress.ToInt32(); } }
        public UInt32 MainModuleSize { get { return (UInt32)this.Process.MainModule.ModuleMemorySize; } }

        public ProcessMemory()
        {
            this.Process = null;
            this.Handle = Native.NULL;
        }

        ~ProcessMemory()
        {
            Dispose(false);
        }

        public bool Open(Process process)
        {
            if (this.Handle != Native.NULL)
            {
                Native.CloseHandle(this.Handle);
                this.Process = null;
                this.Handle = Native.INVALID_HANDLE_VALUE;
            }

            var theProcess = Native.OpenProcess(
                Native.PROCESS_ALL_ACCESS,
                Native.FALSE,
                process.Id);
            if (theProcess == Native.NULL)
            {
                return false;
            }

            this.Process = process;
            this.Handle = theProcess;
            return true;
        }

        public bool Close()
        {
            if (this.Handle == Native.NULL)
            {
                throw new InvalidOperationException("process handle is invalid");
            }

            var result = Native.CloseHandle(this.Handle);

            this.Process = null;
            this.Handle = Native.NULL;

            return result == Native.TRUE ? true : false;
        }

        public UInt32 Read(UInt32 address, ref byte[] data)
        {
            return this.Read(address, ref data, (UInt32)data.Length);
        }

        public UInt32 Read(UInt32 address, ref byte[] data, UInt32 size)
        {
            if (this.Handle == Native.NULL)
            {
                throw new InvalidOperationException("process handle is invalid");
            }

            uint read;
            var result = Native.ReadProcessMemory(
                this.Handle, (IntPtr)(address), data, size, out read);
            if (result == 0)
            {
                throw new NativeException("error " + Native.GetLastError().ToString());
            }
            else if (read != size)
            {
                throw new InvalidOperationException("only read " + read.ToString() + " instead of " + size);
            }

            return read;
        }

        public Byte ReadU8(UInt32 address)
        {
            var data = new byte[1];
            this.Read(address, ref data);
            return data[0];
        }

        public SByte ReadS8(UInt32 address)
        {
            var data = new byte[1];
            this.Read(address, ref data);
            return (SByte)data[0];
        }

        public UInt16 ReadU16(UInt32 address)
        {
            var data = new byte[2];
            this.Read(address, ref data);
            return BitConverter.ToUInt16(data, 0);
        }

        public Int16 ReadS16(UInt32 address)
        {
            var data = new byte[2];
            this.Read(address, ref data);
            return BitConverter.ToInt16(data, 0);
        }

        public UInt32 ReadU32(UInt32 address)
        {
            var data = new byte[4];
            this.Read(address, ref data);
            return BitConverter.ToUInt32(data, 0);
        }

        public Int32 ReadS32(UInt32 address)
        {
            var data = new byte[4];
            this.Read(address, ref data);
            return BitConverter.ToInt32(data, 0);
        }

        public UInt64 ReadU64(UInt32 address)
        {
            var data = new byte[8];
            this.Read(address, ref data);
            return BitConverter.ToUInt64(data, 0);
        }

        public Int64 ReadS64(UInt32 address)
        {
            var data = new byte[8];
            this.Read(address, ref data);
            return BitConverter.ToInt64(data, 0);
        }

        public Single ReadF32(UInt32 address)
        {
            var data = new byte[4];
            this.Read(address, ref data);
            return BitConverter.ToSingle(data, 0);
        }

        public Double ReadF64(UInt32 address)
        {
            var data = new byte[8];
            this.Read(address, ref data);
            return BitConverter.ToDouble(data, 0);
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        protected virtual void Dispose(bool disposing)
        {
            if (disposing)
            {
                // nada
            }

            if (this.Handle != Native.NULL)
            {
                this.Close();
            }
        }
    }
}
