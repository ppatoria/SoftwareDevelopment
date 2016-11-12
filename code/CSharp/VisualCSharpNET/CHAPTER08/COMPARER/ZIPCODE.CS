using System;

namespace MSPress.CSharpCoreRef.ch08Comparer
{
    public struct ZipCode: IComparable
    {
        public ZipCode(string zip, string plusFour)
        {
            _zip = zip;
            _plusFour = plusFour;
        }

        public ZipCode(string zip)
        {
            _zip = zip;
            _plusFour = null;
        }

        public int CompareTo(object obj)
        {
            if(obj == null)
                return 1;

            if(obj.GetType() != this.GetType())
                throw new ArgumentException("Invalid comparison");

            ZipCode other = (ZipCode)obj;
            int result = _zip.CompareTo(other._zip);
            if(result == 0)
            {
                if(other._plusFour == null)
                    result = _plusFour == null? 1: 0;
                else
                    result = _plusFour.CompareTo(other._plusFour);
            }
            return result;
        }

        public override string ToString()
        {
            string result;
            if(_plusFour != null && _plusFour.Length != 0)
                result = string.Format("{0}-{1}", _zip, _plusFour);
            else
                result = _zip;
            return result;
        }

        string _zip;
        string _plusFour;
    }
}
