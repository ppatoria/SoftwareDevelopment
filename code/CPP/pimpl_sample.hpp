// pimpl_sample.hpp
#if !defined (PIMPL_SAMPLE)
#define PIMPL_SAMPLE

struct impl;

class pimpl_sample 
{
    impl* pimpl_;

public:
    pimpl_sample();
    ~pimpl_sample();
    void do_something();
};

#endif
