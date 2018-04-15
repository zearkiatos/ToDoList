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
    public class BOARDsController : ApiController
    {
        private TO_DO_LISTEntities db = new TO_DO_LISTEntities();

        [Route("api/" + Utils.Contants.version + "/Boards")]

        // GET: api/BOARDs

        public IQueryable<BOARD> GetBOARD()
        {
            return db.BOARD;
        }

        // GET: api/BOARDs/5
        [ResponseType(typeof(BOARD))]
        [Route("api/" + Utils.Contants.version + "/Boards/{id}")]
        public IHttpActionResult GetBOARD(long id)
        {
            BOARD bOARD = db.BOARD.Find(id);
            if (bOARD == null)
            {
                return NotFound();
            }

            return Ok(bOARD);
        }

        // GET: api/BOARDs/5
        [ResponseType(typeof(BOARD))]
        [Route("api/" + Utils.Contants.version + "/BoardByUser/{userId}")]
        public IHttpActionResult GetBoardByUser(int userId)
        {
            List<BOARD> bOARD = db.BOARD.Where(x=>x.user_id == userId).ToList();
            if (bOARD == null)
            {
                return NotFound();
            }

            return Ok(bOARD);
        }

        // PUT: api/BOARDs/5
        [ResponseType(typeof(void))]
        [Route("api/" + Utils.Contants.version + "/Boards/{id}")]
        public IHttpActionResult PutBOARD(long id, BOARD bOARD)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != bOARD.id)
            {
                return BadRequest();
            }

            db.Entry(bOARD).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!BOARDExists(id))
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

        // POST: api/BOARDs
        [Route("api/" + Utils.Contants.version + "/Boards")]
        [ResponseType(typeof(BOARD))]
        public IHttpActionResult PostBOARD(BOARD bOARD)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.BOARD.Add(bOARD);
            db.SaveChanges();

            return CreatedAtRoute("DefaultApi", new { id = bOARD.id }, bOARD);
        }

        // DELETE: api/BOARDs/5
        [Route("api/" + Utils.Contants.version + "/Boards/{id}")]
        [ResponseType(typeof(BOARD))]
        public IHttpActionResult DeleteBOARD(long id)
        {
            BOARD bOARD = db.BOARD.Find(id);
            if (bOARD == null)
            {
                return NotFound();
            }

            db.BOARD.Remove(bOARD);
            db.SaveChanges();

            return Ok(bOARD);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool BOARDExists(long id)
        {
            return db.BOARD.Count(e => e.id == id) > 0;
        }
    }
}