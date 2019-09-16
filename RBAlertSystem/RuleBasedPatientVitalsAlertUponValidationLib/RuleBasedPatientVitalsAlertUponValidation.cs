using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PatientVitalsAlertUponValidationContractsLib;
using DataAccessContractsLib;using InstanceCreatorLib;
using VitalSignLib;
using System.Reflection;
using PatientVitalsValidatorContractsLib;
using PatientVitalsType;
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
                alertMessage=patientVitalsAlerter.SendAlert(item, patientVitals);
            }

            return alertMessage;
        }
        #endregion
    }
}
