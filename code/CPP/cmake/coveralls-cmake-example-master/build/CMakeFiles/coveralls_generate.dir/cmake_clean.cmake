FILE(REMOVE_RECURSE
  "CMakeFiles/coveralls_generate"
)

# Per-language clean rules from dependency scanning.
FOREACH(lang)
  INCLUDE(CMakeFiles/coveralls_generate.dir/cmake_clean_${lang}.cmake OPTIONAL)
ENDFOREACH(lang)
