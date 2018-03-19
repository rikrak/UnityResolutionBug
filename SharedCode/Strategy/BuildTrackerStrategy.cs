using Unity.Builder;
using Unity.Builder.Strategy;

namespace UnityBuildStrategyDemo.Strategy
{
    public class BuildTrackerStrategy : BuilderStrategy
    {
#if UNITY_5_5_0
        public override object PreBuildUp(IBuilderContext context)
#else
        public override void PreBuildUp(IBuilderContext context)
#endif
        {
            IBuildTrackerPolicy policy = BuildTracker.GetPolicy(context);
            if (policy == null)
            {
                policy = BuildTracker.SetPolicy(context);
            }

            policy.BuildKeys.Push(context.BuildKey);
#if UNITY_5_5_0
            return null;
#endif
        }

#if UNITY_5_5_0
        public override void PostBuildUp(IBuilderContext context, object pre=null)
#else
        public override void PostBuildUp(IBuilderContext context)
#endif
        {
            IBuildTrackerPolicy policy = BuildTracker.GetPolicy(context);
            if ((policy != null) && (policy.BuildKeys.Count > 0))
            {
                policy.BuildKeys.Pop();
            }
        }
    }
}