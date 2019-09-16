using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PatientVitalsDataModelsLib;
using VitalSignLib;

namespace DataAccessContractsLib
{
    public interface IDataAccessComponent
    {
        int Count { get; set; }
        PatientVitals ReadPatientVitalsData(string patientId);
        void WritePatientVitalsData(PatientVitals patientVitals);
        void WriteListOfEnabledPatientVitals(string patientID, List<VitalSign> vitalsSigns);
        List<VitalSign> GetEnabledVitalsList(string patientId);
    }
}
