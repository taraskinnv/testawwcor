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
    public class CarOrdersController : ApiController
    {
        private DBCarShowEntities db = new DBCarShowEntities();

        // GET: api/CarOrders
        public IQueryable<CarOrder> GetCarOrder()
        {
            return db.CarOrder;
        }

        // GET: api/CarOrders/5
        [ResponseType(typeof(CarOrder))]
        public IHttpActionResult GetCarOrder(int id)
        {
            CarOrder carOrder = db.CarOrder.Find(id);
            if (carOrder == null)
            {
                return NotFound();
            }

            return Ok(carOrder);
        }

        // PUT: api/CarOrders/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutCarOrder(int id, CarOrder carOrder)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != carOrder.id)
            {
                return BadRequest();
            }

            db.Entry(carOrder).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!CarOrderExists(id))
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

        // POST: api/CarOrders
        [ResponseType(typeof(CarOrder))]
        public IHttpActionResult PostCarOrder(CarOrder carOrder)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.CarOrder.Add(carOrder);
            db.SaveChanges();

            return CreatedAtRoute("DefaultApi", new { id = carOrder.id }, carOrder);
        }

        // DELETE: api/CarOrders/5
        [ResponseType(typeof(CarOrder))]
        public IHttpActionResult DeleteCarOrder(int id)
        {
            CarOrder carOrder = db.CarOrder.Find(id);
            if (carOrder == null)
            {
                return NotFound();
            }

            db.CarOrder.Remove(carOrder);
            db.SaveChanges();

            return Ok(carOrder);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool CarOrderExists(int id)
        {
            return db.CarOrder.Count(e => e.id == id) > 0;
        }
    }
}