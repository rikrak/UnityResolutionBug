using UnityBuildStrategyDemo.LogFacade;

namespace UnityBuildStrategyDemo.Stub
{
    public class ClassWithLogFacadeDependency
    {
        private readonly ILogFacade _logger;

        #region Constructors

        /// <summary>
        /// Creates a new instance of <see cref="ClassWithLogFacadeDependency"/>
        /// </summary>
        public ClassWithLogFacadeDependency(ILogFacade logger)
        {
            _logger = logger;
        }

        #endregion

        public ILogFacade Logger
        {
            get { return _logger; }
        }
    }
}