using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using MyAssignment2.Models;
using MyAssignment2.Models.Masters;

namespace MyAssignment2.Controllers.Masters
{
    public class TablesController : Controller
    {
        private ProductContext db = new ProductContext();

        // GET: Tables
        public ActionResult Index()
        {
            return View(db.Tables.ToList());
        }

        // GET: Tables/Details/5
        public ActionResult Details(Guid? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Tables tables = db.Tables.Find(id);
            if (tables == null)
            {
                return HttpNotFound();
            }
            return View(tables);
        }

        // GET: Tables/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Tables/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "TableId,TableName,Capacity")] Tables tables)
        {
            if (ModelState.IsValid)
            {
                tables.TableId = Guid.NewGuid();
                db.Tables.Add(tables);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(tables);
        }

        // GET: Tables/Edit/5
        public ActionResult Edit(Guid? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Tables tables = db.Tables.Find(id);
            if (tables == null)
            {
                return HttpNotFound();
            }
            return View(tables);
        }

        // POST: Tables/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "TableId,TableName,Capacity")] Tables tables)
        {
            if (ModelState.IsValid)
            {
                db.Entry(tables).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(tables);
        }

        // GET: Tables/Delete/5
        public ActionResult Delete(Guid? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Tables tables = db.Tables.Find(id);
            if (tables == null)
            {
                return HttpNotFound();
            }
            return View(tables);
        }

        // POST: Tables/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(Guid id)
        {
            Tables tables = db.Tables.Find(id);
            db.Tables.Remove(tables);
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
