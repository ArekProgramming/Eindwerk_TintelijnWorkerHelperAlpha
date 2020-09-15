using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Eindwerk_TintelijnWorkerHelperAlpha.Models
{
    public class Employee
    {
        [Key]
        public int EmployeeId { get; set; }

        [Required(ErrorMessage = "Field required")]
        [Column(TypeName = "nvarchar(50)")]
        [DisplayName("First Name")]
        public string FirstName { get; set; }

        [Required(ErrorMessage = "Field required")]
        [Column(TypeName = "nvarchar(50)")]
        [DisplayName("Last Name")]
        public string LastName { get; set; }

        [Required(ErrorMessage = "Field required")]
        [Column(TypeName = "nvarchar(100)")]
        [DisplayName("Email")]
        [EmailAddress(ErrorMessage = "Invalid email format")]
        public string EmailAddress { get; set; }


        // bij toevoegen nieuwe properties niet vergeten die toevoegen bij controller AddOrEdit als extra parameters!!!

        //public DateTime ContractStart { get; set; }
        //public int MyProperty { get; set; }

    }
}
