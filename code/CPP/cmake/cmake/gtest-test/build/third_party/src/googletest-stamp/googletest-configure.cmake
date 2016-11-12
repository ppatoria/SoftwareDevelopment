

set(command "/usr/bin/cmake;-GUnix Makefiles;/home/pralay/g-code/cmake/gtest-test/build/third_party/src/googletest")
execute_process(
  COMMAND ${command}
  RESULT_VARIABLE result
  OUTPUT_FILE "/home/pralay/g-code/cmake/gtest-test/build/third_party/src/googletest-stamp/googletest-configure-out.log"
  ERROR_FILE "/home/pralay/g-code/cmake/gtest-test/build/third_party/src/googletest-stamp/googletest-configure-err.log"
  )
if(result)
  set(msg "Command failed: ${result}\n")
  foreach(arg IN LISTS command)
    set(msg "${msg} '${arg}'")
  endforeach()
  set(msg "${msg}\nSee also\n  /home/pralay/g-code/cmake/gtest-test/build/third_party/src/googletest-stamp/googletest-configure-*.log\n")
  message(FATAL_ERROR "${msg}")
else()
  set(msg "googletest configure command succeeded.  See also /home/pralay/g-code/cmake/gtest-test/build/third_party/src/googletest-stamp/googletest-configure-*.log\n")
  message(STATUS "${msg}")
endif()
