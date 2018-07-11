using System;
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


    }
}
