using System;
using System.Runtime.Serialization;

namespace StandupTracker.Exeptions;

[Serializable]
public class UserUnauthenticatedExeption : Exception
{
    public UserUnauthenticatedExeption()
    {
    }

    public UserUnauthenticatedExeption(string? message) : base(message)
    {
    }

    public UserUnauthenticatedExeption(string? message, Exception? innerException) : base(message, innerException)
    {
    }

    protected UserUnauthenticatedExeption(SerializationInfo info, StreamingContext context) : base(info, context)
    {
    }
}