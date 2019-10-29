using Microsoft.AspNetCore.Mvc;
using EpicodusGossip.Models;
using EpicodusGossip.Data;
using System.Collections.Generic;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace EpicodusGossip.Controllers
{
    public class GossipsController : Controller
    {
        private readonly ApplicationDbContext _db;

        public GossipsController(ApplicationDbContext db)
        {
            _db = db;
        }
        public ActionResult Index()
        {
            List<Gossip> model = _db.Gossips.ToList();
            return View(model);
        }

        public ActionResult Create()
        {
            ViewBag.ApplicationUserId = new SelectList(_db.ApplicationUsers, "ApplicationUserId", "Name");
            return View();
        }

        [HttpPost]
        public ActionResult Create(Gossip gossip)
        {
            _db.Gossips.Add(gossip);
            _db.SaveChanges();
            return RedirectToAction("Index");
        }
        public ActionResult Details(int id)
        {
            Gossip thisGossip = _db.Gossips.FirstOrDefault(gossips => gossips.GossipId == id);
            return View(thisGossip);
        }
        [HttpGet]
        public ActionResult Edit(int id)
        {

            Gossip thisGossip = _db.Gossips.FirstOrDefault(gossips => gossips.GossipId == id);

            return View(thisGossip);
        }

        [HttpPost]
        public ActionResult Edit(Gossip gossip)
        {
            _db.Entry(gossip).State = EntityState.Modified;
            _db.SaveChanges();
            return RedirectToAction("Index");
        }

    }

}