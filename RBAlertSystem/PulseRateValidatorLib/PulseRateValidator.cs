using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PatientVitalsValidatorContractsLib;
using ConstantsLib;
namespace PulseRateValidatorLib
{
    /// <summary>
    /// This class generates the validates the Pulserate value.
    /// </summary>
    public class PulseRateValidator : IPatientVitalsValidate
    {
        #region Methods
        /// <summary>
        /// This function validatees the spo2 value
        /// </summary>
        /// <param name="vitalValue"></param>
        /// <returns>bool value</returns>
        readonly Constants constants = new Constants();
        public bool Validate(double vitalValue)
        {
            if (vitalValue >= constants.PulseRateMin && vitalValue <= constants.PulseRateMax)
                return true;
            return false;
        }
        #endregion
    }
}
