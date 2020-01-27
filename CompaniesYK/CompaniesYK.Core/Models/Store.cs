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
        [DisplayName("Owner Company")]
        public string OwnerCompany { get; set; }

        [Required]
        public Guid CompanyId { get; set; }
        [ForeignKey("CompanyId")]
        public virtual Company Company { get; set; }
        // Key attribute is realy needed ?

        [Required(ErrorMessage = "Please enter a store name.")]
        [StringLength(100, ErrorMessage = "Name length can't be more than 100 characters.")]
        [DisplayName("Store Name")]
        public string Name { get; set; }
        [Required]
        public string Adress { get; set; }
        [Required]
        public string City { get; set; }
        [Required]
        [StringLength(16, ErrorMessage = "Zip length can't be more than 16 characters.")]
        [DataType(DataType.PostalCode)]
        public string Zip { get; set; }
        [Required]
        public string Country { get; set; }
        [StringLength(15, ErrorMessage = "Longitude length can't be more than 15 characters.")]
        public string Longitude { get; set; }
        [StringLength(15, ErrorMessage = "Latitude length can't be more than 15 characters.")]
        public string Latitude { get; set; }



    }
}
