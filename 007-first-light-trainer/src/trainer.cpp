#include "trainer.h"
#include <sstream>

namespace Trainer {

TrainerState::TrainerState() : flags_(0) {}

void TrainerState::enable(Feature f) {
    flags_ |= static_cast<uint8_t>(f);
}

void TrainerState::disable(Feature f) {
    flags_ &= ~static_cast<uint8_t>(f);
}

bool TrainerState::is_enabled(Feature f) const {
    return (flags_ & static_cast<uint8_t>(f)) != 0;
}

std::string TrainerState::status() const {
    std::ostringstream oss;
    oss << "Trainer Status:\n"
        << "  Infinite Health: " << (is_enabled(Feature::INFINITE_HEALTH) ? "ON" : "OFF") << "\n"
        << "  Infinite Ammo:   " << (is_enabled(Feature::INFINITE_AMMO) ? "ON" : "OFF") << "\n"
        << "  Stealth Mode:    " << (is_enabled(Feature::STEALTH_MODE) ? "ON" : "OFF") << "\n";
    return oss.str();
}

} // namespace Trainer