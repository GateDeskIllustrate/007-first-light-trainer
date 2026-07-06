#include <iostream>
#include "trainer.h"
#include "memory.h"

int main() {
    Trainer::TrainerState state;
    Trainer::MemoryManager mem;

    std::cout << "007 First Light Trainer v1.0\n";
    std::cout << "============================\n\n";

    state.enable(Trainer::Feature::INFINITE_HEALTH);
    state.enable(Trainer::Feature::INFINITE_AMMO);

    std::cout << state.status() << std::endl;

    std::cout << "Memory regions found:\n";
    auto regions = mem.list_regions();
    for (const auto& r : regions) {
        std::cout << "  " << r.name << " @ 0x" << std::hex << r.base << "\n";
    }

    return 0;
}