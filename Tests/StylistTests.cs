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
