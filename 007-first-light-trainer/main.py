import sys
import time
from trainer import Trainer
from memory_reader import MemoryReader

def main():
    print("007 First Light Trainer v1.0")
    print("============================")
    print("Hotkeys:")
    print("  F1 - Infinite Ammo Toggle")
    print("  F2 - Infinite Health Toggle")
    print("  F3 - No Reload Toggle")
    print("  F5 - Exit")
    print()

    reader = MemoryReader("firstlight.exe")
    trainer = Trainer(reader)

    try:
        while True:
            trainer.handle_input()
            trainer.apply_cheats()
            time.sleep(0.05)
    except KeyboardInterrupt:
        print("\nExiting...")
    finally:
        reader.close()

if __name__ == "__main__":
    main()