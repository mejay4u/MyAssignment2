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

namespace MyAssignment2.Controllers
{
    public class RoomsController : Controller
    {
        private ProductContext db = new ProductContext();

        // GET: Rooms
        public ActionResult Index()
        {
            return View(db.Rooms.ToList());
        }

        // GET: Rooms/Details/5
        public ActionResult Details(Guid? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Rooms rooms = db.Rooms.Find(id);
            if (rooms == null)
            {
                return HttpNotFound();
            }
            return View(rooms);
        }

        // GET: Rooms/Create
        public ActionResult Create()
        {
            Rooms room = new Rooms();

            List<SelectListItem> selectRoomType = new List<SelectListItem>();
            List<RoomType> roomTypeList = db.RoomTypes.ToList();
            foreach (var listItem in roomTypeList)
            {
                selectRoomType.Add(new SelectListItem
                {
                    Text = listItem.RoomTypeName,
                    Value = listItem.RoomTypeId.ToString()
                });
            }
            room.RoomsTypeList = selectRoomType;

            return View(room);
        }

        // POST: Rooms/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "RoomId,RoomNo,RoomTypeId")] Rooms rooms)
        {
            if (ModelState.IsValid)
            {
                rooms.RoomId = Guid.NewGuid();
                db.Rooms.Add(rooms);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(rooms);
        }

        // GET: Rooms/Edit/5
        public ActionResult Edit(Guid? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Rooms rooms = db.Rooms.Find(id);

            if (rooms == null)
            {
                return HttpNotFound();
            }
          

            List<SelectListItem> selectRoomType = new List<SelectListItem>();
            List<RoomType> roomTypeList = db.RoomTypes.ToList();
            foreach (var listItem in roomTypeList)
            {
                selectRoomType.Add(new SelectListItem
                {
                    Text = listItem.RoomTypeName,
                    Value = listItem.RoomTypeId.ToString()
                });
            }
            rooms.RoomsTypeList = selectRoomType;
            return View(rooms);
        }

        // POST: Rooms/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "RoomId,RoomNo,RoomTypeId")] Rooms rooms)
        {
            if (ModelState.IsValid)
            {
                db.Entry(rooms).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(rooms);
        }

        // GET: Rooms/Delete/5
        public ActionResult Delete(Guid? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Rooms rooms = db.Rooms.Find(id);
            if (rooms == null)
            {
                return HttpNotFound();
            }
            return View(rooms);
        }

        // POST: Rooms/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(Guid id)
        {
            Rooms rooms = db.Rooms.Find(id);
            db.Rooms.Remove(rooms);
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
