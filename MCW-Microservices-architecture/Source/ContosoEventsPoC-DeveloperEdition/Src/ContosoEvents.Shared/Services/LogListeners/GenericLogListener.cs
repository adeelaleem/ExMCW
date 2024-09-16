﻿using ContosoEvents.Models;
using ContosoEvents.Shared.Services.LogSources;

namespace ContosoEvents.Shared.Services.LogListeners
{
    public class GenericLogListener
    {
        private ILogMessageEventSource _source;
        private ISettingService _settingService;
        public ISettingService TheSettingService
        {
            get
            {
                return _settingService;
            }

            set
            {
                _settingService = value;
            }
        }

        public GenericLogListener(ILogMessageEventSource source, ISettingService setting)
        {
            // http://www.codeproject.com/Articles/738109/The-NET-weak-event-pattern-in-Csharp
            //WeakEventManager<ILogMessageEventSource, EventArgs>.AddHandler(source, "LogMessageReceived", OnLogMessageReceived);
            _source = source;
            _source.LogMessageReceived += OnLogMessageReceived;
            _settingService = setting;
        }

        private void OnLogMessageReceived(object args, LogMessage message)
        {
            ProcessLogMessage(message);
        }

        public virtual void Unsubscribe()
        {
            if (_source != null)
            {
                _source.LogMessageReceived -= OnLogMessageReceived;
            }
        }

        public virtual void ProcessLogMessage(LogMessage message)
        {
            // Nothing in the base class
        }
    }
}
