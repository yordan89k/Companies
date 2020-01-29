using CompaniesYK.Core.Contracts;
using CompaniesYK.Core.Models;
using CompaniesYK.DataAccess.InMemory;
using System;
using System.Collections.Generic;
using System.IO;
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
        public ActionResult Create(Company company, HttpPostedFileBase file)
        {
            if (!ModelState.IsValid)
            {
                return View(company);
            }
            else
            {
                if (file != null)
                {
                    company.Logo = company.Id + Path.GetExtension(file.FileName);
                    file.SaveAs(Server.MapPath("//Content//CompanyImages//") + company.Logo);
                }

                companyContext.Insert(company);
                companyContext.Commit();

                return RedirectToAction("Index");
            }
        }

        public ActionResult Edit(Guid Id)
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
        public ActionResult Edit(Company company, Guid Id, HttpPostedFileBase file)
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

                if (file != null)
                {
                    companyToEdit.Logo = company.Id + Path.GetExtension(file.FileName);
                    file.SaveAs(Server.MapPath("//Content//CompanyImages//") + companyToEdit.Logo);
                }

                {
                    companyToEdit.Name = company.Name;
                    companyToEdit.OrganizationNumber = company.OrganizationNumber;
                    companyToEdit.Notes = company.Notes;

                    companyContext.Commit();

                    return RedirectToAction("Index");
                }
            }
        }

        public ActionResult Delete(Guid Id)
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
        public ActionResult ConfirmDelete(Guid Id)
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

        public ActionResult Details(Guid Id)
        {
            var company = companyContext.Find(Id);
            if (company == null)
            {
                return HttpNotFound();
            }
            else
            {
                return View(company);
            }
        }
    }
}