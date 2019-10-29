using Microsoft.AspNetCore.Mvc;
using EpicodusGossip.Models;
using EpicodusGossip.Data;
using System.Collections.Generic;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Mvc.Rendering;


namespace EpicodusGossip.Controllers
{
    public class AccountsController : Controller
    {
        private readonly ApplicationDbContext _db;

        public AccountsController(ApplicationDbContext db)
        {
            _db = db;
        }

        public ActionResult Index()
        {
            List<ApplicationUser> model = _db.ApplicationUsers.ToList();
            return View(model);
        }

        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Create(ApplicationUser applicationUser)
        {
            _db.ApplicationUsers.Add(applicationUser);
            _db.SaveChanges();
            return RedirectToAction("Index");
        }

        public ActionResult Details(int id)
        {
            ApplicationUser thisApplicationUser = _db.ApplicationUsers.FirstOrDefault(applicationUser => applicationUser.ApplicationUserId == id);
            return View(thisApplicationUser);
        }

        public ActionResult Edit(int id)
        {
            var thisApplicationUser = _db.ApplicationUsers.FirstOrDefault(applicationUser => applicationUser.ApplicationUserId == id);
            return View(thisApplicationUser);
        }

        [HttpPost]
        public ActionResult Edit(ApplicationUser applicationUser)
        {
            _db.Entry(applicationUser).State = EntityState.Modified;
            _db.SaveChanges();
            return RedirectToAction("Index");
        }

        public ActionResult Delete(int id)
        {
            var thisApplicationUser = _db.ApplicationUsers.FirstOrDefault(applicationUser => applicationUser.ApplicationUserId == id);
            return View(thisApplicationUser);
        }

        [HttpPost, ActionName("Delete")]
        public ActionResult DeleteConfirmed(int id)
        {
            var thisApplicationUser = _db.ApplicationUsers.FirstOrDefault(applicationUser => applicationUser.ApplicationUserId == id);
            _db.ApplicationUsers.Remove(thisApplicationUser);
            _db.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}