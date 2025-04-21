using System.ComponentModel.DataAnnotations;

namespace WebSite.Core.ViewModel.Blog
{
    public class AddNewBlogByAdminViewModelEnglish
    {

        [Display(Name = "Title")]
        [Required(ErrorMessage = "Please enter {0}.")]
        [MaxLength(500, ErrorMessage = "{0} cannot be longer than {1} characters.")]
        public string? Title { get; set; }

        [Display(Name = "Summary")]
        public string? Summary { get; set; }

        [Display(Name = "Full Content")]
        public string? Content { get; set; }

        [Display(Name = "Tags")]
        [Required(ErrorMessage = "Please enter {0}.")]
        [MaxLength(500, ErrorMessage = "{0} cannot be longer than {1} characters.")]
        public string? Tags { get; set; }

        [Display(Name = "Author")]
        [MaxLength(100, ErrorMessage = "{0} cannot be longer than {1} characters.")]
        public string? Author { get; set; }
        
        [Display(Name = "Article Date")]
        [Required(ErrorMessage = "Please enter {0}.")]
        public DateTime? BlogDate { get; set; }
        
        //relation 
        [Display(Name = "Group")]
        [Required(ErrorMessage = "Please enter {0}.")]
        [Range(0,int.MaxValue,ErrorMessage = "Please enter {0}.")]
        public int? GroupRefId { get; set; }
    }
}
