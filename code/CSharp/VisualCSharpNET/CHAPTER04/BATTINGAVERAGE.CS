using System;

namespace MSPress.CSharpCoreRef.BattingAverageExample
{
    /// <summary>
    /// Value type that models baseball batting averages.
    /// </summary>
    public struct BattingAverage
    {
        /// <summary>
        /// Constructs a new BattingAverage value type instance
        /// </summary>
        /// <param name="atBats">Number of at-bats</param>
        /// <param name="hits">Number of hits</param>
        public BattingAverage(int atBats, int hits)
        {
            TestValid(atBats, hits);
            _atBats = atBats;
            _hits = hits;
        }

        /// <summary>
        /// Convert the batting average into a string.
        /// </summary>
        /// <returns>Returns a string representation of a 
        /// batting average in the typical 3 digit format.
        /// </returns>
        public override string ToString()
        {
            float average = Average();
            string result = string.Format("{0:#.000}", average);
            return result;          
        }

        #region operator overloading

        /// <summary>
        /// Equality operator for batting averages.
        /// </summary>
        /// <param name="left">Left operand</param>
        /// <param name="right">Right operand</param>
        /// <returns>True if the averages are equal, false
        /// otherwise</returns>
        public static bool operator ==(BattingAverage left,
                                       BattingAverage right)
        {
            if((object)left == null)
                return false;
            else
                return left.Equals(right);
        }

        /// <summary>
        /// Inequality operator for batting averages.
        /// </summary>
        /// <param name="left">Left operand</param>
        /// <param name="right">Right operand</param>
        /// <returns>True if the averages aren't equal, false
        /// otherwise</returns>
        public static bool operator !=(BattingAverage left,
                                       BattingAverage right)
        {
            return !(left == right);
        }

        /// <summary>
        /// Override of the Object.Equals method, returns
        /// true if the current object is equal to another
        /// object passed as a parameter.
        /// </summary>
        /// <param name="other">The object to test for equality.
        /// </param>
        /// <returns>True if the objects are logically equal,
        /// false otherwise.</returns>
        public override bool Equals(object other)
        {
            bool result = false;
            if(other != null)
            {
                if((object)this == other)
                {
                    result = true;
                }
                else if(other is BattingAverage)
                {
                    BattingAverage otherAvg = (BattingAverage)other;
                    result = Average() == otherAvg.Average();
                }
            }
            return result;
        }

        /// <summary>
        /// Converts the batting average into a string, and then
        /// uses the string to generate the hash code
        /// </summary>
        /// <returns>A hash code for this instance.</returns>
        public override int GetHashCode()
        {
            return ToString().GetHashCode();
        }

        /// <summary>
        /// Compares two operands using the greater-than operator
        /// </summary>
        /// <param name="left">Left operand</param>
        /// <param name="right">Right operand</param>
        /// <returns>True if the left operand is greater than
        /// the right operand</returns>
        public static bool operator >(BattingAverage left,
                                      BattingAverage right)
        {
            return left.Average() > right.Average();
        }
        
        /// <summary>
        /// Compares two operands using the less-than or equal
        /// to operator
        /// </summary>
        /// <param name="left">Left operand</param>
        /// <param name="right">Right operand</param>
        /// <returns>True if the left operand is less than or
        /// equal to the right operand</returns>
        public static bool operator <=(BattingAverage left,
                                       BattingAverage right)
        {
            return left.Average() <= right.Average();
        }

        /// <summary>
        /// Compares two operands using the less-than operator.
        /// </summary>
        /// <param name="left">Left operand</param>
        /// <param name="right">Right operand</param>
        /// <returns>True if the left operand is less than 
        /// the right operand</returns>
        public static bool operator <(BattingAverage left,
                                      BattingAverage right)
        {
            return left.Average() < right.Average();
        }

        /// <summary>
        /// Compares two operands using the greater-than or
        /// equal to operator
        /// </summary>
        /// <param name="left">Left operand</param>
        /// <param name="right">Right operand</param>
        /// <returns>True if the left operand is greater than or
        /// equal to the right operand</returns>
        public static bool operator >=(BattingAverage left,
                                      BattingAverage right)
        {
            return left.Average() >= right.Average();
        }

        /// <summary>
        /// Returns true if the object is logically false
        /// </summary>
        /// <param name="avg">The object to be tested</param>
        /// <returns>True if the object is logically false
        /// </returns>
        public static bool operator false(BattingAverage avg)
        {
            return avg.Average() == 0;
        }

        /// <summary>
        /// Returns true if the object is logically true
        /// </summary>
        /// <param name="avg">The object to be tested</param>
        /// <returns>True if the object is logically true
        /// </returns>
        public static bool operator true(BattingAverage avg)
        {
            return avg.Average() != 0;
        }

        /// <summary>
        /// Performs an AND operation on two batting averages
        /// </summary>
        /// <param name="left">Left operand</param>
        /// <param name="right">Right operand</param>
        /// <returns>A new object that represents an AND
        /// of the two operands</returns>
        public 
        static BattingAverage operator &(BattingAverage left,
                                         BattingAverage right)
        {
            if(left.Average() == 0 || right.Average() == 0)
                return new BattingAverage();
            else
                return new BattingAverage(left._atBats + right._atBats,
                                          left._hits + left._hits);
        }

        /// <summary>
        /// Performs an OR operation on two batting averages.
        /// </summary>
        /// <param name="left">Left operand</param>
        /// <param name="right">Right operand</param>
        /// <returns>Returns a new object that is a copy of
        /// the left operand. If the left operand has a batting
        /// average of zero, the right operand is returned.
        /// </returns>
        public 
        static BattingAverage operator |(BattingAverage left,
                                         BattingAverage right)
        {
            if(left.Average() != 0)
                return new BattingAverage(left._atBats,
                                          left._hits);
            else if(right.Average() != 0)
                return new BattingAverage(right._atBats,
                                          right._hits);
            else
                return new BattingAverage();
        }

        #endregion

        /// <summary>
        /// Returns the batting average, subject to floating-
        /// point rounding
        /// </summary>
        /// <returns>a float that represents the batting
        /// average.</returns>
        public float Average()
        {
            if(_atBats == 0)
                return 0.0f;
            else
                return (float)_hits / (float)_atBats;
        }

        /// <summary>
        /// Implements the AtBats property, which shadows the
        /// _atBats member field. Implementation as a property
        /// allows input values to be tested for validity.
        /// </summary>
        public int AtBats
        {
            get
            {
                return _atBats;
            }
            set
            {
                TestValid(value, _hits);
                _atBats = value;
            }
        }

        /// <summary>
        /// Implements the Hits property, which shadows the
        /// _hits member field. Implementation as a property
        /// allows input values to be tested for validity.
        /// </summary>
        public int Hits
        {
            get
            {
                return _hits;
            }
            set
            {
                TestValid(_atBats, value);
                _hits = value;
            }
        }

        /// <summary>
        /// User-defined explicit conversion to float
        /// </summary>
        /// <param name="avg"></param>
        /// <returns>The </returns>
        public static explicit operator float(BattingAverage avg)
        {
            return avg.Average();
        }

        /// <summary>
        /// Tests for valid hits and at bats, throwing an exception
        /// if the parameters are invalid
        /// </summary>
        /// <param name="testAtBats">Number of at-bats</param>
        /// <param name="testHits">Number of hits</param>
        private static void TestValid(int testAtBats, int testHits)
        {
            if(testAtBats < 0)
            {
                string msg = "At-bats must not be negative";
                throw new ArgumentOutOfRangeException(msg);
            }
            if(testAtBats < testHits)
            {
                string msg = "Hits must not exceed atBats";
                throw new ArgumentOutOfRangeException(msg);
            }
        }

        /// <summary>
        /// The number of at-bats for this instance
        /// </summary>
        private int _atBats;
        /// <summary>
        /// The number of hits for this instance
        /// </summary>
        private int _hits;
    }
}
