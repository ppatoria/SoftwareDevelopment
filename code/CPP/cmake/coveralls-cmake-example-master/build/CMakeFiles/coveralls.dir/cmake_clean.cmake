FILE(REMOVE_RECURSE
  "CMakeFiles/coveralls"
)

# Per-language clean rules from dependency scanning.
FOREACH(lang)
  INCLUDE(CMakeFiles/coveralls.dir/cmake_clean_${lang}.cmake OPTIONAL)
ENDFOREACH(lang)
