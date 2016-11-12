using System;

namespace MSPress.CSharpCoreRef.Authoring
{

    [Author("Mickey")]
	public class Sailboat
	{
		public Sailboat(string name)
		{
            _name = name;
		}

        public bool AvoidWhale()
        {
            return false;
        }

        public string Name
        {
            get { return _name; }
            set { _name = value; }
        }

        protected string _name;
	}
}
