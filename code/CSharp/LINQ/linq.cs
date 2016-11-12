using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

class Customer{
    public string    Name;
    public int       UniqueID;
    public float     Weighting;
    public List<int> Preferences;
}
class Test{ 
    public static void Main(){    
        Customer c1 = new Customer{Name="Don"    ,UniqueID=6 ,Weighting=6 ,Preferences=new List<int>{1,2,4,8}};        
        Customer c2 = new Customer{Name="Peter"  ,UniqueID=7 ,Weighting=4 ,Preferences=new List<int>{10,20,30,40}};
        Customer c3 = new Customer{Name="Freddy" ,UniqueID=8 ,Weighting=9 ,Preferences=new List<int>{11,12,14}};
        Customer c4 = new Customer{Name="Freddi" ,UniqueID=9 ,Weighting=1 ,Preferences=new List<int>{21,22,29,42}};

        var customers = new List<Customer>{ c1,c2,c3,c4 };

        var result =
            from cust in customers
            where cust.Name.Length == 6
            select new {cust.Name, cust.UniqueID};
        
        foreach( var c in result) Console.WriteLine("{0}", c);            
        
        var result1 =
            customers
            .Where  ( cust => cust.Name.Length == 6)
            .Select ( cust => new {cust.Name, cust.UniqueID});
            
        foreach( var c in result1) Console.WriteLine("{0}", c);
            
    }

    
}