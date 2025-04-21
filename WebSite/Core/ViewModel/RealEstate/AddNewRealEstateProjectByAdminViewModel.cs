using System.ComponentModel.DataAnnotations;
using WebSite.DataLayer.Entities.Language;

namespace WebSite.Core.ViewModel.RealEstate
{
    public class AddNewRealEstateProjectByAdminViewModel
    {
        [Display(Name = "Title")]
        [Required(ErrorMessage = "Please enter {0}.")]
        [MaxLength(500, ErrorMessage = "{0} cannot be longer than {1} characters.")]
        public string? Title { get; set; }

        [Display(Name = "Short Title")]
        [Required(ErrorMessage = "Please enter {0}.")]
        [MaxLength(500, ErrorMessage = "{0} cannot be longer than {1} characters.")]
        public string? ShortTitle { get; set; }

        [Display(Name = "Code")]
        [MaxLength(500, ErrorMessage = "{0} cannot be longer than {1} characters.")]
        public string? Code { get; set; }

        [Display(Name = "Tags")]
        [MaxLength(2000, ErrorMessage = "{0} cannot be longer than {1} characters.")]
        public string? Tags { get; set; }

        [Display(Name = "Description")]
        public string? Summary { get; set; }

        //price
        [Display(Name = "Price")]
        [Required(ErrorMessage = "Please enter {0}.")]
        [MaxLength(100, ErrorMessage = "{0} cannot be longer than {1} characters.")]
        public string? Price { get; set; }

        //option
        [Display(Name = "Area")]
        [Required(ErrorMessage = "Please enter {0}.")]
        [MaxLength(100, ErrorMessage = "{0} cannot be longer than {1} characters.")]
        public string? Area { get; set; }

        [Display(Name = "Room")]
        [Required(ErrorMessage = "Please enter {0}.")]
        [MaxLength(100, ErrorMessage = "{0} cannot be longer than {1} characters.")]
        public string? Room{ get; set; }

        [Display(Name = "Bathroom")]
        [Required(ErrorMessage = "Please enter {0}.")]
        [MaxLength(100, ErrorMessage = "{0} cannot be longer than {1} characters.")]
        public string? Bathroom { get; set; }

        //location
        [Display(Name = "Location")]
        [MaxLength(500, ErrorMessage = "{0} cannot be longer than {1} characters.")]
        public string? Location { get; set; }

        [Display(Name = "Iframe")]
        [MaxLength(2000, ErrorMessage = "{0} cannot be longer than {1} characters.")]
        public string? Iframe { get; set; }

        //relation 

        //city
        [Display(Name = "City")]
        [Required(ErrorMessage = "Please enter {0}.")]
        [Range(1, int.MaxValue, ErrorMessage = "Please select {0}.")]
        public int? CityRefId { get; set; }

        //status
        [Display(Name = "Status")]
        [Required(ErrorMessage = "Please enter {0}.")]
        [Range(1, int.MaxValue, ErrorMessage = "Please select {0}.")]
        public int? StatusRefId { get; set; }

        //agent
        [Display(Name = "Agent")]
        public int? AgentRefId { get; set; }

        [Display(Name = "Language")]
        public int? LanguageRefId { get; set; }

        [Display(Name = "Language")]
        public string? LanguageShortTitle { get; set; }

        [Display(Name = "Language")]
        public string? LanguageEnglishTitle { get; set; }


    }
}
