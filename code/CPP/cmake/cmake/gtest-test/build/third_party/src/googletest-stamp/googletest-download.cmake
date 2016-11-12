

set(command "/usr/bin/cmake;-Dmake=${make};-Dconfig=${config};-P;/home/pralay/g-code/cmake/gtest-test/build/third_party/src/googletest-stamp/googletest-download-impl.cmake")
execute_process(
  COMMAND ${command}
  RESULT_VARIABLE result
  OUTPUT_FILE "/home/pralay/g-code/cmake/gtest-test/build/third_party/src/googletest-stamp/googletest-download-out.log"
  ERROR_FILE "/home/pralay/g-code/cmake/gtest-test/build/third_party/src/googletest-stamp/googletest-download-err.log"
  )
if(result)
  set(msg "Command failed: ${result}\n")
  foreach(arg IN LISTS command)
    set(msg "${msg} '${arg}'")
  endforeach()
  set(msg "${msg}\nSee also\n  /home/pralay/g-code/cmake/gtest-test/build/third_party/src/googletest-stamp/googletest-download-*.log\n")
  message(FATAL_ERROR "${msg}")
else()
  set(msg "googletest download command succeeded.  See also /home/pralay/g-code/cmake/gtest-test/build/third_party/src/googletest-stamp/googletest-download-*.log\n")
  message(STATUS "${msg}")
endif()
