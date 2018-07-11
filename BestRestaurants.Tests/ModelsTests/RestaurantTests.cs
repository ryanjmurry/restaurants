using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using BestRestaurants.Models;
using System.Collections.Generic;

namespace BestRestaurants.Tests
{
    [TestClass]
    public class RestaurantTests : IDisposable
    {

        public void Dispose()
        {
            Restaurant.DeleteAll();
        }

        public RestaurantTests()
        {
            DBConfiguration.ConnectionString = "server=localhost;user id=root;password=root;port=8889;database=best_restaurant_test;";
        }

        [TestMethod]
        public void Equals_ReturnsTrueIfDescriptionsAreTheSame_Restaurant()
        {
            Restaurant firstRestaurant = new Restaurant(1, "test name", "test street1", "test street2", "test city", "test state", 673812, "test atmosphere", "test price", "test portion", 5 , "test comment");
            Restaurant secondRestaurant = new Restaurant(1, "test name", "test street1", "test street2", "test city", "test state", 673812, "test atmosphere", "test price", "test portion", 5, "test comment");

            Assert.AreEqual(firstRestaurant, secondRestaurant);
        }

        [TestMethod]
        public void GetAll_DbStartsEmpty_0()
        {
            int result = Restaurant.GetAll().Count;
            Assert.AreEqual(0, result);
        }

        [TestMethod]
        public void Save_SavesToDatabase_RestaurantList()
        {
            //Arrange
            Restaurant testRestaurant = new Restaurant(1, "test name", "test street1", "test street2", "test city", "test state", 673812, "test atmosphere", "test price", "test portion", 5 , "test comment");

            //Act
            testRestaurant.Save();
            List<Restaurant> result = Restaurant.GetAll();

            List<Restaurant> testList = new List<Restaurant> { testRestaurant };

            //Assert
            CollectionAssert.AreEqual(testList, result);
        }
    }
}
