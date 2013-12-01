using System.Windows;
using System.Runtime.InteropServices;
using System;
namespace CustomItem
{
    public class MemoryManagement
    {
        [DllImportAttribute("kernel32.dll", EntryPoint = "SetProcessWorkingSetSize", ExactSpelling = true, CharSet = CharSet.Unicode, SetLastError = true)]

        private static extern int SetProcessWorkingSetSize(IntPtr process, int minimumWorkingSetSize, int
        maximumWorkingSetSize);

        //[DllImport ("kernel32.dll")]
        //private static extern int MemoryManagement.SetProcessWorkingSetSize (IntPtr process, int minimumWorkingSetSize , int maximumWorkingSetSize);
        
		public static void FlushMemory()
        {
            GC.Collect();
            GC.WaitForPendingFinalizers();
            if (Environment.OSVersion.Platform == PlatformID.Win32NT)
				MemoryManagement.SetProcessWorkingSetSize(System.Diagnostics.Process.GetCurrentProcess().Handle, -1, -1);
            GC.Collect();
        }
    }
}

