using System.Collections.Generic;
using Unity.Builder;

namespace UnityBuildStrategyDemo.Strategy
{
    public class BuildTrackerPolicy : IBuildTrackerPolicy
    {
        public BuildTrackerPolicy()
        {
            this.BuildKeys = new Stack<INamedType>();
        }

        public Stack<INamedType> BuildKeys { get; private set; }
    }
}