using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace WebSite.DataLayer.Entities.RealEstate
{
    public class RealEstateRentPeriod
    {
        [Key]
        [Display(Name = "شناسه")]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int Id { get; set; }

        [Display(Name = "بازه اجاره")]
        [Required(ErrorMessage = "لطفا {0} را وارد کنید")]
        [MaxLength(100, ErrorMessage = "حداکثر طول مجاز برای {0} {1} کاراکتر می باشد")]
        public string? Title { get; set; }

        [Display(Name = "ترتیب نمایش")]
        public int? Sort { get; set; }


        [Display(Name = "وضعیت نمایش")]
        public bool? IsVisible { get; set; }

        //relations 
        //language
        [Display(Name = "زبان")]
        public int? LanguageRefId { get; set; }

        [ForeignKey("LanguageRefId")]
        public virtual Language.Language? Language { get; set; }
    }
}
