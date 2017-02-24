using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;

namespace HairSalonApp
{
    public class Stylist
    {
        private string _name;
        private int _id;

        public Stylist(string newName, int newId = 0)
        {
            _name = newName;
            _id = newId;
        }

        public static List<Stylist> GetAll()
        {
            List<Stylist> allStylists = new List<Stylist> {};

            SqlConnection conn = DB.Connection();
            conn.Open();

            SqlCommand cmd = new SqlCommand("SELECT * FROM stylists", conn);
            SqlDataReader rdr = cmd.ExecuteReader();

            while(rdr.Read())
            {
                allStylists.Add(new Stylist(rdr.GetString(1), rdr.GetInt32(0)));
            }

            DB.CloseSqlConnection(rdr, conn);

            return allStylists;
        }




        public void SetName(string newName)
        {
            _name = newName;
        }
        public string GetName()
        {
            return _name;
        }
        public void SetId(int newId)
        {
            _id = newId;
        }
        public int GetId()
        {
            return _id;
        }

        public static void DeleteAll()
        {
            DB.TableDeleteAll("stylists");
        }
    }
}
