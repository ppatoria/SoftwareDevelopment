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
CMAKE_SOURCE_DIR = /home/pralay/g-code/CPP

# The top-level build directory on which CMake was run.
CMAKE_BINARY_DIR = /home/pralay/g-code/CPP/build

# Utility rule file for NightlyTest.

# Include the progress variables for this target.
include functional-programming/CMakeFiles/NightlyTest.dir/progress.make

functional-programming/CMakeFiles/NightlyTest:
	cd /home/pralay/g-code/CPP/build/functional-programming && /usr/bin/ctest -D NightlyTest

NightlyTest: functional-programming/CMakeFiles/NightlyTest
NightlyTest: functional-programming/CMakeFiles/NightlyTest.dir/build.make
.PHONY : NightlyTest

# Rule to build all files generated by this target.
functional-programming/CMakeFiles/NightlyTest.dir/build: NightlyTest
.PHONY : functional-programming/CMakeFiles/NightlyTest.dir/build

functional-programming/CMakeFiles/NightlyTest.dir/clean:
	cd /home/pralay/g-code/CPP/build/functional-programming && $(CMAKE_COMMAND) -P CMakeFiles/NightlyTest.dir/cmake_clean.cmake
.PHONY : functional-programming/CMakeFiles/NightlyTest.dir/clean

functional-programming/CMakeFiles/NightlyTest.dir/depend:
	cd /home/pralay/g-code/CPP/build && $(CMAKE_COMMAND) -E cmake_depends "Unix Makefiles" /home/pralay/g-code/CPP /home/pralay/g-code/CPP/functional-programming /home/pralay/g-code/CPP/build /home/pralay/g-code/CPP/build/functional-programming /home/pralay/g-code/CPP/build/functional-programming/CMakeFiles/NightlyTest.dir/DependInfo.cmake --color=$(COLOR)
.PHONY : functional-programming/CMakeFiles/NightlyTest.dir/depend

