cmake_minimum_required( VERSION 2.8.12 )

project(problem-solving)

set( src-files
  main-gtest.cpp
  problem-solving.cpp
  )

add_executable( problem-solving
  ${src-files}
  )

target_link_libraries( problem-solving
  ${GTEST_LIBRARIES}
  pthread
  )

#########
# CTEST #
#########
include( CTest )
enable_testing()
add_test( "ps-test" problem-solving)

