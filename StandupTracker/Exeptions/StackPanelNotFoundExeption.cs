using System;
using System.Runtime.Serialization;

namespace StandupTracker.Exeptions;

[Serializable]
internal class StackPanelNotFoundExeption : Exception
{
    public StackPanelNotFoundExeption()
    {
    }

    public StackPanelNotFoundExeption(string? message) : base(message)
    {
    }

    public StackPanelNotFoundExeption(string? message, Exception? innerException) : base(message, innerException)
    {
    }

    protected StackPanelNotFoundExeption(SerializationInfo info, StreamingContext context) : base(info, context)
    {
    }
}