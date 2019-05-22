using System;

namespace GOT.Services.Abstract
{
    public interface ILogger
    {
        void LogMessage(string text);
        void LogError(Exception exception);
    }
}
