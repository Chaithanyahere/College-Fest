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
    public class ResultsController : Controller
    {
        private programEntities db = new programEntities();

        // GET: Results
        public ActionResult Index()
        {
            var results = db.results.Include(r => r.register).Include(r => r.tb_event);
            return View(results.ToList());
        }

        // GET: Results/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            result result = db.results.Find(id);
            if (result == null)
            {
                return HttpNotFound();
            }
            return View(result);
        }

        // GET: Results/Create
        public ActionResult Create()
        {
            ViewBag.rid = new SelectList(db.registers, "rid", "firstname");
            ViewBag.eid = new SelectList(db.tb_event, "eventid", "eventname");
            return View();
        }

        // POST: Results/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "resultid,rid,eid,prize,comment")] result result)
        {
            if (ModelState.IsValid)
            {
                db.results.Add(result);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.rid = new SelectList(db.registers, "rid", "firstname", result.rid);
            ViewBag.eid = new SelectList(db.tb_event, "eventid", "eventname", result.eid);
            return View(result);
        }

        // GET: Results/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            result result = db.results.Find(id);
            if (result == null)
            {
                return HttpNotFound();
            }
            ViewBag.rid = new SelectList(db.registers, "rid", "firstname", result.rid);
            ViewBag.eid = new SelectList(db.tb_event, "eventid", "eventname", result.eid);
            return View(result);
        }

        // POST: Results/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "resultid,rid,eid,prize,comment")] result result)
        {
            if (ModelState.IsValid)
            {
                db.Entry(result).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.rid = new SelectList(db.registers, "rid", "firstname", result.rid);
            ViewBag.eid = new SelectList(db.tb_event, "eventid", "eventname", result.eid);
            return View(result);
        }

        // GET: Results/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            result result = db.results.Find(id);
            if (result == null)
            {
                return HttpNotFound();
            }
            return View(result);
        }

        // POST: Results/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            result result = db.results.Find(id);
            db.results.Remove(result);
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
