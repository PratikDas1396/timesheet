using db.timesheet.com;
using repository.timesheet.com;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace app.timesheet.com {
    public class TimeSheetViewModel {
        public string Mode { get; set; }

        public Guid ID { get; set; }

        public Guid AccountID { get; set; }

        [Required(ErrorMessage = "Please Select Customer")]
        [Display(Name = "Customer", Description = "Customer")]
        public string CustomerID { get; set; }

        [Required(ErrorMessage = "Please Select Product")]
        [Display(Name = "Product", Description = "Product")]
        public string ProductID { get; set; }

        [Required(ErrorMessage = "Please Select Customer-Product Mapping")]
        [Display(Name = "Customer-Product Mapping", Description = "CustomerProductMapping")]
        public string CustomerProductMappingID { get; set; }

        [Required(ErrorMessage = "Please Select Activity")]
        [Display(Name = "Activity", Description = "Activity")]
        public string ActivityID { get; set; }

        [Required(ErrorMessage = "Please Select Task")]
        [Display(Name = "Task", Description = "Task")]
        public string TaskID { get; set; }

        [Required(ErrorMessage = "Please Enter Task Description")]
        [Display(Name = "Task Description", Description = "Task Description")]
        public string TaskDescription { get; set; }

        [Required(ErrorMessage = "Please Enter From Time")]
        [Display(Name = "From Time", Description = "From Time")]
        public string FromTime { get; set; }

        [Required(ErrorMessage = "Please Enter To Time")]
        [Display(Name = "To Time", Description = "To Time")]
        public string ToTime { get; set; }

        public List<DropdownKeyValue> TimeSheetList { get; set; }
        public List<DropdownKeyValue> CustomerList { get; set; }
        public List<DropdownKeyValue> ProductList { get; set; }
        public List<DropdownKeyValue> TaskList { get; set; }
        public List<DropdownKeyValue> CustomerProductMappingList { get; set; }
        public List<DropdownKeyValue> ActivityList { get; set; }
    }
}