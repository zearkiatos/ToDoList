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
    public class USERSController : ApiController
    {
        private TO_DO_LISTEntities db = new TO_DO_LISTEntities();
        [Route("api/" + Utils.Contants.version + "/USERS")]
        // GET: api/USERS
        public IQueryable<USERS> GetUSERS()
        {
            return db.USERS;
        }

        // GET: api/USERS/5
        [Route("api/" + Utils.Contants.version + "/USERS/{id}")]
        [ResponseType(typeof(USERS))]
        public IHttpActionResult GetUSERS(long id)
        {
            USERS uSERS = db.USERS.Find(id);
            if (uSERS == null)
            {
                return NotFound();
            }

            return Ok(uSERS);
        }

        // PUT: api/USERS/5
        [ResponseType(typeof(void))]
        [Route("api/" + Utils.Contants.version + "/USERS/{id}")]
        public IHttpActionResult PutUSERS(long id, USERS uSERS)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != uSERS.id)
            {
                return BadRequest();
            }

            db.Entry(uSERS).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!USERSExists(id))
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

        // POST: api/USERS
        [Route("api/" + Utils.Contants.version + "/USERS")]
        [ResponseType(typeof(USERS))]
        public IHttpActionResult PostUSERS(USERS uSERS)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.USERS.Add(uSERS);
            db.SaveChanges();

            return CreatedAtRoute("DefaultApi", new { id = uSERS.id }, uSERS);
        }

        // DELETE: api/USERS/5
        [ResponseType(typeof(USERS))]
        [Route("api/" + Utils.Contants.version + "/USERS/{id}")]
        public IHttpActionResult DeleteUSERS(long id)
        {
            USERS uSERS = db.USERS.Find(id);
            if (uSERS == null)
            {
                return NotFound();
            }

            db.USERS.Remove(uSERS);
            db.SaveChanges();

            return Ok(uSERS);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool USERSExists(long id)
        {
            return db.USERS.Count(e => e.id == id) > 0;
        }
    }
}