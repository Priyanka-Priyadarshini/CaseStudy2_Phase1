//=============================================================================
// COPYRIGHT KONINKLIJKE PHILIPS ELECTRONICS N.V. 2019
// All rights are reserved. Reproduction in whole or in part is
// prohibited without the written consent of the copyright owner.
//============================================================================= 

using System;
using System.Collections.Generic;
using PatientVitalsDataGeneratorContractsLib;
using PatientVitalsDataModelsLib;
using InstanceCreatorLib;
using DataAccessContractsLib;
using System.Reflection;
using PatientVitalsRandomiseContractsLib;
using VitalSignLib;
namespace PatientVitalsDataGeneratorLib
{
    /// <summary>
    /// This class randomly generates the patient data of the enabled patient vitals .
    /// </summary>
    public class PatientVitalsDataGenerator : IPatientVitalsDataGenerator
    {
        #region Member
        private readonly IDataAccessComponent _dataAccessComponent;
        readonly PatientVitals patientVitals = new PatientVitals();

        #endregion
        #region Constructor
        public PatientVitalsDataGenerator(IDataAccessComponent dataAccessComponent)
        {
            this._dataAccessComponent = dataAccessComponent;
        }
        #endregion
        #region Methods
        /// <summary>
        /// It randomly generates the values of the enabled patientVitals for a particular patient
        /// </summary>
        /// <param name="patientId"></param>
        /// <returns>object of class PatientVitals that contains values of selected vitals</returns>        
        public PatientVitals GeneratePatientVitals(string patientId)
        {
            patientVitals.PatientId = patientId;
            List<VitalSign> enabledVitalsList = _dataAccessComponent.GetEnabledVitalsList(patientId);
            foreach (var item in enabledVitalsList)
            {
                if(item.IsEnabled)
                {
                    PropertyInfo property = typeof(PatientVitals).GetProperty(item.Type.ToString());
                    var vitalRandomise = InstanceCreator.Create_Instance(property.Name, "Randomise") as IPatientVitalsRandomise;
                    property.SetValue(patientVitals, vitalRandomise.RandomPatientVital());
                }
               
            }
            return patientVitals;
        }
        #endregion
    }
}
