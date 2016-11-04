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
using FoodDeliverySystem.ViewModels;

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

        static OrderedProductService _OrderedProductService;
        public static OrderedProductService OrderedProductService
        {
            get
            {
                if (_OrderedProductService == null)
                {

                    _OrderedProductService = OrderedProductService.GetInstance();
                }
                return _OrderedProductService;
            }
            private set
            {
                _OrderedProductService = value;
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
            var companyViewModelDD = new CompanyViewModelDD();
            CompanyService.PopulateSelectLists(companyViewModelDD);

            return View(companyViewModelDD);
        }

        //
        // POST: /Company/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(CompanyViewModelDD companyViewModelDD)
        {
            if (ModelState.IsValid)
            {
                var company = new Company();
                CompanyService.PopulateCompany(companyViewModelDD, company);
                company.RegistrationDate = DateTime.Now;
                CompanyService.Add(company);

                return RedirectToAction("Index");
            }
            CompanyService.PopulateSelectLists(companyViewModelDD);
            return View(companyViewModelDD);
        }

        //
        // GET: /Company/Edit/5
        public ActionResult Edit(int id)
        {
            CompanyViewModelDD companyViewModelDD = new CompanyViewModelDD();
            Company company = CompanyService.FindByID(id);

            CompanyService.PopulateCompanyViewModelDD(companyViewModelDD, company);
            CompanyService.PopulateSelectLists(companyViewModelDD);

            return View(companyViewModelDD);
        }

        //
        // POST: /Company/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(CompanyViewModelDD companyViewModelDD)
        {
            if (ModelState.IsValid)
            {
                Company company = new Company();
                CompanyService.PopulateCompany(companyViewModelDD, company);
                CompanyService.Update(company);

                return RedirectToAction("Index");
            }
            CompanyService.PopulateSelectLists(companyViewModelDD);
            return View(companyViewModelDD);

        }

        //
        // GET: /Company/Delete/5
        public ActionResult Delete(int id)
        {
            var company = CompanyService.FindByID(id);
            return View(company);
        }

        //
        // POST: /Company/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(Company company)
        {
            if (ModelState.IsValid)
            {
                CompanyService.Delete(company);
                return RedirectToAction("Index");
            }
            return View(company);
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
            var uid = User.Identity.GetUserId();
            decimal vTotalCost = 0;

            foreach (var a in OrderedProducts)
            {
                vTotalCost += a.Price * a.ProductQuantity;
            }
            Order order = new Order()
            {
                OrderDate = DateTime.Now,
                state = 1,
                UserID = uid,
                CompanyID = OrderedProducts[0].CompanyID,
                TotalCost = vTotalCost,
            };

            var createdOrder = OrderService.Add(order);

            foreach (var op in OrderedProducts)
            {
                op.OrderID = createdOrder.ID;
                OrderedProductService.Add(op);
            }

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

        public ActionResult Report()
        {
            var uid = User.Identity.GetUserId();
            CompanyService.GenerateAllReporst(uid);


            return View("Index");
        }
        #endregion

    }
}
