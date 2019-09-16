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
using DataAccessContractsLib;
using VitalSignLib;
using GlobalShareLib;using PatientVitalsDataModelsLib;

namespace DataAccessLib
{
    /// <summary>
    /// This is the Data Access layer...accessing the Global Share memory that consists of patient-data
    /// </summary>
    public class DataAccess : IDataAccessComponent
    {
        public int Count { get; set; }

        #region Methods
        /// <summary>
        /// This function reads the values of the vitals(SPO2,Temp,PulseRate) that was generated & stored of a particular patient if it exists
        /// </summary>
        /// <param name="patientId"></param>
        /// <returns>obj of PatientVitals else null</returns>
        public PatientVitals ReadPatientVitalsData(string patientId)
        {
            Queue<PatientVitals> patientVitalsData = null;
            if (GlobalShare.PatientVitalsignDataDict.TryGetValue(patientId, out patientVitalsData))
            {
                PatientVitals patientVitals = patientVitalsData.Dequeue();
                return patientVitals;
            }
            return null;
        }
        /// <summary>
        /// This function writes the generated values of the enabled vitals for a paticular patient
        /// </summary>
        /// <param name="patientVitals"></param>
       
        public void WritePatientVitalsData(PatientVitals patientVitals)
        {
            Queue<PatientVitals> patientVitalsQueue;
            if (GlobalShare.PatientVitalsignDataDict.TryGetValue(patientVitals.PatientId, out patientVitalsQueue))
            {
                patientVitalsQueue.Enqueue(patientVitals);
                GlobalShare.PatientVitalsignDataDict[patientVitals.PatientId] = patientVitalsQueue;
            }
           else 
           {
                patientVitalsQueue = new Queue<PatientVitals>();
                patientVitalsQueue.Enqueue(patientVitals);
                GlobalShare.PatientVitalsignDataDict.Add(patientVitals.PatientId, patientVitalsQueue);
            }
           

        }
        /// <summary>
        /// This function writes the list of patient-vitals enabled for a particular patient
        /// </summary>
        /// <param name="patientID"></param>
        /// <param name="vitalsSigns"></param>
        public void WriteListOfEnabledPatientVitals(string patientID, List<VitalSign> vitalsSigns)
        {
            if (GlobalShare.PatientVitalsignMap.ContainsKey(patientID))
            {
                GlobalShare.PatientVitalsignMap[patientID] = vitalsSigns;
            }
            else
            {
                GlobalShare.PatientVitalsignMap.Add(patientID, vitalsSigns);
                Count++;
            }
           
        }
        /// <summary>
        /// This function returns the list of enabled patient-vitals for a particular patient.
        /// If it doesn't exist, default vitals list is returned
        /// </summary>
        /// <param name="patientId"></param>
        /// <returns>List of enabled patient-vitals</returns>
        public List<VitalSign> GetEnabledVitalsList(string patientId)
        {
            List<VitalSign> enabledVitalsList = null;
            GlobalShare.PatientVitalsignMap.TryGetValue(patientId, out enabledVitalsList);
            if (enabledVitalsList!=null) //getting list of enabled vitals
            {
               return enabledVitalsList;
            }
            return GlobalShare.DefaultVitalsList;
        }
        #endregion
    }
}
