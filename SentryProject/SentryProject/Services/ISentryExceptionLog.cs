using System;

namespace SentryProject.Services
{
    public interface ISentryExceptionLog
    {
        void Log(string message);
        void Log(Exception ex);
    }
}
