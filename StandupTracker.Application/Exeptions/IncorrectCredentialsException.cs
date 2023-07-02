using System.Runtime.Serialization;

namespace StandupTracker.Applications.Exeptions;

[Serializable]
internal class IncorrectCredentialsException : Exception
{
    public IncorrectCredentialsException()
    {
    }

    public IncorrectCredentialsException(string? message) : base(message)
    {
    }

    public IncorrectCredentialsException(string? message, Exception? innerException) : base(message, innerException)
    {
    }

    protected IncorrectCredentialsException(SerializationInfo info, StreamingContext context) : base(info, context)
    {
    }
}