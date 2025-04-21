using System.ComponentModel.DataAnnotations;
using WebSite.Core.ViewModel.Global;

namespace WebSite.Core.ViewModel.RealEstate
{
    public class AddNewRealEstateCommentViewModelEnglish:GoogleRecaptchaViewModel
    {
        [Display(Name = "Name")]
        [Required(ErrorMessage = "Please enter {0}.")]
        [MaxLength(100, ErrorMessage = "{0} cannot be longer than {1} characters.")]
        public string? Name { get; set; }

        [Display(Name = "Phone")]
        [MaxLength(100, ErrorMessage = "{0} cannot be longer than {1} characters.")]
        public string? Tell { get; set; }

        [Display(Name = "Email")]
        [MaxLength(100, ErrorMessage = "{0} cannot be longer than {1} characters.")]
        public string? Email { get; set; }

        [Display(Name = "Comment")]
        [Required(ErrorMessage = "Please enter {0}.")]
        [MaxLength(5000, ErrorMessage = "{0} cannot be longer than {1} characters.")]
        public string? Comment { get; set; }

        //relation
        [Display(Name = "Property")]
        public int? RealEstateRefId { get; set; }
    }
}
