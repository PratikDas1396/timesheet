using System;
using System.ComponentModel.DataAnnotations;

namespace db.timesheet.com
{
    public class TimeSheet
    {
        [Key]
        public Guid ID { get; set; }

        [Required]
        public string TaskDescription { get; set; }

        [Required]
        public Guid AccountID { get; set; }

        [Required]
        public Guid ActivityID { get; set; }

        [Required]
        public Guid TaskID { get; set; }

        [Required]
        [DataType(DataType.Time)]
        public string FromTime { get; set; }

        [Required]
        [DataType(DataType.Time)]
        public string ToTime { get; set; }

        [Required]
        public DateTime TaskDate { get; set; }

        [Required]
        public string CreatedBy { get; set; }

        [Required]
        public DateTime CreatedDtim { get; set; }

        public string UpdatedBy { get; set; }

        public DateTime? UpdatedDtim { get; set; }

        //Navigation
        //public Account Account { get; set; }
        public Activity Activity { get; set; }
        public Task Task { get; set; }
    }
}