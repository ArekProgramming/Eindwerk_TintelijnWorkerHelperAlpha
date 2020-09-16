using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Eindwerk_TintelijnWorkerHelperAlpha.Models
{
    public class Address
    {
        [Key]
        public int AddressId { get; set; }

        [Required(ErrorMessage = "Field required")]
        [Column(TypeName = "nvarchar(100)")]
        [DisplayName("Street Name")]
        public string StreetName { get; set; }

        [Required(ErrorMessage = "Field required")]
        [Column(TypeName = "nvarchar(25)")]
        [DisplayName("House Number")]
        public string HouseNumber { get; set; }

        [Required(ErrorMessage = "Field required")]
        [Column(TypeName = "nvarchar(4)")]
        [MaxLength(4)]
        [Range(1000,9999)]
        [DisplayName("Postal Code")]
        public int PostalCode { get; set; }

        [Required(ErrorMessage = "Field required")]
        [Column(TypeName = "nvarchar(100)")]
        public string City { get; set; }

        //public int ConstructionSiteId { get; set; }
        public ConstructionSite ConstructionSite { get; set; }

    }
}
