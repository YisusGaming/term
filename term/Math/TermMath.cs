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

    public static float? RunArithmetics(string property)
    {
        if (property.Contains((char) ArithmeticOperators.ADDITION))
        {
            string[] addition = property.Split((char) ArithmeticOperators.ADDITION);
            try
            {
                float x1 = Convert.ToSingle(addition[0].Trim());
                float x2 = Convert.ToSingle(addition[1].Trim());
                
                return x1 + x2;
            }
            catch (Exception exception)
            {
                throw new ArithmeticFaultException(exception.Message, exception);
            }
        }

        // If no arithmetic operation is found,
        // return null.
        return null;
    }
}