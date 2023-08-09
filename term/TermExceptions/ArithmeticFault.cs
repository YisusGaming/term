namespace TermLib;

[System.Serializable]
public class ArithmeticFaultException : System.Exception
{
    public ArithmeticFaultException() { }
    public ArithmeticFaultException(string message) : base(message) { }
    public ArithmeticFaultException(string message, System.Exception inner) : base(message, inner) { }
    protected ArithmeticFaultException(
        System.Runtime.Serialization.SerializationInfo info,
        System.Runtime.Serialization.StreamingContext context) : base(info, context) { }
}