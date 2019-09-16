using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PatientVitalsRandomiseContractsLib;
namespace Spo2RandomiseLib
{
    /// <summary>
    /// This class generates the random data for SPO2.
    /// </summary>
    public class Spo2Randomise : IPatientVitalsRandomise
    {
        /// <summary>
        /// This function returns a random value for Spo2
        /// </summary>
        /// <returns>double</returns>

        public double RandomPatientVital()
        {
            Random random = new Random();
            return random.Next(91, 98);
        }
    }
}
