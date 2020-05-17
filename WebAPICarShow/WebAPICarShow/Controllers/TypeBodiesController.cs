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
using WebAPICarShow.Models;

namespace WebAPICarShow.Controllers
{
    public class TypeBodiesController : ApiController
    {
        private DBCarShowEntities db = new DBCarShowEntities();

        // GET: api/TypeBodies
        public IQueryable<TypeBody> GetTypeBody()
        {
            return db.TypeBody;
        }

        // GET: api/TypeBodies/5
        [ResponseType(typeof(TypeBody))]
        public IHttpActionResult GetTypeBody(int id)
        {
            TypeBody typeBody = db.TypeBody.Find(id);
            if (typeBody == null)
            {
                return NotFound();
            }

            return Ok(typeBody);
        }

        // PUT: api/TypeBodies/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutTypeBody(int id, TypeBody typeBody)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != typeBody.id)
            {
                return BadRequest();
            }

            db.Entry(typeBody).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!TypeBodyExists(id))
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

        // POST: api/TypeBodies
        [ResponseType(typeof(TypeBody))]
        public IHttpActionResult PostTypeBody(TypeBody typeBody)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.TypeBody.Add(typeBody);
            db.SaveChanges();

            return CreatedAtRoute("DefaultApi", new { id = typeBody.id }, typeBody);
        }

        // DELETE: api/TypeBodies/5
        [ResponseType(typeof(TypeBody))]
        public IHttpActionResult DeleteTypeBody(int id)
        {
            TypeBody typeBody = db.TypeBody.Find(id);
            if (typeBody == null)
            {
                return NotFound();
            }

            db.TypeBody.Remove(typeBody);
            db.SaveChanges();

            return Ok(typeBody);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool TypeBodyExists(int id)
        {
            return db.TypeBody.Count(e => e.id == id) > 0;
        }
    }
}