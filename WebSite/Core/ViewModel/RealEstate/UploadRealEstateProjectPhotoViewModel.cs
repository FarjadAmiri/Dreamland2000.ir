using System.ComponentModel.DataAnnotations;

namespace WebSite.Core.ViewModel.RealEstate
{
    public class UploadRealEstateProjectPhotoViewModel
    {
        [Display(Name = "Title")]
        [Required(ErrorMessage = "Please enter {0}.")]
        [MaxLength(500, ErrorMessage = "{0} cannot be longer than {1} characters.")]
        public string? Title { get; set; }

        //relation 
        [Display(Name = "Project")]
        public int? ProjectRefId { get; set; }
    }
}
