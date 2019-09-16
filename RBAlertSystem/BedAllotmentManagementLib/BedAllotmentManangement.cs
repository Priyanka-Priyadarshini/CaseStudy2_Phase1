//=============================================================================
// COPYRIGHT KONINKLIJKE PHILIPS ELECTRONICS N.V. 2019
// All rights are reserved. Reproduction in whole or in part is
// prohibited without the written consent of the copyright owner.
//============================================================================= 

using System;
using BedConfigurationAccessLib;
using SqlConnectionLib;
using System.Data.SqlClient;

namespace BedAllotmentManagementLib
{
    /// <summary>
    /// This class manages the allotment of bed to patients
    /// </summary>
    public class BedAllotmentManangement
    {
        #region Member
        private readonly BedConfigurationAccess _bedConfiguration;
        #endregion
        #region Constructor
        public BedAllotmentManangement(BedConfigurationAccess bedConfiguration)
        {
            _bedConfiguration = bedConfiguration;
        }
        #endregion
        #region Methods
        /// <summary>
        /// This function helps to allot bed to patients
        /// </summary>
        /// <param name="patientId"></param>
        public void AllotBedToPatient(string patientId)
        {
            int bedNo = _bedConfiguration.GetAvailableBed();
            SqlCommand cmd = SqlConnector.CreateCommand("BedAllotment");
            cmd.Parameters.AddWithValue("@PatientId", patientId);
            cmd.Parameters.AddWithValue("@BedNo", bedNo);
            SqlConnector.ExecuteConnection(cmd);
            _bedConfiguration.UpdateBedConfiguration(bedNo);
        }
        /// <summary>
        /// This function gets the alloted BedNo to a particular patient
        /// </summary>
        /// <param name="patientId"></param>
        /// <returns>bedNo</returns>
        public int GetAllotedBedNo(string patientId)
        {
            SqlCommand cmd = SqlConnector.CreateCommand("GetAllotedBedNo");
            cmd.Parameters.AddWithValue("@PatientId", patientId);
            cmd.Connection.Open();
            SqlDataReader reader = cmd.ExecuteReader();
            reader.Read();
            var bedNo = Convert.ToInt32(reader["BedNo"]);
            cmd.Connection.Close();
            return bedNo;
        }
        /// <summary>
        /// This function deallots the bed given to a patient.
        /// </summary>
        /// <param name="bedNo"></param>
        public void DeAllotBed(int bedNo)
        {
            SqlCommand cmd = SqlConnector.CreateCommand("BedDeallotment");
            cmd.Parameters.AddWithValue("@BedNo", bedNo);
            SqlConnector.ExecuteConnection(cmd);

        }
        #endregion
    }
}
