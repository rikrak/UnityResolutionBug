using System;
using System.Linq;
using log4net;
using Unity.Builder;
using Unity.Builder.Strategy;
using Unity.Policy;
using UnityBuildStrategyDemo.LogFacade;

namespace UnityBuildStrategyDemo.Strategy
{
    public class LogCreationStrategy : BuilderStrategy
    {
        public bool IsPolicySet { get; private set; }

        public override void PreBuildUp(IBuilderContext context)
        {
            Type typeToBuild = context.BuildKey.Type;
            if (typeof(ILog) == typeToBuild)
            {
                if (context.Policies.Get<IBuildPlanPolicy>(context.BuildKey) == null)
                {
                    Type typeForLog = LogCreationStrategy.GetLogType(context);
                    IBuildPlanPolicy policy = new LogBuildPlanPolicy(typeForLog);
                    context.Policies.Set<IBuildPlanPolicy>(policy, context.BuildKey);

                    this.IsPolicySet = true;
                }
            }
        }

        public override void PostBuildUp(IBuilderContext context)
        {
            if (this.IsPolicySet)
            {
                context.Policies.Clear(context.BuildKey.Type, context.BuildKey.Name, typeof(IBuildPlanPolicy));
                this.IsPolicySet = false;
            }
        }

        private static Type GetLogType(IBuilderContext context)
        {
            // default log type.  Used if the actual log type cannot be determined.
            // This can occur if the logger is not resolved by constructor injection
            Type logType = typeof(ILog);

            var buildTrackingPolicy = BuildTracker.GetPolicy(context);

            if ((buildTrackingPolicy != null) && (buildTrackingPolicy.BuildKeys.Count >= 2))
            {
                for (int i = 1; i < buildTrackingPolicy.BuildKeys.Count; i++)
                {
                    var requestingType = buildTrackingPolicy.BuildKeys.ElementAt(i).Type;
                    var loggerInterface = requestingType.GetInterface(typeof(ILogFacade).FullName);
                    if (loggerInterface == null)
                    {
                        logType = requestingType;
                        break;
                    }

                }
            }

            return logType;
        }
    }
}