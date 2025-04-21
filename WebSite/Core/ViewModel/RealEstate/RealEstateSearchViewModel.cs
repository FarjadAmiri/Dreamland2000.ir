using System.ComponentModel.DataAnnotations;

namespace WebSite.Core.ViewModel.RealEstate
{
    public class RealEstateSearchViewModel
    {
        [Display(Name = "متن جستجو")]
        [Required(ErrorMessage = "لطفا {0} را وارد کنید")]
        public string? SearchText { get; set; }

      
    }
}
