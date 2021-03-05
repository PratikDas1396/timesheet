using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace db.timesheet.com
{
    public class Account
    {

        public Guid ID { get; set; }

        [Required, MaxLength(200)]
        public string UserName { get; set; }

        [Required]
        public string UserEmail { get; set; }

        [Required]
        public string UserPin { get; set; }

        //[Required]
        //public Department Department_Code { get; set; }

        //[Required]
        //public Designation Designation_Code { get; set; }

        [Required]
        public string CreatedBy { get; set; }

        [Required]
        public DateTime CreatedDtim { get; set; }

        public string UpdatedBy { get; set; }

        public DateTime? UpdatedDtim { get; set; }
    }
}