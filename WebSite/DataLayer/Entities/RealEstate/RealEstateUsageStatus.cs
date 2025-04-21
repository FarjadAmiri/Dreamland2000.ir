using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace WebSite.DataLayer.Entities.RealEstate
{
    public class RealEstateUsageStatus
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        [Display(Name = "Id")]
        public int Id { get; set; }

        [Display(Name = "Title")]
        [Required(ErrorMessage = "Please enter {0}.")]
        [MaxLength(100, ErrorMessage = "{0} cannot be longer than {1} characters.")]
        public string? Title { get; set; }

        //gallery
        [Display(Name = "Photo")]
        [MaxLength(100, ErrorMessage = "{0} cannot be longer than {1} characters.")]
        public string? Photo { get; set; }
      

        //setting   
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
