using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CompaniesYK.Core.Models
{
    public class Store : Base
    {

        public string OwnerCompany { get; set; }

        
        public string CompanyId { get; set; }
        [ForeignKey("CompanyId")]
        public virtual Company Company { get; set; }
        // Key attribute is realy needed ?

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
