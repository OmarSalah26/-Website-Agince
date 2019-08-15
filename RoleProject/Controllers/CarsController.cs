using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.IO;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using RoleProject.Models;

namespace RoleProject.Controllers
{
    public class CarsController:Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();
        
        // GET: Cars
        public ActionResult List_Of_All()
        {
            var cars = db.Cars.ToList();
            return View(cars);
        }

        // GET: Cars/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Car car = db.Cars.Find(id);
            if (car == null)
            {
                return HttpNotFound();
            }
            return View(car);
        }



        // GET: Cars/Create
        //[Authorize(Roles = "Clinet")]
        public ActionResult Create()
        {

            return View();
        }

        // POST: Cars/Create

        [HttpPost]
        [ValidateAntiForgeryToken]

        public ActionResult Create( Car car)
        {
            if (ModelState.IsValid)
            {

                //string filename = Path.GetFileNameWithoutExtension(car.photo_path.FileName);
                //string Extintion = Path.GetExtension(car.photo_path.FileName);
                //filename = filename + DateTime.Now.ToString("yymmssfff") + Extintion;
                //car.photo_Car = filename;
                //filename = Path.Combine(Server.MapPath("~/images/"), filename);
                //car.photo_path.SaveAs(filename);

                db.Cars.Add(car);
                db.SaveChanges();
                return RedirectToAction("List_Of_All");
            }

            return View(car);
        }

        // GET: Cars/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Car car = db.Cars.Find(id);
            if (car == null)
            {
                return HttpNotFound();
            }

            return View(car);
        }

        // POST: Cars/Edit/5








        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(Car car)
        {
            if (ModelState.IsValid)
            {
                string filename = Path.GetFileNameWithoutExtension(car.photo_path.FileName);
                string Extintion = Path.GetExtension(car.photo_path.FileName);
                filename = filename + DateTime.Now.ToString("yymmssfff") + Extintion;
                car.photo_Car = filename;
                filename = Path.Combine(Server.MapPath("~/images/"), filename);
                car.photo_path.SaveAs(filename);

                db.Entry(car).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("List_Of_All");
            }

            return View(car);
        }

        // GET: Cars/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Car car = db.Cars.Find(id);
            if (car == null)
            {
                return HttpNotFound();
            }
            return View(car);
        }

        // POST: Cars/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Car car = db.Cars.Find(id);
            db.Cars.Remove(car);
            db.SaveChanges();
            return RedirectToAction("List_Of_All");
        }










        public ActionResult Booking(int id)
        {
            return View(db.Cars.Find(id));
        }

        // POST: Cars/Edit/5




        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Booking(Car car)
        {
            if (ModelState.IsValid)
            {

                db.Entry(car).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(car);
        }

        public ActionResult CancelBooking(int id)
        {
            return View(db.Cars.Find(id));
        }

        // POST: Cars/Edit/5




        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult CancelBooking(Car car)
        {
            if (ModelState.IsValid)
            {

                db.Entry(car).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(car);
        }

        //search 

        public ActionResult Search(string searchName)
        {
            var result =((from e in db.Cars
                          where e.Car_Model.Contains(searchName)
                          select e).ToList());
            return View("List_Of_All", result);
                }
        }
}