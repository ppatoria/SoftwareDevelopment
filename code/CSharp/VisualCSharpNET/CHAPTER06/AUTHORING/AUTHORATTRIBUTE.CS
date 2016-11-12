using System;

namespace MSPress.CSharpCoreRef.Authoring
{
	[AttributeUsage(AttributeTargets.All)]
    public class AuthorAttribute: Attribute
	{
		public AuthorAttribute(string name)
		{
            _name = name;
		}

        public string Name
        {
            get { return _name; }
        }

        public string Notes
        {
            set { _notes = value; }
            get { return _notes; }
        }

        protected string _name;
        protected string _notes;
	}
}
