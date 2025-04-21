using System.ComponentModel.DataAnnotations;

namespace WebSite.Core.ViewModel.Global
{
    public class GlobalSearchViewModel
    {
        [Display(Name = "متن جستجو")]
        [Required(ErrorMessage = "لطفا {0} را وارد کنید")]
        public string? SearchText { get; set; }

        [Display(Name = "نوع جستجو")]
        public int? SearchType { get; set; }
    }
}
