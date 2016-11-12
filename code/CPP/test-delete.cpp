
#include <iostream>

#include <mutex>
#include <condition_variable>
#include <thread>
#include <stdio.h>

class AutoResetEvent
{
  public:
  explicit AutoResetEvent(bool initial = false);

  void Set();
  void Reset();

  bool WaitOne();

  private:
  AutoResetEvent(const AutoResetEvent&);
  AutoResetEvent& operator=(const AutoResetEvent&); // non-copyable
  bool flag_;
  std::mutex protect_;
  std::condition_variable signal_;
};

AutoResetEvent::AutoResetEvent(bool initial)
: flag_(initial)
{
}

void AutoResetEvent::Set()
{
  std::lock_guard<std::mutex> _(protect_);
  flag_ = true;
  signal_.notify_one();
}

void AutoResetEvent::Reset()
{
  std::lock_guard<std::mutex> _(protect_);
  flag_ = false;
}

bool AutoResetEvent::WaitOne()
{
  std::unique_lock<std::mutex> lk(protect_);
  while( !flag_ ) // prevent spurious wakeups from doing harm
    signal_.wait(lk);
  flag_ = false; // waiting resets the flag
  return true;
}


/* AutoResetEvent event; */

/* void otherthread() */
/* { */
/*   event.WaitOne(); */
/*   printf("Hello from other thread!\n"); */
/* } */


/* int main() */
/* { */
/*   std::thread h(otherthread); */
/*   printf("Hello from the first thread\n"); */
/*   event.Set(); */

/*   h.join(); */
/* } */
AutoResetEvent event_;
class cls{
public:
  void func(){};
};
void func( cls* ptr )
{
  event_.WaitOne();
  if( ptr )
    {
      std::cout << "calling...: " <<std::endl;
      ptr->func();
    }
}

int main()
{
  cls* ptr = new cls();
  delete ptr;
  ptr = nullptr;
  event_.Set();
  std::thread(func, ptr );
  return 0;
}

