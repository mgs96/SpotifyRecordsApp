using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using SpotifyRecordsApp.Models;

namespace SpotifyRecordsApp.Controllers
{
    public class RankingsController : Controller
    {
        private SpotifyRecordsEntities db = new SpotifyRecordsEntities();

        // GET: Rankings
        public ActionResult Index()
        {
            var rankings = db.Rankings.Include(r => r.Users).Include(r => r.Songs);
            return View(rankings.ToList());
        }

        // GET: Rankings/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Rankings rankings = db.Rankings.Find(id);
            if (rankings == null)
            {
                return HttpNotFound();
            }
            return View(rankings);
        }

        // GET: Rankings/Create
        public ActionResult Create()
        {
            ViewBag.UserId = new SelectList(db.Users, "Id", "Username");
            ViewBag.SongId = new SelectList(db.Songs, "Id", "Name");
            return View();
        }

        // POST: Rankings/Create
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "UserId,SongId,Rating")] Rankings rankings)
        {
            if (ModelState.IsValid)
            {
                db.Rankings.Add(rankings);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.UserId = new SelectList(db.Users, "Id", "Username", rankings.UserId);
            ViewBag.SongId = new SelectList(db.Songs, "Id", "Name", rankings.SongId);
            return View(rankings);
        }

        // GET: Rankings/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Rankings rankings = db.Rankings.Find(id);
            if (rankings == null)
            {
                return HttpNotFound();
            }
            ViewBag.UserId = new SelectList(db.Users, "Id", "Username", rankings.UserId);
            ViewBag.SongId = new SelectList(db.Songs, "Id", "Name", rankings.SongId);
            return View(rankings);
        }

        // POST: Rankings/Edit/5
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "UserId,SongId,Rating")] Rankings rankings)
        {
            if (ModelState.IsValid)
            {
                db.Entry(rankings).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.UserId = new SelectList(db.Users, "Id", "Username", rankings.UserId);
            ViewBag.SongId = new SelectList(db.Songs, "Id", "Name", rankings.SongId);
            return View(rankings);
        }

        // GET: Rankings/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Rankings rankings = db.Rankings.Find(id);
            if (rankings == null)
            {
                return HttpNotFound();
            }
            return View(rankings);
        }

        // POST: Rankings/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Rankings rankings = db.Rankings.Find(id);
            db.Rankings.Remove(rankings);
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
