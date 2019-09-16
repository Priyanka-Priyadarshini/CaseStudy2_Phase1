﻿//=============================================================================
// COPYRIGHT KONINKLIJKE PHILIPS ELECTRONICS N.V. 2019
// All rights are reserved. Reproduction in whole or in part is
// prohibited without the written consent of the copyright owner.
//============================================================================= 

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PatientVitalsStorageContractsLib;
using PatientVitalsDataModelsLib;
using DataAccessContractsLib;

namespace QueuePatientVitalsStorageLib
{
    /// <summary>
    /// This class stores the patient data to the in-memory in the form of a queue.
    /// </summary>
    public class QueuePatientVitalsStorage : IPatientVitalsStorage
    {
        #region Member
        private readonly IDataAccessComponent _dataAccessComponent;
       
        #endregion

        #region Constructor
        public QueuePatientVitalsStorage(IDataAccessComponent dataAccessComponent)
        {
            this._dataAccessComponent = dataAccessComponent;
        }

        #endregion
        #region Methods
        /// <summary>
        /// This function stores the values of the patient-vitals generated for a particular patient
        /// </summary>
        /// <param name="patientVitals"></param>
        public void StorePatientVitalsData(PatientVitals patientVitals)
        {
            if (patientVitals.PatientId == "")
                throw new ArgumentException("PtaientTid"); 
            _dataAccessComponent.WritePatientVitalsData(patientVitals);
        }
        #endregion
    }
}
