//=============================================================================
// COPYRIGHT KONINKLIJKE PHILIPS ELECTRONICS N.V. 2019
// All rights are reserved. Reproduction in whole or in part is
// prohibited without the written consent of the copyright owner.
//============================================================================= 

using System;
using DataAccessContractsLib;
using DataAccessLib;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using PatientVitalsDataModelsLib;

namespace PatientVitalsDataGeneratorLib.Tests
{
    [TestClass]
    public class PatientVitalsDataGeneratorUnitTest
    {
        PatientVitalsDataGenerator dataGenerator;
        IDataAccessComponent dataAccess;

        [TestInitialize]
        public void Init()
        {
            dataAccess = new DataAccess();
            dataGenerator = new PatientVitalsDataGenerator(dataAccess);

        }
        [TestMethod]
        public void GivenPatientId_WhenGeneratePatientVitals_ExpectedPatientVitalsObject()
        {
            var obj=dataGenerator.GeneratePatientVitals("q101");
            Assert.AreEqual(true,obj !=null);
        }
        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void GivenPatientIdNull_WhenGeneratePatientVitals_ExpectedException()
        {
             dataGenerator.GeneratePatientVitals(null);
           
        }
        [TestCleanup]
        public void TestCleanUp()
        {
            dataGenerator = null;
            dataAccess = null;
        }
    }
}
