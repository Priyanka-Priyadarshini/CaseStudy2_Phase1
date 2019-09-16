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
using PatientVitalsDataModelsLib;
using VitalSignLib;
using PatientVitalsType;

namespace GlobalShareLib
{
    /// <summary>
    /// This class acts as a Patient Data Storage:
    /// 1) stores patientId with the liast of enabled patient vitals
    /// 2) stores patientId with its generated patient data for each enabled vitals
    /// </summary>
    public static class GlobalShare
    {
        private static Dictionary<string, List<VitalSign>> patientVitalsignMap = new Dictionary<string, List<VitalSign>>();
        private static Dictionary<string, Queue<PatientVitals>> patientVitalsignDataDict = new Dictionary<string, Queue<PatientVitals>>();

        public static Dictionary<string, List<VitalSign>> PatientVitalsignMap
        {
            get
            {
                return patientVitalsignMap;
            }
        }

        public static Dictionary<string, Queue<PatientVitals>> PatientVitalsignDataDict
        {
            get
            {
                return patientVitalsignDataDict;
            }
        }

        public static List<VitalSign> DefaultVitalsList { get; set; } = new List<VitalSign>
        {
            new VitalSign{IsEnabled=true,Type=VitalsType.Spo2},
            new VitalSign{IsEnabled=true,Type=VitalsType.PulseRate},
            new VitalSign{IsEnabled=true,Type=VitalsType.Temperature}
        };
    }   

}
