using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace db.timesheet.com
{
    public class Activity
    {
        [Key]
        public Guid ID { get; set; }

        [Required]
        public string ActivityCode { get; set; }

        [Required]
        public string ActivityName { get; set; }

        [Required]
        public CustomerProductMapping customerProductMapping { get; set; }

        [Required]
        public string CreatedBy { get; set; }

        [Required]
        public DateTime CreatedDtim { get; set; }

        public string UpdatedBy { get; set; }

        public DateTime? UpdatedDtim { get; set; }
    }
}