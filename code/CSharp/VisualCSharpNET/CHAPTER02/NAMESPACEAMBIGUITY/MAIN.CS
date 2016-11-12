using System;
using ClubTypes;
using BankTypes;

namespace MSPress.CSharpCoreRef.NamespaceAmbiguity
{

	class NamespaceApp
	{
		static void Main(string[] args)
		{
            // The following line won't compile due
            // to an ambiguity with the Id type.
            //Id myId = new Id("Ambiguous")
            ClubTypes.Id clubId= new ClubTypes.Id("Club");
            BankTypes.Id bankId = new BankTypes.Id("Bank");
        }
	}
}
