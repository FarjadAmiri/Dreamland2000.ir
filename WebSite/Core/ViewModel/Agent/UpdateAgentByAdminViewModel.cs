using System.ComponentModel.DataAnnotations;

namespace WebSite.Core.ViewModel.Agent
{
    public class UpdateAgentByAdminViewModel
    {
        [Display(Name = "Id")]
        public int? AgentRefId { get; set; }

        [Display(Name = "Name")]
        [Required(ErrorMessage = "Please enter {0}.")]
        [MaxLength(100, ErrorMessage = "{0} cannot be longer than {1} characters.")]
        public string? Name { get; set; }

        [Display(Name = "Responsibility")]
        [MaxLength(100, ErrorMessage = "{0} cannot be longer than {1} characters.")]
        public string? Responsibility { get; set; }

        [Display(Name = "Biography")]
        public string? Summary { get; set; }

        //gallery
        [Display(Name = "Photo")]
        [MaxLength(100, ErrorMessage = "{0} cannot be longer than {1} characters.")]
        public string? Photo { get; set; }
        //contact
        [Display(Name = "Phone")]
        [MaxLength(100, ErrorMessage = "{0} cannot be longer than {1} characters.")]
        public string? Tell { get; set; }

        [Display(Name = "Email")]
        [MaxLength(100, ErrorMessage = "{0} cannot be longer than {1} characters.")]
        public string? Email { get; set; }

        [Display(Name = "Address")]
        [MaxLength(500, ErrorMessage = "{0} cannot be longer than {1} characters.")]
        public string? Address { get; set; }

        //setting
        [Display(Name = "Sort")]
        public int? Sort { get; set; }

        //relation
        [Display(Name = "Language")]
        public int? LanguageRefId { get; set; }

        [Display(Name = "Language Title")]
        public string? LanguageEnglishTitle { get; set; }

        [Display(Name = "Language Short Title")]
        public string? LanguageShortTitle { get; set; }
    }
}
