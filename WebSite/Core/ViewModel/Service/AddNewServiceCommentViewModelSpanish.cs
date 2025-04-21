using System.ComponentModel.DataAnnotations;
using WebSite.Core.Utility;
using WebSite.Core.ViewModel.Global;

namespace WebSite.Core.ViewModel.Service
{
    public class AddNewServiceCommentViewModelSpanish:GoogleRecaptchaViewModel
    {
        [Display(Name = "Fecha de envío")]
        public DateTime? SendDate { get; set; } = MyDate.GetCurrentDate();

        [Display(Name = "Nombre")]
        [Required(ErrorMessage = "Por favor, introduzca {0}.")]
        [MaxLength(100, ErrorMessage = "{0} no puede tener más de {1} caracteres.")]
        public string? Name { get; set; }

        //sender contact info
        [Display(Name = "Número de teléfono")]
        [Required(ErrorMessage = "Por favor, introduzca {0}.")]
        [MaxLength(100, ErrorMessage = "{0} no puede tener más de {1} caracteres.")]
        public string? Tell { get; set; }

        [Display(Name = "Correo electrónico")]
        [MaxLength(100, ErrorMessage = "{0} no puede tener más de {1} caracteres.")]
        public string? Email { get; set; }

        [Display(Name = "Comentario")]
        [Required(ErrorMessage = "Por favor, introduzca {0}.")]
        [MaxLength(2000, ErrorMessage = "{0} no puede tener más de {1} caracteres.")]
        public string? Comment { get; set; }

        //relation
        [Display(Name = "Service")]
        public int? ServiceRefId { get; set; }
    }
}
