using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PatientVitalsDataReaderContractsLib;
using PatientVitalsDataModelsLib;
using Newtonsoft.Json;

namespace PatientVitalsDataJsonReaderLib
{
    public class PatientVitalsDataJsonReader : IPatientVitalsDataReader
    {
        
        public void PatientVitalsRead(string patientData)
        {
            var patient = JsonConvert.DeserializeObject<dynamic>(patientData);
        }
    }
}
