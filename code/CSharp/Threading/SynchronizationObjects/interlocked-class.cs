public static class Interlocked {
   // return (++location)
   public static Int32 Increment(ref Int32 location);

   // return (--location)
   public static Int32 Decrement(ref Int32 location);

   // return (location += value)
   // Note: value can be a negative number allowing subtraction
   public static Int32 Add(ref Int32 location, Int32 value);

   // Int32 old = location; location = value; return old;
   public static Int32 Exchange(ref Int32 location, Int32 value);

   // Int32 old = location;
   // if (location == comparand) location = value;
   // return old;
   public static Int32 CompareExchange(ref Int32 location, Int32 value, Int32 comparand);
   ...
}