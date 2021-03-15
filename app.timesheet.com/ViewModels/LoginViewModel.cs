using System.ComponentModel.DataAnnotations;

namespace app.timesheet.com {
    public class LoginViewModel {

        [Required]
        [Display(Description = "UserID", Name = "UserID")]
        public string UserID { get; set; }

        [Required]
        [Display(Description = "Password", Name = "Password")]
        public string UserPin { get; set; }

        public bool RememberMe { get; set; }
    }
}