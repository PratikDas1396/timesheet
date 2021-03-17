using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;


namespace db.timesheet.com {
    public class ErrorLog {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Key]
        public int RecId { get; set; }
        
        public string ClassName { get; set; }

        public string MethodName { get; set; }

        public string ErrorDescription { get; set; }

        public string StackTrace { get; set; }

        [Required]
        [DataType(DataType.DateTime)]
        public string CreatedBy { get; set; }

        [Required]
        public DateTime CreatedDtim { get; set; }
    }
}
