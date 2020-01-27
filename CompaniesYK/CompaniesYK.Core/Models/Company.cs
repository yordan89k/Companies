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

        [Required]
        [StringLength(225)]
        public string Name { get; set; }
        [DisplayName("Num")]
        [Required]
        public int OrganizationNumber { get; set; }
        public string Notes { get; set; }
        public string Logo { get; set; }
    }
}
