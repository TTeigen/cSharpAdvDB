using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System;
using Microsoft.AspNetCore.Mvc.Rendering;
using System.Linq;
using SweetsTreats.Models;


namespace SweetsTreatsControllers
{

    class TreatsController : Controller
    {
        private readonly SweetsTreatsContext _db;

        public TreatsController(SweetsTreatsContext db)
        {
            _db = db;
        }

        public ActionResult Index()
        {
            var treats = _db.Treats.ToList();
            return View(treats);
        }

        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Create(Treat treat)
        {
            _db.Treats.Add(treat);
            _db.SaveChanges();
            return RedirectToAction("Index");
        }

        public ActionResult Details(int id)
        {

            var model = _db.Treats
            .Include(treat => treat.Genres)
            .ThenInclude(join => join.Genre)
            .FirstOrDefault(treat => treat.TreatId == id);
            return View(model);
        }
    }
}