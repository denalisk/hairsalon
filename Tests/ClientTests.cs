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
            Assert.Equal(0, Client.GetAll().Count);

        }

        // [Fact]
        // public void Client_EqualsIdentityTest_ReturnsTrueForIdenticalObjects()
        // {
        //     // Arrange
        //     Client firstClient = new Client("Bob");
        //
        //     // Act
        //     Client secondClient = new Client("Bob");
        //
        //     // Assert
        //     Assert.Equal(firstClient, secondClient);
        //
        // }
        //
        // [Fact]
        // public void Client_Save_SavesToDatabase()
        // {
        //     // Arrange
        //     Client firstClient = new Client("Bob");
        //     List<Client> testList = new List<Client>{firstClient};
        //
        //     // Act
        //     firstClient.Save();
        //
        //     // Assert
        //     Assert.Equal(testList, Client.GetAll());
        //
        // }
        //
        // [Fact]
        // public void Client_Save_AltersLocalId()
        // {
        //     // Arrange
        //     Client firstClient = new Client("Bob");
        //     List<Client> testList = new List<Client>{firstClient};
        //
        //     // Act
        //     firstClient.Save();
        //
        //     // Assert
        //     Assert.Equal(testList, Client.GetAll());
        // }
        //
        // [Fact]
        // public void Client_FindById_ReturnIdenticalObject()
        // {
        //     // Arrange
        //     Client firstClient = new Client("Bob");
        //     firstClient.Save();
        //
        //     // Act
        //     Client foundClient = Client.Find(firstClient.GetId());
        //
        //     // Assert
        //     Assert.Equal(firstClient, foundClient);
        //
        // }
        //
        // [Fact]
        // public void Client_Update_AlterSavedClient()
        // {
        //     // Arrange
        //     Client firstClient = new Client("Bob");
        //     firstClient.Save();
        //     int targetId = firstClient.GetId();
        //
        //     // Act
        //     firstClient.Update("Robert");
        //
        //     // Assert
        //     Assert.Equal("Robert", Client.Find(targetId).GetName());
        //
        // }
        //
        // [Fact]
        // public void Client_Delete_RemoveInstanceFromDatabase()
        // {
        //     // Arrange
        //     Client firstClient = new Client("Bob");
        //     Client secondClient = new Client("Jenny");
        //     List<Client> testList = new List<Client>{secondClient};
        //
        //     // Act
        //     firstClient.Save();
        //     secondClient.Save();
        //     firstClient.Delete();
        //
        //     // Assert
        //     Assert.Equal(testList, Client.GetAll());
        //
        // }
        //
        // [Fact]
        // public void Client_Search_ReturnClientWithTargetName()
        // {
        //     // Arrange
        //     Client firstClient = new Client("Bob");
        //     Client secondClient = new Client("Jenny");
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
        //     Client firstClient = new Client("Bob");
        //     Client secondClient = new Client("Jenny");
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
        //     Client firstClient = new Client("Bob");
        //     Client secondClient = new Client("Jenny");
        //     firstClient.Save();
        //     secondClient.Save();
        //     Client dupeClient = new Client("Bob");
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
        //
        //     // Act
        //
        //     // Assert
        //
        // }

        public void Dispose()
        {
            Client.DeleteAll();
        }
    }
}
