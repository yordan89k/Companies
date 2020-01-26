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
        CompanyRepository context;

        public CompanyManagerController()
        {
            context = new CompanyRepository();
        }
        public ActionResult Index()
        {
            List<Company> companies = context.Collection().ToList();
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
                context.Insert(company);
                context.Commit();

                return RedirectToAction("Index");
            }
        }

        public ActionResult Edit(string Id)
        {
            Company company = context.Find(Id);
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
            Company companyToEdit = context.Find(Id);
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


                    context.Commit();

                    return RedirectToAction("Index");
                }
            }
        }

        public ActionResult Delete(string Id)
        {
            Company companyToDelete = context.Find(Id);

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
            Company companyToDelete = context.Find(Id);

            if (companyToDelete == null)
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