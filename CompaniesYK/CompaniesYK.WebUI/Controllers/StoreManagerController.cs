using CompaniesYK.Core.Contracts;
using CompaniesYK.Core.Models;
using CompaniesYK.Core.ViewModels;
using CompaniesYK.DataAccess.InMemory;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace CompaniesYK.WebUI.Controllers
{

    public class StoreManagerController : Controller
    {
        IRepository<Store> storeContext;
        IRepository<Company> companyContext;

        public StoreManagerController(IRepository<Store> storeContext, IRepository<Company> companyContext)
        {
            this.storeContext = storeContext;
            this.companyContext = companyContext;
        }

        public ActionResult Index()
        {
            List<Store> stores = storeContext.Collection().ToList();
            return View(stores);
        }

        public ActionResult SelectCompany()
        {
            List<Company> companies = companyContext.Collection().ToList();
            return View(companies);
        }

        public ActionResult Create(Guid companyId, string companyName)
        {
            var viewModel = new StoreManagerViewModel();
            viewModel.Store = new Store();

            viewModel.Companies = companyContext.Collection();
            viewModel.SelectedCompanyId = companyId.ToString();
            viewModel.SelectedCompanyName = companyName.ToString();

            return View(viewModel);
        }

        [HttpPost]
        public ActionResult Create(Store store)
        {
            if (!ModelState.IsValid)
            {
                return View(store);
            }
            else
            {
                storeContext.Insert(store);
                storeContext.Commit();

                return RedirectToAction("Index");
            }
        }

        public ActionResult Edit(Guid Id)
        {
            Store store = storeContext.Find(Id);
            if (store == null)
            {
                return HttpNotFound();
            }
            else
            {
                var viewModel = new StoreManagerViewModel();
                viewModel.Store = store;
                viewModel.Companies = companyContext.Collection();
                return View(viewModel);
            }
        }

        [HttpPost]
        public ActionResult Edit(Store store, Guid Id)
        {
            Store storeToEdit = storeContext.Find(Id);
            if (store == null)
            {
                return HttpNotFound();
            }
            else
            {
                if (!ModelState.IsValid)
                {
                    return View(store);
                }
                else
                {
                    storeToEdit.OwnerCompany = store.OwnerCompany;
                    storeToEdit.Name = store.Name;
                    storeToEdit.Adress = store.Name; 
                    storeToEdit.City = store.Name;
                    storeToEdit.Zip = store.Name;
                    storeToEdit.Country = store.Name;
                    storeToEdit.Longitude = store.Name;
                    storeToEdit.Latitude = store.Name;

                    storeContext.Commit();

                    return RedirectToAction("Index");
                }
            }
        }

        public ActionResult Delete(Guid Id)
        {
            Store storeToDelete = storeContext.Find(Id);

            if (storeToDelete == null)
            {
                return HttpNotFound();
            }
            else
            {
                return View(storeToDelete);
            }
        }
        [HttpPost]
        [ActionName("Delete")]
        public ActionResult ConfirmDelete(Guid Id)
        {
            Store storeToDelete = storeContext.Find(Id);

            if (storeToDelete == null)
            {
                return HttpNotFound();
            }
            else
            {
                storeContext.Delete(Id);
                storeContext.Commit();
                return RedirectToAction("Index");
            }
        }


        /* Method to recognise a name of a company and get output of its Guid Id as string
         * 
        public string FetchCompanyId(string NameInput)
        {
            string CompanyIdFetched = "";
            NameInput = "Wise Home";


            foreach (var company in companyContext.Collection())
            {
                if (NameInput == company.Name)
                {
                    CompanyIdFetched = company.Id.ToString();

                }
            }

            return CompanyIdFetched;
        }
        */

    }
}