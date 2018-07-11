using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using BestRestaurants.Models;
using System.Collections.Generic;

namespace BestRestaurants.Tests
{
    [TestClass]
    public class CuisineTests : IDisposable
    {
        public CuisineTests()
        {
            DBConfiguration.ConnectionString = "server=localhost;user id=root;password=root;port=8889;database=best_restaurant_test;";
        }

        [TestMethod]
        public void Find_FindsCategoryInDatabase_Category()
        {
            //Act
            Cuisine foundCuisine = Cuisine.Find(1);
            string type = foundCuisine.Type;

            //Assert
            Assert.AreEqual("american", type);
        }

        public void Dispose()
        {
            Restaurant.DeleteAll();
        }
    }
}
