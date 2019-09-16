//=============================================================================
// COPYRIGHT KONINKLIJKE PHILIPS ELECTRONICS N.V. 2019
// All rights are reserved. Reproduction in whole or in part is
// prohibited without the written consent of the copyright owner.
//============================================================================= 

using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using EnablePatientVitalsLib;using VitalSignLib;using PatientVitalsType;
using System.Collections.Generic;using DataAccessContractsLib;
using Moq;

namespace EnablePatientVitalsLib.Tests
{
    

    [TestClass]
    public class EnablePatientVitalsUnitTest
    {
        Moq.Mock<IDataAccessComponent> _mockObj;
        IDataAccessComponent neighbourRef;
        EnablePatientVitals enablePatientVitals;
        
       [TestInitialize]
        public void TestInit()
        {
           _mockObj = new Moq.Mock<IDataAccessComponent>();
            _mockObj.Setup(f => f.WriteListOfEnabledPatientVitals(null, vitalSign)).Throws<ArgumentNullException>();
           
            var calls = 0;
            _mockObj.Setup(f => f.Count)
                .Callback(() => calls++)
                .Returns(() => calls);
            neighbourRef = _mockObj.Object;
           enablePatientVitals = new EnablePatientVitals(neighbourRef);
         
        }
        public static List<VitalSign> vitalSign { get; set; } = new List<VitalSign>
        {
            new VitalSign{IsEnabled=true,Type=VitalsType.Spo2},
            new VitalSign{IsEnabled=true,Type=VitalsType.PulseRate},
            new VitalSign{IsEnabled=true,Type=VitalsType.Temperature}
        };
        [TestMethod]
        public void GivenListOfPatientVitals_WhenEnablePatientVitalsCalled_ThenExpectedCountOne()
        { 
            enablePatientVitals.EnableSelectedPatientVitals("101", vitalSign);
            _mockObj.Verify(neighbour => neighbour.WriteListOfEnabledPatientVitals("101", vitalSign), Moq.Times.Exactly(1));
           
        }
        [TestMethod]
      [ExpectedException(typeof(System.NullReferenceException))]
        public void GivenNullPatientVitalsList_WhenEnablePatientVitalsCalled_ThenExceptionExpected()
        {
            enablePatientVitals.EnableSelectedPatientVitals("101",null);
            neighbourRef = _mockObj.Object;
        }
        [TestMethod]
        public void GivenSamePatientIdTwice_WhenEnablePatientVitalsCalled_ThenExpectedCountOne()
        {
            enablePatientVitals.EnableSelectedPatientVitals("101", vitalSign);
            enablePatientVitals.EnableSelectedPatientVitals("101", vitalSign);
            Assert.AreEqual(1, neighbourRef.Count);
        }
        [TestMethod][ExpectedException(typeof(System.ArgumentNullException))]
        public void GivenPatientIdNull_WhenEnablePatientVitalsCalled_ThenExpectedCountOne()
        {
            enablePatientVitals.EnableSelectedPatientVitals(null, vitalSign);
         }
        [TestCleanup]
        public void TestCleanUp()
        {
            _mockObj=null;
            neighbourRef=null;
            enablePatientVitals=null;

        }
    }
}
