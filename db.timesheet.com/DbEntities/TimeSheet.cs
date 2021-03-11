using System;
using System.ComponentModel.DataAnnotations;

namespace db.timesheet.com
{
    public class TimeSheet
    {
        public Guid ID { get; set; }

        public string TaskDescription { get; set; }

        [Required]
        public Activity ActivityCode { get; set; }

        [Required]
        public Task TaskCode { get; set; }

        [Required]
        [DataType(DataType.Time)]
        public string From { get; set; }

        [Required]
        [DataType(DataType.Time)]
        public string To { get; set; }

        [Required]
        public string CreatedBy { get; set; }

        [Required]
        public DateTime CreatedDtim { get; set; }

        public string UpdatedBy { get; set; }

        public DateTime? UpdatedDtim { get; set; }
    }
}