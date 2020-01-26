using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CompaniesYK.Core.Models
{
    public class Store : Base
    {

        public string Company { get; set; }
        public string CompanyId { get; set; }
        // Should this be int or something else since it comes from the Company class?

        [StringLength(100)]
        [DisplayName("Store Name")]
        public string Name { get; set; }
        public string Adress { get; set; }
        public string City { get; set; }
        public string Zip { get; set; }
        public string Country { get; set; }
        public string Longitude { get; set; }
        public string Latitude { get; set; }



    }
}
