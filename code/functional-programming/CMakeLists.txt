cmake_minimum_required( VERSION 2.8.12 )

project( fp )

set( fp-files
  main-gtest.cpp
  functional-container-wrapper.cpp
  )

add_executable( fp
  ${fp-files}
  )

target_link_libraries( fp
  ${GTEST_LIBRARIES}
  pthread 
  )

#########
# CTEST #
#########
include( CTest )
enable_testing()
add_test( "fp-test" fp)

