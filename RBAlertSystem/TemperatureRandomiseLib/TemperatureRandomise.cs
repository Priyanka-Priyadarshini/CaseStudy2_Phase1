//=============================================================================
// COPYRIGHT KONINKLIJKE PHILIPS ELECTRONICS N.V. 2019
// All rights are reserved. Reproduction in whole or in part is
// prohibited without the written consent of the copyright owner.
//============================================================================= 

using System;
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
