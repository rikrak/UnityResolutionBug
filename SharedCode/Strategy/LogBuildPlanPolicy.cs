using System;
using log4net;
using Unity.Builder;
using Unity.Policy;

namespace UnityBuildStrategyDemo.Strategy
{
    public class LogBuildPlanPolicy : IBuildPlanPolicy
    {

        public LogBuildPlanPolicy(Type type)
        {
            var logType = GetTypeForLogger(type);
            this.LogType = logType;
        }

        public Type LogType { get; }

        public void BuildUp(IBuilderContext context)
        {
            if (context.Existing == null)
            {
                var log = LogManager.GetLogger(this.LogType);
                context.Existing = log;
            }
        }

        /// <summary>
        /// Returns the type to be associated with the logger
        /// </summary>
        /// <remarks>
        /// Effectively this returns the given type, or in the case where the given type is a generic type, returns the open generic type
        /// e.g. List&lt;T&gt; instead of List&lt;int&gt;
        /// 
        /// This was introduced to make the debug output a bit more readable.
        /// </remarks>
        private static Type GetTypeForLogger(Type type)
        {
            var logType = type;
            if (type.IsGenericType)
            {
                // the type is a generic type, e.g. List<int>
                // try to get the open generic type e.g. List<>
                logType = type.GetGenericTypeDefinition();
            }
            return logType;
        }
    }
}