using Unity.Builder;
using Unity.Extension;
using Unity.Policy;

namespace UnityBuildStrategyDemo.Strategy
{
    public class BuildTracker : UnityContainerExtension
    {

        protected override void Initialize()
        {
            this.Context.Strategies.Add(new BuildTrackerStrategy(), UnityBuildStage.TypeMapping);
        }

        public static IBuildTrackerPolicy GetPolicy(IBuilderContext context)
        {
            var returnVal = context.Policies.GetOrDefault(typeof(IBuildTrackerPolicy), context.BuildKey, out _);

            return returnVal as IBuildTrackerPolicy;
        }

        public static IBuildTrackerPolicy SetPolicy(IBuilderContext context)
        {
            IBuildTrackerPolicy policy = new BuildTrackerPolicy();
            context.Policies.SetDefault<IBuildTrackerPolicy>(policy);
            return policy;
        }
    }
}