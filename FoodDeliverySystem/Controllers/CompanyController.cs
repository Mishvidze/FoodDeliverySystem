using Microsoft.AspNet.Identity;
using FoodDeliverySystem.AdditionalClasses;
using FoodDeliverySystem.Models;
using FoodDeliverySystem.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Net;

namespace FoodDeliverySystem.Controllers
{
    [Authorize]
    public class CompanyController : Controller
    {
        #region Service
        static CompanyService _companyService;
        public static CompanyService CompanyService
        {
            get
            {
                if (_companyService == null)
                {

                    _companyService = CompanyService.GetInstance();
                }
                return _companyService;
            }
            private set
            {
                _companyService = value;
            }
        }

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


        static CardService _CardService;
        public static CardService CardService
        {
            get
            {
                if (_CardService == null)
                {

                    _CardService = CardService.GetInstance();
                }
                return _CardService;
            }
            private set
            {
                _CardService = value;
            }
        }
        #endregion

        #region CRUD
        //
        // GET: /Company/
        public ActionResult Index()
        {
            return View(CompanyService.GetAllCompanyViewModels());
        }

        //
        // GET: /Company/Details/5
        public ActionResult Details(int id)
        {
            var company = CompanyService.FindByID(id);
            var companyViewModel = CompanyService.PopulateCompanyViewModel(company);

            return View(companyViewModel);
        }

        //
        // GET: /Company/Create
        public ActionResult Create()
        {
            return View();
        }

        //
        // POST: /Company/Create
        [HttpPost]
        public ActionResult Create(Company company, HttpPostedFileBase file)
        {

            return View(company);
        }

        //
        // GET: /Company/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        //
        // POST: /Company/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add update logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        //
        // GET: /Company/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        //
        // POST: /Company/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add delete logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
        #endregion

        #region Custon Functions
        public ActionResult Choose(int id)
        {
            return View(CompanyService.FindByID(id));
        }

        [HttpPost]
        public ActionResult FindSimilarCompanies(List<SimilarProduct> SimilarProducts)
        {
            List<SimilarCompany> SimilarCompanies = CompanyService.PopulateSimilarCompanies(SimilarProducts).ToList();
         
            return View(SimilarCompanies);
        }

        [HttpPost]
        public ActionResult PlaceOrder(List<OrderedProduct> OrderedProducts)
        {


            var uid=User.Identity.GetUserId();
            decimal vTotalCost = 0;

            foreach (var a in OrderedProducts)
            {
                vTotalCost += a.Price * a.ProductQuantity;
            }

            Order order = new Order()
            {
                ID = 1,
                OrderDate = DateTime.Now,
                state = 1,
                UserID = uid,
                CompanyID = OrderedProducts[0].CompanyID,
                Products = OrderedProducts,
                TotalCost=vTotalCost,
                Company = CompanyService.FindByID(OrderedProducts[0].CompanyID)
            };

            OrderService.Add(order);

            return new HttpStatusCodeResult(HttpStatusCode.OK); 
        }

        public ActionResult Pay()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Pay(Card card)
        {
            if (ModelState.IsValid)
            {
                var b = CardService.CheckTheCard(card.CardNumber);
                if (b)
                {
                    CardService.Add(card);
                }
                return RedirectToAction("Index");
            }
            return View(card);
        }
        #endregion

    }
}
