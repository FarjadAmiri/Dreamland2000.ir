using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace WebSite.DataLayer.Entities.Address
{
    public class Province
    {
        [Key]
        [Display(Name = "شناسه")]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int Id { get; set; }

        [Display(Name = "نام استان")]
        [Required(ErrorMessage = "لطفا {0} را وارد کنید")]
        [MaxLength(100, ErrorMessage = "حداکثر طول مجاز برای {0} {1} کاراکتر می باشد")]
        public string? Title { get; set; }

        //setting
        [Display(Name = "ترتیب نمایش")]
        [Required(ErrorMessage = "لطفا {0} را وارد کنید")]
        public int? Sort { get; set; }

        [Display(Name = "وضعیت نمایش")]
        public bool? IsVisible { get; set; }
       
      
        //language
        [Display(Name = "زبان")]
        public int? LanguageRefId { get; set; }

        [ForeignKey("LanguageRefId")]
        public virtual Language.Language? Language { get; set; }

        public virtual ICollection<City>? CityList { get; set; }

        

    }
}
