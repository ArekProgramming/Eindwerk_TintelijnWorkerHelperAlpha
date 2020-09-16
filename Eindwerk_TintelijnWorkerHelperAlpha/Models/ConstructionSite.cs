
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Eindwerk_TintelijnWorkerHelperAlpha.Models
{
    public class ConstructionSite
    {
        [Key]
        public int ConstructionSiteId { get; set; }

        [Required(ErrorMessage = "Field required")]
        [Column(TypeName = "nvarchar(100)")]
        [DisplayName("Client Name")]
        public string ClientName { get; set; }

        [DisplayName("Active Site")]
        public bool IsActive { get; set; } = false;

        public int AddressId { get; set; }
        public Address Address { get; set; }

    }
}
