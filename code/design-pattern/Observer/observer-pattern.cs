//#define using_interface
using System;
using System.Collections;

#if using_interface

public interface IObserver                                           //interface the all observer classes should implement
{   
    void Notify(object anObject);   
}

public interface IObservable                                         //interface that all observable classes should implement
{
    void Register   (IObserver anObserver);
    void UnRegister (IObserver anObserver);
}

public class ObservableImpl:IObservable                              //helper class that implements observable interface
{   
    protected Hashtable _observerContainer=new Hashtable();          //container to store the observer instance (is not synchronized for this example)
       
    public void Register(IObserver anObserver){                      //add the observer
        _observerContainer.Add(anObserver,anObserver); 
    }     
    
    public void UnRegister(IObserver anObserver){                    //remove the observer
        _observerContainer.Remove(anObserver); 
    }
    
    public void NotifyObservers(object anObject) {                   //common method to notify all the observers                 
        foreach(IObserver anObserver in _observerContainer.Keys) {   //enumeration the observers and invoke their notify method
            anObserver.Notify(anObject); 
        }      
    }
}

public class Stock : ObservableImpl                                  //represents a stock in an application      
{       
    object _askPrice;                                                //instance variable for ask price    

    public object AskPrice {                                         //property for ask price 
        set{    
            _askPrice = value;
            base.NotifyObservers(_askPrice);
        }      
    }
 
}

public class StockDisplay:IObserver                                  //represents the user interface in the application
{       
    public void Notify(object anObject){ 
        Console.WriteLine("The new ask price is:" + anObject); 
    }
}

public class MainClass
{
    public static void Main(){       
 
        StockDisplay stockDisplay=new StockDisplay();                //create new display and stock instances
        Stock stock=new Stock();
        
        stock.Register(stockDisplay);                                //register the grid
        
        for(int looper=0;looper < 100;looper++) {                    //loop 100 times and modify the ask price
            stock.AskPrice=looper;
        }
        
        stock.UnRegister(stockDisplay);                              //unregister the display      
    }   
}

#else

public class Stock 
{   
   public delegate void AskPriceDelegate(object aPrice);             //declare a delegate for the event
   public event AskPriceDelegate AskPriceChanged;                    //declare the event using the delegate
   
   object _askPrice;                                                 //instance variable for ask price
   
    public object AskPrice {                                         //property for ask price
        set 
        {                                                            //set the instance variable
            _askPrice=value;          
            AskPriceChanged(_askPrice);                              //fire the event
        }     
    } 
}

public class StockDisplay                                            //represents the user interface in the application
{
   public void AskPriceChanged(object aPrice) {
      Console.Write("The new ask price is:" + aPrice + "\r\n"); 
   }
}

public class MainClass 
{
   public static void Main(){
      
      StockDisplay stockDisplay=new StockDisplay();                  //create new display and stock instances
      Stock stock=new Stock();
      
      stock.AskPriceChanged += new                                   //create a new delegate instance and bind it to the observer's askpricechanged method
          Stock.AskPriceDelegate(stockDisplay.AskPriceChanged);      //add the delegate to the event
      
      for(int looper=0;looper < 100;looper++) {                      //loop 100 times and modify the ask price
         stock.AskPrice=looper;
      }
      
      stock.AskPriceChanged -= new                                   //create a new delegate instance and bind it to the observer's askpricechanged method
          Stock.AskPriceDelegate(stockDisplay.AskPriceChanged);      //remove the delegate from the event
   }
}
#endif