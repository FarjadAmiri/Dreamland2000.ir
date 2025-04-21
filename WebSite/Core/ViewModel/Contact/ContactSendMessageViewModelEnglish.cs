using System.ComponentModel.DataAnnotations;
using WebSite.Core.Utility;
using WebSite.Core.ViewModel.Global;

namespace WebSite.Core.ViewModel.Contact
{
    public class ContactSendMessageViewModelEnglish:GoogleRecaptchaViewModel
    {
        [Display(Name = "Send Date")]
        public DateTime? SendDate { get; set; } = MyDate.GetCurrentDate();

        [Display(Name = "Name")]
        [Required(ErrorMessage = "Please enter {0}.")]
        [MaxLength(100, ErrorMessage = "{0} cannot be longer than {1} characters.")]
        public string? Name { get; set; }

        //sender contact info
        [Display(Name = "Phone Number")]
        [Required(ErrorMessage = "Please enter {0}.")]
        [MaxLength(100, ErrorMessage = "{0} cannot be longer than {1} characters.")]
        public string? Tell { get; set; }

        [Display(Name = "Email")]        
        [MaxLength(100, ErrorMessage = "{0} cannot be longer than {1} characters.")]
        public string? Email { get; set; }

        //subject and message
        [Display(Name = "Subject")]
        [Required(ErrorMessage = "Please enter {0}.")]
        [MaxLength(200, ErrorMessage = "{0} cannot be longer than {1} characters.")]
        public string? Subject { get; set; }

        [Display(Name = "Message")]
        [Required(ErrorMessage = "Please enter {0}.")]
        [MaxLength(5000, ErrorMessage = "{0} cannot be longer than {1} characters.")]
        public string? Message { get; set; }
    }
}
