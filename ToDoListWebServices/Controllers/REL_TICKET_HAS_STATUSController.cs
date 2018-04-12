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
using ToDoListWebServices.Models;

namespace ToDoListWebServices.Controllers
{
    public class REL_TICKET_HAS_STATUSController : ApiController
    {
        private TO_DO_LISTEntities db = new TO_DO_LISTEntities();

        [Route("api/" + Utils.Contants.version + "/REL_TICKET_HAS_STATUS")]

        // GET: api/REL_TICKET_HAS_STATUS
        public IQueryable<REL_TICKET_HAS_STATUS> GetREL_TICKET_HAS_STATUS()
        {
            return db.REL_TICKET_HAS_STATUS;
        }

        [Route("api/" + Utils.Contants.version + "/REL_TICKET_HAS_STATUS/{id}")]
        // GET: api/REL_TICKET_HAS_STATUS/5
        [ResponseType(typeof(REL_TICKET_HAS_STATUS))]
        public IHttpActionResult GetREL_TICKET_HAS_STATUS(long id)
        {
            REL_TICKET_HAS_STATUS rEL_TICKET_HAS_STATUS = db.REL_TICKET_HAS_STATUS.Find(id);
            if (rEL_TICKET_HAS_STATUS == null)
            {
                return NotFound();
            }

            return Ok(rEL_TICKET_HAS_STATUS);
        }

        // PUT: api/REL_TICKET_HAS_STATUS/5
        [Route("api/" + Utils.Contants.version + "/REL_TICKET_HAS_STATUS/{id}")]
        [ResponseType(typeof(void))]
        public IHttpActionResult PutREL_TICKET_HAS_STATUS(long id, REL_TICKET_HAS_STATUS rEL_TICKET_HAS_STATUS)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != rEL_TICKET_HAS_STATUS.id)
            {
                return BadRequest();
            }

            db.Entry(rEL_TICKET_HAS_STATUS).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!REL_TICKET_HAS_STATUSExists(id))
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

        // POST: api/REL_TICKET_HAS_STATUS
        [Route("api/" + Utils.Contants.version + "/REL_TICKET_HAS_STATUS")]
        [ResponseType(typeof(REL_TICKET_HAS_STATUS))]
        public IHttpActionResult PostREL_TICKET_HAS_STATUS(REL_TICKET_HAS_STATUS rEL_TICKET_HAS_STATUS)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.REL_TICKET_HAS_STATUS.Add(rEL_TICKET_HAS_STATUS);
            db.SaveChanges();

            return CreatedAtRoute("DefaultApi", new { id = rEL_TICKET_HAS_STATUS.id }, rEL_TICKET_HAS_STATUS);
        }

        // DELETE: api/REL_TICKET_HAS_STATUS/5
        [Route("api/" + Utils.Contants.version + "/REL_TICKET_HAS_STATUS/{id}")]
        [ResponseType(typeof(REL_TICKET_HAS_STATUS))]
        public IHttpActionResult DeleteREL_TICKET_HAS_STATUS(long id)
        {
            REL_TICKET_HAS_STATUS rEL_TICKET_HAS_STATUS = db.REL_TICKET_HAS_STATUS.Find(id);
            if (rEL_TICKET_HAS_STATUS == null)
            {
                return NotFound();
            }

            db.REL_TICKET_HAS_STATUS.Remove(rEL_TICKET_HAS_STATUS);
            db.SaveChanges();

            return Ok(rEL_TICKET_HAS_STATUS);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool REL_TICKET_HAS_STATUSExists(long id)
        {
            return db.REL_TICKET_HAS_STATUS.Count(e => e.id == id) > 0;
        }
    }
}