using CompaniesYK.Core.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CompaniesYK.DataAccess.SQL
{
    public class DataContext : DbContext
    {
        public DataContext()
            : base("DefaultConnection")
        {

        }

        public DbSet<Store> Stores { get; set; }
        public DbSet<Company> Companies { get; set; }

    }
}
