using CompaniesYK.Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Caching;
using System.Text;
using System.Threading.Tasks;

namespace CompaniesYK.DataAccess.InMemory
{
    public class CompanyRepository
    {
        ObjectCache cache = MemoryCache.Default;
        List<Company> companies;

        public CompanyRepository()
        {
            companies = cache["products"] as List<Company>;
            if (companies == null)
            {
                companies = new List<Company>();
            }

        }

        public void Commit()
        {
            cache["companies"] = companies;
        }

        public void Insert(Company p)
        {
            companies.Add(p);
        }

        public void Update(Company company)
        {
            Company companyToUpdate = companies.Find(p => p.Id == company.Id);

            if (companyToUpdate != null)
            {
                companyToUpdate = company;
            }
            else
            {
                throw new Exception("Company not found");
            }
        }

        public Company Find(string Id)
        {
            Company company = companies.Find(p => p.Id == Id);

            if (company != null)
            {
                return company;
            }
            else
            {
                throw new Exception("Company not found");
            }
        }

        public IQueryable<Company> Collection()
        {
            return companies.AsQueryable();
        }

        public void Delete(string Id)
        {
            {
                Company companyToDelete = companies.Find(p => p.Id == Id);

                if (companyToDelete != null)
                {
                    companies.Remove(companyToDelete);
                }
                else
                {
                    throw new Exception("Company not found");
                }
            }
        }





    }
}