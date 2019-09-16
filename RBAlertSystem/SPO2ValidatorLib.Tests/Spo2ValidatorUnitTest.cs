//=============================================================================
// COPYRIGHT KONINKLIJKE PHILIPS ELECTRONICS N.V. 2019
// All rights are reserved. Reproduction in whole or in part is
// prohibited without the written consent of the copyright owner.
//============================================================================= 

using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Spo2ValidatorLib;

namespace SPO2ValidatorLib.Tests
{
    [TestClass]
    public class Spo2ValidatorUnitTest
    {
        Spo2Validator spo2Validator;
       [TestInitialize]
       public void TestInit()
        {
            spo2Validator = new Spo2Validator();
        }
        [TestMethod]
        public void GivenSpo2Value90_WhenValidateCalled_ThenExpectedFalse()
        { 
            Assert.AreEqual(false, spo2Validator.Validate(90));
        }
        [TestMethod]
        public void GivenSpo2Value91_WhenValidateCalled_ThenExpectedTrue()
        {
            Assert.AreEqual(true, spo2Validator.Validate(91));
        }
        [TestMethod]
        public void GivenSpo2Value95_WhenValidateCalled_ThenExpectedTrue()
        {
            Assert.AreEqual(true, spo2Validator.Validate(95));
        }
        [TestMethod]
        public void GivenSpo2Value96_WhenValidateCalled_ThenExpectedFalse()
        {
            Assert.AreEqual(false, spo2Validator.Validate(96));
        }
        [TestCleanup]
        public void TestCleanUp()
        {
            spo2Validator = null;
        }
    }
}
