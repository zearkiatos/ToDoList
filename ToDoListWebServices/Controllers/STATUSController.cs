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
    public class STATUSController : ApiController
    {
        private TO_DO_LISTEntities db = new TO_DO_LISTEntities();
        [Route("api/" + Utils.Contants.version + "/STATUS")]

        // GET: api/STATUS
        public IQueryable<STATUS> GetSTATUS()
        {
            return db.STATUS;
        }

        // GET: api/STATUS/5
        [ResponseType(typeof(STATUS))]
        [Route("api/" + Utils.Contants.version + "/STATUS/{id}")]
        public IHttpActionResult GetSTATUS(long id)
        {
            STATUS sTATUS = db.STATUS.Find(id);
            if (sTATUS == null)
            {
                return NotFound();
            }

            return Ok(sTATUS);
        }

        // PUT: api/STATUS/5
        [ResponseType(typeof(void))]
        [Route("api/" + Utils.Contants.version + "/STATUS/{id}")]
        public IHttpActionResult PutSTATUS(long id, STATUS sTATUS)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != sTATUS.id)
            {
                return BadRequest();
            }

            db.Entry(sTATUS).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!STATUSExists(id))
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

        // POST: api/STATUS
        [ResponseType(typeof(STATUS))]
        [Route("api/" + Utils.Contants.version + "/STATUS")]
        public IHttpActionResult PostSTATUS(STATUS sTATUS)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.STATUS.Add(sTATUS);
            db.SaveChanges();

            return CreatedAtRoute("DefaultApi", new { id = sTATUS.id }, sTATUS);
        }

        // DELETE: api/STATUS/5
        [ResponseType(typeof(STATUS))]
        [Route("api/" + Utils.Contants.version + "/STATUS/{id}")]
        public IHttpActionResult DeleteSTATUS(long id)
        {
            STATUS sTATUS = db.STATUS.Find(id);
            if (sTATUS == null)
            {
                return NotFound();
            }

            db.STATUS.Remove(sTATUS);
            db.SaveChanges();

            return Ok(sTATUS);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool STATUSExists(long id)
        {
            return db.STATUS.Count(e => e.id == id) > 0;
        }
    }
}