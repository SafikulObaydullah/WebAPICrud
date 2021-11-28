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
using WebApplication1.Models;

namespace WebApplication1.Controllers
{
    public class InstituteInfoesController : ApiController
    {
        private dbModel db = new dbModel();

        // GET: api/InstituteInfoes
        public IQueryable<InstituteInfo> GetInstituteInfos()
        {
            return db.InstituteInfos;
        }

        // GET: api/InstituteInfoes/5
        [ResponseType(typeof(InstituteInfo))]
        public IHttpActionResult GetInstituteInfo( int id)
        {
            InstituteInfo instituteInfo = db.InstituteInfos.Find(id);
            if (instituteInfo == null)
            {
                return NotFound();
            }

            return Ok(instituteInfo);
        }

        // PUT: api/InstituteInfoes/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutInstituteInfo(int id, InstituteInfo instituteInfo)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != instituteInfo.Id)
            {
                return BadRequest();
            }

            db.Entry(instituteInfo).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!InstituteInfoExists(id))
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

        // POST: api/InstituteInfoes
        [ResponseType(typeof(InstituteInfo))]
        public IHttpActionResult PostInstituteInfo(InstituteInfo instituteInfo)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.InstituteInfos.Add(instituteInfo);
            db.SaveChanges();

            return CreatedAtRoute("DefaultApi", new { id = instituteInfo.Id }, instituteInfo);
        }

        // DELETE: api/InstituteInfoes/5
        [ResponseType(typeof(InstituteInfo))]
        public IHttpActionResult DeleteInstituteInfo(int id)
        {
            InstituteInfo instituteInfo = db.InstituteInfos.Find(id);
            if (instituteInfo == null)
            {
                return NotFound();
            }

            db.InstituteInfos.Remove(instituteInfo);
            db.SaveChanges();

            return Ok(instituteInfo);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool InstituteInfoExists(int id)
        {
            return db.InstituteInfos.Count(e => e.Id == id) > 0;
        }
    }
}