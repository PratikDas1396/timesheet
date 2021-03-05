using db.timesheet.com;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace app.timesheet.com {
    public class DepartmentViewModel {
        public string Mode { get; set; }

        public Guid ID { get; set; }

        [Required(ErrorMessage = " Please Enter Department Code")]
        [Display(Name = "Department Code", Description = "Department Code")]
        public string DepartmentCode { get; set; }

        [Required(ErrorMessage = " Please Enter Department Name")]
        [Display(Name = "Department Name", Description = "Department Name")]
        public string DepartmentName { get; set; }

        public List<Department> DepartmentList { get; set; }
    }
}