using log4net;

namespace UnityBuildStrategyDemo.Stub
{
    public class ClassWithLogDependency
    {
        private readonly ILog _logger;

        #region Constructors

        /// <summary>
        /// Creates a new instance of <see cref="ClassWithLogDependency"/>
        /// </summary>
        public ClassWithLogDependency(ILog logger)
        {
            _logger = logger;
        }

        #endregion

        public ILog Logger => _logger;
    }
}