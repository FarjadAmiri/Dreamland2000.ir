using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using WebSite.Core.Utility;

namespace WebSite.DataLayer.Entities.Blog
{
    public class BlogPhoto
    {
        [Key]
        [Display(Name = "شناسه")]
        public int Id { get; set; }

        [Display(Name = "عنوان")]
        [Required(ErrorMessage = "لطفا {0} را وارد کنید")]
        [MaxLength(100, ErrorMessage = "{0} نمی تواند بیشتر از {1} کاراکتر باشد .")]
        public string? Title { get; set; }

        //gallery 
        [Display(Name = "تصویر")]
        [MaxLength(100, ErrorMessage = "{0} نمی تواند بیشتر از {1} کاراکتر باشد .")]
        public string? Photo { get; set; } = "default.jpg";

        //setting 
        [Display(Name = "تاریخ بارگذاری'")]
        public DateTime? UploadDate { get; set; } = MyDate.GetCurrentDate();

        [Display(Name = "ترتیب نمایش")]
        public int? Sort { get; set; } = 1;

        //relation 
        [Display(Name = "مقاله")]
        public int? BlogRefId { get; set; }

        [ForeignKey("BlogRefId")]
        public virtual Blog? Blog { get; set; }
    }
}
