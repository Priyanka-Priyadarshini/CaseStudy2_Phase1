using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PatientVitalsDataModelsLib;

namespace PatientVitalsDataGeneratorContractsLib
{
    public interface IPatientVitalsDataGenerator
    {
        PatientVitals GeneratePatientVitals(string patientId);
    }
}
