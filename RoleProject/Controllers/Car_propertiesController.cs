using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using RoleProject.Models;

namespace RoleProject.Controllers
{
    public class Car_propertiesController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: Car_properties
        public ActionResult List_Of_All()
        {
            return View(db.Car_properties.ToList());
        }

        // GET: Car_properties/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Car_properties car_properties = db.Car_properties.Find(id);
            if (car_properties == null)
            {
                return HttpNotFound();
            }
            return View(car_properties);
        }

        // GET: Car_properties/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Car_properties/Create
  
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create( Car_properties car_properties)
        {
            if (ModelState.IsValid)
            {
                db.Car_properties.Add(car_properties);
                db.SaveChanges();
                return RedirectToAction("List_Of_All");
            }

            return View(car_properties);
        }

        // GET: Car_properties/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Car_properties car_properties = db.Car_properties.Find(id);
            if (car_properties == null)
            {
                return HttpNotFound();
            }
            return View(car_properties);
        }

        // POST: Car_properties/Edit/5
    
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit( Car_properties car_properties)
        {
            if (ModelState.IsValid)
            {
                db.Entry(car_properties).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("List_Of_All");
            }
            return View(car_properties);
        }

        // GET: Car_properties/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Car_properties car_properties = db.Car_properties.Find(id);
            if (car_properties == null)
            {
                return HttpNotFound();
            }
            return View(car_properties);
        }

        // POST: Car_properties/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Car_properties car_properties = db.Car_properties.Find(id);
            db.Car_properties.Remove(car_properties);
            db.SaveChanges();
            return RedirectToAction("List_Of_All");
        }

    }
}
