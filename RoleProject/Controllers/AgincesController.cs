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
    public class AgincesController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: Aginces
        public ActionResult List_Of_All()
        {
            return View(db.Agince.ToList());
        }

        // GET: Aginces/Details/5
        public ActionResult Details(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Agince agince = db.Agince.Find(id);
            if (agince == null)
            {
                return HttpNotFound();
            }
            return View(agince);
        }

        // GET: Aginces/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Aginces/Create
     
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create( Agince agince)
        {
            if (ModelState.IsValid)
            {
                //string filename = Path.GetFileNameWithoutExtension(agince.photo_path.FileName);
                //string Extintion = Path.GetExtension(agince.photo_path.FileName);
                //filename = filename + DateTime.Now.ToString("yymmssfff") + Extintion;
                //agince.photo_Agince = filename;
                //filename = Path.Combine(Server.MapPath("~/images/"), filename);
                //agince.photo_path.SaveAs(filename);

                db.Agince.Add(agince);
                db.SaveChanges();
                return RedirectToAction("List_Of_All");
            }

            return View(agince);
        }

        // GET: Aginces/Edit/5
        public ActionResult Edit(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Agince agince = db.Agince.Find(id);
            if (agince == null)
            {
                return HttpNotFound();
            }
            return View(agince);
        }

        // POST: Aginces/Edit/5
      
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit( Agince agince)
        {
            if (ModelState.IsValid)
            {
                string filename = Path.GetFileNameWithoutExtension(agince.photo_path.FileName);
                string Extintion = Path.GetExtension(agince.photo_path.FileName);
                filename = filename + DateTime.Now.ToString("yymmssfff") + Extintion;
                agince.photo_Agince = filename;
                filename = Path.Combine(Server.MapPath("~/images/"), filename);
                agince.photo_path.SaveAs(filename);


                db.Entry(agince).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("List_Of_All");
            }
            return View(agince);
        }

        // GET: Aginces/Delete/5
        public ActionResult Delete(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Agince agince = db.Agince.Find(id);
            if (agince == null)
            {
                return HttpNotFound();
            }
            return View(agince);
        }

        // POST: Aginces/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(string id)
        {
            Agince agince = db.Agince.Find(id);
            db.Agince.Remove(agince);
            db.SaveChanges();
            return RedirectToAction("List_Of_All");
        }

      
    }
}
