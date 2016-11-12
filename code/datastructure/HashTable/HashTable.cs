/*
 * Hashing Table
 * *************
 *
 * Efficiency
 * ----------
 * - Insertion, Deletion and retrieval --> O(1)
 * - Not good for searching (finding min,max) etc  
 *
 * Collision: Two key hash to same value.
 * ----------
 * 
 * Prime Number: Array size in hash table is normally prime number to avoid collission.
 * -------------
 * Refer: http://computinglife.wordpress.com/2008/11/20/why-do-hash-functions-use-prime-numbers/
 */


using System;

class chapter10 {
    static void Main() {
        string[] names = new string[7]; string name;
        string[] someNames = new string[]{
            // "David", 
            // "Jennifer", 
            // "Donnie", 
            "Mayo", 
            "Raymond",
            "Bernica", 
            "Mike", 
            "Clayton", 
            "Beata", 
            "Michael"
        };
        int hashVal;
        for(int i = 0; i <= someNames.GetUpperBound(0); i++) {
            name = someNames[i];
            //hashVal = SimpleHash(name, names);
            hashVal = BetterHash(name, names);
            names[hashVal] = name;
            Console.WriteLine("{0}:{1}",hashVal,name);
        }
        ShowDistrib(names);
    }
 
    static int SimpleHash(string s, string[] arr) {        
        int tot = 0;
        char[] cname = s.ToCharArray();
        for(int i = 0; i <= cname.GetUpperBound(0); i++)
            tot += (int)cname[i];
        return tot % arr.GetUpperBound(0);
    }

    static int BetterHash(string s, string[] arr) {
        long tot = 0;
        char[] cname;
        cname = s.ToCharArray();
        for(int i = 0; i <= cname.GetUpperBound(0); i++)
            tot += 37 * tot + (int)cname[i];
        tot = tot % arr.GetUpperBound(0);
        if (tot < 0)
            tot += arr.GetUpperBound(0);
        return (int)tot;
    }
 
    static void ShowDistrib(string[] arr) {
        for(int i = 0; i <= arr.GetUpperBound(0); i++)
            if (arr[i] != null)
                Console.WriteLine(i + " " + arr[i]);
    }
}