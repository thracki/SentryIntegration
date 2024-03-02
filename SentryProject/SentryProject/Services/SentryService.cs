using Sentry;
using System;

namespace SentryProject.Services
{
    public class SentryService : ISentryExceptionLog
    {
        private readonly IHub hub;

        public SentryService(IHub hub)
        {
            this.hub = hub;
        }
        public void Log(string message)
        {
            throw new NotImplementedException();
        }

        public void Log(Exception ex)
        {
            var sentryEvent = new SentryEvent(ex);
            sentryEvent.Modules.Clear();
            
            this.hub.CaptureEvent(sentryEvent, scope => {
                scope.SetTag("new_tag", "Nowy tag");
                scope.SetTag("RequestId", "my-request");

            });
        }
    }
}
