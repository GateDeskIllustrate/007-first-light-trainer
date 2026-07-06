cmake_minimum_required(VERSION 3.10)
project(007-first-light-trainer LANGUAGES CXX)

set(CMAKE_CXX_STANDARD 17)
set(CMAKE_CXX_STANDARD_REQUIRED ON)

add_library(trainer_core OBJECT
    src/trainer.cpp
    src/memory.cpp
)

target_include_directories(trainer_core PUBLIC include)

add_executable(trainer_test
    test/test_trainer.cpp
    $<TARGET_OBJECTS:trainer_core>
)

target_link_libraries(trainer_test PRIVATE)

add_executable(trainer_app
    main.cpp
    $<TARGET_OBJECTS:trainer_core>
)

target_link_libraries(trainer_app PRIVATE)