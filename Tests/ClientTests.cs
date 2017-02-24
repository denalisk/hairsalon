using Xunit;
using System.Collections.Generic;
using System;
using System.Data;
using System.Data.SqlClient;

namespace HairSalonApp
{
    public class ClientTest : IDisposable
    {
        public ClientTest()
        {
            DBConfiguration.ConnectionString = "Data Source=(localdb)\\mssqllocaldb;Initial Catalog=hair_salon_test;Integrated Security=SSPI";
        }

        // START Facts

        [Fact]
        public void Client_TestDBStartsEmpty_EmptyDB()
        {
            // Arrange, Act, Assert
            Stylist firstStylist = new Stylist("Lauren");
            firstStylist.Save();
            Assert.Equal(0, Client.GetAll().Count);

        }

        [Fact]
        public void Client_EqualsIdentityTest_ReturnsTrueForIdenticalObjects()
        {
            // Arrange
            Stylist firstStylist = new Stylist("Lauren");
            firstStylist.Save();
            Client firstClient = new Client("Bob", firstStylist.GetId(), "Brown", System.DateTime.Now);

            // Act
            Client secondClient = new Client("Bob", firstStylist.GetId(), "Brown", System.DateTime.Now);

            // Assert
            Assert.Equal(firstClient, secondClient);

        }

        [Fact]
        public void Client_Save_SavesToDatabase()
        {
            // Arrange
            Stylist firstStylist = new Stylist("Lauren");
            firstStylist.Save();
            Client firstClient = new Client("Bob", firstStylist.GetId(), "Brown", System.DateTime.Now);
            List<Client> testList = new List<Client>{firstClient};

            // Act
            firstClient.Save();

            // Assert
            Assert.Equal(testList, Client.GetAll());

        }

        [Fact]
        public void Client_Save_AltersLocalId()
        {
            // Arrange
            Stylist firstStylist = new Stylist("Lauren");
            firstStylist.Save();
            Client firstClient = new Client("Bob", firstStylist.GetId(), "Brown", System.DateTime.Now);
            List<Client> testList = new List<Client>{firstClient};

            // Act
            firstClient.Save();

            // Assert
            Assert.Equal(testList, Client.GetAll());
        }

        [Fact]
        public void Client_FindById_ReturnIdenticalObject()
        {
            // Arrange
            Stylist firstStylist = new Stylist("Lauren");
            firstStylist.Save();
            Client firstClient = new Client("Bob", firstStylist.GetId(), "Brown", System.DateTime.Now);
            firstClient.Save();

            // Act
            Client foundClient = Client.Find(firstClient.GetId());

            // Assert
            Assert.Equal(firstClient, foundClient);

        }

        [Fact]
        public void Client_Update_AlterSavedClient()
        {
            // Arrange
            Stylist firstStylist = new Stylist("Lauren");
            firstStylist.Save();
            Client firstClient = new Client("Bob", firstStylist.GetId(), "Brown", System.DateTime.Now);
            Client duplicateClient = new Client("Bob", firstStylist.GetId(), "Brown", System.DateTime.Now);
            firstClient.Save();
            firstClient.SetId(0);
            // Act
            firstClient.Update("Robert", "Brown", "Ralph");

            // Assert
            Assert.Equal(duplicateClient, firstClient);

        }

        [Fact]
        public void Client_Delete_RemoveInstanceFromDatabase()
        {
            // Arrange
            Stylist firstStylist = new Stylist("Lauren");
            firstStylist.Save();
            Client firstClient = new Client("Bob", firstStylist.GetId(), "Brown", System.DateTime.Now);
            Client secondClient = new Client("Jenny", firstStylist.GetId(), "Brown", System.DateTime.Now);
            List<Client> testList = new List<Client>{secondClient};

            // Act
            firstClient.Save();
            secondClient.Save();
            firstClient.Delete();

            // Assert
            Assert.Equal(testList, Client.GetAll());

        }

        // [Fact]
        // public void Client_Search_ReturnClientWithTargetName()
        // {
        //     // Arrange
            // Stylist firstStylist = new Stylist("Lauren");
            // firstStylist.Save();
        //     Client firstClient = new Client("Bob", firstStylist.GetId(), "Brown", System.DateTime.Now);
        //     Client secondClient = new Client("Jenny", firstStylist.GetId(), "Brown", System.DateTime.Now);
        //     List<Client> testList = new List<Client>{secondClient};
        //
        //     // Act
        //     firstClient.Save();
        //     secondClient.Save();
        //
        //     // Assert
        //     Assert.Equal(testList, Client.Search("Jen"));
        //
        // }
        //
        // [Fact]
        // public void Client_IsNewClient_ReturnNegOneForTrueOtherwiseId()
        // {
        //     // Arrange
            // Stylist firstStylist = new Stylist("Lauren");
            // firstStylist.Save();
        //     Client firstClient = new Client("Bob", firstStylist.GetId(), "Brown", System.DateTime.Now);
        //     Client secondClient = new Client("Jenny", firstStylist.GetId(), "Brown", System.DateTime.Now);
        //     firstClient.Save();
        //     secondClient.Save();
        //     Client dupeClient = new Client("Blake");
        //
        //     // Act
        //     int result = dupeClient.IsNewClient();
        //
        //     // Assert
        //     Assert.Equal(-1, result);
        //
        // }
        //
        // [Fact]
        // public void Client_Save_NoSaveOnDuplicate()
        // {
        //     // Arrange
            // Stylist firstStylist = new Stylist("Lauren");
            // firstStylist.Save();
        //     Client firstClient = new Client("Bob", firstStylist.GetId(), "Brown", System.DateTime.Now);
        //     Client secondClient = new Client("Jenny", firstStylist.GetId(), "Brown", System.DateTime.Now);
        //     firstClient.Save();
        //     secondClient.Save();
        //     Client dupeClient = new Client("Bob", firstStylist.GetId(), "Brown", System.DateTime.Now);
        //
        //
        //     List<Client> testList = new List<Client>{firstClient, secondClient};
        //
        //     // Act
        //     dupeClient.Save();
        //
        //     // Assert
        //     Assert.Equal(2, Client.GetAll().Count);
        //
        // }
        //
        //
        // [Fact]
        // public void TEST1()
        // {
        //     // Arrange
            // Stylist firstStylist = new Stylist("Lauren");
            // firstStylist.Save();
        //
        //     // Act
        //
        //     // Assert
        //
        // }

        public void Dispose()
        {
            Client.DeleteAll();
            Stylist.DeleteAll();
        }
    }
}
