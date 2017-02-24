using Xunit;
using System.Collections.Generic;
using System;
using System.Data;
using System.Data.SqlClient;

namespace HairSalonApp
{
    public class StylistTest : IDisposable
    {
        public StylistTest()
        {
            DBConfiguration.ConnectionString = "Data Source=(localdb)\\mssqllocaldb;Initial Catalog=hair_salon_test;Integrated Security=SSPI";
        }

        [Fact]
        public void Stylist_TestDBStartsEmpty_EmptyDB()
        {
            // Arrange, Act, Assert
            Assert.Equal(0, Stylist.GetAll().Count);

        }

        [Fact]
        public void Stylist_EqualsIdentityTest_ReturnsTrueForIdenticalObjects()
        {
            // Arrange
            Stylist firstStylist = new Stylist("Bob");

            // Act
            Stylist secondStylist = new Stylist("Bob");

            // Assert
            Assert.Equal(firstStylist, secondStylist);

        }

        [Fact]
        public void Stylist_Save_SavesToDatabase()
        {
            // Arrange
            Stylist firstStylist = new Stylist("Bob");
            List<Stylist> testList = new List<Stylist>{firstStylist};

            // Act
            firstStylist.Save();

            // Assert
            Assert.Equal(testList, Stylist.GetAll());

        }

        [Fact]
        public void Stylist_Save_AltersLocalId()
        {
            // Arrange
            Stylist firstStylist = new Stylist("Bob");
            List<Stylist> testList = new List<Stylist>{firstStylist};

            // Act
            firstStylist.Save();

            // Assert
            Assert.Equal(testList, Stylist.GetAll());
        }

        [Fact]
        public void Stylist_FindById_ReturnIdenticalObject()
        {
            // Arrange
            Stylist firstStylist = new Stylist("Bob");
            firstStylist.Save();

            // Act
            Stylist foundStylist = Stylist.Find(firstStylist.GetId());

            // Assert
            Assert.Equal(firstStylist, foundStylist);

        }

        [Fact]
        public void Stylist_Update_AlterSavedStylist()
        {
            // Arrange
            Stylist firstStylist = new Stylist("Bob");
            firstStylist.Save();
            int targetId = firstStylist.GetId();

            // Act
            firstStylist.Update("Robert");

            // Assert
            Assert.Equal("Robert", Stylist.Find(targetId).GetName());

        }

        [Fact]
        public void Stylist_Delete_RemoveInstanceFromDatabase()
        {
            // Arrange
            Stylist firstStylist = new Stylist("Bob");
            Stylist secondStylist = new Stylist("Jenny");
            List<Stylist> testList = new List<Stylist>{secondStylist};

            // Act
            firstStylist.Save();
            secondStylist.Save();
            firstStylist.Delete();

            // Assert
            Assert.Equal(testList, Stylist.GetAll());

        }

        [Fact]
        public void Stylist_Search_ReturnStylistWithTargetName()
        {
            // Arrange
            Stylist firstStylist = new Stylist("Bob");
            Stylist secondStylist = new Stylist("Jenny");
            List<Stylist> testList = new List<Stylist>{secondStylist};

            // Act
            firstStylist.Save();
            secondStylist.Save();

            // Assert
            Assert.Equal(testList, Stylist.Search("Jen"));

        }

        [Fact]
        public void Stylist_IsNewStylist_ReturnNegOneForTrueOtherwiseId()
        {
            // Arrange
            Stylist firstStylist = new Stylist("Bob");
            Stylist secondStylist = new Stylist("Jenny");
            firstStylist.Save();
            secondStylist.Save();
            Stylist dupeStylist = new Stylist("Blake");

            // Act
            int result = dupeStylist.IsNewStylist();

            // Assert
            Assert.Equal(-1, result);

        }


        [Fact]
        public void TEST1()
        {
            // Arrange

            // Act

            // Assert

        }

        // START Facts
        public void Dispose()
        {
            Stylist.DeleteAll();
        }
    }
}
