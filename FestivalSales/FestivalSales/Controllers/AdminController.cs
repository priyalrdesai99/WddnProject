using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using Microsoft.AspNet.Identity;
using FestivalSales.Models;
namespace FestivalSales.Controllers
{
    public class AdminController : Controller
    {
        // GET: Admin
        string tid;
        [Authorize]
        public ActionResult Index()
        {
            
            DataModel db = new DataModel();
            string idd = User.Identity.GetUserId();
            UserInfo info = db.UserInfos.FirstOrDefault(x => x.AccountId == idd);
            System.Diagnostics.Debug.WriteLine(info.name);
            System.Diagnostics.Debug.WriteLine(info.userRole.Id);
            ViewBag.Events = db.Events.Where(x => x.is_approved == false).ToList();
            ViewBag.Offers = db.Offers.Where(x => x.is_approved == false).ToList();
            ViewBag.Services = db.Services.Where(x => x.is_approved == false).ToList();
            return View();
        }
        [Authorize]
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
        [Authorize]
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