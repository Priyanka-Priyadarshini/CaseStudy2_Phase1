using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using GlobalShareLib;
using PatientVitalsDataModelsLib;using VitalSignLib;
using PatientVitalsType;
using System.Collections.Generic;

namespace DataAccessLib.Tests
{
    [TestClass]
    public class DataAccessUnitTest
    {
        DataAccess dataAccess;
       PatientVitals patientVitalsData;
        PatientVitals patientVitalsData2;
        List<VitalSign> enabledVitalsList;
        List<VitalSign> diffVitalsList;
      [TestInitialize]
        public void TestInit()
        {
            dataAccess = new DataAccess();
            patientVitalsData = new PatientVitals() { PatientId = "TRIW10", Spo2 = 88, Temperature = 97, PulseRate = 70 };

            enabledVitalsList = new List<VitalSign>
              {
                 new VitalSign{IsEnabled=true,Type=VitalsType.Spo2},
              };
           diffVitalsList = new List<VitalSign>
              {
                 new VitalSign{IsEnabled=true,Type=VitalsType.Spo2},
                 new VitalSign{IsEnabled=true,Type=VitalsType.PulseRate}
              };
            patientVitalsData2 = new PatientVitals() { PatientId = "102", Spo2 = 88, Temperature = 97, PulseRate = 70 };

        }
        #region Test Methods for WritePatientVitalsData() function
        [TestMethod]
        public void GivenPatientVitals_WhenWritePatientVitalsDataCalled_ExpectedGlobalCountOne()
        {
            dataAccess.WritePatientVitalsData(patientVitalsData);
            Assert.AreEqual(true, GlobalShare.PatientVitalsignDataDict.ContainsKey("TRIW10"));
        }
        [TestMethod]
        public void GivenDifferentPatientId_WhenWritePatientVitalsDataCalled_ExpectedGlobalCountTwice()
        {
            dataAccess.WritePatientVitalsData(patientVitalsData);
            dataAccess.WritePatientVitalsData(patientVitalsData2);
            Assert.AreEqual(2, GlobalShare.PatientVitalsignDataDict.Count);
        }
        #endregion
        #region Test methods for ReadPatientVitalsData() function
        [TestMethod]
        public void GivenPatientIdIsStored_WhenReadPatientVitalsDataCalled_ThenExpectedPatientVitalsData()
        {
           
            dataAccess.WritePatientVitalsData(patientVitalsData);
            Assert.AreEqual(false,GlobalShare.PatientVitalsignMap.ContainsKey("TRIW10"));
        }
        [TestMethod]
        public void GivenPatientIdNotStoredBefore_WhenReadPatientVitalsDataCalled_ThenExpectedNull()
        {
            Assert.AreEqual(null,dataAccess.ReadPatientVitalsData("11"));
        }
       
        #endregion
      
        #region Test Methods for GetEnabledPatientVitalsList() function
        [TestMethod]
        public void GivenPatientIdWhosePatientVitalsNotEnabled_WhenGetEnabledPatientVitalsListCalled_ThenExpectedDefaultVitalsList()
        {
            Assert.AreEqual(GlobalShare.DefaultVitalsList, dataAccess.GetEnabledVitalsList("110"));
        }
        [TestMethod]
        public void GivenPatientIdWhosePatientVitalsEnabled_WhenGetEnabledPatientVitalsListCalled_ThenExpectedEnabledVitalsList()
        {
            dataAccess.WriteListOfEnabledPatientVitals("101", enabledVitalsList);
            Assert.AreEqual(enabledVitalsList,dataAccess.GetEnabledVitalsList("101"));
        }
        #endregion
        #region Test Methods For WriteListOfEnabledPatientVitals() function
        [TestMethod]
        public void GivenEnabledPatientVitalsListForPatientId_WhenWriteListOfEnabledPatientVitals_ThenExpectedGlobalCountOne()
        {
            dataAccess.WriteListOfEnabledPatientVitals("101", enabledVitalsList);
            Assert.AreEqual(1,GlobalShare.PatientVitalsignMap.Count);
        }
        [TestMethod]
        public void GivenDifferentListForExistingPatientIdWithEnabledPatientVitals_WhenWriteListOfEnabledPatientVitals_ThenExpectedGlobalCountOne()
        {
            dataAccess.WriteListOfEnabledPatientVitals("101", enabledVitalsList);
            dataAccess.WriteListOfEnabledPatientVitals("101",diffVitalsList);
            Assert.AreEqual(diffVitalsList,dataAccess.GetEnabledVitalsList("101"));
        }
        [TestMethod]
        public void GivenTwoPatientIdsWithEnabledVitalsList_WhenWriteListOfEnabledPatientVitals_ThenExpectedGlobalCountTwo()
        {
            dataAccess.WriteListOfEnabledPatientVitals("101", enabledVitalsList);
            dataAccess.WriteListOfEnabledPatientVitals("102", enabledVitalsList);
            Assert.AreEqual(2, GlobalShare.PatientVitalsignMap.Count);
        }
        #endregion
        [TestCleanup]
        public void TestCleanUp()
        {
            dataAccess = null;
        }
    }
}
