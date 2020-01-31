using CompaniesYK.Core.Models;
using System.Collections.Generic;

namespace CompaniesYK.Core.ViewModels
{
    public class StoreManagerViewModel
    {
        public Store Store { get; set; }
        public IEnumerable<Company> Companies { get; set; }
        public string SelectedCompanyId { get; set; }
        public string SelectedCompanyName { get; set; }

    }
}
