//=============================================================================
// COPYRIGHT KONINKLIJKE PHILIPS ELECTRONICS N.V. 2019
// All rights are reserved. Reproduction in whole or in part is
// prohibited without the written consent of the copyright owner.
//============================================================================= 

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BedAllotmentManagementLib;
using BedConfigurationAccessLib;

namespace PatientRegistrationDeskLib
{
    /// <summary>
    /// This class is used to discharge patient
    /// </summary>
    public class PatientRegistrationDesk
    {
        #region Members
        private readonly BedConfigurationAccess _bedConfiguration;
        private readonly BedAllotmentManangement _bedAllotmentManangement;
        #endregion
        #region Constructor
        public PatientRegistrationDesk(BedAllotmentManangement bedAllotmentManangement,BedConfigurationAccess bedConfiguration)
        {
            _bedConfiguration = bedConfiguration;
            _bedAllotmentManangement = bedAllotmentManangement;
        }
        #endregion
        #region Methods
        /// <summary>
        /// This function is used to discharge a patient by patientId
        /// </summary>
        /// <param name="patientId"></param>
        public void DischargePatient(string patientId)
        {
           int bedNo= _bedAllotmentManangement.GetAllotedBedNo(patientId);
            _bedAllotmentManangement.DeAllotBed(bedNo);
            _bedConfiguration.UpdateBedConfiguration(bedNo);

        }
        #endregion
    }
}
