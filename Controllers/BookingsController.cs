using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using College_Fest.Models;

namespace College_Fest.Controllers
{
    public class BookingsController : Controller
    {
        private programEntities db = new programEntities();

        // GET: Bookings
        public ActionResult Index()
        {
            var bookings = db.bookings.Include(b => b.tb_event).Include(b => b.register);
            return View(bookings.ToList());
        }

        // GET: Bookings/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            booking booking = db.bookings.Find(id);
            if (booking == null)
            {
                return HttpNotFound();
            }
            return View(booking);
        }

        // GET: Bookings/Create
        public ActionResult Create()
        {
            ViewBag.eid = new SelectList(db.tb_event, "eventid", "eventname");
            ViewBag.rid = new SelectList(db.registers, "rid", "firstname");
            return View();
        }

        // POST: Bookings/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "bid,eid,rid")] booking booking)
        {
            if (ModelState.IsValid)
            {
                db.bookings.Add(booking);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.eid = new SelectList(db.tb_event, "eventid", "eventname", booking.eid);
            ViewBag.rid = new SelectList(db.registers, "rid", "firstname", booking.rid);
            return View(booking);
        }

        // GET: Bookings/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            booking booking = db.bookings.Find(id);
            if (booking == null)
            {
                return HttpNotFound();
            }
            ViewBag.eid = new SelectList(db.tb_event, "eventid", "eventname", booking.eid);
            ViewBag.rid = new SelectList(db.registers, "rid", "firstname", booking.rid);
            return View(booking);
        }

        // POST: Bookings/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "bid,eid,rid")] booking booking)
        {
            if (ModelState.IsValid)
            {
                db.Entry(booking).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.eid = new SelectList(db.tb_event, "eventid", "eventname", booking.eid);
            ViewBag.rid = new SelectList(db.registers, "rid", "firstname", booking.rid);
            return View(booking);
        }

        // GET: Bookings/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            booking booking = db.bookings.Find(id);
            if (booking == null)
            {
                return HttpNotFound();
            }
            return View(booking);
        }

        // POST: Bookings/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            booking booking = db.bookings.Find(id);
            db.bookings.Remove(booking);
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
