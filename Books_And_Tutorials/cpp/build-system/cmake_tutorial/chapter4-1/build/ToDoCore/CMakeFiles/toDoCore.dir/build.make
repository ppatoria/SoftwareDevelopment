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
CMAKE_SOURCE_DIR = /media/sf_Google_Drive/SoftwareDevelopment/Books_And_Tutorials/cpp/build-system/cmake_tutorial/chapter4-1

# The top-level build directory on which CMake was run.
CMAKE_BINARY_DIR = /media/sf_Google_Drive/SoftwareDevelopment/Books_And_Tutorials/cpp/build-system/cmake_tutorial/chapter4-1/build

# Include any dependencies generated for this target.
include ToDoCore/CMakeFiles/toDoCore.dir/depend.make

# Include the progress variables for this target.
include ToDoCore/CMakeFiles/toDoCore.dir/progress.make

# Include the compile flags for this target's objects.
include ToDoCore/CMakeFiles/toDoCore.dir/flags.make

ToDoCore/CMakeFiles/toDoCore.dir/ToDo.cc.o: ToDoCore/CMakeFiles/toDoCore.dir/flags.make
ToDoCore/CMakeFiles/toDoCore.dir/ToDo.cc.o: ../ToDoCore/ToDo.cc
	$(CMAKE_COMMAND) -E cmake_progress_report /media/sf_Google_Drive/SoftwareDevelopment/Books_And_Tutorials/cpp/build-system/cmake_tutorial/chapter4-1/build/CMakeFiles $(CMAKE_PROGRESS_1)
	@$(CMAKE_COMMAND) -E cmake_echo_color --switch=$(COLOR) --green "Building CXX object ToDoCore/CMakeFiles/toDoCore.dir/ToDo.cc.o"
	cd /media/sf_Google_Drive/SoftwareDevelopment/Books_And_Tutorials/cpp/build-system/cmake_tutorial/chapter4-1/build/ToDoCore && /usr/bin/c++   $(CXX_DEFINES) $(CXX_FLAGS) -o CMakeFiles/toDoCore.dir/ToDo.cc.o -c /media/sf_Google_Drive/SoftwareDevelopment/Books_And_Tutorials/cpp/build-system/cmake_tutorial/chapter4-1/ToDoCore/ToDo.cc

ToDoCore/CMakeFiles/toDoCore.dir/ToDo.cc.i: cmake_force
	@$(CMAKE_COMMAND) -E cmake_echo_color --switch=$(COLOR) --green "Preprocessing CXX source to CMakeFiles/toDoCore.dir/ToDo.cc.i"
	cd /media/sf_Google_Drive/SoftwareDevelopment/Books_And_Tutorials/cpp/build-system/cmake_tutorial/chapter4-1/build/ToDoCore && /usr/bin/c++  $(CXX_DEFINES) $(CXX_FLAGS) -E /media/sf_Google_Drive/SoftwareDevelopment/Books_And_Tutorials/cpp/build-system/cmake_tutorial/chapter4-1/ToDoCore/ToDo.cc > CMakeFiles/toDoCore.dir/ToDo.cc.i

ToDoCore/CMakeFiles/toDoCore.dir/ToDo.cc.s: cmake_force
	@$(CMAKE_COMMAND) -E cmake_echo_color --switch=$(COLOR) --green "Compiling CXX source to assembly CMakeFiles/toDoCore.dir/ToDo.cc.s"
	cd /media/sf_Google_Drive/SoftwareDevelopment/Books_And_Tutorials/cpp/build-system/cmake_tutorial/chapter4-1/build/ToDoCore && /usr/bin/c++  $(CXX_DEFINES) $(CXX_FLAGS) -S /media/sf_Google_Drive/SoftwareDevelopment/Books_And_Tutorials/cpp/build-system/cmake_tutorial/chapter4-1/ToDoCore/ToDo.cc -o CMakeFiles/toDoCore.dir/ToDo.cc.s

ToDoCore/CMakeFiles/toDoCore.dir/ToDo.cc.o.requires:
.PHONY : ToDoCore/CMakeFiles/toDoCore.dir/ToDo.cc.o.requires

ToDoCore/CMakeFiles/toDoCore.dir/ToDo.cc.o.provides: ToDoCore/CMakeFiles/toDoCore.dir/ToDo.cc.o.requires
	$(MAKE) -f ToDoCore/CMakeFiles/toDoCore.dir/build.make ToDoCore/CMakeFiles/toDoCore.dir/ToDo.cc.o.provides.build
.PHONY : ToDoCore/CMakeFiles/toDoCore.dir/ToDo.cc.o.provides

ToDoCore/CMakeFiles/toDoCore.dir/ToDo.cc.o.provides.build: ToDoCore/CMakeFiles/toDoCore.dir/ToDo.cc.o

# Object files for target toDoCore
toDoCore_OBJECTS = \
"CMakeFiles/toDoCore.dir/ToDo.cc.o"

# External object files for target toDoCore
toDoCore_EXTERNAL_OBJECTS =

ToDoCore/libtoDoCore.a: ToDoCore/CMakeFiles/toDoCore.dir/ToDo.cc.o
ToDoCore/libtoDoCore.a: ToDoCore/CMakeFiles/toDoCore.dir/build.make
ToDoCore/libtoDoCore.a: ToDoCore/CMakeFiles/toDoCore.dir/link.txt
	@$(CMAKE_COMMAND) -E cmake_echo_color --switch=$(COLOR) --red --bold "Linking CXX static library libtoDoCore.a"
	cd /media/sf_Google_Drive/SoftwareDevelopment/Books_And_Tutorials/cpp/build-system/cmake_tutorial/chapter4-1/build/ToDoCore && $(CMAKE_COMMAND) -P CMakeFiles/toDoCore.dir/cmake_clean_target.cmake
	cd /media/sf_Google_Drive/SoftwareDevelopment/Books_And_Tutorials/cpp/build-system/cmake_tutorial/chapter4-1/build/ToDoCore && $(CMAKE_COMMAND) -E cmake_link_script CMakeFiles/toDoCore.dir/link.txt --verbose=$(VERBOSE)

# Rule to build all files generated by this target.
ToDoCore/CMakeFiles/toDoCore.dir/build: ToDoCore/libtoDoCore.a
.PHONY : ToDoCore/CMakeFiles/toDoCore.dir/build

ToDoCore/CMakeFiles/toDoCore.dir/requires: ToDoCore/CMakeFiles/toDoCore.dir/ToDo.cc.o.requires
.PHONY : ToDoCore/CMakeFiles/toDoCore.dir/requires

ToDoCore/CMakeFiles/toDoCore.dir/clean:
	cd /media/sf_Google_Drive/SoftwareDevelopment/Books_And_Tutorials/cpp/build-system/cmake_tutorial/chapter4-1/build/ToDoCore && $(CMAKE_COMMAND) -P CMakeFiles/toDoCore.dir/cmake_clean.cmake
.PHONY : ToDoCore/CMakeFiles/toDoCore.dir/clean

ToDoCore/CMakeFiles/toDoCore.dir/depend:
	cd /media/sf_Google_Drive/SoftwareDevelopment/Books_And_Tutorials/cpp/build-system/cmake_tutorial/chapter4-1/build && $(CMAKE_COMMAND) -E cmake_depends "Unix Makefiles" /media/sf_Google_Drive/SoftwareDevelopment/Books_And_Tutorials/cpp/build-system/cmake_tutorial/chapter4-1 /media/sf_Google_Drive/SoftwareDevelopment/Books_And_Tutorials/cpp/build-system/cmake_tutorial/chapter4-1/ToDoCore /media/sf_Google_Drive/SoftwareDevelopment/Books_And_Tutorials/cpp/build-system/cmake_tutorial/chapter4-1/build /media/sf_Google_Drive/SoftwareDevelopment/Books_And_Tutorials/cpp/build-system/cmake_tutorial/chapter4-1/build/ToDoCore /media/sf_Google_Drive/SoftwareDevelopment/Books_And_Tutorials/cpp/build-system/cmake_tutorial/chapter4-1/build/ToDoCore/CMakeFiles/toDoCore.dir/DependInfo.cmake --color=$(COLOR)
.PHONY : ToDoCore/CMakeFiles/toDoCore.dir/depend
