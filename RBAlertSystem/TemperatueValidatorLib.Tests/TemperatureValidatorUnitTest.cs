using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using TemperatureValidatorLib;

namespace TemperatueValidatorLib.Tests
{
    [TestClass]
    public class TemperatureValidatorUnitTest
    {
        TemperatureValidator temperatureValidator;
        [TestInitialize]
        public void TestInit()
        {
            temperatureValidator = new TemperatureValidator();
        }
        [TestMethod]
        public void GivenTemperatureValue96_WhenValidateCalled_ThenExpectedFalse()
        {
            Assert.AreEqual(false, temperatureValidator.Validate(96));
        }
        [TestMethod]
        public void GivenTemperatureValue97_WhenValidateCalled_ThenExpectedTrue()
        {
            Assert.AreEqual(true, temperatureValidator.Validate(97));
        }
        [TestMethod]
        public void GivenTemperatureValue99_WhenValidateCalled_ThenExpectedTrue()
        {
            Assert.AreEqual(true, temperatureValidator.Validate(99));
        }
        [TestMethod]
        public void GivenTemperatureValue100_WhenValidateCalled_ThenExpectedFalse()
        {
            Assert.AreEqual(false, temperatureValidator.Validate(100));
        }
        [TestCleanup]
        public void TestCleanUp()
        {
            temperatureValidator = null; 
        }
    }
}
