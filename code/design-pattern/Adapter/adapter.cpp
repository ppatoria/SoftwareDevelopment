#include <string>
#include <iostream>

/**
 * Purpose : to prevent breaking of client when a function is changed/enhanced.
 * Steps: (1) Extract interface from the existing class exposed to client.
 *        (2) (a) Create a Adaptor class which implements the interface (1) .
 *            (b) Either privately inherit the class which contains the new function or compose it.
 *                NOTE: private inharitance to prevent any on public functionality to be exposed to client.
 *            (c) wrap the new function in the overriden/implemented interface.
 * client ----> Existing Class 
 **/


using namespace std;

/* ***************************************
 * old class exposed to client : adaptee
 * **************************************/
class logger
{
public:
    static const string debug;
    static const string info;
    static const string error;
    
    logger ()
    { 
        cout << "logger constructor" << endl; 
    }
    
    void log (const string& level, 
              const string& str) 
    {
        cout << level << ": " << str << endl;
    }
};

const string logger::debug = "DEBUG";
const string logger::info  = "INFO";
const string logger::error = "ERROR";

/* *************************************************
 * new changed interface exposed to child : target
 * ************************************************/
class new_logger_interface
{
public:
    virtual void log (const string& str) = 0;
};

/* **********************************************************************************
 * new wrapper class that wrap the existing some additional functionality : adaptor
 * *********************************************************************************/
class info_logger : public new_logger_interface, private logger
{
public:
    info_logger () 
    {
        cout << "info_logger constructor" << endl;
    }

    virtual void log (const string& message) 
    {
        logger::log (logger::info, message);
    }
};

/* *********************************************************************************
 * new wrapper class that wrap the existing some additional functionality : adaptor
 * *********************************************************************************/
class info_logger2 : public new_logger_interface
{
    logger existing_logger;
public:
    info_logger2 ()
    {
        cout << "info_logger2 constructor" << endl;
    }

    virtual void log (const string& message)
    {
        existing_logger.log (logger::info, message);
    }

};

int main() 
{
    info_logger logger;
    logger.log ("Testing the logger.");

    info_logger2 logger2;
    logger2.log ("Testing the logger2.");    

    return 0;
} 


