using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using SpaceCats.Models;
using Microsoft.AspNetCore.Http;

namespace SpaceCats.Controllers
{
    public class HomeController : Controller
    {
        public static List<Cat> AllCats = new List<Cat>();
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

    [HttpGet("")]
        public IActionResult Index()
        {
            Cat[] allCats = new Cat[]
            {
            new Cat {Name = "Benny", Breed = "Cat", Weapon = "Laser Gun", Lives = 7, MortalEnemy = "Dogs"},
            new Cat {Name = "George", Breed = "Cat", Weapon = "Plasma Accelerator", Lives = 5, MortalEnemy = "Dogs"},
            new Cat {Name = "Cuddles", Breed = "Cat", Weapon = "Light Sabor", Lives = 9, MortalEnemy = "Humans"}
            };
            // if(HttpContext.Session.GetInt32("NumCats") == null)
            // {
            //     HttpContext.Session.SetInt32("NumCats", 0);
            // }
            // ViewBag.CatCount = HttpContext.Session.GetInt32("NumCats");
            List<Cat> orderedByLives = allCats.OrderBy(cats => cats.Name).ToList();
            ViewBag.AllCats = orderedByLives;
            IEnumerable<Cat> DogEnemies = allCats.Where(c => c.MortalEnemy == "Dogs" && c.Weapon.Contains("Plasma Accelerator")).OrderBy(a => a.Lives);
            ViewBag.DogEnemies = DogEnemies;
            Cat Gun = allCats.FirstOrDefault(c => c.Weapon == "Laser Gun");
            ViewBag.Gun = Gun;
            return View();
        }

    [HttpPost("createCat")]
    public IActionResult createCat(Cat newCat)
    {
        if(ModelState.IsValid)
        {
            AllCats.Add(newCat);
            int numCats = (int)HttpContext.Session.GetInt32("NumCats");
            HttpContext.Session.SetInt32("NumCats", numCats + 1);
            return RedirectToAction("Index");
        } else {
            ViewBag.AllCats = AllCats;
            return View("Index");
        }
        
    }


    }
}
