using System.ComponentModel.DataAnnotations;

namespace WebSite.Core.ViewModel.Agent
{
    public class AgentSendMessageViewModelSpanish
    {
        [Display(Name = "Nombre")]
        [Required(ErrorMessage = "Por favor, introduzca {0}.")]
        [MaxLength(100, ErrorMessage = "{0} no puede tener más de {1} caracteres.")]
        public string? Name { get; set; }

        [Display(Name = "Número de teléfono")]
        [Required(ErrorMessage = "Por favor, introduzca {0}.")]
        [MaxLength(100, ErrorMessage = "{0} no puede tener más de {1} caracteres.")]
        public string? Tell { get; set; }

        [Display(Name = "Correo electrónico")]
        [MaxLength(100, ErrorMessage = "{0} no puede tener más de {1} caracteres.")]
        public string? Email { get; set; }

        [Display(Name = "Mensaje")]
        [Required(ErrorMessage = "Por favor, introduzca {0}.")]
        [MaxLength(100, ErrorMessage = "{0} no puede tener más de {1} caracteres.")]
        public string? Message { get; set; }

        //relation
        [Display(Name = "Agente")]
        public int? AgentRefId { get; set; }
    }
}
