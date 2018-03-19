using Unity.Builder;
using Unity.Builder.Strategy;

namespace UnityBuildStrategyDemo.Strategy
{
    public class BuildTrackerStrategy : BuilderStrategy
    {

        public override void PreBuildUp(IBuilderContext context)
        {
            IBuildTrackerPolicy policy = BuildTracker.GetPolicy(context);
            if (policy == null)
            {
                policy = BuildTracker.SetPolicy(context);
            }

            policy.BuildKeys.Push(context.BuildKey);
        }

        public override void PostBuildUp(IBuilderContext context)
        {
            IBuildTrackerPolicy policy = BuildTracker.GetPolicy(context);
            if ((policy != null) && (policy.BuildKeys.Count > 0))
            {
                policy.BuildKeys.Pop();
            }
        }
    }
}