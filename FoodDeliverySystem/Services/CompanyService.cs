using FoodDeliverySystem.AdditionalClasses;
using FoodDeliverySystem.Models;
using FoodDeliverySystem.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Web;

namespace FoodDeliverySystem.Services
{
    public class CompanyService : AbstractService<Company>
    {
        #region Services

        static ProductService _productService;
        public static ProductService ProductService
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

        static CompanyCostTypeService _companyCostTypeService;
        public static CompanyCostTypeService CompanyCostTypeService
        {
            get
            {
                if (_companyCostTypeService == null)
                {

                    _companyCostTypeService = CompanyCostTypeService.GetInstance();
                }
                return _companyCostTypeService;
            }
            private set
            {
                _companyCostTypeService = value;
            }
        }


        static CompanyTypeService _companyTypeService;
        public static CompanyTypeService CompanyTypeService
        {
            get
            {
                if (_companyTypeService == null)
                {

                    _companyTypeService = CompanyTypeService.GetInstance();
                }
                return _companyTypeService;
            }
            private set
            {
                _companyTypeService = value;
            }
        }

        static RaitingService _ratingService;
        public static RaitingService RaitingService
        {
            get
            {
                if (_ratingService == null)
                {

                    _ratingService = RaitingService.GetInstance();
                }
                return _ratingService;
            }
            private set
            {
                _ratingService = value;
            }
        }

        #endregion

        #region Constructor
        private CompanyService()
        {
            container = new List<Company>()
                {
                    new Company()
                    {
                        ID = 1,
                        Name = "Fragola",
                        CompanyCostTypeID=2,
                        CompanyTypeID=1,
                        Logo=null,
                        RegistrationDate=new DateTime(2016,01,15),

                        CompanyCostType=CompanyCostTypeService.FindByID(2),
                        CompanyType=CompanyTypeService.FindByID(1),
                        
                        Products=ProductService.GetProductsByCompanyID(1).ToList(),
                        Raitings=RaitingService.GetRaitingsByCompanyID(1).ToList(),
                    },

                    new Company()
                    {
                        ID = 2,
                        Name = "თაღლაურა",
                        CompanyCostTypeID=2,
                        CompanyTypeID=1,
                        Logo=null,
                        RegistrationDate=new DateTime(2016,01,15),

                        CompanyCostType=CompanyCostTypeService.FindByID(2),
                        CompanyType=CompanyTypeService.FindByID(1),
                        
                        Products=ProductService.GetProductsByCompanyID(1).ToList(),
                        Raitings=RaitingService.GetRaitingsByCompanyID(2).ToList(),
                    },

                };

        }
        #endregion

        static CompanyService instance;
        [MethodImpl(MethodImplOptions.Synchronized)]
        public static CompanyService GetInstance()
        {
            if (instance == null)
            {
                instance = new CompanyService();
            }
            return instance;
        }
        #region Custom Functions

        public IEnumerable<SimilarCompany> PopulateSimilarCompanies(List<SimilarProduct> SimilarProducts)
        {

            List<SimilarCompany> similarCompanies =
                container
                .Where(
                    company =>
                        SimilarProducts.All
                        (
                            similarProduct => company.Products.Select(product => product.GeneralProductID).ToList().Contains(similarProduct.ProductCode)
                        )
                ).Select(
                    c =>
                        Func(c, SimilarProducts)
                ).ToList();

            return similarCompanies;
        }

        private SimilarCompany Func(Company company, List<SimilarProduct> SimilarProducts)
        {
            double sum = 0;
            foreach (var a in company.Raitings)
            {
                sum += a.score;
            }

            var cVotes = company.Raitings.Count;
            var cAvarageRating = sum / (double)cVotes;

            var cCookingTime = 0;
            decimal cTotalCost = 0;

            foreach (var sm in SimilarProducts)
            {
                var c = company.Products.First(p => p.GeneralProductID == sm.ProductCode);
                cCookingTime += c.CookingTime;
                cTotalCost += c.Cost;
            }

            SimilarCompany similarCompany = new SimilarCompany()
            {
                ID = company.ID,
                Name = company.Name,
                Logo = company.Logo,
                Votes = cVotes,
                AvarageRating = cAvarageRating,
                CookingTime = cCookingTime,
                TotalCost = cTotalCost
            };

            return similarCompany;
        }


        public IEnumerable<CompanyViewModel> GetAllCompanyViewModels()
        {
            return container.Select(a => PopulateCompanyViewModel(a));
        }

        public CompanyViewModel PopulateCompanyViewModel(Company company)
        {
            CompanyViewModel companyViewModel = new CompanyViewModel();
            companyViewModel.ID = company.ID;
            companyViewModel.Name = company.Name;
            companyViewModel.Logo = company.Logo;

            double sum = 0;
            foreach (var a in company.Raitings)
            {
                sum += a.score;
            }

            companyViewModel.Votes = company.Raitings.Count;
            companyViewModel.AvarageRating = sum / (double)companyViewModel.Votes;

            return companyViewModel;
        }
        #endregion

    }
}