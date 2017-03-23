using System;
using System.Collections;
using System.Collections.Generic;

namespace Logger
{
    public class LogEntry
    {
        public LogEntry()
        {
            Properties = new Dictionary<object, object>();
        }

        public string Message { get; set; }
        public Exception Exception { get; set; }
        public IDictionary Properties { get; set; }
        public LogLevel LogLevel { get; set; }
    }
}
