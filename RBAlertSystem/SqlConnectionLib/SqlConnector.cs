//=============================================================================
// COPYRIGHT KONINKLIJKE PHILIPS ELECTRONICS N.V. 2019
// All rights are reserved. Reproduction in whole or in part is
// prohibited without the written consent of the copyright owner.
//============================================================================= 

using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SqlConnectionLib
{
    public static class SqlConnector
    {
        private const string path = @"Data Source=.\SQLEXPRESS;Initial Catalog=HospitalDb;Integrated Security=True";
        public static SqlCommand CreateCommand(string query)
        {
            SqlConnection con = new SqlConnection(path);
            SqlCommand cmd = new SqlCommand(query, con);
            cmd.CommandType = System.Data.CommandType.StoredProcedure;
            return cmd;
        }
        public static void ExecuteConnection(SqlCommand cmd)
        {
            cmd.Connection.Open();
            cmd.ExecuteNonQuery();
            cmd.Connection.Close();
        }
    }
}
