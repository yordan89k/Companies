using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CompaniesYK.Core.Models
{
    public class Company : Base
    {

        [StringLength(225)]
        [DisplayName("Company Name")]
        public string Name { get; set; }
        public int OrganizationNumber { get; set; }
        public string Logo { get; set; }
    }
}
