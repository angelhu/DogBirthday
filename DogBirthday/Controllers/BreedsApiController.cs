using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Description;
using DogBirthday.Models;

namespace DogBirthday.Controllers
{
    public class BreedsApiController : ApiController
    {
        private DogBirthdayContext db = new DogBirthdayContext();

        // GET: api/BreedsApi
        public IQueryable<Breed> GetBreeds()
        {
            return db.Breeds;
        }

        // GET: api/BreedsApi/5
        [ResponseType(typeof(Breed))]
        public IHttpActionResult GetBreed(int id)
        {
            Breed breed = db.Breeds.Find(id);
            if (breed == null)
            {
                return NotFound();
            }

            return Ok(breed);
        }

        // PUT: api/BreedsApi/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutBreed(int id, Breed breed)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != breed.BreedID)
            {
                return BadRequest();
            }

            db.Entry(breed).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!BreedExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return StatusCode(HttpStatusCode.NoContent);
        }

        // POST: api/BreedsApi
        [ResponseType(typeof(Breed))]
        public IHttpActionResult PostBreed(Breed breed)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.Breeds.Add(breed);
            db.SaveChanges();

            return CreatedAtRoute("DefaultApi", new { id = breed.BreedID }, breed);
        }

        // DELETE: api/BreedsApi/5
        [ResponseType(typeof(Breed))]
        public IHttpActionResult DeleteBreed(int id)
        {
            Breed breed = db.Breeds.Find(id);
            if (breed == null)
            {
                return NotFound();
            }

            db.Breeds.Remove(breed);
            db.SaveChanges();

            return Ok(breed);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool BreedExists(int id)
        {
            return db.Breeds.Count(e => e.BreedID == id) > 0;
        }
    }
}