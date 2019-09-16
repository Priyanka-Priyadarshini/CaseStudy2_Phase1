//=============================================================================
// COPYRIGHT KONINKLIJKE PHILIPS ELECTRONICS N.V. 2019
// All rights are reserved. Reproduction in whole or in part is
// prohibited without the written consent of the copyright owner.
//============================================================================= 

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PatientVitalsAlertUponValidationContractsLib
{
    public interface IPatientVitalsAlertUponValidation
    {
        string PatientVitalsAlertUponValidation(string patientId);
    }
}
