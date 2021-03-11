using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace db.timesheet.com {
    public class CustomerProductMapping
    {
        [Key]
        [Column(Order = 1)]
        public Guid ID { get; set; }

        [Column(Order = 2)]
        public Guid CustomerID { get; set; }

        [Column(Order = 3)]
        public Guid ProductID { get; set; }

        [Required]
        public Customer Customer { get; set; }

        [Required]
        public Product Product { get; set; }

        [Required]
        public string CreatedBy { get; set; }

        [Required]
        public DateTime CreatedDtim { get; set; }

        public string UpdatedBy { get; set; }

        public DateTime? UpdatedDtim { get; set; }

        //Navigation Property
        public ICollection<Activity> Activities { get; set; }
    }
}