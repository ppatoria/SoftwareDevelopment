using System;
using System.Xml.Serialization;
namespace MSPress.CSharpCoreRef.Authoring
{
	class AuthoringApp
	{
		static void Main(string[] args)
		{
            Type t = typeof(Sailboat);
            AuthorAttributeCheck check = new AuthorAttributeCheck(t);
            string name = check.GetAuthorName();
            if(name != null)
                Console.WriteLine("The author's name is: {0}", name);
            name = check.GetAuthorName();
            if(name != null)
                Console.WriteLine("The author's name is: {0}", name);

            string notes = check.GetNotes();
            if(notes != null)
                Console.WriteLine("The author's notes are: {0}", notes);

            string[] authorInfo = check.GetAllMemberAuthorInfo();
            foreach(string authorName in authorInfo)
            {
                Console.WriteLine(authorName);
            }

            string[] authorInfo2 = check.GetMemberAuthorInfo("Text");
            foreach(string authorName in authorInfo2)
            {
                Console.WriteLine(authorName);
            }
            name = check.GetAssemblyAuthorName("Authoring");
            Console.WriteLine("Assembly author attribute: {0}", name);
            Console.WriteLine("done");
        }

	}

    [Author("Mickey")]
    class Foo
    {
        [Author("Mickey")]
        public void Show()
        {
        }

        [Author("Mickey")]
        public void Hide()
        {
        }

        [Author("Mickey")]
        [XmlIgnore()]
        public int Size;

        [Author("Mickey")]
        public string Text
        {
            get {return "Hello";}
        }
    }

    [Obsolete("Use the new BubbleSorter class")]
    class BubbleSort
    {
    }

}
