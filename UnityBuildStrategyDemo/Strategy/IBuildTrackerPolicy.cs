using System.Collections.Generic;
using Unity.Builder;
using Unity.Policy;

namespace UnityBuildStrategyDemo.Strategy
{
    public interface IBuildTrackerPolicy : IBuilderPolicy
    {
        Stack<INamedType> BuildKeys { get; }
    }
}