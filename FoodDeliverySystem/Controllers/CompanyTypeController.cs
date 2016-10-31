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
    public class CompanyTypeController : Controller
    {
        #region Services
        static CompanyTypeService _service;
        public static CompanyTypeService Service
        {
            get
            {
                if (_service == null)
                {

                    _service = CompanyTypeService.GetInstance();
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
        //
        // GET: /CompanyType/
        public ActionResult Index()
        {
            return View(Service.GetAll());
        }

        //
        // GET: /CompanyType/Details/5
        public ActionResult Details(int id)
        {
            return View(Service.FindByID(id));
        }

        //
        // GET: /CompanyType/Create
        public ActionResult Create()
        {
            return View();
        }

        //
        // POST: /CompanyType/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(CompanyType item)
        {
            if (ModelState.IsValid)
            {
                Service.Add(item);
                return RedirectToAction("Index");
            }
            return View(item);
        }

        //
        // GET: /CompanyType/Edit/5
        public ActionResult Edit(int id)
        {
            return View(Service.FindByID(id));
        }

        //
        // POST: /CompanyType/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(CompanyType item)
        {
            if (ModelState.IsValid)
            {
                Service.Update(item);
                return RedirectToAction("Index");
            }
            return View(item);
        }

        //
        // GET: /CompanyType/Delete/5
        public ActionResult Delete(int id)
        {
            return View(Service.FindByID(id));
        }

        //
        // POST: /CompanyType/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(CompanyType item)
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
