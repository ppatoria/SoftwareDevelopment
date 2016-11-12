using System;
using System.Collections;

namespace MSPress.CSharpCoreRef.ElementHashtable
{
    class HashtableApp
    {
        struct Element
        {
            public Element(string itsName, string itsSymbol)
            {
                Name = itsName;
                Symbol = itsSymbol;
            }
            public string Name;
            public string Symbol;
        }

        static void Main(string[] args)
        {
            Hashtable elements = new Hashtable(118, 1.0f);
            Element sodium = new Element("Sodium", "Na");
            Element lead = new Element("Lead", "Pb");
            Element gold = new Element("Gold", "Au");
            elements.Add(sodium.Symbol, sodium);
            elements.Add(lead.Symbol, lead);
            elements.Add(gold.Symbol, gold);

            Element anElement = (Element)elements["Na"];
            Console.WriteLine(anElement.Name);
            foreach(DictionaryEntry entry in elements)
            {
                string symbol = (string)entry.Key;
                Element elem = (Element)entry.Value;
                Console.WriteLine("{0} - {1}", symbol, elem.Name);
            }

            foreach(object key in elements.Keys)
            {
                Element e = (Element)elements[key];
                Console.WriteLine(e.Name);
            }
            Console.WriteLine("Done");
        }
    }
}
