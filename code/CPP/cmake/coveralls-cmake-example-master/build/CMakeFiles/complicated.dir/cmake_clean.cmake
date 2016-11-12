FILE(REMOVE_RECURSE
  "CMakeFiles/complicated.dir/complicated.c.o"
  "libcomplicated.pdb"
  "libcomplicated.a"
)

# Per-language clean rules from dependency scanning.
FOREACH(lang C)
  INCLUDE(CMakeFiles/complicated.dir/cmake_clean_${lang}.cmake OPTIONAL)
ENDFOREACH(lang)
