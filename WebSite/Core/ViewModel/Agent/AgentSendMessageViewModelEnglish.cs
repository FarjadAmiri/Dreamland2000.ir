using System.ComponentModel.DataAnnotations;

namespace WebSite.Core.ViewModel.Agent
{
    public class AgentSendMessageViewModelEnglish
    {
        [Display(Name = "Name")]
        [Required(ErrorMessage = "Please enter {0}.")]
        [MaxLength(100, ErrorMessage = "{0} cannot be longer than {1} characters.")]
        public string? Name { get; set; }

        [Display(Name = "Phone")]
        [Required(ErrorMessage = "Please enter {0}.")]
        [MaxLength(100, ErrorMessage = "{0} cannot be longer than {1} characters.")]
        public string? Tell { get; set; }

        [Display(Name = "Email")]
        [MaxLength(100, ErrorMessage = "{0} cannot be longer than {1} characters.")]
        public string? Email { get; set; }

        [Display(Name = "Message")]
        [Required(ErrorMessage = "Please enter {0}.")]
        [MaxLength(100, ErrorMessage = "{0} cannot be longer than {1} characters.")]
        public string? Message { get; set; }

        //relation
        [Display(Name = "Agent")]
        public int? AgentRefId { get; set; }
    }
}
