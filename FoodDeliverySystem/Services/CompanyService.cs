using FoodDeliverySystem.AdditionalClasses;
using FoodDeliverySystem.Models;
using FoodDeliverySystem.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Web;
using System.Web.Mvc;
using System.Data.Entity;

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

        #region Custom CRUD
        public override IEnumerable<Company> GetAll()
        {
            using (var ctx = new ApplicationDbContext())
            {

                return ctx.Companies
                .Include(a => a.CompanyCostType)
                .Include(b => b.CompanyType)
                .Include(j => j.Raitings)
                .Include(
                        d => d.Products
                            .Select(
                                e => e.GeneralProduct
                             )
                        ).ToList();

            }

        }

        public override Company FindByID(int id)
        {
            Company company = base.FindByID(id);

            using (var ctx = new ApplicationDbContext())
            {
                Company cm = ctx.Companies
                    .Include(a => a.CompanyCostType)
                    .Include(b => b.CompanyType)
                    .Include(j => j.Raitings)
                    .Include(
                            d => d.Products
                                .Select(
                                    e => e.ProductCategory
                                 )
                            )

                    .Single(c => c.ID == id);

                foreach (var pro in cm.Products)
                {
                    ctx.Products.Attach(pro);
                    ctx.Entry(pro).Reference(p => p.GeneralProduct).Load();
                }

                return cm;

                //ctx.Companies.Attach(company);
                //ctx.Entry(company).Reference(p => p.CompanyCostType).Load();
                //ctx.Entry(company).Reference(p => p.CompanyType).Load();

                //ctx.Entry(company)
                //    .Collection(c => c.Products)
                //    //.Query()
                //    //.Include("ProductCategory")
                //    //.Include("GeneralProduct")
                //    .Load();

                //ctx.Entry(company).Collection(p => p.Raitings).Load();
                //ctx.Set<T>().Attach(item);

                //ctx.Entry(item).State = EntityState.Deleted;
                //return ctx.SaveChanges();

                //return company
                //    .Include(c => c.CompanyType)
                //    .Include(c => c.CompanyCostType)
                //    .ToList();

                //context.Entry(post).Reference(p => p.Blog).Load(); 


            }


            //return company;
        }
        #endregion

        #region Code for single element creation
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
        #endregion

        #region Custom Functions

        public IEnumerable<SimilarCompany> PopulateSimilarCompanies(List<SimilarProduct> SimilarProducts)
        {

            List<SimilarCompany> similarCompanies =
                this.GetAll()
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
            return this.GetAll().Select(a => PopulateCompanyViewModel(a));
        }

        public CompanyViewModel PopulateCompanyViewModel(Company company)
        {
            CompanyViewModel companyViewModel = new CompanyViewModel();
            companyViewModel.ID = company.ID;
            companyViewModel.Name = company.Name;
            companyViewModel.Logo = company.Logo;

            // TODO: this 'if' is temporary
            using (var ctx = new ApplicationDbContext())
            {
                //context.Entry(blog).Collection(p => p.Posts).Load(); 
                ctx.Set<Company>().Attach(company);
                ctx.Entry(company).Collection(c => c.Raitings).Load();
                if (company.Raitings != null)
                {
                    double sum = 0;
                    foreach (var a in company.Raitings)
                    {
                        sum += a.score;
                    }

                    companyViewModel.Votes = company.Raitings.Count;
                    companyViewModel.AvarageRating = sum / (double)companyViewModel.Votes;
                }

            }
            return companyViewModel;
        }
        #endregion

        #region Functions for dropdowns

        public void PopulateCompany(CompanyViewModelDD companyViewModelDD, Company company)
        {
            company.ID = companyViewModelDD.ID;
            company.CompanyTypeID = companyViewModelDD.CompanyTypeID;
            company.CompanyCostTypeID = companyViewModelDD.CompanyCostTypeID;
            //
            company.Name = companyViewModelDD.Name;
            company.RegistrationDate = companyViewModelDD.RegistrationDate;
        }

        public void PopulateCompanyViewModelDD(CompanyViewModelDD companyViewModelDD, Company company)
        {
            companyViewModelDD.ID = company.ID;
            companyViewModelDD.CompanyTypeID = company.CompanyTypeID;
            companyViewModelDD.CompanyCostTypeID = company.CompanyCostTypeID;
            //
            companyViewModelDD.Name = company.Name;
            companyViewModelDD.RegistrationDate = company.RegistrationDate;
        }

        public void PopulateSelectLists(CompanyViewModelDD companyViewModelDD)
        {
            var CompanyTypeSelectList = CompanyTypeService.GetAll().Select(companyType => new SelectListItem
            {
                Text = companyType.CompanyTypeName,
                Value = companyType.ID.ToString(),
                Selected = companyType.ID == companyViewModelDD.CompanyCostTypeID
            });

            var CompanyCostTypeSelectList = CompanyCostTypeService.GetAll().Select(companyCostType => new SelectListItem
            {
                Text = companyCostType.CostType,
                Value = companyCostType.ID.ToString(),
                Selected = companyCostType.ID == companyViewModelDD.CompanyCostTypeID
            });

            companyViewModelDD.CompanyTypes = CompanyTypeSelectList;
            companyViewModelDD.CompanyCostTypes = CompanyCostTypeSelectList;
        }

        #endregion

        internal static void GenerateAllReporst(string userID)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var uid = userID;

                // პირველი რეპორტი
                var query1 =
                            from company in ctx.Companies
                            join order in ctx.Orders.Where(o => o.UserID == uid)
                            on company.ID equals order.CompanyID
                            into g
                            select new ForReport1
                            {
                                CompanyName = company.Name,
                                TotalSpent = g.Sum(a => a.TotalCost) 
                            };
                List<ForReport1> ForReport1s = query1.ToList();

                // მეორე რეპორტი    
                var query2 =
                    from gProduct in ctx.GeneralProducts
                    join order in ctx.OrderedProducts.Where(a => ctx.Orders.Where(o => o.UserID == uid).Select(b => b.ID).Contains(a.OrderID))
                    on gProduct.ID equals order.GeneralProductID
                    into g
                    select new ForReport2
                    {
                        GenaralProduct = gProduct.Name,
                        OrderedCount = g.Count()
                    };

                List<ForReport2> ForReport2s = query2.OrderByDescending(a => a.OrderedCount).ToList();

                if (ForReport2s.Count > 0)
                {
                    ForReport2 report2 = ForReport2s[0];
                }

                // მესამე რეპორტი

                var query3 =
                    from company in ctx.Companies
                    join order in ctx.Orders
                    on company.ID equals order.CompanyID
                    into g
                    select new ForReport3
                    {
                        CompanyName = company.Name,
                        OrderCount = g.Count(),
                        TotalAmount = g.Sum(a => a.TotalCost)
                    };

                List<ForReport3> ForReport3s = query3.ToList();
                int heiuwh = 0;

            }

        }
    }
}