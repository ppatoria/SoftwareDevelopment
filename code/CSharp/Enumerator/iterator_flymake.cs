using System;
using System.Collections;

class MyWordCollection : IEnumerable//, IEnumerator
{
    string[] words = new string[100];
    int currentIndex = -1;

    public MyWordCollection()
        {}

    
    public void Add(string word)
        {
            words[++currentIndex] = word;
        }
    
    public int RemoveAt(int index)
        {
            throw new Exception("not implemented");
        }

    public string Remove(string value)
        {
            throw new Exception("not implemented");    
        }

    public string IndexAt(int index)
        {
            return words[index];
        }
    
    public IEnumerator GetEnumerator()
        {
            throw new Exception("Not Implemented");
        }

    public bool MoveNext()
        {        
            return currentIndex++ <= words.Length;
        }

    public string Current
        {
            get
            {
                words[currentIndex];
            }
        }
        
        
}

public class Program
{
    public static void Main()
        {
            MyWordCollection words = new MyWordCollection();
            words.Add("Test");
            Console.WriteLine(words.IndexAt(0));
        }
}

