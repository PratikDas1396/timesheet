using db.timesheet.com;
using repository.timesheet.com;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace app.timesheet.com {
    public class ActivityViewModel {
        public string Mode { get; set; }

        public Guid ID { get; set; }

        public Guid DepartmentID { get; set; }

        public Guid CustomerProductMappingID { get; set; }

        [Required(ErrorMessage = "Please Enter Activity Code")]
        [Display(Name = "Activity Code", Description = "Activity Code")]
        public string ActivityCode { get; set; }

        [Required(ErrorMessage = "Please Enter Activity Name")]
        [Display(Name = "Activity Name", Description = "Activity Name")]
        public string ActivityName { get; set; }

        public List<DropdownKeyValue> DepartmentList { get; set; }
        public List<DropdownKeyValue> CustomerProductMappingList { get; set; }
        public List<Activity> ActivityList { get; set; }
    }
}