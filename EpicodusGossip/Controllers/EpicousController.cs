using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using EpicodusGossip.Models;
using EpicodusGossip.Data;

namespace EpicodusGossip.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EpicodusController : ControllerBase
    {
        private ApplicationDbContext _db;

        public EpicodusController(ApplicationDbContext db)
        {
            _db = db;
        }

        // GET api/applicationUsers
        [HttpGet]
        public ActionResult<IEnumerable<ApplicationUser>> Get(string name)
        {
            var query = _db.ApplicationUsers.AsQueryable();

            if (name != null)
            {
                query = query.Where(entry => entry.Name.Contains(name));
            }



            return query.ToList();
        }

        // POST api/applicationUsers
        [HttpPost]
        public void Post([FromBody] ApplicationUser applicationUser)
        {
            _db.ApplicationUsers.Add(applicationUser);
            _db.SaveChanges();
        }

        // GET api/applicationUsers/5
        [HttpGet("{id}")]
        public ActionResult<ApplicationUser> Get(int id)
        {
            return _db.ApplicationUsers.FirstOrDefault(entry => entry.ApplicationUserId == id);
        }

        // PUT api/applicationUsers/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] ApplicationUser applicationUser)
        {
            applicationUser.ApplicationUserId = id;
            _db.Entry(applicationUser).State = EntityState.Modified;
            _db.SaveChanges();
        }

        // DELETE api/applicationUsers/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
            var applicationUserToDelete = _db.ApplicationUsers.FirstOrDefault(entry => entry.ApplicationUserId == id);
            _db.ApplicationUsers.Remove(applicationUserToDelete);
            _db.SaveChanges();
        }
    }
}