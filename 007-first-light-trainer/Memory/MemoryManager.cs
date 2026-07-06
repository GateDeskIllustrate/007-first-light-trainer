using System;
using System.Diagnostics;
using System.Runtime.InteropServices;

namespace _007_First_Light_Trainer.Memory
{
    public class MemoryManager
    {
        [DllImport("kernel32.dll")]
        private static extern IntPtr OpenProcess(int dwDesiredAccess, bool bInheritHandle, int dwProcessId);

        [DllImport("kernel32.dll")]
        private static extern bool ReadProcessMemory(IntPtr hProcess, IntPtr lpBaseAddress, byte[] lpBuffer, int dwSize, out int lpNumberOfBytesRead);

        [DllImport("kernel32.dll")]
        private static extern bool WriteProcessMemory(IntPtr hProcess, IntPtr lpBaseAddress, byte[] lpBuffer, int dwSize, out int lpNumberOfBytesWritten);

        private const int PROCESS_WM_READ = 0x0010;
        private const int PROCESS_VM_WRITE = 0x0020;
        private const int PROCESS_VM_OPERATION = 0x0008;

        private IntPtr _processHandle;

        public bool AttachToProcess(string processName)
        {
            try
            {
                var process = Process.GetProcessesByName(processName)[0];
                _processHandle = OpenProcess(PROCESS_VM_OPERATION | PROCESS_VM_WRITE | PROCESS_WM_READ, false, process.Id);
                return true;
            }
            catch
            {
                return false;
            }
        }

        public void WriteMemory(long address, byte[] value)
        {
            WriteProcessMemory(_processHandle, (IntPtr)address, value, value.Length, out _);
        }

        public byte[] ReadMemory(long address, int size)
        {
            byte[] buffer = new byte[size];
            ReadProcessMemory(_processHandle, (IntPtr)address, buffer, size, out _);
            return buffer;
        }
    }
}