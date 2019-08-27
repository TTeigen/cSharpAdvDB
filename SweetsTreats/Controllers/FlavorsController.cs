using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.AspNetCore.Authorization;
using System.Linq;
using System.Threading.Tasks;
using System.Security.Claims;
using System.Collections.Generic;
using SweetsTreats.Models;

namespace SweetsTreats.Controllers
{
    public class FlavorsController : Controller
    {
        private readonly SweetsTreatsContext _db;
        private readonly UserManager<ApplicationUser> _userManager;

        public FlavorsController(UserManager<ApplicationUser> userManager, SweetsTreatsContext db)
        {
            _userManager = userManager;
            _db = db;
        }

        public ActionResult Index()
        {
            var model = _db.Flavors.ToList();
            return View(model);
        }

        public ActionResult Create()
        {
            return View();
        }


        // [Authorize]
        [HttpPost]
        public async Task<ActionResult> Create(Flavor flavor)
        {
            var userId = this.User.FindFirst(ClaimTypes.NameIdentifier)?.Value;
            var currentUser = await _userManager.FindByIdAsync(userId);
            flavor.User = currentUser;
            _db.Flavors.Add(flavor);
            _db.SaveChanges();
            return RedirectToAction("Index");
        }

        public ActionResult Details(int id)
        {
            var thisFlavor = _db.Flavors
                .Include(flavor => flavor.Treats)
                .ThenInclude(join => join.Treat)
                .FirstOrDefault(flavor => flavor.FlavorId == id);
            return View(thisFlavor);
        }

        public ActionResult Edit(int id)
        {
            var thisFlavor = _db.Flavors.FirstOrDefault(flavors => flavors.FlavorId == id);
            ViewBag.TreatId = new SelectList(_db.Treats, "TreatId", "Name");
            return View(thisFlavor);
        }

        [HttpPost]
        public ActionResult Edit(Flavor flavor)
        {
            _db.Entry(flavor).State = EntityState.Modified;
            _db.SaveChanges();
            return RedirectToAction("Index");
        }

        public ActionResult Delete(int id)
        {
            var thisFlavor = _db.Flavors.FirstOrDefault(flavors => flavors.FlavorId == id);
            return View(thisFlavor);
        }

        [HttpPost, ActionName("Delete")]
        public ActionResult DeleteConfirmed(int id)
        {
            var thisFlavor = _db.Flavors.FirstOrDefault(flavors => flavors.FlavorId == id);
            _db.Flavors.Remove(thisFlavor);
            _db.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}