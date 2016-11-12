// Adapter Pattern used in HermesAdaptor (not exactly as there is no IAgora interface and its distributed but something similar

// (1) Client use IAgora interface which internally uses GMR to insert transactions.
// (2) GMR Send method returns int aotag as a unique identifier of that transaction.
// (3) Client want to move to Hermes without breaking existing code.
// (4) In Hermes Send method returns 16 digit string/alphanumeric id. This may break the IAgora interface.
// (5) We will create a Adapter say HermesAdaptor to solve this problem.
//      (a)  Adapter class will Implement the IAgora and contains Hermes instance.
//      (b) Adapter will generate aotag for corresponding orderid and maintain map.
//      (c) Adapter Send Method (implementer from IAgora) will return int (aotag) from the map.



interface IAgora
{
    int /*aotag*/ Send( string query);
}

class HermesAdaptor : IAgora
{
    IAgoraConnection/*Hermes*/ _hermes;
    public HermesAdaptor()
	{
	    _hermes = new AgoraConnection(ConnectionType.Gen3);      
	}

    public int /*aotag*/ Send(string query) 
	{
	    string orderid = _hermes.Send (query);
	    int    aotag   = GenerateAotag (orderid);
	    RegisterAotagOrderIDMapping (aotag, orderid);
	    return aotag;
	}
}


class Program
{
    public static void Main()
	{
	    string query = "insert into ...........";
      
	    // Existing code with gmr
	    IAgora agoraGMR = new GMRClient();
	    int    aotag    = agora.Send(query);
      
	    // Using HermesAdaptor with same IAgora interface 
	    IAgora agoraHermes = new HermesAdaptor();
	    aotag = agoraHermes.Send(query);      
	}
}
