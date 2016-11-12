using System;
using System.IO;
using System.Xml;

public class Videos
{
   public static void Main()
   {
     //Create the XmlDocument.
     XmlDocument myDoc = new XmlDocument();
     myDoc.LoadXml("<?xml version='1.0' ?>" +
                   "<Video><Title>Gone with the Wind</Title>" +
                   "<rating>PG</rating></Video>");

     Console.WriteLine(myDoc.DocumentElement.InnerXml);
   }
}
