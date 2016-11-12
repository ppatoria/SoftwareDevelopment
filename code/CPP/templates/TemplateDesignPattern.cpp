#include <iostream>
#include <vector>
#include <memory>



using namespace std;

template <class PayloadType>
class Message{
    PayloadType payload;
public:
    PayloadType GetPayload (){
	return payload;
    }
    void SetPayload (PayloadType payload){
	this->payload = payload;
    }
};



template <class DerivedType>
class Endpoint
{
public:
    virtual void Open () = 0;
    
    template <class MessageType>
    void SendMessage (Message<MessageType>* message){	    
	cout << "Base: " << message->GetPayload() << endl;
	static_cast<DerivedType*>(this)->SendMessage (message);	
    }
    
    virtual void Close () = 0;
};

class MercuryEndpoint : public Endpoint<MercuryEndpoint>
{
public:
    void Open (){
	cout << "Derived Open" << endl; 
    }

    template <class MessageType>
    void SendMessage (Message<MessageType>* message){
	cout << "Derived: "  << message->GetPayload() << endl;
    }

    void Close (){
	cout << "Derived Close" << endl;
    }
};

typedef Endpoint<MercuryEndpoint>  MCEndpoint;
typedef vector<MCEndpoint*> MCEndpointList;

class Service
{
public:
    Service (){};
     Service (MCEndpointList endpoints)
     	{
     	    this->endpoints = endpoints;
     	}

    template <class EndpointType>
    void SetEndpoints (Endpoint<EndpointType>* endpoint)
	{
	    endpoint = new EndpointType();
	    //endpoints.push_back (endpoint);
	}
    template <class MessageType>
    void SendMessage( Message<MessageType>* message)
	{
	    	    
	     for_each (endpoints.begin(), endpoints.end(),
		       [](endpoint){
	     		  endpoint.SendMessage<MessageType>(message);
	     	      });
	     //endpoint->SendMessage (message);
	}
// private:
    MCEndpointList endpoints;
    MCEndpoint* endpoint;
};



int main (){
    Message<int>* message = new Message<int>();
    message->SetPayload (1);
    MCEndpointList v;
    v.push_back (message);
    Service service (v);
    //service.SetEndpoints(new MercuryEndpoint());
    service.SendMessage (message);
    // Endpoint<MercuryEndpoint>* endpoint = new MercuryEndpoint();
    // string message = "message text";
    // endpoint->SendMessage<string> (message);
    return 1;
}
