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
    public class CompanyCostTypeController : Controller
    {
        #region Services
        static CompanyCostTypeService _service;
        public static CompanyCostTypeService Service
        {
            get
            {
                if (_service == null)
                {

                    _service = CompanyCostTypeService.GetInstance();
                }
                return _service;
            }
            private set
            {
                _service = value;
            }
        }
        #endregion

        #region CRUD
        
        public ActionResult Index()
        {
            return View(Service.GetAll());
        }

        public ActionResult Details(int id)
        {
            return View(Service.FindByID(id));
        }

        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(CompanyCostType item)
        {
            if (ModelState.IsValid)
            {
                Service.Add(item);
                return RedirectToAction("Index");
            }
            return View(item);
        }

        public ActionResult Edit(int id)
        {
            return View(Service.FindByID(id));
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(CompanyCostType item)
        {
            if (ModelState.IsValid)
            {
                Service.Update(item);
                return RedirectToAction("Index");
            }
            return View(item);
        }

        public ActionResult Delete(int id)
        {
            return View(Service.FindByID(id));
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(CompanyCostType item)
        {
            if (ModelState.IsValid)
            {
                Service.Delete(item);
                return RedirectToAction("Index");
            }
            return View(item);
        }
        #endregion

    }
}
