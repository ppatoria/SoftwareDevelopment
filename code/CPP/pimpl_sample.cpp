// pimpl_sample.cpp
#include "pimpl_sample.hpp"
#include <string>
#include <iostream>

struct pimpl_sample::impl 
{
    void do_something_() 
    {
        std::cout << s_ << "\n";
    }
    std::string s_;
};

pimpl_sample::pimpl_sample()
  : pimpl_(new impl) 
{
    pimpl_->s_ = "This is the pimpl idiom";
}

pimpl_sample::~pimpl_sample() 
{
    delete pimpl_;
}

void pimpl_sample::do_something() 
{
    pimpl_->do_something_();
}
