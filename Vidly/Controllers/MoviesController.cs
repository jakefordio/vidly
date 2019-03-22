using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Vidly.Models;

namespace Vidly.Controllers
{
    public class MoviesController : Controller
    {
        // We could set return type to ViewResult() which is actually better practice (Saves an extra casting when unit testing)
        // However, sometimes different actions can have different execution paths and return different action results.
        // We will leave this action as ActionResult so that we can return different result types.
        public ActionResult Random()
        {
            var movie = new Movie()
            {
                Name = "Beerfest"
            };

            ViewData["Movie"] = movie;

            return View();
            // Other result type examples:
            // return Content("Hello World!");
            // return new EmptyResult(); - EmptyResult doesn't have a helper method, so we have to add "new" keyword.
            //return RedirectToAction("Index", "Home", new { page = 1, sortBy = "name" });
        }

        public ActionResult Edit(int id)
        {
            return Content("ID: " + id);
        }

        // Adding question mark makes it optional parameter(nullable).
        // We don't need to do this for sortBy, because string is a reference type in C# and is already nullable.
        public ActionResult Index(int? pageIndex, string sortBy)
        {
            if(!pageIndex.HasValue)
            {
                pageIndex = 1;
            }

            if (String.IsNullOrWhiteSpace(sortBy))
            {
                sortBy = "Name";
            }

            return Content(String.Format("pageIndex={0}&sortBy={1}", pageIndex, sortBy));
        }

        [Route("movies/released/{year}/{month:regex(\\d{4}):range(1, 12)}")]
        public ActionResult ByReleaseDate(int year, byte month)
        {
            return Content(year + "/" + month);
        }
    }
}