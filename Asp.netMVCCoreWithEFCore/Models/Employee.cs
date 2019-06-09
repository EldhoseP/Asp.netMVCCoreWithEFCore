using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Asp.netMVCCoreWithEFCore.Models
{
    public class Employee
    {
        [Key]
        public int EmployeeId { get; set; }
        [Column(TypeName ="nvarchar(350)")]
        [Required(ErrorMessage ="This field is required")]
        [DisplayName("Full Name")]
        public string FullName { get; set; }
        [Column(TypeName = "nvarchar(20)")]
        [DisplayName("Emp Code")]
        [Required(ErrorMessage = "This field is required")]
        public string EmpCode { get; set; }
        [Column(TypeName = "nvarchar(150)")]
        [DisplayName("Designation")]
        public string Designation { get; set; }
        [Column(TypeName = "nvarchar(200)")]
        [DisplayName("Office Locations")]
        public string OfficeLocations { get; set; }
    }
}
