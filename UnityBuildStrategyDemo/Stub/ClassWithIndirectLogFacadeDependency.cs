
namespace UnityBuildStrategyDemo.Stub
{
    public class ClassWithIndirectLogFacadeDependency
    {
        private readonly ClassWithLogFacadeDependency _directDependencyOnLogger;

        #region Constructors

        /// <summary>
        /// Creates a new instance of <see cref="ClassWithIndirectLogFacadeDependency"/>
        /// </summary>
        public ClassWithIndirectLogFacadeDependency(ClassWithLogFacadeDependency directDependencyOnLogger)
        {
            _directDependencyOnLogger = directDependencyOnLogger;
        }

        #endregion

        public ClassWithLogFacadeDependency DirectDependencyOnLogger => _directDependencyOnLogger;
    }
}