using System;
using System.ComponentModel.DataAnnotations;

namespace db.timesheet.com {
    public class Tasks
    {
        public Guid ID { get; set; }

        [Required]
        public string TaskCode { get; set; }

        [Required]
        public string TaskDescription { get; set; }

        [Required]
        public string CreatedBy { get; set; }

        [Required]
        public DateTime CreatedDtim { get; set; }

        public string UpdatedBy { get; set; }

        public DateTime? UpdatedDtim { get; set; }
    }
}