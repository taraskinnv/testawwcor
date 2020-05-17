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
    public class PaymentTypesController : ApiController
    {
        private DBCarShowEntities db = new DBCarShowEntities();

        // GET: api/PaymentTypes
        public IQueryable<PaymentTypes> GetPaymentTypes()
        {
            return db.PaymentTypes;
        }

        // GET: api/PaymentTypes/5
        [ResponseType(typeof(PaymentTypes))]
        public IHttpActionResult GetPaymentTypes(int id)
        {
            PaymentTypes paymentTypes = db.PaymentTypes.Find(id);
            if (paymentTypes == null)
            {
                return NotFound();
            }

            return Ok(paymentTypes);
        }

        // PUT: api/PaymentTypes/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutPaymentTypes(int id, PaymentTypes paymentTypes)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != paymentTypes.id)
            {
                return BadRequest();
            }

            db.Entry(paymentTypes).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!PaymentTypesExists(id))
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

        // POST: api/PaymentTypes
        [ResponseType(typeof(PaymentTypes))]
        public IHttpActionResult PostPaymentTypes(PaymentTypes paymentTypes)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.PaymentTypes.Add(paymentTypes);
            db.SaveChanges();

            return CreatedAtRoute("DefaultApi", new { id = paymentTypes.id }, paymentTypes);
        }

        // DELETE: api/PaymentTypes/5
        [ResponseType(typeof(PaymentTypes))]
        public IHttpActionResult DeletePaymentTypes(int id)
        {
            PaymentTypes paymentTypes = db.PaymentTypes.Find(id);
            if (paymentTypes == null)
            {
                return NotFound();
            }

            db.PaymentTypes.Remove(paymentTypes);
            db.SaveChanges();

            return Ok(paymentTypes);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool PaymentTypesExists(int id)
        {
            return db.PaymentTypes.Count(e => e.id == id) > 0;
        }
    }
}