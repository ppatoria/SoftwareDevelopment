using System;

struct Info
{
    int x;
}

struct Managed
{
    int i ;
    Info obj;

    // public Managed( int i)
    //     {
    //         this.i = i;
    //     }

    public Managed( int i, Info obj)
        {
            this.i = i;
            this.obj = obj;
        }

    // public override string ToString()
    //     {            
    //         return 
    //             string.Format("int: {0}{1}object: {2}",
    //                           i, Environment.NewLine, obj);
    //     }

    // public unsafe static string Manipulate ()
    //     {
    //         string result = string.Empty;;
    //         Managed managed = new Managed();
    //         Managed* managed_ptr = &managed; 
    //         //result = managed_ptr->ToString();
    //         return result;
    //     }

    // unsafe static void Main ()
    //     {
    //         string result = string.Empty;;
    //         Managed managed = new Managed(10, "test");
    //         Managed* managed_ptr = &managed; 
    //         //result = managed_ptr->ToString();
    //         return result;
    //     }

    unsafe static void Main ()
        {            
            Managed managed = new Managed(10, new Info());
            Managed* managed_ptr = &managed;
            Console.WriteLine (managed_ptr->i);
            

        }
}

// class Program
// {
//     public static void Main ()
//         {
//             Managed managedObject = new Managed ();
//             Console.WriteLine (managedObject.ToString () );
//             //Console.WriteLine (managedObject.Manipulate () );
//             Console.WriteLine (Managed.Manipulate () );

//             Unmanaged unManagedObject = new Unmanaged ();
//             Console.WriteLine (unManagedObject.Manipulate () );
//         }
// }

// class Unmanaged
// {
//     public unsafe string Manipulate ()
//         {
//             Managed  managed     = new Managed();
//             Managed* managed_ptr = &managed; 
//             managed_ptr->ToString();
//         }
// }