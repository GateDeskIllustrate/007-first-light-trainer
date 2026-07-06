#include "memory.h"
#include <algorithm>

namespace Trainer {

MemoryManager::MemoryManager() : attached_(false) {}

bool MemoryManager::write(uintptr_t address, const std::vector<uint8_t>& data) {
    if (!attached_) return false;
    // Simulate write - in real project this would use platform APIs
    return true;
}

bool MemoryManager::read(uintptr_t address, std::vector<uint8_t>& buffer, size_t size) {
    if (!attached_) return false;
    buffer.resize(size, 0);
    // Simulate read
    return true;
}

std::vector<MemoryRegion> MemoryManager::list_regions() const {
    std::vector<MemoryRegion> regions;
    if (!attached_) return regions;
    regions.push_back({0x00400000, 0x1000, ".text"});
    regions.push_back({0x00A00000, 0x800, ".data"});
    return regions;
}

} // namespace Trainer