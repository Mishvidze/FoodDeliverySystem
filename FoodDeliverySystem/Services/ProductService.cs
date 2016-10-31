using FoodDeliverySystem.Models;
using FoodDeliverySystem.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Web;
using System.Web.Mvc;

namespace FoodDeliverySystem.Services
{
    public class ProductService : AbstractService<Product>
    {
        #region Services
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

        static ProductCategorySevice _productCategorySevice;
        public static ProductCategorySevice ProductCategorySevice
        {
            get
            {
                if (_productCategorySevice == null)
                {

                    _productCategorySevice = ProductCategorySevice.GetInstance();

                }
                return _productCategorySevice;
            }
            private set
            {
                _productCategorySevice = value;
            }
        }

        

            
        static GeneralProductService _generalProductService;
        public static GeneralProductService GeneralProductService
        {
            get
            {
                if (_generalProductService == null)
                {

                    _generalProductService = GeneralProductService.GetInstance();

                }
                return _generalProductService;
            }
            private set
            {
                _generalProductService = value;
            }
        }
        #endregion

        #region Constructor
        private ProductService()
        {
            InicializeContainer();
        }

        public void InicializeContainer()
        {
            container = new List<Product>()
                {
                    new Product()
                    {
                        ID = 1,
                        Name ="ღორის მწვადი",
                        Company = null,
                        CompanyID = 1,
                        CookingTime = 20,
                        Cost=5,
                        GeneralProduct=GeneralProductService.FindByID(1),
                        GeneralProductID=1,
                        ProductCategory=ProductCategorySevice.FindByID(2),
                        ProductCategoryID=1,
                    },

                    new Product()
                    {
                        ID = 2,
                        Name ="ლობიო მწნილით",
                        Company = null,
                        CompanyID = 1,
                        CookingTime = 20,
                        Cost=5,
                        GeneralProduct=GeneralProductService.FindByID(6),
                        GeneralProductID=6,
                        ProductCategory=ProductCategorySevice.FindByID(2),
                        ProductCategoryID=1,
                    },

                    new Product()
                    {
                        ID = 3,
                        Name ="რაჭული ლობიანი",
                        Company = null,
                        CompanyID = 1,
                        CookingTime = 20,
                        Cost=5,
                        GeneralProduct=GeneralProductService.FindByID(5),
                        GeneralProductID=5,
                        ProductCategory=ProductCategorySevice.FindByID(1),
                        ProductCategoryID=1,
                    },

                    new Product()
                    {
                        ID = 4,
                        Name ="იმერული ხაჭაპური",
                        Company = null,
                        CompanyID = 1,
                        CookingTime = 20,
                        Cost=5,
                        GeneralProduct=GeneralProductService.FindByID(4),
                        GeneralProductID=4,
                        ProductCategory=ProductCategorySevice.FindByID(1),
                        ProductCategoryID=1,
                    },

                    new Product()
                    {
                        ID = 5,
                        Name ="ხინკალი",
                        Company = null,
                        CompanyID = 2,
                        CookingTime = 20,
                        Cost=5,
                        GeneralProduct=GeneralProductService.FindByID(2),
                        GeneralProductID=2,
                        ProductCategory=ProductCategorySevice.FindByID(2),
                        ProductCategoryID=2,
                    },

                    new Product()
                    {
                        ID = 7,
                        Name ="ღორის მწვადი",
                        Company = null,
                        CompanyID = 2,
                        CookingTime = 20,
                        Cost=5,
                        GeneralProduct=GeneralProductService.FindByID(1),
                        GeneralProductID=1,
                        ProductCategory=ProductCategorySevice.FindByID(2),
                        ProductCategoryID=1,
                    },

                    new Product()
                    {
                        ID = 8,
                        Name ="ლობიო მწნილით",
                        Company = null,
                        CompanyID = 2,
                        CookingTime = 20,
                        Cost=5,
                        GeneralProduct=GeneralProductService.FindByID(6),
                        GeneralProductID=6,
                        ProductCategory=ProductCategorySevice.FindByID(2),
                        ProductCategoryID=1,
                    },

                    new Product()
                    {
                        ID = 9,
                        Name ="რაჭული ლობიანი",
                        Company = null,
                        CompanyID = 2,
                        CookingTime = 20,
                        Cost=5,
                        GeneralProduct=GeneralProductService.FindByID(5),
                        GeneralProductID=5,
                        ProductCategory=ProductCategorySevice.FindByID(1),
                        ProductCategoryID=1,
                    },

                    new Product()
                    {
                        ID = 10,
                        Name ="იმერული ხაჭაპური",
                        Company = null,
                        CompanyID = 2,
                        CookingTime = 20,
                        Cost=5,
                        GeneralProduct=GeneralProductService.FindByID(4),
                        GeneralProductID=4,
                        ProductCategory=ProductCategorySevice.FindByID(1),
                        ProductCategoryID=1,
                    },

                    new Product()
                    {
                        ID = 11,
                        Name ="ხინკალი",
                        Company = null,
                        CompanyID = 2,
                        CookingTime = 20,
                        Cost=5,
                        GeneralProduct=GeneralProductService.FindByID(2),
                        GeneralProductID=2,
                        ProductCategory=ProductCategorySevice.FindByID(2),
                        ProductCategoryID=2,
                    },

                };
        }
        #endregion

        public override IEnumerable<Product> GetAll()
        {
            foreach (var product in container)
            {
                product.Company = CompanyService.FindByID(product.CompanyID);
            }
            return base.GetAll();
        }

        static ProductService instance;
        [MethodImpl(MethodImplOptions.Synchronized)]
        public static ProductService GetInstance()
        {
            if(instance == null)
            {
                instance =new ProductService();
            }
            return instance;
        }


        #region additional functions
        public void PopulateProduct(ProductViewModel productViewModel, Product product)
        {
            product.ID = productViewModel.ID;
            product.CompanyID = productViewModel.CompanyID;
            product.GeneralProductID = productViewModel.GeneralProductID;
            product.ProductCategoryID = productViewModel.ProductCategoryID;
            //
            product.Name = productViewModel.Name;
            product.Cost = productViewModel.Cost;
            product.CookingTime = productViewModel.CookingTime;
            //
            product.Company = CompanyService.FindByID(product.CompanyID);
            product.GeneralProduct = GeneralProductService.FindByID(product.GeneralProductID);
            product.ProductCategory = ProductCategorySevice.FindByID(product.ProductCategoryID);
        }

        public void PopulateProductViewModel(ProductViewModel productViewModel, Product product)
        {
            productViewModel.CompanyID = product.CompanyID;
            productViewModel.GeneralProductID = product.GeneralProductID;
            productViewModel.ProductCategoryID = product.ProductCategoryID;
            //
            productViewModel.Name = product.Name;
            productViewModel.Cost = product.Cost;
            productViewModel.CookingTime = product.CookingTime;
        }

        public void PopulateSelectLists(ProductViewModel productViwModel)
        {
            var companySelectList = CompanyService.GetAll().Select(company => new SelectListItem
            {
                Text = company.Name,
                Value = company.ID.ToString(),
                Selected = company.ID == productViwModel.CompanyID
            });

            var generalProductSelectList = GeneralProductService.GetAll().Select(gp => new SelectListItem
            {
                Text = gp.Name,
                Value = gp.ID.ToString(),
                Selected = gp.ID == productViwModel.GeneralProductID
            });

            var productCategorySelectList = ProductCategorySevice.GetAll().Select(c => new SelectListItem
            {
                Text = c.Name,
                Value = c.ID.ToString(),
                Selected = c.ID == productViwModel.ProductCategoryID
            });

            productViwModel.Companies = companySelectList;
            productViwModel.ProductCategories = productCategorySelectList;
            productViwModel.GeneralProducts = generalProductSelectList;
        }

        public IEnumerable<Product> GetProductsByCompanyID(int id)
        {
            return container.Where(a => a.CompanyID == id);
        }
        #endregion


        internal object GetRaitingsByCompanyID(int p)
        {
            throw new NotImplementedException();
        }
    }
}