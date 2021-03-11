using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace db.timesheet.com {
    public class Department
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int RecId { get; set; }

        [Key]
        public Guid ID { get; set; }

        [Required]
        public string DepartmentCode { get; set; }

        [Required]
        public string DepartmentName { get; set; }

        [Required]
        public string CreatedBy { get; set; }

        [Required]
        public DateTime CreatedDtim { get; set; }

        public string UpdatedBy { get; set; }

        public DateTime? UpdatedDtim { get; set; }

        public ICollection<Activity> Activities { get; set; }
    }
}