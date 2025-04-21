using System.ComponentModel.DataAnnotations;

namespace WebSite.Core.ViewModel.Blog
{
    public class BlogSearchViewModel
    {
        [Display(Name = "متن جستجو")]
        [Required(ErrorMessage = "لطفا {0} را وارد کنید")]
        public string? SearchText { get; set; }

    }
}
