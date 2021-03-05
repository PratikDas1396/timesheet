using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace db.timesheet.com
{
    public class CustomerProductMapping
    {
        public Guid ID { get; set; }

        [Required]
        public Customer CustomerCode { get; set; }

        [Required]
        public Product ProductCode { get; set; }

        [Required]
        public string CreatedBy { get; set; }

        [Required]
        public DateTime CreatedDtim { get; set; }

        public string UpdatedBy { get; set; }

        public DateTime? UpdatedDtim { get; set; }
    }
}