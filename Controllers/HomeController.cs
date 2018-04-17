using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Http;
using LostInTheWoods.Models;
using LostInTheWoods.Factory;

namespace LostInTheWoods.Controllers
{
    public class HomeController : Controller
    {

        private readonly TrailFactory trailFactory;
        public HomeController()
        {
            //Instantiate a UserFactory object that is immutable (READONLY)
            //This establishes the initial DB connection for us.
            trailFactory = new TrailFactory();
        }

        // GET: /Home/
        [HttpGet]
        [Route("")]
        public IActionResult Index()
        {
            ViewBag.Error = TempData["error"];
            ViewBag.Trails = trailFactory.FindAll();
            return View();
        }

        [HttpGet]
        [Route("trails/{id}")]
        public IActionResult ShowTrail(int id)
        {
            ViewBag.Trail = trailFactory.FindByID(id);
            return View();
        }

        [HttpGet]
        [Route("NewTrail")]
        public IActionResult NewTrail()
        {
            return View();
        }

        [HttpPost]
        [Route("AddTrail")]
        public IActionResult AddTrail(NewTrailViewModel trail)
        {
            if(ModelState.IsValid)
            {
                Console.WriteLine("ModelState is valid.");
                Trail NewTrail = new Trail
                {
                    TrailName = trail.TrailName,
                    Description = trail.Description,
                    TrailLength = trail.TrailLength,
                    ElevationGain = trail.ElevationGain,
                    Lattitude = trail.Lattitude,
                    Longitude = trail.Longitude
                };

                trailFactory.Add(NewTrail);
            }
            else
            {
                ViewBag.errors = ModelState.Values;
                return View();
            }
            return RedirectToAction("Index");
        }
    }
}
