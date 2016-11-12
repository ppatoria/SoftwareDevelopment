FILE(REMOVE_RECURSE
  "CMakeFiles/googletest"
  "CMakeFiles/googletest-complete"
  "third_party/src/googletest-stamp/googletest-install"
  "third_party/src/googletest-stamp/googletest-mkdir"
  "third_party/src/googletest-stamp/googletest-download"
  "third_party/src/googletest-stamp/googletest-update"
  "third_party/src/googletest-stamp/googletest-patch"
  "third_party/src/googletest-stamp/googletest-configure"
  "third_party/src/googletest-stamp/googletest-build"
)

# Per-language clean rules from dependency scanning.
FOREACH(lang)
  INCLUDE(CMakeFiles/googletest.dir/cmake_clean_${lang}.cmake OPTIONAL)
ENDFOREACH(lang)
