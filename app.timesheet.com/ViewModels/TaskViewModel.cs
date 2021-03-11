using db.timesheet.com;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace app.timesheet.com {
    public class TaskViewModel {
        public string Mode { get; set; }

        public Guid ID { get; set; }

        [Required(ErrorMessage = " Please Enter Task Code")]
        [Display(Name = "Task Code", Description = "Task Code")]
        public string TaskCode { get; set; }

        [Required(ErrorMessage = " Please Enter Task Description")]
        [Display(Name = "Task Description", Description = "Task Description")]
        public string TaskDescription { get; set; }

        public List<Task> TaskList { get; set; }
    }
}