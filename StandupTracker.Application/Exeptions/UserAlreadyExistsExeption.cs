using System.Runtime.Serialization;

namespace StandupTracker.Applications.Exeptions;

[Serializable]
internal class UserAlreadyExistsExeption : Exception
{
    public UserAlreadyExistsExeption()
    {
    }

    public UserAlreadyExistsExeption(string? message) : base(message)
    {
    }

    public UserAlreadyExistsExeption(string? message, Exception? innerException) : base(message, innerException)
    {
    }

    protected UserAlreadyExistsExeption(SerializationInfo info, StreamingContext context) : base(info, context)
    {
    }
}