//=============================================================================
// COPYRIGHT KONINKLIJKE PHILIPS ELECTRONICS N.V. 2019
// All rights are reserved. Reproduction in whole or in part is
// prohibited without the written consent of the copyright owner.
//============================================================================= 
using System.Collections.Generic;
using VitalSignLib;
using DataAccessContractsLib;

namespace IEnableVitalsContractsLib
{
    public interface IEnablePatientVitals
    {

        void EnableSelectedPatientVitals(string patientId, List<VitalSign> vitalsSigns);
    }
}
