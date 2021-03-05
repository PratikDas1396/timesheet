using System;
using System.ComponentModel.DataAnnotations;

namespace db.timesheet.com
{
    public class Product
    {
        public Guid ID { get; set; }

        [Required]
        [Display(Name = "Product Code")]

        public string ProductCode { get; set; }

        [Required]
        [Display(Name = "Product Name")]
        public string ProductName { get; set; }

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