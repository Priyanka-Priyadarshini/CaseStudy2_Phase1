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

namespace ConstantsLib
{
   
    public class Constants
    {
       
        public double TempMax { get; set; } = 99.0;
        public double TempMin { get; set; } = 97.0;
        public double Spo2Max { get; set; } = 95.0;
        public double Spo2Min { get; set; } = 91.0;
        public double PulseRateMax { get; set; } = 100.0;
        public double PulseRateMin { get; set; } = 60.0;

      

       
    }
}
