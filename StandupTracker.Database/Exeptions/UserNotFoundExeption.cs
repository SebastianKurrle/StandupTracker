using System.Runtime.Serialization;

namespace StandupTracker.Database.Exeptions;

[Serializable]
internal class UserNotFoundExeption : Exception
{
    public UserNotFoundExeption()
    {
    }

    public UserNotFoundExeption(string? message) : base(message)
    {
    }

    public UserNotFoundExeption(string? message, Exception? innerException) : base(message, innerException)
    {
    }

    protected UserNotFoundExeption(SerializationInfo info, StreamingContext context) : base(info, context)
    {
    }
}