using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using PatientVitalsAlertUponValidationContractsLib;
using RuleBasedPatientVitalsAlertUponValidationLib;
using DataAccessContractsLib;using DataAccessLib;
using PatientVitalsDataModelsLib;
using InstanceCreatorLib;

namespace PatientAlertingService.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PatientAlertController : ControllerBase
    {
        #region Members
        readonly IDataAccessComponent dataAccess = new DataAccess();
        #endregion
        #region Post Methods
        /// <summary>
        /// This function provides the alert depending upon the validation of the patient vitals data .
        /// </summary>

        [HttpPost]
        [ActionName("PatientVitalsAlertUponValidation")]

        public string PatientVitalsAlert(string patientId)
        {
            IPatientVitalsAlertUponValidation alertUponValidation = new RuleBasedPatientVitalsAlertUponValidation(dataAccess);
            return alertUponValidation.PatientVitalsAlertUponValidation(patientId);
        }
        #endregion
    }
}
