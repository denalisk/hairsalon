using System.Data;
using System.Data.SqlClient;
using System.Collections.Generic;
using System;

namespace HairSalonApp
{
    public class DB
    {
        public static SqlConnection Connection()
        {
            SqlConnection conn = new SqlConnection(DBConfiguration.ConnectionString);
            return conn;
        }

        public static void CloseSqlConnection(SqlDataReader reader, SqlConnection connection)
        {
            if (reader != null)
            {
                reader.Close();
            }
            if (connection != null)
            {
                connection.Close();
            }
        }

        public static void TableDeleteAll(string tableName)
        {
            SqlConnection conn = DB.Connection();
            conn.Open();
            SqlCommand cmd = new SqlCommand("DELETE FROM " + tableName + ";", conn);
            cmd.ExecuteNonQuery();
            conn.Close();
        }

        public static string SqlFormattedDate(DateTime newDateTime)
        {
            return newDateTime.ToString("yyyy-MM-dd HH:mm:ss.fff");
        }
    }
}
