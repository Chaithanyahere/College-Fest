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
    public class WinnersController : Controller
    {
        private programEntities db = new programEntities();

        // GET: Winners
        public ActionResult Index()
        {
            var winners = db.winners.Include(w => w.register).Include(w => w.tb_event);
            return View(winners.ToList());
        }

        // GET: Winners/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            winner winner = db.winners.Find(id);
            if (winner == null)
            {
                return HttpNotFound();
            }
            return View(winner);
        }

        // GET: Winners/Create
        public ActionResult Create()
        {
            ViewBag.rid = new SelectList(db.registers, "rid", "firstname");
            ViewBag.eid = new SelectList(db.tb_event, "eventid", "eventname");
            return View();
        }

        // POST: Winners/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "winid,eid,rid,prizetype,prizewon")] winner winner)
        {
            if (ModelState.IsValid)
            {
                db.winners.Add(winner);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.rid = new SelectList(db.registers, "rid", "firstname", winner.rid);
            ViewBag.eid = new SelectList(db.tb_event, "eventid", "eventname", winner.eid);
            return View(winner);
        }

        // GET: Winners/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            winner winner = db.winners.Find(id);
            if (winner == null)
            {
                return HttpNotFound();
            }
            ViewBag.rid = new SelectList(db.registers, "rid", "firstname", winner.rid);
            ViewBag.eid = new SelectList(db.tb_event, "eventid", "eventname", winner.eid);
            return View(winner);
        }

        // POST: Winners/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "winid,eid,rid,prizetype,prizewon")] winner winner)
        {
            if (ModelState.IsValid)
            {
                db.Entry(winner).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.rid = new SelectList(db.registers, "rid", "firstname", winner.rid);
            ViewBag.eid = new SelectList(db.tb_event, "eventid", "eventname", winner.eid);
            return View(winner);
        }

        // GET: Winners/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            winner winner = db.winners.Find(id);
            if (winner == null)
            {
                return HttpNotFound();
            }
            return View(winner);
        }

        // POST: Winners/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            winner winner = db.winners.Find(id);
            db.winners.Remove(winner);
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
