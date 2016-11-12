using System;

namespace MSPress.CSharpCoreRef.QuoteArray
{
	class QuoteArrayApp
	{
        static string [] quotes = new string []
        {
            // Henry V
            "We few, we happy few, we band of brothers.",
            // Hamlet
            "Alas, poor Yorick!",
            // Titus Andronicus
            "I know them all, though they suppose me mad",
            // Twelfth Night
            "Some are born great, some achieve greatness, " +
            "and others have greatness thrust upon them."
        };
        static void Main(string[] args)
		{
            for(int i = 0; i < quotes.Length; ++i)
            {
                Console.WriteLine(quotes[i]);
            }
		}
	}
}
