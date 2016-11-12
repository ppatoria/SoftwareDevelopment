using System;

namespace MSPress.CSharpCoreRef.Controls
{
    /// <summary>
    /// Summary description for Sailboat.
    /// </summary>
    public class Sailboat
    {
        public Sailboat(string name, int length)
        {
            _name = name;
            _length = length;
        }

        public string Name
        {
            set { _name = value; }
            get { return _name; }
        }

        public int Length
        {
            set { _length = value; }
            get { return _length; }
        }

        override public string ToString()
        {
            return _name;
        }

        string _name;
        int    _length;
    }
}
