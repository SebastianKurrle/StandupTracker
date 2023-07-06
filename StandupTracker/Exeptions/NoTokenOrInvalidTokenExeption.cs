using System;
using System.Runtime.Serialization;

namespace StandupTracker.Exeptions;

[Serializable]
public class NoTokenOrInvalidTokenExeption : Exception
{
    public NoTokenOrInvalidTokenExeption()
    {
    }

    public NoTokenOrInvalidTokenExeption(string? message) : base(message)
    {
    }

    public NoTokenOrInvalidTokenExeption(string? message, Exception? innerException) : base(message, innerException)
    {
    }

    protected NoTokenOrInvalidTokenExeption(SerializationInfo info, StreamingContext context) : base(info, context)
    {
    }
}