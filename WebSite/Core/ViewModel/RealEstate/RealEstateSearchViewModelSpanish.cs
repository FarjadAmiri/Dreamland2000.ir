using System.ComponentModel.DataAnnotations;

namespace WebSite.Core.ViewModel.RealEstate
{
    public class RealEstateSearchViewModelSpanish
    {
        [Display(Name = "Buscar texto")]
        [Required(ErrorMessage = "Por favor, introduzca {0}.")]
        [MaxLength(100, ErrorMessage = "{0} no puede tener más de {1} caracteres.")]
        public string? SearchText { get; set; }
    }
}
