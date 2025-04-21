using System.ComponentModel.DataAnnotations;

namespace WebSite.Core.ViewModel.Blog
{
    public class AddNewBlogByAdminViewModel
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

        //date
        [Display(Name = "Blog Date")]
        [Required(ErrorMessage = "Please enter {0}.")]
        public DateTime? BlogDate { get; set; }

        //relation 
        [Display(Name = "Group")]
        [Required(ErrorMessage = "Please enter {0}.")]
        [Range(0, int.MaxValue, ErrorMessage = "Please enter {0}.")]
        public int? GroupRefId { get; set; }

        [Display(Name = "Language")]
        public int? LanguageRefId { get; set; }
        [Display(Name = "Language Title")]
        public string? LanguageEnglishTitle { get; set; }

        [Display(Name = "Language Short Title")]
        public string? LanguageShortTitle { get; set; }



    }
}
