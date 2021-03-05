using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace db.timesheet.com
{
    public class Customer
    {
        public Guid ID { get; set; }

        [Required]
        [Display(Name = "Customer Code")]
        public string CustomerCode { get; set; }

        [Required]
        [Display(Name = "Customer Name")]
        public string  CustomerName { get; set; }

        [Required]
        [Display(Name = "Created By")]
        [DataType(DataType.DateTime)]
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