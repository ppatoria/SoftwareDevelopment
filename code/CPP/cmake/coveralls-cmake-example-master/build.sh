mkdir build && cd build
cmake -DCOVERALLS=ON -DCMAKE_BUILD_TYPE=Debug ..
make
make coveralls
