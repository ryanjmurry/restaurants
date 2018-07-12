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
            Restaurant firstRestaurant = new Restaurant(1, "test name", "test street1", "test city", "test state", 673812, "test atmosphere", "test price", "test portion", 5 , "test comment");
            Restaurant secondRestaurant = new Restaurant(1, "test name", "test street1", "test city", "test state", 673812, "test atmosphere", "test price", "test portion", 5, "test comment");

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
            Restaurant testRestaurant = new Restaurant(1, "test name", "test street1", "test city", "test state", 673812, "test atmosphere", "test price", "test portion", 5 , "test comment");

            //Act
            testRestaurant.Save();
            List<Restaurant> result = Restaurant.GetAll();

            List<Restaurant> testList = new List<Restaurant> { testRestaurant };

            //Assert
            CollectionAssert.AreEqual(testList, result);
        }

        [TestMethod]
        public void Find_FindsRestaurantInDatabase_Restaurant()
        {
            Restaurant testRestaurant = new Restaurant(1, "test name", "test street1", "test city", "test state", 673812, "test atmosphere", "test price", "test portion", 5, "test comment");
            testRestaurant.Save();

            Restaurant foundRestaurant = Restaurant.Find(testRestaurant.Id);

            Assert.AreEqual(testRestaurant, foundRestaurant);
        }

        [TestMethod]
        public void Update_UpdatesRestaurantInDatabase_Restaurant()
        {
            Restaurant testRestaurant = new Restaurant(1, "test name", "test street1", "test city", "test state", 673812, "test atmosphere", "test price", "test portion", 5, "test comment");
            testRestaurant.Save();
            testRestaurant.Update(1, "new name", "test street1", "test city", "test state", 673812, "test atmosphere", "test price", "test portion", 5, "test comment");
            string result = Restaurant.Find(testRestaurant.Id).Name;
            Assert.AreEqual("new name", result);
        }

        [TestMethod]
        public void Delete_DeleteSingleRestaurantFromDatabase_DeletesRestaurant()
        {
            Restaurant newRestaurant1 = new Restaurant(1, "test name", "test street1", "test city", "test state", 673812, "test atmosphere", "test price", "test portion", 5, "test comment");
            newRestaurant1.Save();
            Restaurant newRestaurant2 = new Restaurant(1, "new name", "test street1", "test city", "test state", 673812, "test atmosphere", "test price", "test portion", 5, "test comment");
            newRestaurant2.Save();
            newRestaurant1.Delete();

            List<Restaurant> restaurantList = new List<Restaurant> { newRestaurant2 };
            List<Restaurant> result = Restaurant.GetAll();

            CollectionAssert.AreEqual(result, restaurantList);
        }

        [TestMethod]
        public void DeleteByCuisine_DeletesAllRestaurantsWithCuisine_RestaurantList()
        {
            Restaurant testRestaurantOne = new Restaurant(1, "test name", "test street1", "test city", "test state", 673812, "test atmosphere", "test price", "test portion", 5, "test comment");
            testRestaurantOne.Save();

            Restaurant testRestaurantTwo = new Restaurant(1, "test name", "test street1", "test city", "test state", 673812, "test atmosphere", "test price", "test portion", 5, "test comment");
            testRestaurantTwo.Save();

            Restaurant testRestaurantThree = new Restaurant(2, "test name", "test street1", "test city", "test state", 673812, "test atmosphere", "test price", "test portion", 5, "test comment");
            testRestaurantThree.Save();

            Restaurant.DeleteByCuisine(testRestaurantOne.CuisineId);

            List<Restaurant> testRestaurantList = new List<Restaurant> { testRestaurantThree };
            List<Restaurant> result = Restaurant.GetAll();

            CollectionAssert.AreEqual(testRestaurantList, result);
        }
    }
}
