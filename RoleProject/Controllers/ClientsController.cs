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
    public class ClientsController:Controller
    {


            private ApplicationDbContext db = new ApplicationDbContext();

            // GET: Clinets
            public ActionResult List_Of_All()
            {
                return View(db.Client.ToList());
            }

            // GET: Clinets/Details/5
            public ActionResult Details(String id)
            {
                if (id == null)
                {
                    return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
                }
            Client clinet = db.Client.Find(id);
                if (clinet == null)
                {
                    return HttpNotFound();
                }
                return View(clinet);
            }

            // GET: Clinets/Create
            public ActionResult Create()
            {
                return View();
            }

            // POST: Clinets/Create

            [HttpPost]
            [ValidateAntiForgeryToken]
            public ActionResult Create(Client clinet)
            {
                if (ModelState.IsValid)
                {
                    db.Client.Add(clinet);
                    db.SaveChanges();
                    return RedirectToAction("List_Of_All");
                }

                return View(clinet);
            }

            // GET: Clinets/Edit/5
            public ActionResult Edit(string id)
            {
                return View(db.Client.Find(id));
            }

            // POST: Clinets/Edit/5

            [HttpPost]
            [ValidateAntiForgeryToken]
            public ActionResult Edit(Client clinet)
            {
                if (ModelState.IsValid)
                {
                    db.Entry(clinet).State = EntityState.Modified;
                    db.SaveChanges();
                    return RedirectToAction("List_Of_All");
                }
                return View(clinet);
            }

            // GET: Clinets/Delete/5
            public ActionResult Delete(String id)
            {
                if (id == null)
                {
                    return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
                }
            Client clinet = db.Client.Find(id);
                if (clinet == null)
                {
                    return HttpNotFound();
                }
                return View(clinet);
            }

            // POST: Clinets/Delete/5
            [HttpPost, ActionName("Delete")]
            [ValidateAntiForgeryToken]
            public ActionResult DeleteConfirmed(String id)
            {
            Client clinet = db.Client.Find(id);
                db.Client.Remove(clinet);
                db.SaveChanges();
                return RedirectToAction("List_Of_All");
            }





        }
    }


