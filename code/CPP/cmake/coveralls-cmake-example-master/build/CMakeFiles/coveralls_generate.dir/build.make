# CMAKE generated file: DO NOT EDIT!
# Generated by "Unix Makefiles" Generator, CMake Version 2.8

#=============================================================================
# Special targets provided by cmake.

# Disable implicit rules so canonical targets will work.
.SUFFIXES:

# Remove some rules from gmake that .SUFFIXES does not remove.
SUFFIXES =

.SUFFIXES: .hpux_make_needs_suffix_list

# Suppress display of executed commands.
$(VERBOSE).SILENT:

# A target that is always out of date.
cmake_force:
.PHONY : cmake_force

#=============================================================================
# Set environment variables for the build.

# The shell in which to execute make rules.
SHELL = /bin/sh

# The CMake executable.
CMAKE_COMMAND = /usr/bin/cmake

# The command to remove a file.
RM = /usr/bin/cmake -E remove -f

# Escaping for special characters.
EQUALS = =

# The top-level source directory on which CMake was run.
CMAKE_SOURCE_DIR = /home/pralay/g-code/CPP/cmake/coveralls-cmake-example-master

# The top-level build directory on which CMake was run.
CMAKE_BINARY_DIR = /home/pralay/g-code/CPP/cmake/coveralls-cmake-example-master/build

# Utility rule file for coveralls_generate.

# Include the progress variables for this target.
include CMakeFiles/coveralls_generate.dir/progress.make

CMakeFiles/coveralls_generate:
	$(CMAKE_COMMAND) -E cmake_progress_report /home/pralay/g-code/CPP/cmake/coveralls-cmake-example-master/build/CMakeFiles $(CMAKE_PROGRESS_1)
	@$(CMAKE_COMMAND) -E cmake_echo_color --switch=$(COLOR) --blue --bold "Generating coveralls output..."
	/usr/bin/cmake -DPROJECT_BINARY_DIR="/home/pralay/g-code/CPP/cmake/coveralls-cmake-example-master/build" -P /home/pralay/g-code/CPP/cmake/coveralls-cmake-example-master/coveralls-cmake/cmake/CoverallsClear.cmake
	/usr/bin/ctest --output-on-failure
	/usr/bin/cmake -DCOVERAGE_SRCS="*/home/pralay/g-code/CPP/cmake/coveralls-cmake-example-master/complicated.c" -DCOVERALLS_OUTPUT_FILE="/home/pralay/g-code/CPP/cmake/coveralls-cmake-example-master/build/coveralls.json" -DCOV_PATH="/home/pralay/g-code/CPP/cmake/coveralls-cmake-example-master/build" -DPROJECT_ROOT="/home/pralay/g-code/CPP/cmake/coveralls-cmake-example-master" -P /home/pralay/g-code/CPP/cmake/coveralls-cmake-example-master/coveralls-cmake/cmake/CoverallsGenerateGcov.cmake

coveralls_generate: CMakeFiles/coveralls_generate
coveralls_generate: CMakeFiles/coveralls_generate.dir/build.make
.PHONY : coveralls_generate

# Rule to build all files generated by this target.
CMakeFiles/coveralls_generate.dir/build: coveralls_generate
.PHONY : CMakeFiles/coveralls_generate.dir/build

CMakeFiles/coveralls_generate.dir/clean:
	$(CMAKE_COMMAND) -P CMakeFiles/coveralls_generate.dir/cmake_clean.cmake
.PHONY : CMakeFiles/coveralls_generate.dir/clean

CMakeFiles/coveralls_generate.dir/depend:
	cd /home/pralay/g-code/CPP/cmake/coveralls-cmake-example-master/build && $(CMAKE_COMMAND) -E cmake_depends "Unix Makefiles" /home/pralay/g-code/CPP/cmake/coveralls-cmake-example-master /home/pralay/g-code/CPP/cmake/coveralls-cmake-example-master /home/pralay/g-code/CPP/cmake/coveralls-cmake-example-master/build /home/pralay/g-code/CPP/cmake/coveralls-cmake-example-master/build /home/pralay/g-code/CPP/cmake/coveralls-cmake-example-master/build/CMakeFiles/coveralls_generate.dir/DependInfo.cmake --color=$(COLOR)
.PHONY : CMakeFiles/coveralls_generate.dir/depend
