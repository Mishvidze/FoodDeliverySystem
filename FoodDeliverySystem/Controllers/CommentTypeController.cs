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
    public class CommentTypeController : Controller
    {
        #region Services
        static CommentTypeService _service;
        public static CommentTypeService Service
        {
            get
            {
                if (_service == null)
                {

                    _service = CommentTypeService.GetInstance();
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
        public ActionResult Create(CommentType item)
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
        public ActionResult Edit(CommentType item)
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
        public ActionResult Delete(CommentType item)
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