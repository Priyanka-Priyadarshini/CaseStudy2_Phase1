using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PatientVitalsDataModelsLib
{
    public class PatientVitals
    {
        public string PatientId { get; set; }
        public double Spo2 { get; set; }
        public double PulseRate { get; set; }
        public double Temperature { get; set; }
    }
}
