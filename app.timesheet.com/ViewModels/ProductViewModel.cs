using db.timesheet.com;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace app.timesheet.com {
    public class ProductViewModel {

        public string Mode { get; set; }

        public Guid ID { get; set; }

        [Required]
        [Display(Name = "Product Code", Description = "Product Code")]
        public string ProductCode { get; set; }

        [Required]
        [Display(Name = "Product Name", Description = "Product Name")]
        public string ProductName { get; set; }

        public List<Product> ProductList { get; set; }
    }
}