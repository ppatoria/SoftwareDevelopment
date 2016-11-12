ExternalProject_Add(
  URL http://pocoproject.org/releases/poco-1.6.1/poco-1.6.1.zip
  PREFIX ${CMAKE_SOURCE_DIR}
  DOWNLOAD_DIR ${CMAKE_SOURCE_DIR}/download
  SOURCE_DIR ${CMAKE_SOURCE_DIR}/source
  BINARY_DIR ${CMAKE_SOURCE_DIR}/binary
  INSTALL_DIR ${CMAKE_SOURCE_DIE}/install
  )