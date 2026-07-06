using _007_First_Light_Trainer.Memory;
using NUnit.Framework;
using System;

namespace _007_First_Light_Trainer.Tests
{
    [TestFixture]
    public class MemoryManagerTests
    {
        [Test]
        public void TestMemoryWriteAndRead()
        {
            var memoryManager = new MemoryManager();
            if (!memoryManager.AttachToProcess("notepad"))
            {
                Assert.Inconclusive("Notepad not running for test");
                return;
            }

            long testAddress = 0x10000000; // Arbitrary address for testing
            byte[] testValue = BitConverter.GetBytes(12345);

            memoryManager.WriteMemory(testAddress, testValue);
            byte[] readValue = memoryManager.ReadMemory(testAddress, testValue.Length);

            Assert.AreEqual(testValue, readValue);
        }
    }
}