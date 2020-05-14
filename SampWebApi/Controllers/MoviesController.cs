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
using SampWebApi.Models;

namespace SampWebApi.Controllers
{
    [RoutePrefix("api")]
    public class MoviesController : ApiController
    {
        private MoviesDBEntities db = new MoviesDBEntities();

        // GET: api/Movies
        [Route("Movies")]
        public IQueryable<Movy> GetMovies()
        {
            return db.Movies;
        }

        // GET: api/Movies/5
        [Route("Movies/{id:int}")]
        [ResponseType(typeof(Movy))]
        public IHttpActionResult GetMovy(int id)
        {
            Movy movy = db.Movies.Find(id);
            if (movy == null)
            {
                return NotFound();
            }

            return Ok(movy);
        }

        // PUT: api/Movies/5
        [Route("UpdateMovie/{id:int}")]
        [ResponseType(typeof(void))]
        public IHttpActionResult PutMovy(int id,Movy movy)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != movy.MovieID)
            {
                return BadRequest();
            }

            db.Entry(movy).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!MovyExists(id))
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

        // POST: api/Movies
        [Route("AddMovie")]
        [ResponseType(typeof(Movy))]
        public IHttpActionResult PostMovy(Movy movy)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.Movies.Add(movy);
            db.SaveChanges();
            return CreatedAtRoute("DefaultApi", new { id = movy.MovieID }, movy);
        }

        // DELETE: api/Movies/5
        [Route("DeleteMovie/{id:int}")]
        [ResponseType(typeof(Movy))]
        public IHttpActionResult DeleteMovy(int id)
        {
            Movy movy = db.Movies.Find(id);
            if (movy == null)
            {
                return NotFound();
            }

            db.Movies.Remove(movy);
            db.SaveChanges();

            return Ok(movy);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool MovyExists(int id)
        {
            return db.Movies.Count(e => e.MovieID == id) > 0;
        }
    }

//minor changes

}