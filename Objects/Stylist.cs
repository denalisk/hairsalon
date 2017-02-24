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
    }
}
