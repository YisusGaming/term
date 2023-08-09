using System;

namespace TermLib;

public static class FaultHandler
{
    public static EventHandler<TermFault>? FaultEvent;

    /// <summary>
    ///     Raises a fault to the interpreter.
    ///     The interpreter will stop execution and manifest the fault.
    /// </summary>
    /// <param name="fault"></param>
    public static void RaiseFault(TermFault fault)
    {
        FaultEvent?.Invoke(null, fault);
    }
}

public class TermFault
{
    private readonly string name;
    private readonly string errorMessage;
    public TermFault(string name, string errorMessage)
    {
        this.name = name;
        this.errorMessage = errorMessage;
    }

    /// <summary>
    ///     The name of this Fault.
    /// </summary>
    protected string Name
    {
        get 
        {
            return this.name;
        }
    }

    /// <summary>
    ///     The message/description of this Fault.
    /// </summary>
    protected string ErrorMessage
    {
        get 
        {
            return this.errorMessage;
        }
    }
}
