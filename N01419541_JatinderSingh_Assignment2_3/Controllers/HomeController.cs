using N01419541_JatinderSingh_Assignment2_3.DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace N01419541_JatinderSingh_Assignment2_3.Controllers
{
    public class HomeController : Controller
    {
        private QuestionContext db = new QuestionContext();

        public ActionResult Index()
        {
            return View(db.Questions.ToList());
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";
            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";
            return View();
        }

        public ActionResult Categories()
        {
            return View(db.Categories.ToList());
        }

        public ActionResult Questions()
        {
            return RedirectToAction("Index", "Questions");
        }
    }
}