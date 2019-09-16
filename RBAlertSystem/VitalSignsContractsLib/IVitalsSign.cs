using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PatientVitalsType;

namespace VitalSignsContractsLib
{
    public interface IVitalsSign
    {
         bool  IsEnabled { get; set; }
         VitalsType Type { get; set; }
    }

    public class VitalsSign : IVitalsSign
    {
        public bool IsEnabled { get; set; }
        public VitalsType Type { get; set; }
    }
}
