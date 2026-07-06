#include <cassert>
#include <iostream>
#include "trainer.h"

int main() {
    Trainer::TrainerState state;

    // Test initial state
    assert(!state.is_enabled(Trainer::Feature::INFINITE_HEALTH));
    assert(!state.is_enabled(Trainer::Feature::INFINITE_AMMO));
    assert(!state.is_enabled(Trainer::Feature::STEALTH_MODE));

    // Test enable
    state.enable(Trainer::Feature::INFINITE_HEALTH);
    assert(state.is_enabled(Trainer::Feature::INFINITE_HEALTH));
    assert(!state.is_enabled(Trainer::Feature::INFINITE_AMMO));

    // Test disable
    state.disable(Trainer::Feature::INFINITE_HEALTH);
    assert(!state.is_enabled(Trainer::Feature::INFINITE_HEALTH));

    // Test multiple flags
    state.enable(Trainer::Feature::INFINITE_AMMO | Trainer::Feature::STEALTH_MODE);
    assert(state.is_enabled(Trainer::Feature::INFINITE_AMMO));
    assert(state.is_enabled(Trainer::Feature::STEALTH_MODE));
    assert(!state.is_enabled(Trainer::Feature::INFINITE_HEALTH));

    std::cout << "All tests passed!" << std::endl;
    return 0;
}