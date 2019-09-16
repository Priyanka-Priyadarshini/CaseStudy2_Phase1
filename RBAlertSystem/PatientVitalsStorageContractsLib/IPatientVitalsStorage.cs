using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PatientVitalsDataModelsLib;

namespace PatientVitalsStorageContractsLib
{
    public interface IPatientVitalsStorage
    {
        void StorePatientVitalsData(PatientVitals patientVitals);
    }
}
