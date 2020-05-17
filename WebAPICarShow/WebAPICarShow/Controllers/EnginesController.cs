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
    public class EnginesController : ApiController
    {
        private DBCarShowEntities db = new DBCarShowEntities();

        // GET: api/Engines
        public IQueryable<Engine> GetEngine()
        {
            return db.Engine;
        }

        // GET: api/Engines/5
        [ResponseType(typeof(Engine))]
        public IHttpActionResult GetEngine(int id)
        {
            Engine engine = db.Engine.Find(id);
            if (engine == null)
            {
                return NotFound();
            }

            return Ok(engine);
        }

        // PUT: api/Engines/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutEngine(int id, Engine engine)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != engine.id)
            {
                return BadRequest();
            }

            db.Entry(engine).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!EngineExists(id))
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

        // POST: api/Engines
        [ResponseType(typeof(Engine))]
        public IHttpActionResult PostEngine(Engine engine)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.Engine.Add(engine);
            db.SaveChanges();

            return CreatedAtRoute("DefaultApi", new { id = engine.id }, engine);
        }

        // DELETE: api/Engines/5
        [ResponseType(typeof(Engine))]
        public IHttpActionResult DeleteEngine(int id)
        {
            Engine engine = db.Engine.Find(id);
            if (engine == null)
            {
                return NotFound();
            }

            db.Engine.Remove(engine);
            db.SaveChanges();

            return Ok(engine);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool EngineExists(int id)
        {
            return db.Engine.Count(e => e.id == id) > 0;
        }
    }
}