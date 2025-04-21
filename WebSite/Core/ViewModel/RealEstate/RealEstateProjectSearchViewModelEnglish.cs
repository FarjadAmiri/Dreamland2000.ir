using System.ComponentModel.DataAnnotations;

namespace WebSite.Core.ViewModel.RealEstate
{
    public class RealEstateProjectSearchViewModelEnglish
    {
        [Display(Name = "Search Text")]
        [Required(ErrorMessage = "Please enter {0}.")]
        [MaxLength(100, ErrorMessage = "{0} cannot be longer than {1} characters.")]
        public string? SearchText { get; set; }
    }
}
