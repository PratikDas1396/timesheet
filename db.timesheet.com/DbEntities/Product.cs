using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace db.timesheet.com {
    public class Product {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int RecId { get; set; }

        public Guid ID { get; set; }

        [Required]
        public string ProductCode { get; set; }

        [Required]
        public string ProductName { get; set; }

        [Required]
        public string CreatedBy { get; set; }

        [Required]
        public DateTime CreatedDtim { get; set; }

        public string UpdatedBy { get; set; }

        public DateTime? UpdatedDtim { get; set; }

        //Navigation
        public virtual ICollection<CustomerProductMapping> Customer { get; set; }
    }
}