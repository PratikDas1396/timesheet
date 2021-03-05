using System;
using System.ComponentModel.DataAnnotations;

namespace db.timesheet.com {
    public class Department
    {
        public Guid ID { get; set; }

        [Required]
        [Display(Name = "Department Code")]
        public string DepartmentCode { get; set; }

        [Required]
        [Display(Name = "Department Name")]
        public string DepartmentName { get; set; }

        [Required]
        [Display(Name = "Created By")]
        public string CreatedBy { get; set; }

        [Required]
        [Display(Name = "Created Datetime")]
        public DateTime CreatedDtim { get; set; }

        [Display(Name = "Updated By")]
        public string UpdatedBy { get; set; }

        [Display(Name = "Updated Datetime")]
        public DateTime? UpdatedDtim { get; set; }
    }
}