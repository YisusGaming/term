using System;

namespace TermLib;

public static class TermMaths
{
    public enum ArithmeticOperators
    {
        ADDITION = '+',
        SUBSTRACTION = '-',
        MULTIPLICATION = '*',
        DIVISION = '/',

        /// <summary>
        ///  This is not an operator, this is just a variant to be
        /// if a property didn't match any of the above.
        /// </summary>
        INVALID
    }

    public static void RunArithmetics(string property)
    {
        if (property.Contains((char) ArithmeticOperators.ADDITION))
        {
            Console.WriteLine(property);
        }
    }
}