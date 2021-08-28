using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Data.Entity;
using System.Net;
using College_Fest.Models;

namespace College_Fest.Controllers
{
    public class HomeController : Controller
    {
        private programEntities db = new programEntities();
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        [Authorize]
        public ActionResult Events()
        {
            ViewBag.Message = "Your application description page.";

            return View(db.tb_event.ToList());
        }



        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }

        public ActionResult Leaderboard()
        {
            ViewBag.Message = "Your contact page.";
            var winners = db.winners.Include(w => w.register).Include(w => w.tb_event);
            return View(winners.ToList());
        }


    }
}