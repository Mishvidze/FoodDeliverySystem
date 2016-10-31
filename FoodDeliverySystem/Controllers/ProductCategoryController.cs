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
    public class ProductCategoryController : Controller
    {
        #region Services
        static ProductCategorySevice _service;
        public static ProductCategorySevice Service
        {
            get
            {
                if (_service == null)
                {

                    _service = ProductCategorySevice.GetInstance();
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
        // GET: /ProductCategory/
        public ActionResult Index()
        {
            return View(Service.GetAll());
        }

        //
        // GET: /ProductCategory/Details/5
        public ActionResult Details(int id)
        {
            return View(Service.FindByID(id));
        }

        //
        // GET: /ProductCategory/Create
        public ActionResult Create()
        {
            return View();
        }

        //
        // POST: /ProductCategory/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(ProductCategory item)
        {
            if (ModelState.IsValid)
            {
                Service.Add(item);
                return RedirectToAction("Index");
            }
            return View(item);
        }

        //
        // GET: /ProductCategory/Edit/5
        public ActionResult Edit(int id)
        {
            return View(Service.FindByID(id));
        }

        //
        // POST: /ProductCategory/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(ProductCategory item)
        {
            if (ModelState.IsValid)
            {
                Service.Update(item);
                return RedirectToAction("Index");
            }
            return View(item);
        }

        //
        // GET: /ProductCategory/Delete/5
        public ActionResult Delete(int id)
        {
            return View(Service.FindByID(id));
        }

        //
        // POST: /ProductCategory/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(ProductCategory item)
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
