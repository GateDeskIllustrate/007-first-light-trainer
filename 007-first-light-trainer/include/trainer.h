#ifndef TRAINER_H
#define TRAINER_H

#include <cstdint>
#include <string>

namespace Trainer {

enum class Feature : uint8_t {
    INFINITE_HEALTH = 0x01,
    INFINITE_AMMO   = 0x02,
    STEALTH_MODE    = 0x04
};

inline Feature operator|(Feature a, Feature b) {
    return static_cast<Feature>(
        static_cast<uint8_t>(a) | static_cast<uint8_t>(b)
    );
}

inline Feature operator&(Feature a, Feature b) {
    return static_cast<Feature>(
        static_cast<uint8_t>(a) & static_cast<uint8_t>(b)
    );
}

class TrainerState {
public:
    TrainerState();
    void enable(Feature f);
    void disable(Feature f);
    bool is_enabled(Feature f) const;
    std::string status() const;
private:
    uint8_t flags_;
};

} // namespace Trainer

#endif // TRAINER_H