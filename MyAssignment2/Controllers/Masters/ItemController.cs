using MyAssignment2.Models;
using MyAssignment2.Models.Masters;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;

namespace MyAssignment2.Controllers.Masters
{
    public class ItemController : Controller
    {
        private ProductContext db = new ProductContext();
        // GET: Item
        public ActionResult Index()
        {
            return View(db.Items.ToList());
        }
        // GET: Item/Create
        public ActionResult Create()
        {
         
            Items item = new Items();
           
            List<SelectListItem> selectUnit = new List<SelectListItem>();
            List<Unit> unitList = db.Units.ToList();
            foreach (var listItem in unitList)
            {
                selectUnit.Add(new SelectListItem
                {
                    Text =listItem.UnitName,
                    Value = listItem.UnitId.ToString()
                });
            }
          
          
            List<SelectListItem> selectItemGroup = new List<SelectListItem>();
            List<ItemGroups> itemgroupList = db.ItemGroups.ToList();
            foreach (var listItem in itemgroupList)
            {
                selectItemGroup.Add(new SelectListItem
                {
                    Text = listItem.ItemGroupName,
                    Value = listItem.ItemGroupId.ToString()
                });
            }

            

            item.UnitsList = selectUnit;
            item.ItemGroupList = selectItemGroup;


            return View(item);
        }

        // GET: Item/Details/5
        public ActionResult Details(Guid? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Items item = db.Items.Find(id);
            if (item == null)
            {
                return HttpNotFound();
            }
            return View(item);
        }

        // POST: Items/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ItemId,ItemName,ItemCode,ItemGroupId,UnitId,RoomRate,TableRate")] Items items)
        {
            if (ModelState.IsValid)
            {
                items.ItemId = Guid.NewGuid();
                db.Items.Add(items);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(items);
        }


        // GET: ItemGroups/Edit/5
        public ActionResult Edit(Guid? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Items item = db.Items.Find(id);
            if (item == null)
            {
                return HttpNotFound();
            }

            List<SelectListItem> selectUnit = new List<SelectListItem>();
            List<Unit> unitList = db.Units.ToList();
            foreach (var listItem in unitList)
            {
                selectUnit.Add(new SelectListItem
                {
                    Text = listItem.UnitName,
                    Value = listItem.UnitId.ToString()
                });
            }


            List<SelectListItem> selectItemGroup = new List<SelectListItem>();
            List<ItemGroups> itemgroupList = db.ItemGroups.ToList();
            foreach (var listItem in itemgroupList)
            {
                selectItemGroup.Add(new SelectListItem
                {
                    Text = listItem.ItemGroupName,
                    Value = listItem.ItemGroupId.ToString()
                });
            }



            item.UnitsList = selectUnit;
            item.ItemGroupList = selectItemGroup;

            return View(item);
        }


        // POST: ItemGroups/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ItemId,ItemName,ItemCode,ItemGroupId,UnitId,RoomRate,TableRate")] Items items)
        {
            if (ModelState.IsValid)
            {
                db.Entry(items).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(items);
        }
        // GET: Item/Delete/5
        public ActionResult Delete(Guid? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Items items = db.Items.Find(id);
            if (items == null)
            {
                return HttpNotFound();
            }
            return View(items);
        }

        // POST: Items/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(Guid id)
        {
            Items items = db.Items.Find(id);
            db.Items.Remove(items);
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