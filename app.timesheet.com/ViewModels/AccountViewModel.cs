using db.timesheet.com;
using repository.timesheet.com;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace app.timesheet.com {
    public class AccountViewModel {
        public string Mode { get; set; }

        public Guid ID { get; set; }
        
        [Required(ErrorMessage = "Please Enter Name")]
        [Display(Name = "Name", Description = "Name")]
        public string UserName { get; set; }

        [Required(ErrorMessage = " Please Enter User ID")]
        [Display(Name = "User ID", Description = "User ID")]
        public string UserID { get; set; }

        [Required(ErrorMessage = " Please Enter Email")]
        [Display(Name = "Email", Description = "Email")]
        public string Email { get; set; }

        [Required(ErrorMessage = "Please Enter Password")]
        [Display(Name = "Password", Description = "Password")]
        public string Password { get; set; }

        [Required(ErrorMessage = "Please Select Department")]
        [Display(Name = "Department", Description = "Department")]
        public Guid DepartmentID { get; set; }

        [Required(ErrorMessage = "Please Select Designation")]
        [Display(Name = "Designation", Description = "Designation")]
        public Guid DesignationID { get; set; }

        public List<Account> UserList { get; set; }
        public List<DropdownKeyValue> DepartmentList { get; set; }
        public List<DropdownKeyValue> DesignationList { get; set; }
    }
}