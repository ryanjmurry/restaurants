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
        public void Find_FindsCuisineInDatabase_Cuisine()
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

        [TestMethod]
        public void GetItems_RetrievesAllRestaurantsWithCuisine_RestaurantList()
        {
            Cuisine testCuisine = new Cuisine(1, "american");

            Restaurant testRestaurantOne = new Restaurant(1, "test name", "test street1", "test city", "test state", 673812, "test atmosphere", "test price", "test portion", 5, "test comment");

            testRestaurantOne.Save();
            Restaurant testRestaurantTwo = new Restaurant(1, "test name", "test street1", "test city", "test state", 673812, "test atmosphere", "test price", "test portion", 5, "test comment");
            testRestaurantTwo.Save();

            List<Restaurant> testRestaurantList = new List<Restaurant> { testRestaurantOne, testRestaurantTwo };
            List<Restaurant> resultRestaurantList = testCuisine.GetRestaurantsByCuisine(1);

            CollectionAssert.AreEqual(testRestaurantList, resultRestaurantList);
        }

        [TestMethod]
        public void GetAll_GetsAllCuisinesFromDatabase_CuisineList()
        {
            int result = Cuisine.GetAll().Count;
            Assert.AreEqual(11, result);
        }


    }
}
