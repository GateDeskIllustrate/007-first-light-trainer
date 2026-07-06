namespace _007_First_Light_Trainer.Features
{
    public class GameFeatures
    {
        private readonly Memory.MemoryManager _memoryManager;

        public GameFeatures(Memory.MemoryManager memoryManager)
        {
            _memoryManager = memoryManager;
        }

        public void SetInfiniteHealth()
        {
            _memoryManager.WriteMemory(0x12345678, BitConverter.GetBytes(9999f));
        }

        public void SetInfiniteAmmo()
        {
            _memoryManager.WriteMemory(0x87654321, BitConverter.GetBytes(999));
        }
    }
}