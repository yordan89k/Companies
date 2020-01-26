using CompaniesYK.Core.Models;
using CompaniesYK.Core.ViewModels;
using CompaniesYK.DataAccess.InMemory;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace CompaniesYK.WebUI.Controllers
{

    public class StoreManagerController : Controller
    {
        InMemoryRepository<Store> storeContext;
        InMemoryRepository<Company> companyContext;

        public StoreManagerController()
        {
            storeContext = new InMemoryRepository<Store>();
            companyContext = new InMemoryRepository<Company>();
        }
        public ActionResult Index()
        {
            List<Store> stores = storeContext.Collection().ToList();
            return View(stores);
        }

        public ActionResult Create()
        {
            StoreManagerViewModel viewModel = new StoreManagerViewModel();
            viewModel.Store = new Store();
            viewModel.Companies = companyContext.Collection();

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

        public ActionResult Edit(string Id)
        {
            Store store = storeContext.Find(Id);
            if (store == null)
            {
                return HttpNotFound();
            }
            else
            {
                StoreManagerViewModel viewModel = new StoreManagerViewModel();
                viewModel.Store = store;
                viewModel.Companies = companyContext.Collection();
                return View(viewModel);
            }
        }

        [HttpPost]
        public ActionResult Edit(Store store, string Id)
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
                    storeToEdit.Company = store.Company;
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

        public ActionResult Delete(string Id)
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
        public ActionResult ConfirmDelete(string Id)
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

    }
}