using System.Collections.Generic;

namespace TermLib;

public static class TermMaths
{
    public enum ArithmeticOperators
    {
        ADDITION,
        SUBSTRACTION,
        MULTIPLICATION,
        DIVISION
    }

    /// <summary>
    ///     Creates a dictionary mapping symbols to values in <c>ArithmeticOperators</c>
    /// </summary>
    public static Dictionary<string, ArithmeticOperators> ArithmeticMap()
    {
        Dictionary<string, ArithmeticOperators> map = new();
        map.TryAdd("+", ArithmeticOperators.ADDITION);
        map.TryAdd("-", ArithmeticOperators.SUBSTRACTION);
        map.TryAdd("*", ArithmeticOperators.MULTIPLICATION);
        map.TryAdd("/", ArithmeticOperators.DIVISION);

        return map;
    }
}