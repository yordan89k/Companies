﻿using CompaniesYK.Core.Models;
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
        StoreRepository context;
        CompanyRepository companies;

        public StoreManagerController()
        {
            context = new StoreRepository();
            companies = new CompanyRepository();
        }
        public ActionResult Index()
        {
            List<Store> stores = context.Collection().ToList();
            return View(stores);
        }

        public ActionResult Create()
        {
            StoreManagerViewModel viewModel = new StoreManagerViewModel();
            viewModel.Store = new Store();
            viewModel.Companies = companies.Collection();

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
                context.Insert(store);
                context.Commit();

                return RedirectToAction("Index");
            }
        }

        public ActionResult Edit(string Id)
        {
            Store store = context.Find(Id);
            if (store == null)
            {
                return HttpNotFound();
            }
            else
            {
                StoreManagerViewModel viewModel = new StoreManagerViewModel();
                viewModel.Store = store;
                viewModel.Companies = companies.Collection();
                return View(viewModel);
            }
        }

        [HttpPost]
        public ActionResult Edit(Store store, string Id)
        {
            Store storeToEdit = context.Find(Id);
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

                    context.Commit();

                    return RedirectToAction("Index");
                }
            }
        }

        public ActionResult Delete(string Id)
        {
            Store storeToDelete = context.Find(Id);

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
            Store storeToDelete = context.Find(Id);

            if (storeToDelete == null)
            {
                return HttpNotFound();
            }
            else
            {
                context.Delete(Id);
                context.Commit();
                return RedirectToAction("Index");
            }
        }

    }
}