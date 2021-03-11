using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace db.timesheet.com {
    public class Designation
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int RecId { get; set; }

        [Key]
        public Guid ID { get; set; }

        [Required]
        public string DesignationCode { get; set; }

        [Required]
        public string DesignationName { get; set; }

        [Required]
        public string CreatedBy { get; set; }

        [Required]
        public DateTime CreatedDtim { get; set; }

        public string UpdatedBy { get; set; }

        public DateTime? UpdatedDtim { get; set; }
    }
}