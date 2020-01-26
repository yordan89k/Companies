using CompaniesYK.Core.Contracts;
using CompaniesYK.Core.Models;
using CompaniesYK.DataAccess.InMemory;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace CompaniesYK.WebUI.Controllers
{

    public class CompanyManagerController : Controller
    {
        IRepository<Company> companyContext;

        public CompanyManagerController(IRepository<Company> companyContext)
        {
            this.companyContext = companyContext;
        }
        public ActionResult Index()
        {
            List<Company> companies = companyContext.Collection().ToList();
            return View(companies);
        }

        public ActionResult Create()
        {
            var company = new Company();
            return View(company);
        }

        [HttpPost]
        public ActionResult Create(Company company)
        {
            if (!ModelState.IsValid)
            {
                return View(company);
            }
            else
            {
                companyContext.Insert(company);
                companyContext.Commit();

                return RedirectToAction("Index");
            }
        }

        public ActionResult Edit(string Id)
        {
            Company company = companyContext.Find(Id);
            if (company == null)
            {
                return HttpNotFound();
            }
            else
            {
                return View(company);
            }
        }

        [HttpPost]
        public ActionResult Edit(Company company, string Id)
        {
            Company companyToEdit = companyContext.Find(Id);
            if (company == null)
            {
                return HttpNotFound();
            }
            else
            {
                if (!ModelState.IsValid)
                {
                    return View(company);
                }
                else
                {
                    companyToEdit.Name = company.Name;
                    companyToEdit.OrganizationNumber = company.OrganizationNumber;
                    companyToEdit.Logo = company.Logo;
                    companyToEdit.Notes = company.Notes;


                    companyContext.Commit();

                    return RedirectToAction("Index");
                }
            }
        }

        public ActionResult Delete(string Id)
        {
            Company companyToDelete = companyContext.Find(Id);

            if (companyToDelete == null)
            {
                return HttpNotFound();
            }
            else
            {
                return View(companyToDelete);
            }
        }
        [HttpPost]
        [ActionName("Delete")]
        public ActionResult ConfirmDelete(string Id)
        {
            Company companyToDelete = companyContext.Find(Id);

            if (companyToDelete == null)
            {
                return HttpNotFound();
            }
            else
            {
                companyContext.Delete(Id);
                companyContext.Commit();
                return RedirectToAction("Index");
            }
        }

    }
}