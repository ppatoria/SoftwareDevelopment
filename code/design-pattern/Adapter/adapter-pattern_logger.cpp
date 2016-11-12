/*
 * THE ADAPTER PATTERN

 * The motivation for changing the abstraction given by a class is not always driven by a desire to hide functionality or protect against performance concerns. 
 * Sometimes, the underlying abstraction cannot be changed but it doesn’t suit the current design. 
 * In this case, you can build an adapter or wrapper class. 
 * The adapter provides the abstraction that the rest of the code uses and serves as the bridge between the desired abstraction and the actual underlying code. 
 * Chapter 12 discusses how the STL uses the adapter pattern to implement containers like stack and queue in terms of other containers, such as deque and list.

 * Example: Adapting a Logger Class

 * For this adapter pattern example, let’s assume a very basic Logger class. 
 * Methods are shown with their implementations directly in the header file. This is not Best Practice, but is done to save space.
*/
#include <string>
#include <iostream>
class Logger
{
    public:

        static const string kLogLevelDebug;
        static const string kLogLevelInfo;
        static const string kLogLevelError;
    
    Logger () 
	{ 
	    cout << "Logger constructor" << endl; 
	}
        
    void log (const string& level, const string& str) 
	{
            cout << level << ": " << str << endl;
        }
};
const string Logger::kLogLevelDebug = "DEBUG";
const string Logger::kLogLevelInfo  = "INFO";
const string Logger::kLogLevelError = "ERROR";

/*
 * Code snippet from LoggerAdapter\LoggerAdapter.h

 * The Logger class has a constructor, which outputs a line of text to the standard console, and a method called log() that writes the given line of text to the console prefixed with a log level.

 * One reason why you might want to write a wrapper class around this basic Logger class is to change the interface of it. 
 * Maybe you are not interested in the log level and you would like to call the log() method with only one parameter, the message itself.

 * Implementation of an Adapter

 * The first step in implementing the adapter pattern is to define the new interface for the underlying functionality. 
 * This new interface is called NewLoggerInterface and looks as follows:
 */

class NewLoggerInterface
{
    public:
        virtual void log (const string& str) = 0;
};

/*
 * Code snippet from LoggerAdapter\LoggerAdapter.h

 * This class is an abstract class, which declares the desired interface that you want for your new logger. 
 * It only defines one abstract method which needs to be implemented by any class inheriting from this interface. 
 * You can think of NewLoggerInterface as a mix-in class. Mix-in classes are discussed in Chapter 28.

 * The next step is to write the actual new logger class, NewLoggerAdapter, which inherits from the NewLoggerInterface so that it has the interface that you designed. 
 * It also privately inherits from the original Logger class. 
 * It is inherited privately so that no functionality from the original Logger class will be publicly available in the NewLoggerAdapter class. 
 * The constructor of the new class writes a line to standard output to keep track of which constructors are being called. 
 * The code then implements the abstract log() method from the NewLoggerInterface interface by forwarding the call to the original log() method and specifying kLogLevelInfo as log level:
 */

class NewLoggerAdapter : public NewLoggerInterface, private Logger
{
    public:
        NewLoggerAdapter() {
            cout << "NewLoggerAdapter constructor" << endl;
        }
        virtual void log (const string& str) {
            Logger::log (Logger::kLogLevelInfo, str);
        }
};

/*
 * Code snippet from LoggerAdapter\LoggerAdapter.h

 * Using an Adapter

 * Since adapters exist to provide a more appropriate interface for the underlying functionality, their use should be straightforward and specific to the particular case. 
 * Given the previous example, the following program uses the new simplified interface for the Logger class:
 */

#include "LoggerAdapter.h"
int main() 
{
    NewLoggerAdapter logger;
    logger.log ("Testing the logger.");
    return 0;
} 

/*
 * Code snippet from LoggerAdapter\TestLoggerAdapter.cpp

 * When you compile and run this example, it will produce the following output:

 * Logger constructor
 * NewLoggerAdapter constructor
 * INFO: Testing the logger.
 */
