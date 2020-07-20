using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using TechJobsMVC.Models;
using TechJobsMVC.Data;

namespace TechJobsMVC.Controllers
{
    public class SearchController : Controller
    {

        // GET: /<controller>/
        public IActionResult Index()
        {
            ViewBag.columns = ListController.ColumnChoices;
            return View();
        }

        // TODO #3: Create an action method to process a search request and render the updated search view.   IN PROGRESS

        // v-- needs a route?
        [HttpPost]
        [Route("/Search/Results")]
        public IActionResult Results(string searchType, string searchTerm)
        {
            ViewBag.title = "Search Results";
            List<Job> jobs;
            string titleString = "Search Results (All)";
  

            if (searchTerm == "" || searchTerm == null)
            {
                jobs = JobData.FindAll();
            }
            else
            {
                jobs = JobData.FindByColumnAndValue(searchType, searchTerm);
                string typeName = "";
                if (searchType != "all")
                {
                    foreach (var n in ListController.ColumnChoices)
                    {
                        if (n.Key == searchType)
                        {
                            typeName = n.Value;
                        }
                    }

                    titleString = "Search Results (by " + typeName + ")";
                }
            }

            ViewBag.title = titleString;
            ViewBag.jobs = jobs;
            ViewBag.searchTerm = searchTerm;
            ViewBag.searchTerm = searchTerm;
            ViewBag.columns = ListController.ColumnChoices;
            

            return View();
        }
    }
}
