#ifndef MEMORY_H
#define MEMORY_H

#include <cstdint>
#include <string>
#include <vector>

namespace Trainer {

struct MemoryRegion {
    uintptr_t base;
    size_t size;
    std::string name;
};

class MemoryManager {
public:
    MemoryManager();
    bool write(uintptr_t address, const std::vector<uint8_t>& data);
    bool read(uintptr_t address, std::vector<uint8_t>& buffer, size_t size);
    std::vector<MemoryRegion> list_regions() const;
private:
    bool attached_;
};

} // namespace Trainer

#endif // MEMORY_H