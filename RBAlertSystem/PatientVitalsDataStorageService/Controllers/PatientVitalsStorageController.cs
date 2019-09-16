using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using PatientVitalsStorageContractsLib;
using PatientVitalsDataModelsLib;
using QueuePatientVitalsStorageLib;
using InstanceCreatorLib;
using DataAccessContractsLib;using DataAccessLib;

namespace PatientVitalsDataStorageService.Controllers
{
    /// <summary>
    /// This class stores the patient vitals data into a global share.
    /// </summary>
    [Route("api/[controller]/[Action]")]
    [ApiController]
    public class PatientVitalsStorageController : ControllerBase
    {
        #region Member
        readonly IDataAccessComponent dataAccess = new DataAccess();
        #endregion
        #region Post Methods
        /// <summary>
        /// It stores the values of the patient-vitals for a particular patient
        /// </summary>
        /// <param name="patientVitals"></param>
        [HttpPost]
        [ActionName("StorePatientVitals")]
        public void StorePatientVitals([FromBody]PatientVitals patientVitals)
        {
            IPatientVitalsStorage patientVitalsStorage = new QueuePatientVitalsStorage(dataAccess);
            patientVitalsStorage.StorePatientVitalsData(patientVitals);

        }
        #endregion
    }
}
