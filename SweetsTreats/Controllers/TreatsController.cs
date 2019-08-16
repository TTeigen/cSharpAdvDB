using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Authorization;
using System.Linq;
using System.Threading.Tasks;
using System.Security.Claims;
using System.Collections.Generic;
using SweetsTreats.Models;

namespace SweetsTreats.Controllers
{
    [Authorize]
    public class TreatsController : Controller
    {
        private readonly SweetsTreatsContext _db;
        private readonly UserManager<ApplicationUser> _userManager;

        public TreatsController(SweetsTreatsContext db, UserManager<ApplicationUser> usermanager)
        {
            _db = db;
            _userManager = usermanager;
        }

        public async Task<ActionResult> Index()
        {
            var userId = this.User.FindFirst(ClaimTypes.NameIdentifier)?.Value;
            var currentUser = await _userManager.FindByIdAsync(userId);
            return View(_db.Treats.Where(x => x.User.Id == currentUser.Id).ToList());
        }
        public ActionResult Details(int id)
        {
            var model = _db.Treats
            .Include(treat => treat.FlavorTreats)
            .ThenInclude(join => join.Flavor)
            .FirstOrDefault(treat => treat.TreatId == id);
            return View(model);
        }

        public ActionResult Create()
        {
            ViewBag.FlavorId = new SelectList(_db.Flavors, "FlavorId", "Name");
            return View();
        }

        [HttpPost]
        public async Task<ActionResult> Create(Treat treat)
        {
            var userId = this.User.FindFirst(ClaimTypes.NameIdentifier)?.Value;
            var currentUser = await _userManager.FindByIdAsync(userId);
            treat.User = currentUser;
            _db.Treats.Add(treat);
            _db.SaveChanges();
            return RedirectToAction("Index");
        }

        public ActionResult Edit(int id)
        {
            ViewBag.FlavorId = new SelectList(_db.Flavors, "FlavorId", "Name");
            var thisTreat = _db.Treats.FirstOrDefault(treat => treat.TreatId == id);
            return View(thisTreat);
        }

        [HttpPost]
        public ActionResult Edit(Treat treat)
        {
            _db.Entry(treat).State = EntityState.Modified;
            _db.SaveChanges();
            return RedirectToAction("Index");
        }

        public ActionResult Delete(int id)
        {
            var thisTreat = _db.Treats.FirstOrDefault(treat => treat.TreatId == id);
            return View(thisTreat);
        }

        [HttpPost, ActionName("Delete")]

        public ActionResult DeleteConfirmed(int id)
        {
            var thisTreat = _db.Treats.FirstOrDefault(treat => treat.TreatId == id);
            _db.Treats.Remove(thisTreat);
            _db.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}