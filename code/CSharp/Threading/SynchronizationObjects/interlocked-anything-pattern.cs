public static Int32 Maximum(ref Int32 target, Int32 value) {
    Int32 currentVal = target, startVal, desiredVal;

    // Don't access target in the loop except in an attempt
    // to change it because another thread may be touching it
    do {
        // Record this iteration's starting value
        startVal = currentVal;

        // Calculate the desired value in terms of startVal and value
        desiredVal = Math.Max(startVal, value);

        // NOTE: the thread could be preempted here!

        // if (target == startVal) target = desiredVal
        // Value prior to potential change is returned
        currentVal = Interlocked.CompareExchange(ref target, desiredVal, startVal);

        // If the starting value changed during this iteration, repeat
    } while (startVal != currentVal);

    // Return the maximum value when this thread tried to set it
    return desiredVal;
}

delegate Int32 Morpher<TResult, TArgument> ( Int32       startValue, 
                                             TArgument   argument,
                                             out TResult morphResult);
static TResult Morph<TResult, TArgument> ( ref Int32 target, 
                                           TArgument argument,
                                           Morpher<TResult, TArgument> morpher) {
    TResult morphResult;
    Int32 currentVal = target, startVal, desiredVal;
    do {
        startVal       = currentVal;
        desiredVal     = morpher(startVal, argument, out morphResult);
        currentVal     = Interlocked.CompareExchange(ref target, desiredVal, startVal);
    } while (startVal != currentVal);
    return morphResult;
}