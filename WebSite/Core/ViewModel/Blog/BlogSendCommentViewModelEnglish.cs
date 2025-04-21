using System.ComponentModel.DataAnnotations;
using WebSite.Core.Utility;
using WebSite.Core.ViewModel.Global;


namespace WebSite.Core.ViewModel.Blog
{
    public class BlogSendCommentViewModelEnglish : GoogleRecaptchaViewModel
    {
        [Display(Name = "Send Date")]
        public DateTime? SendDate { get; set; } = MyDate.GetCurrentDate();

        [Display(Name = "Name")]
        [Required(ErrorMessage = "Please enter {0}.")]
        [MaxLength(100, ErrorMessage = "{0} cannot be longer than {1} characters.")]
        public string? Name { get; set; }

        //sender contact info
        [Display(Name = "Phone")]
        [Required(ErrorMessage = "Please enter {0}.")]
        [MaxLength(100, ErrorMessage = "{0} cannot be longer than {1} characters.")]
        public string? Tell { get; set; }

        [Display(Name = "Email Address")]
        [MaxLength(100, ErrorMessage = "{0} cannot be longer than {1} characters.")]
        public string? Email { get; set; }

        [Display(Name = "Comment")]
        [Required(ErrorMessage = "Please enter {0}.")]
        [MaxLength(2000, ErrorMessage = "{0} cannot be longer than {1} characters.")]
        public string? Comment { get; set; }

        //relation
        [Display(Name = "Blog")]
        public int? BlogRefId{ get; set; }

    }
}
