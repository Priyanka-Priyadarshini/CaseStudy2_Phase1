//=============================================================================
// COPYRIGHT KONINKLIJKE PHILIPS ELECTRONICS N.V. 2019
// All rights are reserved. Reproduction in whole or in part is
// prohibited without the written consent of the copyright owner.
//============================================================================= 

using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using DataAccessContractsLib;using PatientVitalsDataModelsLib;
using PatientVitalsValidatorContractsLib;
using InstanceCreatorLib;using DataAccessLib;

namespace RuleBasedPatientVitalsAlertUponValidationLib.Tests
{
    [TestClass]
    public class RuleBasedPatientVitalsAlertUponValidationUnitTest
    {
        RuleBasedPatientVitalsAlertUponValidation vitalsAlertUponValidation;
        IDataAccessComponent dataAccess;

        [TestInitialize]
        public void Init()
        {
            dataAccess = new DataAccess();
            vitalsAlertUponValidation = new RuleBasedPatientVitalsAlertUponValidation(dataAccess);

        }
        [TestMethod]
        public void GivenPatientIdWhoseDataStored_WhenPatientVitalsAlertUponValidation_ThenExpectedAlertMessage()
        {
            dataAccess.WritePatientVitalsData(new PatientVitals() { PatientId = "101", Temperature = 100, Spo2 = 96, PulseRate = 70 });
            string str = "Spo2Alert TemperatureAlert ";
           Assert.AreEqual(str, vitalsAlertUponValidation.PatientVitalsAlertUponValidation("101"));
            

        }
        [TestMethod]
        public void GivenPatientIdWhoseDataStored_WhenPatientVitalsAlertUponValidation_ThenExpectedHealthy()
        {
            dataAccess.WritePatientVitalsData(new PatientVitals() { PatientId = "101", Temperature = 97, Spo2 = 94, PulseRate = 70 });
            string str = "Healthy";
            Assert.AreEqual(str, vitalsAlertUponValidation.PatientVitalsAlertUponValidation("101"));


        }
        [TestMethod]
        [ExpectedException(typeof(System.Reflection.TargetException))]
        public void GivenPatientIdDoesntExist_WhenPatientVitalsAlertUponValidation_ThenExpectedException()
        {
          vitalsAlertUponValidation.PatientVitalsAlertUponValidation("110");
        }
        [TestMethod]
        [ExpectedException(typeof(System.Reflection.TargetException))]
        public void GivenPatientIdIsNull_WhenPatientVitalsAlertUponValidation_ThenExpectedException()
        {
            vitalsAlertUponValidation.PatientVitalsAlertUponValidation("");
        }
        [TestCleanup]
        public void TestCleanUp()
        {
            vitalsAlertUponValidation = null;
            dataAccess = null;
        }
    }
}
