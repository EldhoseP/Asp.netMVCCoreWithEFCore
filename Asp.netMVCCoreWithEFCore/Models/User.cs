using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Asp.netMVCCoreWithEFCore.Models
{
    public class User
    {
        [Key]
        public int UserId { get; set; }
        [Column(TypeName = "nvarchar(350)")]
        [DisplayName("User Name")]
        public string UserName { get; set; }
        [Column(TypeName = "nvarchar(350)")]
        public string Password { get; set; }
    }
}
