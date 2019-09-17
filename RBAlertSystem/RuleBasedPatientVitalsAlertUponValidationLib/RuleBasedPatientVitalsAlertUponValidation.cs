//=============================================================================
// COPYRIGHT KONINKLIJKE PHILIPS ELECTRONICS N.V. 2019
// All rights are reserved. Reproduction in whole or in part is
// prohibited without the written consent of the copyright owner.
//============================================================================= 

using System;
using System.Collections.Generic;
using PatientVitalsAlertUponValidationContractsLib;
using DataAccessContractsLib;
using VitalSignLib;
using PatientVitalsDataModelsLib;
using PatientVitalsAlerterLib;

namespace RuleBasedPatientVitalsAlertUponValidationLib
{
    /// <summary>
    /// It validates the patient vitals data and then generates the  required alert message
    /// </summary>
    public class RuleBasedPatientVitalsAlertUponValidation:IPatientVitalsAlertUponValidation
    {
        #region Member
        private readonly IDataAccessComponent _dataAccessComponent;

        #endregion

        #region Constructor
        public RuleBasedPatientVitalsAlertUponValidation(IDataAccessComponent dataAccessComponent)
        {
            this._dataAccessComponent = dataAccessComponent;
        }

        #endregion
        #region Methods
      /// <summary>
      /// This function returns alert messsage depending upon the validation of the vitals values of a particular patient
      /// </summary>
      /// <param name="patientId"></param>
      /// <returns>AlertMessage</returns>

        public string PatientVitalsAlertUponValidation(string patientId)
        {
            PatientVitalsAlerter patientVitalsAlerter = new PatientVitalsAlerter();
           string alertMessage = "";
            PatientVitals patientVitals = _dataAccessComponent.ReadPatientVitalsData(patientId);
            List<VitalSign> enabledVitalsList = _dataAccessComponent.GetEnabledVitalsList(patientId);
            foreach (var item in enabledVitalsList)
            {
                alertMessage+=patientVitalsAlerter.SendAlert(item, patientVitals);
            }
             if (alertMessage == "")
                alertMessage = "Healthy";
            return alertMessage;
        }
        #endregion
    }
}
