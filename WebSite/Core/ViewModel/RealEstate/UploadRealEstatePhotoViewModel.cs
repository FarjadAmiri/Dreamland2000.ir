using System.ComponentModel.DataAnnotations;

namespace WebSite.Core.ViewModel.RealEstate
{
    public class UploadRealEstatePhotoViewModel
    {
        [Display(Name = "Title")]
        [Required(ErrorMessage = "Please enter {0}.")]
        [MaxLength(500, ErrorMessage = "{0} cannot be longer than {1} characters.")]
        public string? Title { get; set; }

        //relation 
        [Display(Name = "Property")]
        public int? RealEstateRefId { get; set; }
    }
}
