//=============================================================================
// COPYRIGHT KONINKLIJKE PHILIPS ELECTRONICS N.V. 2019
// All rights are reserved. Reproduction in whole or in part is
// prohibited without the written consent of the copyright owner.
//============================================================================= 

using System;
using System.Data.SqlClient;
using SqlConnectionLib;
namespace BedConfigurationAccessLib
{
    /// <summary>
    /// This class is used for bed Configuration 
    /// </summary>
    public class BedConfigurationAccess
    {
#region Methods
        /// <summary>
        /// This function is used to configure a bed
        /// </summary>
        /// <param name="bedNo"></param>
        public void ConfigureBed(int bedNo)
        {
                SqlCommand cmd = SqlConnector.CreateCommand("InsertBedData");
                
                cmd.Parameters.AddWithValue("@BedNo", bedNo);
             
                SqlConnector.ExecuteConnection(cmd);
          
            
        }
        /// <summary>
        /// This function is used to get the BedNo of available Bed.
        /// </summary>
        /// <returns></returns>
        public int GetAvailableBed()
        {
            SqlCommand cmd = SqlConnector.CreateCommand("GetAvailableBed");
            cmd.Connection.Open();
             SqlDataReader reader = cmd.ExecuteReader();
            reader.Read();
           var bedNo = Convert.ToInt32(reader["BedNo"]);
            cmd.Connection.Close();
            return bedNo;
        }
        /// <summary>
        /// This function is used to update the bed configuration whether it is occupied or not
        /// </summary>
        /// <param name="bedNo"></param>
        public void UpdateBedConfiguration( int bedNo)
        {
            SqlCommand cmd = SqlConnector.CreateCommand("UpdateBedData");

            cmd.Parameters.AddWithValue("@BedNo", bedNo);
                SqlConnector.ExecuteConnection(cmd);

        }
        #endregion
    }
}
