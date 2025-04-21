using System.ComponentModel.DataAnnotations;

namespace WebSite.Core.ViewModel.RealEstate
{
    public class RealEstateProjectSearchViewModel
    {
        [Display(Name = "متن جستجو")]
        [Required(ErrorMessage = "لطفا {0} را وارد کنید")]
        public string? SearchText { get; set; }
    }
}
