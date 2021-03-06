﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using BestRestaurants.Models;

namespace BestRestaurants.Controllers
{
    public class RestaurantsController : Controller
    {
        [HttpGet("/restaurants")]
        public ActionResult Index()
        {
            List<Restaurant> restaurantList = new List<Restaurant> { };
            restaurantList = Restaurant.GetAll();
            return View(restaurantList);
        }

        [HttpGet("/restaurants/new")]
        public ActionResult Create()
        {
            return View();
        }

        [HttpPost("/restaurants")]
        public ActionResult SaveRestaurant(int restaurantCuisine, string restaurantName, string restaurantStreet1, string restaurantCity, string restaurantState, int restaurantZip, string restaurantAtmosphere, string restaurantPrice, string restaurantPortion, int restaurantRating, string restaurantComments)
        {
            Restaurant newRestaurant = new Restaurant(restaurantCuisine, restaurantName, restaurantStreet1, restaurantCity, restaurantState, restaurantZip, restaurantAtmosphere, restaurantPrice, restaurantPortion, restaurantRating, restaurantComments);
            newRestaurant.Save();
            return RedirectToAction("Details", new { id = newRestaurant.Id});
        }

        [HttpGet("/restaurants/{id}")]
        public ActionResult Details(int id)
        {
            Restaurant currentRestaurant = Restaurant.Find(id);
            return View(currentRestaurant);
        }

        [HttpGet("/restaurants/delete")]
        public ActionResult Delete()
        {
            return View();
        }

        [HttpPost("/restaurants/delete")]
        public ActionResult DeleteAll()
        {
            Restaurant.DeleteAll();
            return RedirectToAction("Index");
        }

        [HttpPost("/restaurants/{id}/delete")]
        public ActionResult DeleteRestaurant(int id)
        {
            Restaurant currentRestaurant = Restaurant.Find(id);
            currentRestaurant.Delete();
            return RedirectToAction("Index");
        }

        [HttpGet("/restaurants/{id}/update")]
        public ActionResult Update()
        {
            return View();
        }

        [HttpPost("/restaurants/{id}/update")]
        public ActionResult Update(int restaurantCuisine, string restaurantName, string restaurantStreet1, string restaurantCity, string restaurantState, int restaurantZip, string restaurantAtmosphere, string restaurantPrice, string restaurantPortion, int restaurantRating, string restaurantComments, int id)
        {
            Restaurant currentRestaurant = Restaurant.Find(id);
            currentRestaurant.Update(restaurantCuisine, restaurantName, restaurantStreet1, restaurantCity, restaurantState, restaurantZip, restaurantAtmosphere, restaurantPrice, restaurantPortion, restaurantRating, restaurantComments, id);
            return RedirectToAction("Details", new { id = currentRestaurant.Id });
        }
    }
}
