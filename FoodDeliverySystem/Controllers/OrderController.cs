﻿using FoodDeliverySystem.Models;
using FoodDeliverySystem.Services;
using Microsoft.AspNet.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace FoodDeliverySystem.Controllers
{
    [Authorize]
    public class OrderController : Controller
    {
        #region Services
        static OrderService _OrderService;
        public static OrderService OrderService
        {
            get
            {
                if (_OrderService == null)
                {

                    _OrderService = OrderService.GetInstance();
                }
                return _OrderService;
            }
            private set
            {
                _OrderService = value;
            }
        }
        #endregion

        public ActionResult Index()
        {
            var userID = User.Identity.GetUserId();
            return View(OrderService.GetOrdersByUserID(userID).ToList());
        }

        [HttpGet]
        public ActionResult CancelOrder(int id)
        {
            return View(OrderService.FindByID(id));
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult CancelOrder(int id, FormCollection dc)
        {
            var order = OrderService.FindByID(id);
            if (ModelState.IsValid)
            {
                order.state = 3;
                return RedirectToAction("Index");
            }
            return View(order);
        }

        ////
        //// GET: /CompanyType/Delete/5
        //public ActionResult Delete(int id)
        //{
        //    return View(Service.FindByID(id));
        //}

        ////
        //// POST: /CompanyType/Delete/5
        //[HttpPost]
        //[ValidateAntiForgeryToken]
        //public ActionResult Delete(CompanyType item)
        //{
        //    if (ModelState.IsValid)
        //    {
        //        Service.Delete(item);
        //        return RedirectToAction("Index");
        //    }
        //    return View(item);
        //}
	}
}