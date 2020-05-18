using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Data.SqlClient;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Description;
using WebAPICarShow.Models;

namespace WebAPICarShow.Controllers
{
    public class CarBrandsController : ApiController
    {
        private DBCarShowEntities db = new DBCarShowEntities();
        
        // GET: api/CarBrands
        public IQueryable<CarBrand> GetCarBrand()
        {
            return db.CarBrand;
        }

        // GET: api/CarBrands/5
        [ResponseType(typeof(CarBrand))]
        public IHttpActionResult GetCarBrand(int id)
        {
            CarBrand carBrand = db.CarBrand.Find(id);
            if (carBrand == null)
            {
                return NotFound();
            }

            return Ok(carBrand);
        }

        // PUT: api/CarBrands/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutCarBrand(int id, CarBrand carBrand)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != carBrand.id)
            {
                return BadRequest();
            }

            db.Entry(carBrand).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!CarBrandExists(id))
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

        // POST: api/CarBrands
        [ResponseType(typeof(CarBrand))]
        public IHttpActionResult PostCarBrand(CarBrand carBrand)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.CarBrand.Add(carBrand);
            db.SaveChanges();

            return CreatedAtRoute("DefaultApi", new { id = carBrand.id }, carBrand);
        }

        // DELETE: api/CarBrands/5
        [ResponseType(typeof(CarBrand))]
        public IHttpActionResult DeleteCarBrand(int id)
        {
            CarBrand carBrand = db.CarBrand.Find(id);
            if (carBrand == null)
            {
                return NotFound();
            }

            db.CarBrand.Remove(carBrand);
            db.SaveChanges();

            return Ok(carBrand);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool CarBrandExists(int id)
        {
            return db.CarBrand.Count(e => e.id == id) > 0;
        }
    }
}