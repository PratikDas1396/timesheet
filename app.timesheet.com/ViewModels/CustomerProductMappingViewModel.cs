using db.timesheet.com;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace app.timesheet.com {
    public class CustomerProductMappingViewModel {

        public string Mode { get; set; }

        public Guid ID { get; set; }

        [Required]
        public Guid CustomerID { get; set; }

        [Display(Name = "Customer", Description = "Customer")]
        public IEnumerable<Customer> CustomerList { get; set; }

        [Required]
        public Guid ProductID { get; set; }

        [Display(Name = "Product", Description = "Product")]
        public IEnumerable<Product> ProductList { get; set; }

        public List<CustomerProductMapping> CustomerProductMappingList { get; set; }
    }
}