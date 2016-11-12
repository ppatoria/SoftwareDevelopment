cmake_minimum_required( VERSION 2.8.12 )

project( cpp )

###################
# Set C++14 flag  #
###################
include(CheckCXXCompilerFlag)
set( CXX-14-FLAG "-std=c++14" )
CHECK_CXX_COMPILER_FLAG("${CXX-14-FLAG}" COMPILER_SUPPORTS_CXX14)
if(COMPILER_SUPPORTS_CXX14)
  set(CMAKE_CXX_FLAGS "${CMAKE_CXX_FLAGS} ${CXX-14-FLAG}")
  message( "cmake cxx flags: ${CMAKE_CXX_FLAGS}" )
else()
    message(FATAL_ERROR "Compiler ${CMAKE_CXX_COMPILER} has no C++14 support.")
endif()


#################
# find packages #
#################
find_package( GTest REQUIRED )
add_subdirectory( functional-programming )
add_subdirectory( problem-solving )
