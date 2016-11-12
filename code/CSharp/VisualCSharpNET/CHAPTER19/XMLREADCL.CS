using System;
using System.Xml;
using System.Text;
using System.Collections;

public class ReadXML
{

  public static void Main()  
  {
     XmlTextReader xtr = new XmlTextReader(@"c:\Videos.xml");

     xtr.WhitespaceHandling = WhitespaceHandling.All;

     //Parse the file and display each of the nodes.
     while (xtr.Read())
     {
        switch (xtr.NodeType)
        {
          case XmlNodeType.Element:
            Console.Write("<{0}>", xtr.Name);
            break;
          case XmlNodeType.Text:
            Console.Write(xtr.Value);
            break;
          case XmlNodeType.CDATA:
            Console.Write("<![CDATA[{0}]]>", xtr.Value);
            break;
          case XmlNodeType.ProcessingInstruction:
            Console.Write("<?{0} {1}?>", xtr.Name, xtr.Value);
            break;
          case XmlNodeType.Comment:
            Console.Write("<!--{0}-->", xtr.Value);
            break;
          case XmlNodeType.XmlDeclaration:
            Console.Write("<?xml version='1.0'?>");
            break;
          case XmlNodeType.DocumentType:
            Console.Write("<!DOCTYPE {0} [{1}]", xtr.Name, xtr.Value);
            break;
          case XmlNodeType.EntityReference:
            Console.Write(xtr.Name);
            break;
          case XmlNodeType.EndElement:
            Console.Write("</{0}>", xtr.Name);
            break;
          case XmlNodeType.Whitespace:
            Console.Write("{0}", xtr.Value );
            break;
        }       
     }           

     if ( xtr != null)
         xtr.Close();
  } 
} // End class
