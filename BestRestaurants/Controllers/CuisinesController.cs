using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using BestRestaurants.Models;

namespace BestRestaurants.Controllers
{
    public class CuisinesController : Controller
    {
        [HttpGet("/cuisines")]
        public ActionResult Index()
        {
            List<Cuisine> cuisineList = new List<Cuisine> { };
            cuisineList = Cuisine.GetAll();
            return View();
        }
    }
}
