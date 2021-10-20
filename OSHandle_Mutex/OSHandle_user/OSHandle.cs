using System;
using System.Collections.Generic;
using System.Text;
using System.Runtime.InteropServices;

namespace OSHandleTest
{
    public class OSHandle : IDisposable
    {
        [DllImport("Kernel32.dll",
            EntryPoint = "CloseHandle",
            SetLastError = true,
            CharSet = CharSet.Auto,
            CallingConvention = CallingConvention.StdCall)]
        private static extern bool CloseHandle(IntPtr handle);

        private bool isDisposed;

        public IntPtr handle { get; set; }

        public OSHandle(IntPtr handle)
        {
            this.handle = handle;
            isDisposed = false;
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        protected virtual void Dispose(bool disposing)
        {
            if (!isDisposed)
            {
                if (disposing)
                {
                    CloseHandle(handle);
                    handle = IntPtr.Zero;
                }

                isDisposed = true;
            }
        }

        ~OSHandle()
        {
            Dispose(false);
        }
    }
}
