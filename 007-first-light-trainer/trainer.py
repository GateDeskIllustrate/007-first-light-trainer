import keyboard
from memory_reader import MemoryReader

class Trainer:
    def __init__(self, reader: MemoryReader):
        self.reader = reader
        self.infinite_ammo = False
        self.infinite_health = False
        self.no_reload = False

    def handle_input(self):
        if keyboard.is_pressed('F1'):
            self.infinite_ammo = not self.infinite_ammo
            print(f"Infinite Ammo: {'ON' if self.infinite_ammo else 'OFF'}")
        if keyboard.is_pressed('F2'):
            self.infinite_health = not self.infinite_health
            print(f"Infinite Health: {'ON' if self.infinite_health else 'OFF'}")
        if keyboard.is_pressed('F3'):
            self.no_reload = not self.no_reload
            print(f"No Reload: {'ON' if self.no_reload else 'OFF'}")
        if keyboard.is_pressed('F5'):
            exit(0)

    def apply_cheats(self):
        if self.infinite_ammo:
            self.reader.write_bytes(0x004A2F10, b'\x90\x90\x90\x90\x90\x90')
        if self.infinite_health:
            self.reader.write_bytes(0x004B3C20, b'\x90\x90\x90\x90\x90\x90')
        if self.no_reload:
            self.reader.write_bytes(0x004A1B40, b'\x90\x90\x90\x90\x90\x90')