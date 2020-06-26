using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace EmployeeManager.Models.Entitys
{
    public class User
    {
        public int Id { get; set; }

        [StringLength(250, ErrorMessage = "Max letters is 250")]
        [MinLength(5, ErrorMessage = "Please add more letter")]
        [Required(ErrorMessage = "This field is requied.")]
        public string UserName { get; set; }

        public string PassWord { get; set; }

        [StringLength(250, ErrorMessage = "Max letters is 250")]
        public string DisplayName { get; set; }

        public DateTime BirthDay { get; set; }

        [StringLength(50, ErrorMessage = "Max letters is 50")]
        public string Phone { get; set; }

        public string Address { get; set; }

        public DateTime CreateDate { get; set; }
    }
}
