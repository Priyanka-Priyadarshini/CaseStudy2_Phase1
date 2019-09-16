using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PatientVitalsRandomiseContractsLib;

namespace TemperatureRandomiseLib
{
    /// <summary>
    /// This class generates the random data for Temperature.
    /// </summary>
    public class TemperatureRandomise : IPatientVitalsRandomise
    {
        /// <summary>
        /// This function returns a random value for Temperature
        /// </summary>
        /// <returns>double</returns>

        public double RandomPatientVital()
        {
            Random random = new Random();
            return random.Next(90, 110);
        }
    }
}
