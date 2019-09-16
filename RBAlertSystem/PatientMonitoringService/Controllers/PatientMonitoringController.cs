using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using VitalSignLib;
using IEnableVitalsContractsLib;
using EnablePatientVitalsLib;
using DataAccessContractsLib;using DataAccessLib;
using PatientVitalsDataGeneratorLib;
using PatientVitalsDataGeneratorContractsLib;
using PatientVitalsDataModelsLib;
using InstanceCreatorLib;

namespace PatientMonitoringService.Controllers
{
    /// <summary>
    /// This class monitors the patients data.
    /// It helps enable the required patient vitals and then generate values of those vitals...
    /// 
    /// </summary>
    [Route("api/[controller]/[Action]")]
    [ApiController]
    public class PatientMonitoringController : ControllerBase
    {
        #region Members
        readonly IDataAccessComponent dataAccess = new DataAccess();
        #endregion
        #region Post Methods
        /// <summary>
        /// It enables the selected patient vitals
        /// </summary>
        /// <param name="patientId"></param>
        /// <param name="vitalsSigns"></param>
        [HttpPost]
        [ActionName("EnablePatientVitals")]
        public void EnablePatientVitals(string patientId, [FromBody]List<VitalSign> vitalsSigns)
        {
            IEnablePatientVitals enablePatientVitals = new EnablePatientVitals(dataAccess);
             enablePatientVitals.EnableSelectedPatientVitals(patientId, vitalsSigns);
            
        }

        /// <summary>
        /// It generates values for the enabled patient-vitals for a particular patient
        /// </summary>
        /// <param name="patientId"></param>
        /// <returns>obj of PatientVitals</returns>
        [HttpPost]
        [ActionName("GeneratePatientVitals")]
        public PatientVitals GeneratePatientVitals(string patientId)
        {
            IPatientVitalsDataGenerator patientVitalsGenerator = new PatientVitalsDataGenerator(dataAccess);
            return patientVitalsGenerator.GeneratePatientVitals(patientId);
           
        }
        #endregion
    }
}
