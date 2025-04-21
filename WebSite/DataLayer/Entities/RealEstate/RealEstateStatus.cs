using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace WebSite.DataLayer.Entities.RealEstate
{
    public class RealEstateStatus
    {
        [Key]
        [Display(Name = "Id")]
        public int Id { get; set; }

        [Display(Name = "Status Title")]
        [Required(ErrorMessage = "لطفا {0} را وارد کنید")]
        [MaxLength(100, ErrorMessage = "حداکثر طول مجاز برای {0} {1} کاراکتر می باشد")]
        public string? Title { get; set; }

        [Display(Name = "Type")]
        [MaxLength(100, ErrorMessage = "حداکثر طول مجاز برای {0} {1} کاراکتر می باشد")]
        public string? Type { get; set; }

        [Display(Name = "Sort")]
        public int? Sort { get; set; }

        [Display(Name = "Visible Status")]
        public bool? IsVisible { get; set; }

        //relations 
        //language
        [Display(Name = "Language")]
        public int? LanguageRefId { get; set; }

        [ForeignKey("LanguageRefId")]
        public virtual Language.Language? Language { get; set; }
    }
}
