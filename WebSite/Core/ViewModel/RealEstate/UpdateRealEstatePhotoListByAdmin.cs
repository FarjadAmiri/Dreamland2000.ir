using System.ComponentModel.DataAnnotations;

namespace WebSite.Core.ViewModel.RealEstate
{
    public class UpdateRealEstatePhotoListByAdmin
    {
        [Display(Name = "Title")]
        [Required(ErrorMessage = "Please enter {0}.")]
        [MaxLength(100, ErrorMessage = "{0} cannot be longer than {1} characters.")]
        public string? Title { get; set; }

        [Display(Name = "Photo")]
        [Required(ErrorMessage = "Please enter {0}.")]
        [MaxLength(100, ErrorMessage = "{0} cannot be longer than {1} characters.")]
        public string? Photo { get; set; }

        [Display(Name = "Sort")]
        [Required(ErrorMessage = "Please enter {0}.")]
        public int? Sort { get; set; }
       
        [Display(Name = "Check")]
        public bool CheckStatus { get; set; }

        //relation
        [Display(Name = "Photo")]
        public int? PhotoRefId { get; set; }
    }
}
