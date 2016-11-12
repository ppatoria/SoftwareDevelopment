FILE(REMOVE_RECURSE
  "CMakeFiles/coveralls_upload"
)

# Per-language clean rules from dependency scanning.
FOREACH(lang)
  INCLUDE(CMakeFiles/coveralls_upload.dir/cmake_clean_${lang}.cmake OPTIONAL)
ENDFOREACH(lang)
