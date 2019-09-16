using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PatientVitalsValidatorContractsLib;
using ConstantsLib;

namespace TemperatureValidatorLib
{
    /// <summary>
    /// This class generates the validates the Temperature value.
    /// </summary>
    public class TemperatureValidator : IPatientVitalsValidate
    {
        readonly Constants constants = new Constants();
        #region Methods
        /// <summary>
        /// This function validatees the temperature value
        /// </summary>
        /// <param name="vitalValue"></param>
        /// <returns>bool value</returns>
        public bool Validate(double vitalValue)
        {
            if (vitalValue >= constants.TempMin && vitalValue <= constants.TempMax)
                return true;
             return false;
        }
        #endregion
    }
}
