import ctypes
import ctypes.wintypes

class MemoryReader:
    def __init__(self, process_name: str):
        self.process_name = process_name
        self.handle = None
        self._open_process()

    def _open_process(self):
        PROCESS_ALL_ACCESS = 0x1F0FFF
        kernel32 = ctypes.windll.kernel32
        pid = self._get_pid_by_name(self.process_name)
        if pid is None:
            raise Exception(f"Process {self.process_name} not found")
        self.handle = kernel32.OpenProcess(PROCESS_ALL_ACCESS, False, pid)
        if not self.handle:
            raise Exception("Failed to open process")

    def _get_pid_by_name(self, name: str) -> int:
        kernel32 = ctypes.windll.kernel32
        psapi = ctypes.windll.psapi
        pids = (ctypes.wintypes.DWORD * 1024)()
        needed = ctypes.wintypes.DWORD()
        kernel32.EnumProcesses(pids, ctypes.sizeof(pids), ctypes.byref(needed))
        count = needed.value // ctypes.sizeof(ctypes.wintypes.DWORD)
        for i in range(count):
            pid = pids[i]
            h_process = kernel32.OpenProcess(0x0410, False, pid)
            if h_process:
                exe_name = ctypes.create_string_buffer(260)
                psapi.GetModuleBaseNameA(h_process, None, exe_name, 260)
                kernel32.CloseHandle(h_process)
                if exe_name.value.decode() == name:
                    return pid
        return None

    def write_bytes(self, address: int, data: bytes):
        if not self.handle:
            return
        kernel32 = ctypes.windll.kernel32
        written = ctypes.wintypes.DWORD()
        kernel32.WriteProcessMemory(self.handle, ctypes.c_void_p(address), data, len(data), ctypes.byref(written))

    def close(self):
        if self.handle:
            ctypes.windll.kernel32.CloseHandle(self.handle)