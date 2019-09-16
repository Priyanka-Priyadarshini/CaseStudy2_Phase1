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

using BedConfigurationAccessLib;
using BedAllotmentManagementLib;
using PatientRegistrationDeskLib;


namespace BedConfigureService.Controllers
{
    /// <summary>
    /// This class is used for configuration and allotmentment of beds and discharge of patients
    /// </summary>
    [Route("api/[controller]/[Action]")]
    [ApiController]
    public class BedConfigurationController : ControllerBase
    {
        #region Members
        readonly BedConfigurationAccess bedConfigurationAccess = new BedConfigurationAccess();
        #endregion
        #region Post Methods
        /// <summary>
        /// This function is used to Configure a bed .
        /// </summary>
        /// <param name="bedConfigurationList"></param>       
        [HttpPost]
        [ActionName("ConfigureBed")]
        public void ConfigureBed(int bedNo)
        {
            bedConfigurationAccess.ConfigureBed(bedNo);
        }
        /// <summary>
        /// This function is used to allot a bed to the patient,if available.
        /// </summary>
        /// <param name="patientId"></param>
        [HttpPost]
        [ActionName("AllotBed")]
        public void AllotBed(string patientId)
        {
            BedAllotmentManangement bedAllotment = new BedAllotmentManangement(bedConfigurationAccess);
            bedAllotment.AllotBedToPatient(patientId);
            
        }
        /// <summary>
        /// This function is used to discharge a patient
        /// </summary>
        /// <param name="patientId"></param>
        [HttpPost]
        [ActionName("DischargePatient")]
        public void DischargePatient(string patientId)
        {
            BedAllotmentManangement bedAllotment = new BedAllotmentManangement(bedConfigurationAccess);
            PatientRegistrationDesk registrationDesk = new PatientRegistrationDesk(bedAllotment,bedConfigurationAccess);
            registrationDesk.DischargePatient(patientId);

        }
        #endregion

    }
}
