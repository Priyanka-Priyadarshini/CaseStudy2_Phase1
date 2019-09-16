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
