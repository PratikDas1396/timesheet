using db.timesheet.com;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace app.timesheet.com {
    public class CustomerViewModel
    {
        public string Mode { get; set; }

        public Guid ID { get; set; }

        [Required(ErrorMessage =" Please Enter Customer Code")]
        [Display(Name = "Customer Code", Description = "Customer Code")]
        public string CustomerCode { get; set; }

        [Required(ErrorMessage = " Please Enter Customer Name")]
        [Display(Name = "Customer Name", Description = "Customer Name")]
        public string CustomerName { get; set; }

        public List<Customer> CustomerList { get; set; }
    }
}