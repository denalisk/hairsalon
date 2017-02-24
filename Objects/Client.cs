using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;

namespace HairSalonApp
{
    public class Client
    {
        private int _stylistId;
        private string _name;
        private string _hairColor;
        private DateTime _date;
        private int _id;

        public Client(string newName, int newStylistId, string newHairColor, DateTime newDate, int newId = 0)
        {
            _name = newName;
            _id = newId;
            _stylistId = newStylistId;
            _hairColor = newHairColor;
            _date = newDate;
        }
        public override bool Equals(System.Object otherClient)
        {
            // This override will allow Client.Equals to test each contained value as an identity
            // DOES NOT check the date value
            if(!(otherClient is Client))
            {
                return false;
            }
            else
            {
                Client newClient = (Client) otherClient;
                bool nameIdentity = this.GetName() == newClient.GetName();
                bool idIdentity = this.GetId() == newClient.GetId();
                bool hairColorIdentity = this.GetHairColor() == newClient.GetHairColor();
                bool stylistIdIdentity = this.GetStylistId() == newClient.GetStylistId();
                return (nameIdentity && idIdentity && stylistIdIdentity && hairColorIdentity);
            }
        }

        public override int GetHashCode()
        {
            // This override will allow Client.GetHashCode to function with the override .Equals
            return this.GetName().GetHashCode();
        }

        public static List<Client> GetAll()
        {
            // Returns a list of all the clients in the client table
            List<Client> allClients = new List<Client> {};

            SqlConnection conn = DB.Connection();
            conn.Open();

            SqlCommand cmd = new SqlCommand("SELECT * FROM clients", conn);
            SqlDataReader rdr = cmd.ExecuteReader();

            while(rdr.Read())
            {
                allClients.Add(new Client(rdr.GetString(2), rdr.GetInt32(1), rdr.GetString(3), rdr.GetDateTime(4), rdr.GetInt32(0)));
            }

            DB.CloseSqlConnection(rdr, conn);

            return allClients;
        }

        public void Save()
        {
            // Adds a local Client Object to the database, won't save if it's a duplicate client
            SqlConnection conn = DB.Connection();
            conn.Open();

            SqlCommand cmd = new SqlCommand("INSERT INTO clients (name, stylist_id, hair_color, creation_date) OUTPUT INSERTED.id VALUES (@NewName, @StylistId, @HairColor, @Date)", conn);
            cmd.Parameters.Add(new SqlParameter("@NewName", this.GetName()));
            cmd.Parameters.Add(new SqlParameter("@StylistId", this.GetStylistId()));
            cmd.Parameters.Add(new SqlParameter("@HairColor", this.GetHairColor()));
            cmd.Parameters.Add(new SqlParameter("@Date", this.GetDate()));

            SqlDataReader rdr = cmd.ExecuteReader();

            while(rdr.Read())
            {
                this.SetId(rdr.GetInt32(0));
            }
            DB.CloseSqlConnection(rdr, conn);
        }

        public static Client Find(int targetId)
        {
            // Looks in the database for a client with the given id, returns it as a Client Object if found, else returns a Client object with null values
            SqlConnection conn = DB.Connection();
            conn.Open();

            SqlCommand cmd = new SqlCommand("SELECT * FROM clients WHERE id=@TargetId;", conn);
            cmd.Parameters.Add(new SqlParameter("@TargetId", targetId));
            SqlDataReader rdr = cmd.ExecuteReader();

            string foundName = null;
            int foundId = 0;
            int foundStylistId = 0;
            DateTime foundDate = DateTime.Now;
            string foundHairColor = null;

            while(rdr.Read())
            {
                foundName = rdr.GetString(2);
                foundId = rdr.GetInt32(0);
                foundStylistId = rdr.GetInt32(1);
                foundDate = rdr.GetDateTime(4);
                foundHairColor = rdr.GetString(3);
            }

            Client foundClient = new Client(foundName, foundStylistId, foundHairColor, foundDate, foundId);

            DB.CloseSqlConnection(rdr, conn);
            return foundClient;
        }

        public void Update(string newName, string newHairColor, string newStylistName)
        {
            // Updates a Clients information in the database and alters the local client, also creates a new Stylist if there is no existing stylist by the name given

            // Stylist Check section
            Stylist newStylist = new Stylist(newStylistName);
            int newStylistId = newStylist.IsNewStylist();
            if (newStylistId == -1)
            {
                newStylist.Save();
                newStylistId = newStylist.GetId();
            }

            // SQL section
            SqlConnection conn = DB.Connection();
            conn.Open();

            SqlCommand cmd = new SqlCommand("UPDATE clients SET name=@NewName, hair_color=@NewHairColor, stylist_id=@NewStylistId WHERE id=@TargetId", conn);
            cmd.Parameters.Add(new SqlParameter("@NewName", newName));
            cmd.Parameters.Add(new SqlParameter("@NewHairColor", newHairColor));
            cmd.Parameters.Add(new SqlParameter("@NewStylistId", newStylistId));
            cmd.Parameters.Add(new SqlParameter("@TargetId", this.GetId()));
            cmd.ExecuteNonQuery();

            if (conn != null)
            {
                conn.Close();
            }
        }

        public void Delete()
        {
            // Delete a client from the databas. Currently does nothing to their clients
            SqlConnection conn = DB.Connection();
            conn.Open();

            SqlCommand cmd = new SqlCommand("DELETE FROM clients WHERE id=@TargetId;", conn);
            cmd.Parameters.Add(new SqlParameter("@TargetId", this.GetId()));
            cmd.ExecuteNonQuery();

            if (conn != null)
            {
                conn.Close();
            }
        }

        public static List<Client> Search(string targetName)
        {
            // Returns a list of Clients from the database if the name is the same
            List<Client> foundClients = new List<Client> {};

            SqlConnection conn = DB.Connection();
            conn.Open();

            SqlCommand cmd = new SqlCommand("SELECT * FROM clients WHERE name LIKE @TargetName;", conn);
            cmd.Parameters.Add(new SqlParameter("@TargetName", "%" + targetName + "%"));

            SqlDataReader rdr = cmd.ExecuteReader();

            while(rdr.Read())
            {
                foundClients.Add(new Client(rdr.GetString(2), rdr.GetInt32(1), rdr.GetString(3), rdr.GetDateTime(4), rdr.GetInt32(0)));
            }
            DB.CloseSqlConnection(rdr, conn);

            return foundClients;

        }

        // public int IsNewClient()
        // {
        //     // Checks if the client already exists in the database. Returns the client Id if already exists, else returns -1
        //     SqlConnection conn = DB.Connection();
        //     conn.Open();
        //
        //     SqlCommand cmd = new SqlCommand("SELECT * FROM clients WHERE name=@TargetName;", conn);
        //     cmd.Parameters.Add(new SqlParameter("@TargetName", this.GetName()));
        //     SqlDataReader rdr = cmd.ExecuteReader();
        //
        //     int resultId = -1;
        //
        //     if(rdr.Read())
        //     {
        //         resultId = rdr.GetInt32(0);
        //     }
        //
        //     DB.CloseSqlConnection(rdr, conn);
        //     return resultId;
        // }
        //
        //
        //
        //
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
        public void SetHairColor(string newHairColor)
        {
            _hairColor = newHairColor;
        }
        public string GetHairColor()
        {
            return _hairColor;
        }
        public void SetStylistId(int newStylistId)
        {
            _stylistId = newStylistId;
        }
        public int GetStylistId()
        {
            return _stylistId;
        }
        public void SetDate(DateTime newDate)
        {
            _date = newDate;
        }
        public DateTime GetDate()
        {
            return _date;
        }
        public string GetStringDate()
        {
            return DB.SqlFormattedDate(_date);
        }

        public static void DeleteAll()
        {
            // Deletes all clients in the client table
            DB.TableDeleteAll("clients");
        }
    }
}
