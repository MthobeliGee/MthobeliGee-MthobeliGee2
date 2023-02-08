using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.IO;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using testApp1_MVC_.Models;

namespace testApp1_MVC_.Controllers
{
    public class Test1Controller : Controller
    {
        private context db = new context();

        // GET: Test1
        public ActionResult Index()
        {
            return View(db.Tests.ToList());
        }


        public FileResult DownloadFile(int id)
        {
            Test1 test1 = db.Tests.Find(id);
            //Build the File Path.
            string path = Server.MapPath(test1.excelFile);

            //Read the File data into Byte Array.
            byte[] bytes = System.IO.File.ReadAllBytes(path);

            //Send the File to Download.
            
            return File(bytes, "application/octet-stream", test1.name+test1.extection);
        }
        // GET: Test1/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Test1 test1 = db.Tests.Find(id);
            if (test1 == null)
            {
                return HttpNotFound();
            }
            return View(test1);
        }

        // GET: Test1/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Test1/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,name,surname,dateOfBirth")] Test1 test1, HttpPostedFileBase upload)
        {
            Console.Write(upload);
            string fileName = Path.GetFileName(upload.FileName);
            string extection = Path.GetExtension(upload.FileName);

            string name = fileName;
            
            if (ModelState.IsValid)
            {
                test1.extection = extection;
                test1.excelFile = "~/excelfiles/" + fileName;
                fileName = Path.Combine(Server.MapPath("~/excelfiles/"), fileName);
                upload.SaveAs(fileName);


                db.Tests.Add(test1);
                db.SaveChanges();
                return RedirectToAction("Index");
            }




            
             
           
           
                    
             
             



            return View(test1);
        }

        // GET: Test1/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Test1 test1 = db.Tests.Find(id);
            if (test1 == null)
            {
                return HttpNotFound();
            }
            return View(test1);
        }

        // POST: Test1/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,name,surname,age")] Test1 test1)
        {
            if (ModelState.IsValid)
            {
                db.Entry(test1).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(test1);
        }

        // GET: Test1/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Test1 test1 = db.Tests.Find(id);
            if (test1 == null)
            {
                return HttpNotFound();
            }
            return View(test1);
        }

        // POST: Test1/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Test1 test1 = db.Tests.Find(id);
            db.Tests.Remove(test1);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
