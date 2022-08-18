using log4net.Core;
using System;

namespace FrameworkExample.Core.CrossCuttingConcerns.Logging.Log4Net
{
    [Serializable]
    public class SerializableLogEvent
    {
        private readonly LoggingEvent _loggingEvent;

        public SerializableLogEvent(LoggingEvent loggingEvent)
        {
            _loggingEvent = loggingEvent;
        }

        public DateTime UtcDate => _loggingEvent.TimeStampUtc.ToUniversalTime();
        public string UserName => _loggingEvent.UserName;
        public object Message => _loggingEvent.MessageObject;
        public string Level => _loggingEvent.Level.DisplayName;
        public Exception Exception => _loggingEvent.ExceptionObject;
    }
}
