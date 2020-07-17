using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using TechJobsMVC.Models;

namespace TechJobsMVC.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            /*            Dictionary<string, string> actionChoices = new Dictionary<string, string>();
                        actionChoices.Add("search", "Search");
                        actionChoices.Add("list", "List");*/

            // Simplified the dictionary init, per VS suggestion
            Dictionary<string, string> actionChoices = new Dictionary<string, string>()
            {
                {"search", "Search" },
                {"list", "List" }
            };

            ViewBag.actions = actionChoices;
            return View();
        }
    }
}
