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
    public class Tb_eventController : Controller
    {
        private programEntities db = new programEntities();

        // GET: Tb_event
        public ActionResult Index()
        {
            return View(db.tb_event.ToList());
        }

        // GET: Tb_event/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            tb_event tb_event = db.tb_event.Find(id);
            if (tb_event == null)
            {
                return HttpNotFound();
            }
            return View(tb_event);
        }

        // GET: Tb_event/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Tb_event/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "eventid,eventname,eventdate,eventimage,entryfee,prize,teamsize")] tb_event tb_event)
        {
            if (ModelState.IsValid)
            {
                db.tb_event.Add(tb_event);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(tb_event);
        }

        // GET: Tb_event/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            tb_event tb_event = db.tb_event.Find(id);
            if (tb_event == null)
            {
                return HttpNotFound();
            }
            return View(tb_event);
        }

        // POST: Tb_event/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "eventid,eventname,eventdate,eventimage,entryfee,prize,teamsize")] tb_event tb_event)
        {
            if (ModelState.IsValid)
            {
                db.Entry(tb_event).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(tb_event);
        }

        // GET: Tb_event/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            tb_event tb_event = db.tb_event.Find(id);
            if (tb_event == null)
            {
                return HttpNotFound();
            }
            return View(tb_event);
        }

        // POST: Tb_event/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            tb_event tb_event = db.tb_event.Find(id);
            db.tb_event.Remove(tb_event);
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
