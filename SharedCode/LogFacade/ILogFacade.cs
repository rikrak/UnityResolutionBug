using log4net.Core;

namespace UnityBuildStrategyDemo.LogFacade
{
    public interface ILogFacade
    {
        void Log(LogLevel level, object message);
        void Log(LogLevel level, string format, object arg);
        void Log(LogLevel level, string format, object arg0, object arg1);
        void Log(LogLevel level, string format, object arg0, object arg1, object arg2);
        void Log(LogLevel level, string format, params object[] args);

    }
}
