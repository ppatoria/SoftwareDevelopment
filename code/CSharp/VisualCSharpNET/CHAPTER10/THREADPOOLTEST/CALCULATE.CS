using System;

namespace MSPress.CSharpCoreRef.ThreadPoolTest
{
    public class Calculate
    {
        double _radius;
        double _result;
        public Calculate(double radius)
        {
            _radius = radius;
        }
        public void Circumference()
        {
            _result = 2 * _radius * 3.1415926535d;
        }
        public double Result
        {
            get { return _result; }
        }
    }
}
