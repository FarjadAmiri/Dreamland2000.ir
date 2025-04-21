using System.ComponentModel.DataAnnotations;
using WebSite.Core.ViewModel.Global;

namespace WebSite.Core.ViewModel.RealEstate
{
    public class AddNewRealEstateCommentViewModel:GoogleRecaptchaViewModel
    {
        [Display(Name = "نام")]
        [Required(ErrorMessage = "لطفا {0} را وارد کنید")]
        [MaxLength(100, ErrorMessage = "{0} نمی تواند بیشتر از {1} کاراکتر باشد .")]
        public string? Name { get; set; }

        [Display(Name = "تلفن")]
        [MaxLength(100, ErrorMessage = "{0} نمی تواند بیشتر از {1} کاراکتر باشد .")]
        public string? Tell { get; set; }

        [Display(Name = "ایمیل")]
        [MaxLength(100, ErrorMessage = "{0} نمی تواند بیشتر از {1} کاراکتر باشد .")]
        public string? Email { get; set; }

        [Display(Name = "دیدگاه")]
        [Required(ErrorMessage = "لطفا {0} خود را بنویسید")]
        [MaxLength(5000, ErrorMessage = "{0} نمی تواند بیشتر از {1} کاراکتر باشد .")]
        public string? Comment { get; set; }

        //relation
        [Display(Name = "ملک")]
        public int? RealEstateRefId { get; set; }
    }
}
