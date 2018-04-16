using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Globalization;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Description;
using ToDoListWebServices.Models;

namespace ToDoListWebServices.Controllers
{
    public class TICKETsController : ApiController
    {
        private TO_DO_LISTEntities db = new TO_DO_LISTEntities();
        [Route("api/" + Utils.Contants.version + "/TICKETs")]
        // GET: api/TICKETs
        public IQueryable<TICKET> GetTICKET()
        {
            return db.TICKET;
        }

        // GET: api/TICKETs/5
        [Route("api/" + Utils.Contants.version + "/TICKETs/{id}")]
        [ResponseType(typeof(TICKET))]
        public IHttpActionResult GetTICKET(long id)
        {
            TICKET tICKET = db.TICKET.Find(id);
            if (tICKET == null)
            {
                return NotFound();
            }

            return Ok(tICKET);
        }

        // PUT: api/TICKET/5
        [Route("api/" + Utils.Contants.version + "/TICKET/{id}")]
        [ResponseType(typeof(void))]
        public IHttpActionResult PutTICKET(int id, TICKET tICKET)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != tICKET.id)
            {
                return BadRequest();
            }

            db.Entry(tICKET).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!TICKETExists(id))
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

        // POST: api/TICKETs
        [HttpPost]
        [Route("api/" + Utils.Contants.version + "/TICKETs",Name = "PostTICKET")]
        [ResponseType(typeof(TICKET))]
        public IHttpActionResult PostTICKET(TICKET tICKET)
        {
            tICKET.date = DateTime.Now.Date + DateTime.Now.TimeOfDay;
            //tICKET.date = DateTime.ParseExact(tICKET.date.ToString(), "yyyy-MM-dd HH:mm:ss",CultureInfo.InvariantCulture);
            //if (!ModelState.IsValid)
            //{
            //    return BadRequest(ModelState);
            //}

            db.TICKET.Add(tICKET);
            db.SaveChanges();

            return CreatedAtRoute("DefaultApi", new { id = tICKET.id }, tICKET);
        }

        // DELETE: api/TICKETs/5

        [Route("api/" + Utils.Contants.version + "/TICKET/{id}")]
        [ResponseType(typeof(TICKET))]
        public IHttpActionResult DeleteTICKET(long id)
        {
            TICKET tICKET = db.TICKET.Find(id);
            if (tICKET == null)
            {
                return NotFound();
            }

            db.TICKET.Remove(tICKET);
            db.SaveChanges();

            return Ok(tICKET);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool TICKETExists(long id)
        {
            return db.TICKET.Count(e => e.id == id) > 0;
        }
    }
}