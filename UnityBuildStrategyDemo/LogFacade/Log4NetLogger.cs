using log4net;

namespace UnityBuildStrategyDemo.LogFacade
{
    public class Log4NetLogger : ILogFacade
    {
        private readonly log4net.ILog _log;

        #region Constructors

        /// <summary>
        /// Creates a new instance of <see cref="Log4NetLogger"/>
        /// </summary>
        public Log4NetLogger(ILog log)
        {
            _log = log;
        }

        internal ILog LogInstance => _log;

        #endregion

        /// <summary>
        /// Writes a log entry
        /// </summary>
        public void Log(LogLevel level, object message)
        {
            switch (level)
            {
                case LogLevel.Fatal:
                    _log.Fatal(message);
                    break;
                case LogLevel.Error:
                    _log.Error(message);
                    break;
                case LogLevel.Warning:
                    _log.Warn(message);
                    break;
                case LogLevel.Information:
                    _log.Info(message);
                    break;
                case LogLevel.Debug:
                    _log.Debug(message);
                    break;
            }
        }

        /// <summary>
        /// Writes a log entry
        /// </summary>
        public void Log(LogLevel level, string format, params object[] args)
        {
            switch (level)
            {
                case LogLevel.Fatal:
                    _log.FatalFormat(format, args);
                    break;
                case LogLevel.Error:
                    _log.ErrorFormat(format, args);
                    break;
                case LogLevel.Warning:
                    _log.WarnFormat(format, args);
                    break;
                case LogLevel.Information:
                    _log.InfoFormat(format, args);
                    break;
                case LogLevel.Debug:
                    _log.DebugFormat(format, args);
                    break;
            }
        }

        /// <summary>
        /// Writes a log entry
        /// </summary>
        public void Log(LogLevel level, string format, object arg)
        {
            switch (level)
            {
                case LogLevel.Fatal:
                    _log.FatalFormat(format, arg);
                    break;
                case LogLevel.Error:
                    _log.ErrorFormat(format, arg);
                    break;
                case LogLevel.Warning:
                    _log.WarnFormat(format, arg);
                    break;
                case LogLevel.Information:
                    _log.InfoFormat(format, arg);
                    break;
                case LogLevel.Debug:
                    _log.DebugFormat(format, arg);
                    break;
            }
        }

        /// <summary>
        /// Writes a log entry
        /// </summary>
        public void Log(LogLevel level, string format, object arg0, object arg1)
        {
            switch (level)
            {
                case LogLevel.Fatal:
                    _log.FatalFormat(format, arg0, arg1);
                    break;
                case LogLevel.Error:
                    _log.ErrorFormat(format, arg0, arg1);
                    break;
                case LogLevel.Warning:
                    _log.WarnFormat(format, arg0, arg1);
                    break;
                case LogLevel.Information:
                    _log.InfoFormat(format, arg0, arg1);
                    break;
                case LogLevel.Debug:
                    _log.DebugFormat(format, arg0, arg1);
                    break;
            }
        }

        /// <summary>
        /// Writes a log entry
        /// </summary>
        public void Log(LogLevel level, string format, object arg0, object arg1, object arg2)
        {
            switch (level)
            {
                case LogLevel.Fatal:
                    _log.FatalFormat(format, arg0, arg1, arg2);
                    break;
                case LogLevel.Error:
                    _log.ErrorFormat(format, arg0, arg1, arg2);
                    break;
                case LogLevel.Warning:
                    _log.WarnFormat(format, arg0, arg1, arg2);
                    break;
                case LogLevel.Information:
                    _log.InfoFormat(format, arg0, arg1, arg2);
                    break;
                case LogLevel.Debug:
                    _log.DebugFormat(format, arg0, arg1, arg2);
                    break;
            }
        }
    }
}