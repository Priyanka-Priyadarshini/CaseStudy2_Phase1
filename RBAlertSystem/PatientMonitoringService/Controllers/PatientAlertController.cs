//=============================================================================
// COPYRIGHT KONINKLIJKE PHILIPS ELECTRONICS N.V. 2019
// All rights are reserved. Reproduction in whole or in part is
// prohibited without the written consent of the copyright owner.
//============================================================================= 

using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using PatientVitalsAlertUponValidationContractsLib;
using RuleBasedPatientVitalsAlertUponValidationLib;
using PatientVitalsDataModelsLib;
using InstanceCreatorLib;
using DataAccessContractsLib;using DataAccessLib;

namespace PatientAlertingService.Controllers
{
    /// <summary>
/// This class validates the patient vitals data and then gives the alert message.
/// </summary>
    [Route("api/[controller]/[Action]")]
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

        public string PatientVitalsAlert(string patientId )
        {
            IPatientVitalsAlertUponValidation alertUponValidation = new RuleBasedPatientVitalsAlertUponValidation(dataAccess);
            return alertUponValidation.PatientVitalsAlertUponValidation(patientId);
        }
        #endregion
    }
}
