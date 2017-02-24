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
        public override bool Equals(System.Object otherStylist)
        {
            // This override will allow Stylist.Equals to test each contained value as an identity
            if(!(otherStylist is Stylist))
            {
                return false;
            }
            else
            {
                Stylist newStylist = (Stylist) otherStylist;
                bool nameIdentity = this.GetName() == newStylist.GetName();
                bool idIdentity = this.GetId() == newStylist.GetId();
                return (nameIdentity && idIdentity);
            }
        }

        public override int GetHashCode()
        {
            // This override will allow Stylist.GetHashCode to function with the override .Equals
            return this.GetName().GetHashCode();
        }

        public static List<Stylist> GetAll()
        {
            // Returns a list of all the stylists in the stylist table
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

        public void Save()
        {
            SqlConnection conn = DB.Connection();
            conn.Open();

            SqlCommand cmd = new SqlCommand("INSERT INTO stylists (name) OUTPUT INSERTED.id VALUES (@NewName)", conn);
            cmd.Parameters.Add(new SqlParameter("@NewName", this.GetName()));

            SqlDataReader rdr = cmd.ExecuteReader();

            while(rdr.Read())
            {
                this.SetId(rdr.GetInt32(0));
            }
            DB.CloseSqlConnection(rdr, conn);
        }

        public static Stylist Find(int targetId)
        {
            SqlConnection conn = DB.Connection();
            conn.Open();

            SqlCommand cmd = new SqlCommand("SELECT * FROM stylists WHERE id=@TargetId;", conn);
            cmd.Parameters.Add(new SqlParameter("@TargetId", targetId));
            SqlDataReader rdr = cmd.ExecuteReader();

            string newName = null;
            int newId = 0;

            while(rdr.Read())
            {
                newName = rdr.GetString(1);
                newId = rdr.GetInt32(0);
            }

            Stylist foundStylist = new Stylist(newName, newId);

            DB.CloseSqlConnection(rdr, conn);
            return foundStylist;
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
            // Deletes all stylists in the stylist table
            DB.TableDeleteAll("stylists");
        }
    }
}
