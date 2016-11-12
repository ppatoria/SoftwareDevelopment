#include <iostream>
#include <utility>
#include <string.h>
#include <stdio.h>

using namespace std;

class ArrayWrapper                                                                                                                      
{                                                                                                                                       
public:                                                                                                                                 
    // default constructor produces a moderately sized array                                                                            
    ArrayWrapper ()                                                                                                                     
	: _p_vals( new int[ 64 ] )                                                                                                      
	, _size( 64 )                                                                                                                   
	{}                                                                                                                                  
                                                                                                                                                         
    ArrayWrapper (int n)                                                                                                                
	: _p_vals( new int[ n ] )                                                                                                       
	, _size( n )                                                                                                                    
	{}                                                                                                                                  
                                                                                                                                                         
    // move constructor                                                                                                                 
    ArrayWrapper (ArrayWrapper&& other)                                                                                                 
	: _p_vals( other._p_vals  )                                                                                                     
	, _size( other._size )                                                                                                          
	{                                               
	    cout << "move constructor called: " << endl;
	    other._p_vals = NULL;                                                                                                           
	    other._size = 0;                                                                                                                
	}                                                                                                                                   
                                                                                                                                                         
    // copy constructor                                                                                                                 
    ArrayWrapper (const ArrayWrapper& other)                                                                                            
	: _p_vals( new int[ other._size  ] )                                                                                            
	, _size( other._size )                                                                                                          
	{                          
	    cout << "Copy Constructor called: " << endl;
	    for ( int i = 0; i < _size; ++i )                                                                                               
	    {                                                                                                                               
		_p_vals[ i ] = other._p_vals[ i ];                                                                                          
	    }                                                                                                                               
	}                                                                                                                                   
    ~ArrayWrapper ()                                                                                                                    
	{                                                                                                                                   
	    delete [] _p_vals;                                                                                                              
	}        

    void add (int val)
	{
	    _p_vals[0] = val;
	}

    void print ()
	{
	    cout << _p_vals << endl;
	    // for (int i=0; i<_size; i++)
	    // 	cout << _p_vals[i] << endl;
	}

    
                                                                                                                                                         
private:                                                                                                                                
    int *_p_vals;                                                                                                                       
    int _size;                                                                                                                          
};                     

class test{
public:
    char* charArray;
    int size;

    test (const char* string, int size){	
	cout << "constructor: " << endl;
	charArray = new char[size];
	//copy(string, string + size, charArray);
	strcpy(charArray, string);
	
	cout << ".... address of argument passed: " << &(*string) << endl;
	cout << ".... address of charArray: " << &(*charArray) << endl;
	
    }

    test (const test& other){
	cout << "Copy contructor" << endl;
	charArray = new char[other.size];
	copy(other.charArray, other.charArray + other.size, charArray);
	size = other.size;
    }

    test (test&& other){
	cout << "Move contructor :"  << endl;
	charArray = other.charArray;
	other.charArray = NULL;
	size = other.size;
	other.size = 0;
	cout << "..... address of other.charArray: " << &(*other.charArray) << endl;
	cout << "..... address of charArray: " << &(*charArray) << endl;
	
    }	

    void print(){
	cout << charArray << endl;
    }

    void printAddress() {
	cout << "..... address of charArray of t: " << charArray << endl;
    }
};

test testRValueReference (){
    test t("pralay", 6);
    cout << "testRValueReference: " << endl;
    t.printAddress();
    cout << "..... address of t: " << &t << endl;
    return move(t);
}

ArrayWrapper getArrayWrapper (){
    ArrayWrapper aw(1);
    //aw.add (99);
}
    



int main (){
    test t = testRValueReference ();
    t.print();
    t.printAddress();
    cout << &t << endl;

    // try{
    // 	ArrayWrapper aw = getArrayWrapper ();
    // 	//aw.print();
    // }catch(exception& ex){
    // 	cout << ex.what() << endl;
    // }
    return 1;
}

