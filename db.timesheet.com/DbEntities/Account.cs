using System;
using System.ComponentModel.DataAnnotations;

namespace db.timesheet.com {
    public class Account
    {

        [Key]
        public Guid ID { get; set; }

        [Required]
        public Guid DepartmentID { get; set; }

        [Required]
        public Guid DesignationID { get; set; }

        [Required, MaxLength(200)]
        public string UserName { get; set; }

        [Required, MaxLength(200)]
        public string UserID { get; set; }

        [Required]
        public string Email { get; set; }

        [Required]
        public string UserPin { get; set; }

        [Required]
        public bool IsActive { get; set; }

        [Required]
        public string CreatedBy { get; set; }

        [Required]
        public DateTime CreatedDtim { get; set; }

        public string UpdatedBy { get; set; }

        public DateTime? UpdatedDtim { get; set; }

        //Navigations
        public Department Department { get; set; }
        public Designation Designation { get; set; }
    }
}