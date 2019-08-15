//using System;
//using System.Collections.Generic;
//using System.IO;
//using System.Linq;
//using System.Net;
//using System.Web;
//using System.Web.Mvc;
//using RoleProject.Models;

//namespace RoleProject.Controllers
//{
//    public class AginceController : Controller
//    {
//        ApplicationDbContext context = new ApplicationDbContext();
//        // GET: Agince
//        public ActionResult Index()
//        {


//            return View(context.Agince.ToList());

//        }

//        // GET: Agince/Details/5
//        public ActionResult Details(String id)
//        {
//            try
//            {
//                var Agince = context.Agince.FirstOrDefault(ag => ag.Agince_ID == id);
//                return View(Agince);
//            }
//            catch
//            {
//                return View();
//            }
//        }

//        // GET: Agince/Create
//        public ActionResult Create()
//        {
//            return View();
//        }

//        // POST: Agince/Create
//        [HttpPost]
//        public ActionResult Create(string password, Agince agince)
//        {
//            #region Old_Creat
//            //try
//            //{
//            //    agince.password = password;  
//            //    /*Add photo to Data Base*/
//            //    string filename = Path.GetFileNameWithoutExtension(agince.photo_path.FileName);
//            //    string Extintion = Path.GetExtension(agince.photo_path.FileName);
//            //    filename = filename + DateTime.Now.ToString("yymmssfff") + Extintion;
//            //    agince.photo_Agince =filename;
//            //    filename = Path.Combine(Server.MapPath("~/images/"), filename);
//            //    agince.photo_path.SaveAs(filename);
//            //    //----------------------------//
//            //    context.Agince.Add(agince);
//            //    context.SaveChanges();
//            //    return RedirectToAction("Index","Home");
//            //}
//            //catch
//            //{
//            //    return View("Create");
//            //} 
//            #endregion
//            if (ModelState.IsValid)
//            {
//                /*Add photo to Data Base*/
//                string filename = Path.GetFileNameWithoutExtension(agince.photo_path.FileName);
//                string Extintion = Path.GetExtension(agince.photo_path.FileName);
//                filename = filename + DateTime.Now.ToString("yymmssfff") + Extintion;
//                agince.photo_Agince = filename;
//                filename = Path.Combine(Server.MapPath("~/images/"), filename);
//                agince.photo_path.SaveAs(filename);
//                //----------------------------//
//                context.Agince.Add(agince);
//                context.SaveChanges();
//                return RedirectToAction("Index");
//            }

//            return View(agince);
//        }

//        // GET: Agince/Edit/5
//        public ActionResult Edit(string id)
//        {

//            if (id == null)
//            {
//                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
//            }
//            Agince aganis_Car = context.Agince.Find(id);
//            if (aganis_Car == null)
//            {
//                return HttpNotFound();
//            }
//            return View(aganis_Car);

//        }
//        // POST: Agince/Edit/5
//        [HttpPost]
//        public ActionResult Edit(String id, Agince agince, string password)
//        {

//            try
//            {
//                var newAgince = context.Agince.FirstOrDefault(agince_ => agince_.Agince_ID == id);

//                if (newAgince.password == password)
//                {
//                    newAgince.password = password;
//                    newAgince.confirm_Password = password;
//                    newAgince.name = agince.name;
//                    newAgince.phone_number = agince.phone_number;
//                    /*Add photo to Data Base*/
//                    string filename = Path.GetFileNameWithoutExtension(agince.photo_path.FileName);
//                    string Extintion = Path.GetExtension(agince.photo_path.FileName);
//                    filename = filename + DateTime.Now.ToString("yymmssfff") + Extintion;
//                    newAgince.photo_Agince = filename;
//                    filename = Path.Combine(Server.MapPath("~/images/"), filename);
//                    agince.photo_path.SaveAs(filename);
//                    //----------------------------//
//                }
//                else
//                {
//                    return View("Edit");
//                }


//                context.SaveChanges();
//                return RedirectToAction("Index");
//            }
//            catch
//            {
//                return View("Edit");
//            }
//        }

//        // GET: Agince/Delete/5
//        public ActionResult Delete(string id)
//        {
//            var Deleted_Agince = context.Agince.FirstOrDefault(agince_ => agince_.Agince_ID == id);
//            return View(Deleted_Agince);
//        }

//        // POST: Agince/Delete/5
//        [HttpPost]
//        public ActionResult Delete(String id)
//        {
//            try
//            {

//                var Deleted_Agince = context.Agince.FirstOrDefault(agince_ => agince_.Agince_ID == id);
//                context.Agince.Remove(Deleted_Agince);
//                context.SaveChanges();
//                return RedirectToAction("Index");
//            }
//            catch
//            {
//                return View();
//            }
//        }
//    }
//}
