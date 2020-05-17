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
    public class ModelCarsController : ApiController
    {
        private DBCarShowEntities db = new DBCarShowEntities();

        // GET: api/ModelCars
        public IQueryable<ModelCar> GetModelCar()
        {
            return db.ModelCar;
        }

        // GET: api/ModelCars/5
        [ResponseType(typeof(ModelCar))]
        public IHttpActionResult GetModelCar(int id)
        {
            ModelCar modelCar = db.ModelCar.Find(id);
            if (modelCar == null)
            {
                return NotFound();
            }

            return Ok(modelCar);
        }

        // PUT: api/ModelCars/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutModelCar(int id, ModelCar modelCar)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != modelCar.id)
            {
                return BadRequest();
            }

            db.Entry(modelCar).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ModelCarExists(id))
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

        // POST: api/ModelCars
        [ResponseType(typeof(ModelCar))]
        public IHttpActionResult PostModelCar(ModelCar modelCar)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.ModelCar.Add(modelCar);
            db.SaveChanges();

            return CreatedAtRoute("DefaultApi", new { id = modelCar.id }, modelCar);
        }

        // DELETE: api/ModelCars/5
        [ResponseType(typeof(ModelCar))]
        public IHttpActionResult DeleteModelCar(int id)
        {
            ModelCar modelCar = db.ModelCar.Find(id);
            if (modelCar == null)
            {
                return NotFound();
            }

            db.ModelCar.Remove(modelCar);
            db.SaveChanges();

            return Ok(modelCar);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool ModelCarExists(int id)
        {
            return db.ModelCar.Count(e => e.id == id) > 0;
        }
    }
}