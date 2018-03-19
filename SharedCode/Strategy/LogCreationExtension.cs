using Unity.Builder;
using Unity.Extension;
using UnityBuildStrategyDemo.Strategy;

namespace UnityBuildStrategyDemo.Strategy
{
    public class LogCreationExtension : UnityContainerExtension
    {

        protected override void Initialize()
        {
            this.Context.Strategies.Add(new LogCreationStrategy(), UnityBuildStage.PreCreation);
        }
    }
}