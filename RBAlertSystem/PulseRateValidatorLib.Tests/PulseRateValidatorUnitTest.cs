//=============================================================================
// COPYRIGHT KONINKLIJKE PHILIPS ELECTRONICS N.V. 2019
// All rights are reserved. Reproduction in whole or in part is
// prohibited without the written consent of the copyright owner.
//============================================================================= 

using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using PulseRateValidatorLib;

namespace PulseRateValidatorLib.Tests
{
    [TestClass]
    public class PulseRateValidatorUnitTest
    {
        PulseRateValidator pulseRateValidator;
        [TestInitialize]
        public void TestInit()
        {
            pulseRateValidator = new PulseRateValidator();
        }
        [TestMethod]
        public void GivenPulseRateValue59_WhenValidateCalled_ThenExpectedFalse()
        {
            Assert.AreEqual(false, pulseRateValidator.Validate(59));
        }
        [TestMethod]
        public void GivenPulseRateValue60_WhenValidateCalled_ThenExpectedTrue()
        {
            Assert.AreEqual(true, pulseRateValidator.Validate(60));
        }
        [TestMethod]
        public void GivenPulseRateValue100_WhenValidateCalled_ThenExpectedTrue()
        {
            Assert.AreEqual(true, pulseRateValidator.Validate(100));
        }
        [TestMethod]
        public void GivenPulseRateValue101_WhenValidateCalled_ThenExpectedFalse()
        {
            Assert.AreEqual(false, pulseRateValidator.Validate(101));
        }
        [TestCleanup]
        public void TestCleanUp()
        {
            pulseRateValidator = null;
        }
    }
}
