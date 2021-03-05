using System;
using System.ComponentModel.DataAnnotations;

namespace db.timesheet.com {
    public class Designation
    {

        public Guid ID { get; set; }

        [Required]
        [Display(Name = "Designation Code")]
        public string DesignationCode { get; set; }

        [Required]
        [Display(Name = "Designation Name")]
        public string DesignationName { get; set; }

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