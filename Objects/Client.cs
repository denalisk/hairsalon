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
        private string _date;
        private int _id;

        public Client(string newName, int newStylistId, string newHairColor, string newDate, int newId = 0)
        {
            _name = newName;
            _id = newId;
            _stylistId = newStylistId;
            _hairColor = newHairColor;
            _date = newDate;
        }
        // public override bool Equals(System.Object otherClient)
        // {
        //     // This override will allow Client.Equals to test each contained value as an identity
        //     if(!(otherClient is Client))
        //     {
        //         return false;
        //     }
        //     else
        //     {
        //         Client newClient = (Client) otherClient;
        //         bool nameIdentity = this.GetName() == newClient.GetName();
        //         bool idIdentity = this.GetId() == newClient.GetId();
        //         return (nameIdentity && idIdentity);
        //     }
        // }
        //
        // public override int GetHashCode()
        // {
        //     // This override will allow Client.GetHashCode to function with the override .Equals
        //     return this.GetName().GetHashCode();
        // }
        //
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
                allClients.Add(new Client(rdr.GetString(2), rdr.GetInt32(1), rdr.GetString(3), rdr.GetString(4), rdr.GetInt32(0)));
            }

            DB.CloseSqlConnection(rdr, conn);

            return allClients;
        }
        //
        // public void Save()
        // {
        //     // Adds a local Client Object to the database, won't save if it's a duplicate client
        //     if (this.IsNewClient() == -1)
        //     {
        //         SqlConnection conn = DB.Connection();
        //         conn.Open();
        //
        //         SqlCommand cmd = new SqlCommand("INSERT INTO clients (name) OUTPUT INSERTED.id VALUES (@NewName)", conn);
        //         cmd.Parameters.Add(new SqlParameter("@NewName", this.GetName()));
        //
        //         SqlDataReader rdr = cmd.ExecuteReader();
        //
        //         while(rdr.Read())
        //         {
        //             this.SetId(rdr.GetInt32(0));
        //         }
        //         DB.CloseSqlConnection(rdr, conn);
        //     }
        // }
        //
        // public static Client Find(int targetId)
        // {
        //     // Looks in the database for a client with the given id, returns it as a Client Object if found, else returns a Client object with null values
        //     SqlConnection conn = DB.Connection();
        //     conn.Open();
        //
        //     SqlCommand cmd = new SqlCommand("SELECT * FROM clients WHERE id=@TargetId;", conn);
        //     cmd.Parameters.Add(new SqlParameter("@TargetId", targetId));
        //     SqlDataReader rdr = cmd.ExecuteReader();
        //
        //     string newName = null;
        //     int newId = 0;
        //
        //     while(rdr.Read())
        //     {
        //         newName = rdr.GetString(1);
        //         newId = rdr.GetInt32(0);
        //     }
        //
        //     Client foundClient = new Client(newName, newId);
        //
        //     DB.CloseSqlConnection(rdr, conn);
        //     return foundClient;
        // }
        //
        // public void Update(string newName)
        // {
        //     // Updates a Clients information in the database and alters the local client
        //     SqlConnection conn = DB.Connection();
        //     conn.Open();
        //
        //     SqlCommand cmd = new SqlCommand("UPDATE clients SET name=@NewName OUTPUT INSERTED.name WHERE id=@TargetId", conn);
        //     cmd.Parameters.Add(new SqlParameter("@NewName", newName));
        //     cmd.Parameters.Add(new SqlParameter("@TargetId", this.GetId()));
        //     SqlDataReader rdr = cmd.ExecuteReader();
        //
        //     while(rdr.Read())
        //     {
        //         this.SetName(rdr.GetString(0));
        //     }
        //
        //     DB.CloseSqlConnection(rdr, conn);
        // }
        //
        // public void Delete()
        // {
        //     // Delete a client from the databas. Currently does nothing to their clients
        //     SqlConnection conn = DB.Connection();
        //     conn.Open();
        //
        //     SqlCommand cmd = new SqlCommand("DELETE FROM clients WHERE id=@TargetId;", conn);
        //     cmd.Parameters.Add(new SqlParameter("@TargetId", this.GetId()));
        //     cmd.ExecuteNonQuery();
        //
        //     if (conn != null)
        //     {
        //         conn.Close();
        //     }
        // }
        //
        // public static List<Client> Search(string targetName)
        // {
        //     // Returns a list of Clients from the database if the name is the same
        //     List<Client> foundClients = new List<Client> {};
        //
        //     SqlConnection conn = DB.Connection();
        //     conn.Open();
        //
        //     SqlCommand cmd = new SqlCommand("SELECT * FROM clients WHERE name LIKE @TargetName;", conn);
        //     cmd.Parameters.Add(new SqlParameter("@TargetName", "%" + targetName + "%"));
        //
        //     SqlDataReader rdr = cmd.ExecuteReader();
        //
        //     while(rdr.Read())
        //     {
        //         foundClients.Add(new Client(rdr.GetString(1), rdr.GetInt32(0)));
        //     }
        //     DB.CloseSqlConnection(rdr, conn);
        //
        //     return foundClients;
        //
        // }
        //
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
        // public void SetName(string newName)
        // {
        //     _name = newName;
        // }
        // public string GetName()
        // {
        //     return _name;
        // }
        // public void SetId(int newId)
        // {
        //     _id = newId;
        // }
        // public int GetId()
        // {
        //     return _id;
        // }
        //
        public static void DeleteAll()
        {
            // Deletes all clients in the client table
            DB.TableDeleteAll("clients");
        }
    }
}
