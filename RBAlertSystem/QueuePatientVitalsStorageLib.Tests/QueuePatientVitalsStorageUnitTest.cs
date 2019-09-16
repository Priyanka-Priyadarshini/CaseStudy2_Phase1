//=============================================================================
// COPYRIGHT KONINKLIJKE PHILIPS ELECTRONICS N.V. 2019
// All rights are reserved. Reproduction in whole or in part is
// prohibited without the written consent of the copyright owner.
//============================================================================= 

using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using DataAccessContractsLib;
using QueuePatientVitalsStorageLib;
using PatientVitalsDataModelsLib;

namespace QueuePatientVitalsStorageLib.Tests
{
    [TestClass]
    public class QueuePatientVitalsStorageUnitTest
    {
        Moq.Mock<IDataAccessComponent> _mockObj;
        IDataAccessComponent neighbourRef;
        QueuePatientVitalsStorage patientVitalsStorage;
        PatientVitals patientVitals;

        [TestInitialize]
        public void Init()
        {
            patientVitals = new PatientVitals() { PatientId="",Spo2=98,PulseRate=67,Temperature=98};
            _mockObj = new Moq.Mock<IDataAccessComponent>();
            neighbourRef = _mockObj.Object;
            patientVitalsStorage = new QueuePatientVitalsStorage(neighbourRef);
            _mockObj.Setup(f => f.WritePatientVitalsData(null)).Throws<ArgumentNullException>();
            _mockObj.Setup(f => f.WritePatientVitalsData(patientVitals)).Throws<ArgumentNullException>();
        }
        [TestMethod]
        [ExpectedException(typeof(System.ArgumentException))]
        public void GivenPatientIdIsNull_WhenStorePatientVitalsDataCalled_ExpectedException()
        {
            neighbourRef = _mockObj.Object;
            patientVitalsStorage.StorePatientVitalsData(patientVitals);
        }
        [TestMethod]
        public void GivenPatientVitals_WhenStorePatientVitalsDataCalled_ExpectedMokerFunctionCalledOnce()
        {
            PatientVitals patientVitalsData = new PatientVitals() { PatientId = "101", Spo2 = 88, Temperature = 97, PulseRate = 70 };
            patientVitalsStorage.StorePatientVitalsData(patientVitalsData);
            _mockObj.Verify(neighbour => neighbour.WritePatientVitalsData(patientVitalsData), Moq.Times.Exactly(1));
        }
       
        [TestMethod]
        public void GivenSamePatientIdTwice_WhenStorePatientVitalsDataCalled_ExpectedMokerFunctionCalledTwice()
        {
            PatientVitals patientVitalsData = new PatientVitals() { PatientId = "101", Spo2 = 88, Temperature = 97, PulseRate = 70 };
            patientVitalsStorage.StorePatientVitalsData(patientVitalsData);
            patientVitalsStorage.StorePatientVitalsData(patientVitalsData);
            _mockObj.Verify(neighbour => neighbour.WritePatientVitalsData(patientVitalsData), Moq.Times.Exactly(2));
        }
        [TestCleanup]
        public void TestCleanUp()
        {
            _mockObj=null;
            neighbourRef=null;
            patientVitalsStorage=null;
            patientVitals=null;

        }
    }
}
