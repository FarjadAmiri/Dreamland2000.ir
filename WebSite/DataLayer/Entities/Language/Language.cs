using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using WebSite.DataLayer.Entities.Address;

namespace WebSite.DataLayer.Entities.Language
{
    public class Language
    {
        [Key()]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        [Display(Name = "شناسه")]
        public int Id { get; set; }
        
        [Display(Name = "Title")]
        [Required(ErrorMessage = "لطفا {0} را وارد کنید")]
        [MaxLength(100, ErrorMessage = "حداکثر طول مجاز برای {0} {1} کاراکتر می باشد")]
        public string? Title { get; set; }

        [Display(Name = "En Title")]
        [MaxLength(100, ErrorMessage = "حداکثر طول مجاز برای {0} {1} کاراکتر می باشد")]
        public string? TitleEnglish { get; set; }

        [Display(Name = "Short Title")]
        [MaxLength(100, ErrorMessage = "حداکثر طول مجاز برای {0} {1} کاراکتر می باشد")]
        public string? ShortTitle { get; set; }

        //setting
        [Display(Name = "Sort")]
        public int? Sort { get; set; }

        [Display(Name = "Visible Status")]
        public bool? IsVisible { get; set; }
       
    }
}
