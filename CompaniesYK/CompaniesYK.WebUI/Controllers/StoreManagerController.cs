using CompaniesYK.Core.Contracts;
using CompaniesYK.Core.Models;
using CompaniesYK.Core.ViewModels;
using CompaniesYK.DataAccess.InMemory;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Web.Mvc;
using System.Web.UI.WebControls;
using System.Xml.Linq;

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
                #region Geocoding with Google API

                string CountryInp = Request.Form["CountryField2"];
                string CityInp = Request.Form["CityField2"];
                string AdressInp = Request.Form["AdressField2"];
                // -- Right now I don't include Zip because there is enough info to find he address. --
                // -- However, if needed just use this: string ZipInp = Request.Form["ZipField2"]; and add  {ZipInp} bellow --
                string adressFull = $"{AdressInp}, {CityInp}, {CountryInp}";

                string requestUri = string.Format("https://maps.googleapis.com/maps/api/geocode/xml?key=AIzaSyAzM-iistE3bx7Y86YPpfYuPQM76uKVzu4&address={0}=false", Uri.EscapeDataString(adressFull));

                WebRequest request = WebRequest.Create(requestUri);
                WebResponse response = request.GetResponse();

                // -- Possible improvement: I can try to add JSON instead. Better practice according to Google

                XDocument xdoc = XDocument.Load(response.GetResponseStream());
                XElement result = xdoc.Element("GeocodeResponse").Element("result");
                XElement locationElement = result.Element("geometry").Element("location");

                XElement lat = locationElement.Element("lat");
                XElement lng = locationElement.Element("lng");

                var reader = lat.CreateReader();
                reader.MoveToContent();
                string resultLat = reader.ReadInnerXml();
                store.Latitude = resultLat;

                var reader2 = lng.CreateReader();
                reader2.MoveToContent();
                string resultLng = reader2.ReadInnerXml();
                store.Longitude = resultLng;
                #endregion

                storeContext.Insert(store);
                storeContext.Commit();

                return RedirectToAction("StoreCreated", new { Id = store.Id });
            }
        }

        // -- In Edit I use ViewModel so the user can select the Company from list with all existing companies in the Db
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
                    storeToEdit.Adress = store.Adress; 
                    storeToEdit.City = store.City;
                    storeToEdit.Zip = store.Zip;
                    storeToEdit.Country = store.Country;
                    storeToEdit.Longitude = store.Longitude;
                    storeToEdit.Latitude = store.Latitude;

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

        public ActionResult Details(Guid Id)
        {
            var store = storeContext.Find(Id);
            if (store == null)
            {
                return HttpNotFound();
            }
            else
            {
                return View(store);
            }
        }

        public ActionResult StoreCreated(Guid Id)
        {
            var store = storeContext.Find(Id);
            if (store == null)
            {
                return HttpNotFound();
            }
            else
            {
                return View(store);
            }
        }
    }
}