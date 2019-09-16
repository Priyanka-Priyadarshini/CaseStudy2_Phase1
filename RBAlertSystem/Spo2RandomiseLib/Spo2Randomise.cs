//=============================================================================
// COPYRIGHT KONINKLIJKE PHILIPS ELECTRONICS N.V. 2019
// All rights are reserved. Reproduction in whole or in part is
// prohibited without the written consent of the copyright owner.
//============================================================================= 

using System;
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
