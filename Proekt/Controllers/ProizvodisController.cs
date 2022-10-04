﻿using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using Proekt.Models;

namespace Proekt.Controllers
{
    public class ProizvodisController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: Proizvodis
        public ActionResult Index()
        {
            return View(db.proizvodi.ToList());
        }

        // GET: Proizvodis/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Proizvodi proizvodi = db.proizvodi.Find(id);
            if (proizvodi == null)
            {
                return HttpNotFound();
            }
            return View(proizvodi);
        }

        // GET: Proizvodis/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Proizvodis/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,Name,Description,Price,ImageURL")] Proizvodi proizvodi)
        {
            if (ModelState.IsValid)
            {
                db.proizvodi.Add(proizvodi);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(proizvodi);
        }

        // GET: Proizvodis/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Proizvodi proizvodi = db.proizvodi.Find(id);
            if (proizvodi == null)
            {
                return HttpNotFound();
            }
            return View(proizvodi);
        }

        // POST: Proizvodis/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,Name,Description,Price,ImageURL")] Proizvodi proizvodi)
        {
            if (ModelState.IsValid)
            {
                db.Entry(proizvodi).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(proizvodi);
        }

        // GET: Proizvodis/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Proizvodi proizvodi = db.proizvodi.Find(id);
            if (proizvodi == null)
            {
                return HttpNotFound();
            }
            return View(proizvodi);
        }

        // POST: Proizvodis/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Proizvodi proizvodi = db.proizvodi.Find(id);
            db.proizvodi.Remove(proizvodi);
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
