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
    public class ItemGroupsController : Controller
    {
        private ProductContext db = new ProductContext();

        // GET: ItemGroups
        public ActionResult Index()
        {
            return View(db.ItemGroups.ToList());
        }

        // GET: ItemGroups/Details/5
        public ActionResult Details(Guid? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ItemGroups itemGroups = db.ItemGroups.Find(id);
            if (itemGroups == null)
            {
                return HttpNotFound();
            }
            return View(itemGroups);
        }

        // GET: ItemGroups/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: ItemGroups/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ItemGroupId,ItemGroupName")] ItemGroups itemGroups)
        {
            if (ModelState.IsValid)
            {
                itemGroups.ItemGroupId = Guid.NewGuid();
                db.ItemGroups.Add(itemGroups);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(itemGroups);
        }

        // GET: ItemGroups/Edit/5
        public ActionResult Edit(Guid? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ItemGroups itemGroups = db.ItemGroups.Find(id);
            if (itemGroups == null)
            {
                return HttpNotFound();
            }
            return View(itemGroups);
        }

        // POST: ItemGroups/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ItemGroupId,ItemGroupName")] ItemGroups itemGroups)
        {
            if (ModelState.IsValid)
            {
                db.Entry(itemGroups).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(itemGroups);
        }

        // GET: ItemGroups/Delete/5
        public ActionResult Delete(Guid? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ItemGroups itemGroups = db.ItemGroups.Find(id);
            if (itemGroups == null)
            {
                return HttpNotFound();
            }
            return View(itemGroups);
        }

        // POST: ItemGroups/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(Guid id)
        {
            ItemGroups itemGroups = db.ItemGroups.Find(id);
            db.ItemGroups.Remove(itemGroups);
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
