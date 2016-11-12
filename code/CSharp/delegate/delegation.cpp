//The interface as seen by the application

interface IGenericResource
{
    byte[] GetSomeData();
}

interface ISpecificResourceOne : IGenericResource
{
    int SomePropertyOfResourceOne {get;}
}

interface ISpecificResourceTwo : IGenericResource
{
    string SomePropertyOfResourceTwo {get;}
}

public abstract class MyLayer
{
    ISpecificResourceOne    CreateResourceOne();
    ISpecificResourceTwo    CreateResourceTwo();

    void UseResourceOne(ISpecificResourceOne one);
    void UseResourceTwo(ISpecificResourceTwo two);
}

//The layer as created in my library

public class LowLevelResource : IGenericResource
{
    byte[] GetSomeData()
    {}
}

public class ResourceOne : LowLevelResource, ISpecificResourceOne
{
    int SomePropertyOfResourceOne {get{}}
}

public class ResourceTwo : ResourceOne, ISpecificResourceTwo
{
    string SomePropertyOfResourceTwo {get {}}
}

public partial class Implementation : MyLayer
{
    override UseResourceOne(ISpecificResourceOne one)
    {
        DoStuff((ResourceOne)one);
    }
}
