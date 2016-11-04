using FoodDeliverySystem.Models;
using FoodDeliverySystem.Services;
using FoodDeliverySystem.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace FoodDeliverySystem.Controllers
{
    [Authorize]
    public class ProductController : Controller
    {
        #region Services
        static ProductService _productService;
        public static ProductService productService
        {
            get
            {
                if (_productService == null)
                {
                    
                    _productService = ProductService.GetInstance();
                }
                return _productService;
            }
            private set
            {
                _productService = value;
            }
        }
        #endregion

        #region CRUD
        //
        // GET: /Product/
        public ActionResult Index()
        {
            return View(productService.GetAll());
        }

        //
        // GET: /Product/Details/5
        public ActionResult Details(int id)
        {
            return View(productService.FindByID(id));
        }

        //
        // GET: /Product/Create
        public ActionResult Create()
        {
            var productViewModel = new ProductViewModel();
            productService.PopulateSelectLists(productViewModel);

            return View(productViewModel);
        }

        //
        // POST: /Product/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(ProductViewModel productViewModel)
        {
            if (ModelState.IsValid)
            {
                var product = new Product();
                productService.PopulateProduct(productViewModel, product);
                productService.Add(product);

                return RedirectToAction("Index");
            }
            productService.PopulateSelectLists(productViewModel);
            return View(productViewModel);
        }

        //
        // GET: /Product/Edit/5
        public ActionResult Edit(int id)
        {
            ProductViewModel productViewModel = new ProductViewModel();
            Product product = productService.FindByID(id);

            productService.PopulateProductViewModel(productViewModel, product);
            productService.PopulateSelectLists(productViewModel);

            return View(productViewModel);
        }

        //
        // POST: /Product/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(ProductViewModel productViewModel)
        {
            if (ModelState.IsValid)
            {
                Product product = new Product();
                productService.PopulateProduct(productViewModel, product);
                productService.Update(product);

                return RedirectToAction("Index");
            }
            productService.PopulateSelectLists(productViewModel);
            return View(productViewModel);
        }

        //
        // GET: /Product/Delete/5
        public ActionResult Delete(int id)
        {
            var product = productService.FindByID(id);
            return View(product);
        }

        //
        // POST: /Product/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(Product product)
        {
            if (ModelState.IsValid)
            {
                productService.Delete(product);
                return RedirectToAction("Index");
            }
            return View(product);
        }

        #endregion
    }
}
