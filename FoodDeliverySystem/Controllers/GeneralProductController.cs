using FoodDeliverySystem.Models;
using FoodDeliverySystem.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace FoodDeliverySystem.Controllers
{
    [Authorize]
    public class GeneralProductController : Controller
    {
        static GeneralProductService _GeneralProductService;
        public static GeneralProductService GeneralProductService
        {
            get
            {
                if (_GeneralProductService == null)
                {

                    _GeneralProductService = GeneralProductService.GetInstance();
                }
                return _GeneralProductService;
            }
            private set
            {
                _GeneralProductService = value;
            }
        }

        //
        // GET: /GeneralProduct/
        public ActionResult Index()
        {
            return View(GeneralProductService.GetAll());
        }

        //
        // GET: /GeneralProduct/Details/5
        public ActionResult Details(int id)
        {
            return View(GeneralProductService.FindByID(id));
        }

        //
        // GET: /GeneralProduct/Create
        public ActionResult Create()
        {
            return View();
        }

        //
        // POST: /GeneralProduct/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(GeneralProduct generalProduct)
        {
            if (ModelState.IsValid)
            {
                GeneralProductService.Add(generalProduct);
                return RedirectToAction("Index");
            }
            return View(generalProduct);
        }

        //
        // GET: /GeneralProduct/Edit/5
        public ActionResult Edit(int id)
        {
            return View(GeneralProductService.FindByID(id));
        }

        //
        // POST: /GeneralProduct/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(GeneralProduct generalProduct)
        {
            if (ModelState.IsValid)
            {
                GeneralProductService.Update(generalProduct);
                return RedirectToAction("Index");
            }
            return View(generalProduct);
        }

        //
        // GET: /GeneralProduct/Delete/5
        public ActionResult Delete(int id)
        {
            return View(GeneralProductService.FindByID(id));
        }

        //
        // POST: /GeneralProduct/Delete/5
        [HttpPost]
        public ActionResult Delete(GeneralProduct generalProduct)
        {
            if (ModelState.IsValid)
            {
                GeneralProductService.Delete(generalProduct);
                return RedirectToAction("Index");
            }
            return View(generalProduct);
        }
    }
}
