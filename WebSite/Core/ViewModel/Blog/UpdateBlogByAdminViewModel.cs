using System.ComponentModel.DataAnnotations;

namespace WebSite.Core.ViewModel.Blog
{
    public class UpdateBlogByAdminViewModel
    {

        [Display(Name = "Title")]
        [Required(ErrorMessage = "Please enter {0}.")]
        [MaxLength(200, ErrorMessage = "{0} cannot be longer than {1} characters.")]
        public string? Title { get; set; }

        [Display(Name = "Summary")]
        public string? Summary { get; set; }

        [Display(Name = "Content")]
        public string? Content { get; set; }

        [Display(Name = "Author")]
        [MaxLength(200, ErrorMessage = "{0} cannot be longer than {1} characters.")]
        public string? Author { get; set; }

        [Display(Name = "Tags")]
        [Required(ErrorMessage = "Please enter {0}.")]
        [MaxLength(2000, ErrorMessage = "{0} cannot be longer than {1} characters.")]
        public string? Tags { get; set; }

        //gallery
        [Display(Name = "Photo")]
        [MaxLength(100, ErrorMessage = "{0} cannot be longer than {1} characters.")]
        public string? Photo { get; set; } = "default.jpg";


        //blog date
        [Display(Name = "Article Date")]
        [Required(ErrorMessage = "Please enter {0}.")]
        public DateTime? BlogDate { get; set; }


        //relation 
        //blog
        [Display(Name = "Article")]
        public int BlogRefId { get; set; }

        //group
        [Display(Name = "Group")]
        [Required(ErrorMessage = "Please enter {0}.")]
        [Range(1, int.MaxValue, ErrorMessage = "Please enter {0}.")]
        public int? GroupRefId { get; set; }

        //language
        [Display(Name = "Language")]
        public int? LanguageRefId { get; set; }


        [Display(Name = "Language Title")]
        public string? LanguageEnglishTitle { get; set; }

        [Display(Name = "Language Short Title")]
        public string? LanguageShortTitle { get; set; }
    }
}
