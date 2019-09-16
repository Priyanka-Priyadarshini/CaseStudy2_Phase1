using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PatientVitalsValidatorContractsLib;
using ConstantsLib;

namespace Spo2ValidatorLib
{
    /// <summary>
    /// This class generates the validates the SPo2 value.
    /// </summary>
    public class Spo2Validator : IPatientVitalsValidate
    {

        readonly Constants constants = new Constants();
        #region Methods
        /// <summary>
        /// This function validatees the spo2 value
        /// </summary>
        /// <param name="vitalValue"></param>
        /// <returns>bool value</returns>
        public bool Validate(double vitalValue)
        {
            if (vitalValue >= constants.Spo2Min && vitalValue <= constants.Spo2Max)
                return true;
            return false;
        }
        #endregion
    }
}
