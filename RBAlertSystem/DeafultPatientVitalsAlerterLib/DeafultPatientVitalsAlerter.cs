using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using PatientVitalsAlerterContractsLib;
using PatientVitalsDataModelsLib;
using PatientVitalsValidatorContractsLib;
using InstanceCreatorLib;using GlobalShareLib;using VitalSignLib;
using SPO2ValidatorLib;using TemperatureValidatorLib;using PulseRateValidatorLib;
using DataAccessContractsLib;
using DataAccessLib;

namespace DeafultPatientVitalsAlerterLib
{
    /// <summary>
    /// It validates the patient vitals data and then generates the  required alert message
    /// </summary>
    public class DeafultPatientVitalsAlerter : IPatientVitalsAlerter
    {
        public string alertMessage { get; set; } = "Healthy";

        public string PatientVitalsAlert(string patientId)
        {
            IDataAccessComponent dataAccess = InstanceCreator.Create_Instance("DataAccess", "") as IDataAccessComponent;
            PatientVitals patientVitals= dataAccess.ReadPatientVitalsData(patientId);
            List<VitalSign> enabledVitalsList = dataAccess.GetEnabledVitalsList(patientId);
            foreach (var item in enabledVitalsList)
            {
                if (item.IsEnabled)
                {
                    PropertyInfo property = typeof(PatientVitals).GetProperty(item.Type.ToString());
                    var vitalsValidator = InstanceCreator.Create_Instance(property.Name, "Validator") as IPatientVitalsValidate;
                    if (!vitalsValidator.Validate((double)property.GetValue(patientVitals)))
                        alertMessage += property.Name + "Alert ";
                }

            }
            
            return alertMessage;
        }
    }
}
