using CompaniesYK.Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CompaniesYK.Core.ViewModels
{
    public class StoreManagerViewModel
    {
        public Store Store { get; set; }
        public IEnumerable<Company> Companies { get; set; }
    }
}
