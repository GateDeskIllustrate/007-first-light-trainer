using System;
using System.Diagnostics;
using System.Runtime.InteropServices;
using System.Threading;

namespace _007_First_Light_Trainer
{
    class Program
    {
        [DllImport("kernel32.dll")]
        static extern IntPtr OpenProcess(int dwDesiredAccess, bool bInheritHandle, int dwProcessId);

        [DllImport("kernel32.dll")]
        static extern bool ReadProcessMemory(IntPtr hProcess, IntPtr lpBaseAddress, byte[] lpBuffer, int dwSize, out int lpNumberOfBytesRead);

        [DllImport("kernel32.dll")]
        static extern bool WriteProcessMemory(IntPtr hProcess, IntPtr lpBaseAddress, byte[] lpBuffer, int dwSize, out int lpNumberOfBytesWritten);

        const int PROCESS_WM_READ = 0x0010;
        const int PROCESS_VM_WRITE = 0x0020;
        const int PROCESS_VM_OPERATION = 0x0008;

        static void Main(string[] args)
        {
            Console.WriteLine("007 First Light Trainer");
            Console.WriteLine("Waiting for game process...");

            Process gameProcess = null;
            while (gameProcess == null)
            {
                try
                {
                    gameProcess = Process.GetProcessesByName("007FirstLight")[0];
                }
                catch
                {
                    Thread.Sleep(1000);
                }
            }

            Console.WriteLine("Game process found! PID: " + gameProcess.Id);
            IntPtr processHandle = OpenProcess(PROCESS_VM_OPERATION | PROCESS_VM_WRITE | PROCESS_WM_READ, false, gameProcess.Id);

            while (true)
            {
                Console.WriteLine("\nSelect option:");
                Console.WriteLine("1. Infinite Health");
                Console.WriteLine("2. Infinite Ammo");
                Console.WriteLine("3. Exit");
                Console.Write("> ");

                string input = Console.ReadLine();
                if (input == "1")
                {
                    WriteMemory(processHandle, 0x12345678, BitConverter.GetBytes(9999f));
                    Console.WriteLine("Infinite health activated!");
                }
                else if (input == "2")
                {
                    WriteMemory(processHandle, 0x87654321, BitConverter.GetBytes(999));
                    Console.WriteLine("Infinite ammo activated!");
                }
                else if (input == "3")
                {
                    break;
                }
            }
        }

        static void WriteMemory(IntPtr processHandle, long address, byte[] value)
        {
            WriteProcessMemory(processHandle, (IntPtr)address, value, value.Length, out _);
        }
    }
}