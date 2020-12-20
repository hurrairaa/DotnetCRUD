using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using FirstProject.Interface;
using FirstProject.Models;
using Microsoft.AspNetCore.Mvc;

namespace FirstProject.Controllers
{
    public class FamilyController : Controller
    {
        IFamilyService familyService;

        public FamilyController(IFamilyService _familyService)
        {
            this.familyService = _familyService;

        }

        public ActionResult Index()
        {
            IEnumerable<Family> family = this.familyService.GetFamily();

            return View(family);
        }
        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Create(Family family)
        {
            familyService.AddFamily(family);
            return RedirectToAction(nameof(Index));
        }

        public ActionResult Edit(int id)
        {
            Family family = familyService.GetFamilyById(id);
            return View(family);
        }
        [HttpPost]
        public ActionResult Edit(Family family)
        {
            familyService.EditFamily(family);
            return RedirectToAction(nameof(Index));
        }
        public ActionResult Delete(int id)
        {
            Family family = familyService.GetFamilyById(id);
            return View(family);
        }
        [HttpPost]
        public ActionResult Delete(Family family)
        {
            familyService.DeleteFamily(family);
            return RedirectToAction(nameof(Index));
        }
    }
}
