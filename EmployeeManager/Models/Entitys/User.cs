using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EmployeeManager.Models.Entitys
{
    public class User
    {
        public int Id { get; set; }

        public string UserName { get; set; }

        public string PassWord { get; set; }

        public string DisplayName { get; set; }

        public DateTime BirthDay { get; set; }

        public string Phone { get; set; }

        public string Address { get; set; }

        public DateTime CreateDate { get; set; }
    }
}
