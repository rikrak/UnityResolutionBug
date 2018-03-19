using FluentAssertions;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Unity;
using UnityBuildStrategyDemo.LogFacade;
using UnityBuildStrategyDemo.Strategy;
using UnityBuildStrategyDemo.Stub;

namespace UnityBuildStrategyDemo
{
    [TestClass]
    public class DynamicDependencyTests
    {
        private UnityContainer _target;


        [TestInitialize]
        public void Setup()
        {
            _target = new UnityContainer();

            _target
                .AddNewExtension<BuildTracker>()
                .AddNewExtension<LogCreationExtension>()
                .RegisterType<ILogFacade, Log4NetLogger>()
                .RegisterType<ClassWithLogFacadeDependency, ClassWithLogFacadeDependency>()
                .RegisterType<ClassWithIndirectLogFacadeDependency, ClassWithIndirectLogFacadeDependency>()
                .RegisterType<ClassWithLogDependency, ClassWithLogDependency>();
        }

        [TestMethod]
        public void ShouldResolveILoggerWithInstanceDependentOnResolvingType()
        {
            // arrange

            // act
            var actual = _target.Resolve<ClassWithLogFacadeDependency>();

            // assert
            actual.Should().NotBeNull("The class should be resolved");
            actual.Logger.Should().NotBeNull("The logger should have been resolved");

            var theLogger = actual.Logger as Log4NetLogger;
            theLogger.Should().NotBeNull("should have been resolved as a log4netLogger as this is what was registered");
            theLogger.LogInstance.Logger.Name
                .Should().Be(typeof(ClassWithLogFacadeDependency).FullName);
        }

        [TestMethod]
        public void ShouldResolveIndirectDependencyOnILoggerWithInstanceDependentOnResolvingType()
        {
            // arrange

            // act
            var actual = _target.Resolve<ClassWithIndirectLogFacadeDependency>();

            // assert
            actual.Should().NotBeNull("The class should be resolved");
            actual.DirectDependencyOnLogger.Should().NotBeNull("The dependency should have been resolved");
            actual.DirectDependencyOnLogger.Logger.Should().NotBeNull("The logger should have been resolved");

            var theLogger = actual.DirectDependencyOnLogger.Logger as Log4NetLogger;
            theLogger.Should().NotBeNull("should have been resolved as a log4netLogger as this is what was registered");
            theLogger.LogInstance.Logger.Name
                .Should().Be(typeof(ClassWithLogFacadeDependency).FullName);
        }


        [TestMethod]
        public void ShouldResolveILogWithInstanceDependentOnResolvingType()
        {
            // arrange

            // act
            var actual = _target.Resolve<ClassWithLogDependency>();

            // assert
            actual.Should().NotBeNull("The class should be resolved");
            actual.Logger.Should().NotBeNull("The logger should have been resolved");

            actual.Logger.Logger.Name
                .Should().Be(typeof(ClassWithLogDependency).FullName);
        }

    }
}