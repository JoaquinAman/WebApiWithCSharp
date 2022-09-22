using System;

namespace webapi.Exceptions;

public class InvalidMsgException : Exception
{
    public InvalidMsgException() { }

    public InvalidMsgException(string message) : base(message)
    {
        Console.WriteLine(message);
    }
    public InvalidMsgException(string message, Exception inner) : base(message, inner)
    {
        Console.WriteLine(message);
    }
}
