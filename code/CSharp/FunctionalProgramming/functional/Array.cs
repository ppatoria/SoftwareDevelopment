public class SamplesArray2{

    public static void Main()  {

        // Creates and initializes a new three-dimensional Array of type Int32.
        Array myArr = Array.CreateInstance( typeof(Int32), 2, 3, 4 );
        for ( int i = myArr.GetLowerBound(0); i <= myArr.GetUpperBound(0); i++ )
            for ( int j = myArr.GetLowerBound(1); j <= myArr.GetUpperBound(1); j++ )
                for (int k = myArr.GetLowerBound(2); k <= myArr.GetUpperBound(2); k++ )  {
                    myArr.SetValue( (i*100)+(j*10)+k, i, j, k );
                }

        // Displays the properties of the Array.
        Console.WriteLine( "The Array has {0} dimension(s) and a total of {1} elements.",
                           myArr.Rank, myArr.Length );
        Console.WriteLine( "\tLength\tLower\tUpper" );
        for ( int i = 0; i < myArr.Rank; i++ )  {
            Console.Write( "{0}:\t{1}", i, myArr.GetLength(i) );
            Console.WriteLine( "\t{0}\t{1}", myArr.GetLowerBound(i), 
                               myArr.GetUpperBound(i) );
        }

        // Displays the contents of the Array.
        Console.WriteLine( "The Array contains the following values:" );
        PrintValues( myArr );
    }


    public static void PrintValues( Array myArr )  {
        System.Collections.IEnumerator myEnumerator = myArr.GetEnumerator();
        int i = 0;
        int cols = myArr.GetLength( myArr.Rank - 1 );
        while ( myEnumerator.MoveNext() )  {
            if ( i < cols )  {
                i++;
            } else  {
                Console.WriteLine();
                i = 1;
            }
            Console.Write( "\t{0}", myEnumerator.Current );
        }
        Console.WriteLine();
    }
}