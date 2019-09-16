//=============================================================================
// COPYRIGHT KONINKLIJKE PHILIPS ELECTRONICS N.V. 2019
// All rights are reserved. Reproduction in whole or in part is
// prohibited without the written consent of the copyright owner.
//============================================================================= 
using System;
using System.Collections.Generic;
using IEnableVitalsContractsLib;
using VitalSignLib;
using DataAccessContractsLib;
using PatientVitalsType;


namespace EnablePatientVitalsLib
{
    /// <summary>
    /// This class is used to select the patient vitals specifically required for a given patientId.
    /// </summary>
    public class EnablePatientVitals : IEnablePatientVitals
    {
        #region Member
        private readonly IDataAccessComponent _dataAccessComponent;
    
        #endregion
       
        #region Constructor
        public EnablePatientVitals(IDataAccessComponent dataAccessComponent)
        {
            this._dataAccessComponent = dataAccessComponent;
        }

      
        #endregion
        #region Methods
        /// <summary>
        /// This function enables the selected patient-vitals for a particular patient
        /// </summary>
        /// <param name="patientId"></param>
        /// <param name="vitalsSigns"></param>
        public void EnableSelectedPatientVitals(string patientId, List<VitalSign> vitalsSigns)
        {
            foreach (var item in vitalsSigns)
            {
                if (!Enum.IsDefined(typeof(VitalsType), item.Type))
                    throw new ArgumentException("Vital type not found");    
            }
            _dataAccessComponent.WriteListOfEnabledPatientVitals(patientId, vitalsSigns);
            
        }
        #endregion
    }
}
