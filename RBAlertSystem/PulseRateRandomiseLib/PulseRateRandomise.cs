using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PatientVitalsRandomiseContractsLib;

namespace PulseRateRandomiseLib
{
    /// <summary>
    /// This class generates the random data for Pulserate.
    /// </summary>
    public class PulseRateRandomise : IPatientVitalsRandomise
    {
        /// <summary>
        /// This function returns a random value for Pulserate
        /// </summary>
        /// <returns>double</returns>
        public double RandomPatientVital()
        {
            Random random = new Random();
            return random.Next(61,67);
        }
    }
}
