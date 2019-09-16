using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using PatientVitalsDataModelsLib;
using VitalSignLib;
using PatientVitalsType;using InstanceCreatorLib;
using PatientVitalsValidatorContractsLib;


namespace PatientVitalsAlerterLib
{
    /// <summary>
    /// This class calls the required validators and sends alert message
    /// </summary>
    public class PatientVitalsAlerter
    {
        /// <summary>
        /// This function returns alert message after validation of vital signs
        /// </summary>
        /// <param name="item"></param>
        /// <param name="patientVitals"></param>
        /// <returns>alert message</returns>
        public string SendAlert(VitalSign item , PatientVitals patientVitals)
        {
            StringBuilder stringBuilder = new StringBuilder("Healthy", 40);
            if (item.IsEnabled)
            {

                PropertyInfo property = typeof(PatientVitals).GetProperty(item.Type.ToString());
                var vitalsValidator = InstanceCreator.Create_Instance(property.Name, "Validator") as IPatientVitalsValidate;
                if (!vitalsValidator.Validate((double)property.GetValue(patientVitals)))
                {
                    stringBuilder.Replace("Healthy", "");
                    stringBuilder.Append(property.Name + "Alert ");
                }
            }
            return stringBuilder.ToString();
        }
    }
}
