struct CDad;
struct CChild;

typedef boost::shared_ptr<Dad>   dadPtr;
typedef boost::shared_ptr<Child> childPtr;


struct Dad : public Sample
{
    childPtr myBoy;
};

struct Child : public Sample
{
    dadPtr myDad;
};

// a "thing" that holds a smart pointer to another "thing":

dadPtr parent (new dad); 
childPtr child (new child);

// deliberately create a circular reference:
parent->myBoy = child; 
child->myDad = parent;


// resetting one ptr...
child.reset();

struct BetterChild : public Sample
{
  weak_ptr<Dad> myDad;

  void BringBeer()
  {
    shared_ptr<Dad> strongDad = myDad.lock(); // request a strong pointer
    if (strongDad)                      // is the object still alive?
      strongDad->SetBeer();
    // strongDad is released when it goes out of scope.
    // the object retains the weak pointer
  }
};
