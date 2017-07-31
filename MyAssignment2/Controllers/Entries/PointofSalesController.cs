using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using MyAssignment2.Models;
using MyAssignment2.Models.Entries;
using MyAssignment2.Models.Masters;

namespace MyAssignment2.Controllers.Entries
{
    public class PointofSalesController : Controller
    {
        private ProductContext db = new ProductContext();

        // GET: PointofSales
        public ActionResult Index()
        {
            return View(db.PointofSales.ToList());
        }

        // GET: PointofSales/Details/5
        public ActionResult Details(Guid? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            PointofSales pointofSales = db.PointofSales.Find(id);
            if (pointofSales == null)
            {
                return HttpNotFound();
            }
            return View(pointofSales);
        }

        // GET: PointofSales/Create
        public ActionResult Create()
        {
            PointofSales pos = new PointofSales();

            List<SelectListItem> selectServiceType = new List<SelectListItem>();


            selectServiceType.Add(new SelectListItem
            {
                Text = "--Select--",
                Value = "0"
            });
            selectServiceType.Add(new SelectListItem
            {
                Text = "Room Service",
                Value = "1"
            });
            selectServiceType.Add(new SelectListItem
            {
                Text = "Table Service",
                Value = "2"
            });
            selectServiceType.Add(new SelectListItem
            {
                Text = "Parce Service",
                Value = "3"
            });



            List<SelectListItem> selectRoom = new List<SelectListItem>();
            List<Rooms> roomList = db.Rooms.ToList();
            selectRoom.Add(new SelectListItem
            {
                Text = "--Select--",
                Value = "0"
            });
            foreach (var listItem in roomList)
            {
               
                selectRoom.Add(new SelectListItem
                {
                    Text = listItem.RoomNo,
                    Value = listItem.RoomId.ToString()
                });
            }

            List<SelectListItem> selectTable = new List<SelectListItem>();
            List<Tables> tableList = db.Tables.ToList();
            selectTable.Add(new SelectListItem
            {
                Text = "--Select--",
                Value = "0"
            });
            foreach (var listItem in tableList)
            {
               
                selectTable.Add(new SelectListItem
                {
                    Text = listItem.TableName,
                    Value = listItem.TableId.ToString()
                });
            }
            List<SelectListItem> selectItem = new List<SelectListItem>();
            List<Items> itemList = db.Items.ToList();
            selectItem.Add(new SelectListItem
            {
                Text = "--Select--",
                Value = "0"
            });
            foreach (var listItem in itemList)
            {
              
                selectItem.Add(new SelectListItem
                {
                    Text = listItem.ItemName,
                    Value = listItem.ItemId.ToString()
                });
            }


            pos.RoomList = selectRoom;
            pos.TableList = selectTable;
            pos.ItemList = selectItem;
            pos.ServiceTypeList = selectServiceType;

            return View(pos);
        }

        // POST: PointofSales/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "BillId,SBId,BillDate,InvoiceNo,ServiceType,RooomId,TableId,ItemCode,TaxAmount,TotoalAmount")] PointofSales pointofSales)
        {
            if (ModelState.IsValid)
            {
                pointofSales.BillId = Guid.NewGuid();
                db.PointofSales.Add(pointofSales);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(pointofSales);
        }

        // GET: PointofSales/Edit/5
        public ActionResult Edit(Guid? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            PointofSales pointofSales = db.PointofSales.Find(id);
            if (pointofSales == null)
            {
                return HttpNotFound();
            }
            return View(pointofSales);
        }

        // POST: PointofSales/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "BillId,SBId,BillDate,InvoiceNo,ServiceType,RooomId,TableId,ItemCode,TaxAmount,TotoalAmount")] PointofSales pointofSales)
        {
            if (ModelState.IsValid)
            {
                db.Entry(pointofSales).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(pointofSales);
        }

        // GET: PointofSales/Delete/5
        public ActionResult Delete(Guid? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            PointofSales pointofSales = db.PointofSales.Find(id);
            if (pointofSales == null)
            {
                return HttpNotFound();
            }
            return View(pointofSales);
        }

        // POST: PointofSales/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(Guid id)
        {
            PointofSales pointofSales = db.PointofSales.Find(id);
            db.PointofSales.Remove(pointofSales);
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
