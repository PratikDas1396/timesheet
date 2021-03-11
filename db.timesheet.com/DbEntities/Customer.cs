using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace db.timesheet.com {
    public class Customer {

        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int RecId { get; set; }

        [Key]
        public Guid ID { get; set; }

        [Required]
        public string CustomerCode { get; set; }

        [Required]
        public string CustomerName { get; set; }

        [Required]
        [DataType(DataType.DateTime)]
        public string CreatedBy { get; set; }

        [Required]
        public DateTime CreatedDtim { get; set; }

        public string UpdatedBy { get; set; }

        public DateTime? UpdatedDtim { get; set; }

        //Navigation
        public virtual ICollection<CustomerProductMapping> Product { get; set; }
    }
}