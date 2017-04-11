using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using DogBirthday.Models;
using Microsoft.AspNet.Identity;

namespace DogBirthday.Controllers
{
    [Authorize]
    public class DogsController : Controller
    {
        private DogBirthdayContext db = new DogBirthdayContext();

        // GET: Dogs
        public ActionResult Index()
        {
            string userId = User.Identity.GetUserId();
            var dogs = db.Dogs.Where(dog => dog.CreatedBy == userId).Include(d => d.DogBreed);
            return View(dogs.ToList());
        }

        // GET: Dogs/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Dog dog = db.Dogs.Find(id);
            if (dog == null || dog.CreatedBy != User.Identity.GetUserId())
            {
                return HttpNotFound();
            }
            return View(dog);
        }

        // GET: Dogs/Create
        public ActionResult Create()
        {
            ViewBag.BreedID = new SelectList(db.Breeds, "BreedID", "Description");
            return View();
        }

        // POST: Dogs/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "DogID,Name,DogGender,Birthday,BreedID,Owner")] Dog dog)
        {
            if (ModelState.IsValid)
            {
                dog.CreatedBy = User.Identity.GetUserId();
                db.Dogs.Add(dog);
                db.SaveChanges();
                return RedirectToAction("Index");
            } 

            ViewBag.BreedID = new SelectList(db.Breeds, "BreedID", "Description", dog.BreedID);
            return View(dog);
        }

        // GET: Dogs/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Dog dog = db.Dogs.Find(id);
            if (dog == null || dog.CreatedBy != User.Identity.GetUserId())
            {
                return HttpNotFound();
            }
            ViewBag.BreedID = new SelectList(db.Breeds, "BreedID", "Description", dog.BreedID);
            return View(dog);
        }

        // POST: Dogs/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "DogID,Name,DogGender,Birthday,BreedID,Owner")] Dog dog)
        {
            Dog originalDog = db.Dogs.Find(dog.DogID);
            if (dog == null || originalDog.CreatedBy != User.Identity.GetUserId())
            {
                return HttpNotFound();
            }
            if (ModelState.IsValid)
            {
                dog.CreatedBy = originalDog.CreatedBy;
                db.Entry(originalDog).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.BreedID = new SelectList(db.Breeds, "BreedID", "Description", dog.BreedID);
            return View(dog);
        }

        // GET: Dogs/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Dog dog = db.Dogs.Find(id);
            if (dog == null || dog.CreatedBy != User.Identity.GetUserId())
            {
                return HttpNotFound();
            }
            return View(dog);
        }

        // POST: Dogs/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Dog dog = db.Dogs.Find(id);
            db.Dogs.Remove(dog);
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
