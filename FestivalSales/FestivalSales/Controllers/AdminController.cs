using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using FestivalSales.Models;
namespace FestivalSales.Controllers
{
    public class AdminController : Controller
    {
        // GET: Admin
        public ActionResult Index()
        {
            DataModel db = new DataModel();
            ViewBag.Events = db.Events.Where(x => x.is_approved == false).ToList();
            ViewBag.Offers = db.Offers.Where(x => x.is_approved == false).ToList();
            ViewBag.Services = db.Services.Where(x => x.is_approved == false).ToList();
            return View();
        }
        [HttpGet]
        public ActionResult ApproveEv(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            DataModel db = new DataModel();
            db.Events.FirstOrDefault(x => x.Id == id).is_approved=true;
            db.SaveChanges();
            return RedirectToAction("Index");

        }


        
        [HttpGet]
        public ActionResult ApproveSe(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            DataModel db = new DataModel();
            db.Services.FirstOrDefault(x => x.Id == id).is_approved = true;
            db.SaveChanges();
            return RedirectToAction("Index");

        }

        [HttpGet]
        public ActionResult ApproveOf(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            DataModel db = new DataModel();
            db.Offers.FirstOrDefault(x => x.Id == id).is_approved = true;
            db.SaveChanges();
            return RedirectToAction("Index");
        }

    }
}