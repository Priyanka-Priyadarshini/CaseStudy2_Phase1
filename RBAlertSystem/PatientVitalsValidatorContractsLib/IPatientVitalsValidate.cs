using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PatientVitalsValidatorContractsLib
{
    public interface IPatientVitalsValidate
    {
        bool Validate(double vitalValue);
    }
}
