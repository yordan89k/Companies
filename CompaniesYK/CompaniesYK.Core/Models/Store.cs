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

        [Required(ErrorMessage = "Please enter a store name.")]
        [StringLength(100, MinimumLength = 3, ErrorMessage = "Name length must be min 3 and max 100 characters.")]
        [RegularExpression(@"^[A-Za-z0-9\s]+$", ErrorMessage = "Name field must not include any Special Characters(ex. @,%,#)")]
        [DisplayName("Store Name")]
        public string Name { get; set; }

        [Required(ErrorMessage = "Please enter an address.")]
        [StringLength(100, MinimumLength = 3, ErrorMessage = "Address length must be min 3 and max 100 characters.")]
        [RegularExpression(@"^[A-Za-z0-9\s]+$", ErrorMessage = "Address must not include any Special Characters(ex. @,%,#)")]
        public string Adress { get; set; }

        [Required(ErrorMessage = "Please enter a City.")]
        [StringLength(100, MinimumLength = 3, ErrorMessage = "City length must be min 3 and max 100 characters.")]
        [RegularExpression(@"^[A-Za-z\s]+$", ErrorMessage = "City field must not include Numbers or any Special Characters(ex. @,%,#)")]
        public string City { get; set; }

        [Required(ErrorMessage = "Please enter a Zip Code.")]
        [StringLength(16, MinimumLength = 3, ErrorMessage = "Zip length must be min 3 and max 16 characters.")]
        [RegularExpression(@"^[0-9\s]+$", ErrorMessage = "Please enter a numeric value.")]
        [DataType(DataType.PostalCode)]
        public string Zip { get; set; }

        [Required]
        [StringLength(80, MinimumLength = 3, ErrorMessage = "Country length must be min 3 and max 80 characters.")]
        [RegularExpression(@"^[A-Za-z\s]+$", ErrorMessage = "Country field must not include any Numbers or Special Characters(ex. @,%,#)")]
        public string Country { get; set; }


        [StringLength(15, ErrorMessage = "Longitude length can't be more than 15 characters.")]
        public string Longitude { get; set; }
        [StringLength(15, ErrorMessage = "Latitude length can't be more than 15 characters.")]
        public string Latitude { get; set; }

    }
}
