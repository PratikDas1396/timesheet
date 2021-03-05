using db.timesheet.com;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace app.timesheet.com {
    public class DesignationViewModel {
        public string Mode { get; set; }

        public Guid ID { get; set; }

        [Required(ErrorMessage = "Please Enter Designation Code")]
        [Display(Name = "Designation Code", Description = "Designation Code")]
        public string DesignationCode { get; set; }

        [Required(ErrorMessage = " Please Enter Designation Name")]
        [Display(Name = "Designation Name", Description = "Designation Name")]
        public string DesignationName { get; set; }

        public List<Designation> DesignationList { get; set; }
    }
}