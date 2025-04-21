using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using WebSite.Core.Utility;
using WebSite.DataLayer.Entities.User;

namespace WebSite.DataLayer.Entities.Blog
{
    public class BlogComment
    {
        [Key]
        [Display(Name = "شناسه")]
        public int Id { get; set; }

        [Display(Name = "نام ارسال کننده")]
        [Required(ErrorMessage = "لطفا {0} را وارد کنید")]
        [MaxLength(100, ErrorMessage = "{0} نمی تواند بیشتر از {1} کاراکتر باشد .")]
        public string? Name { get; set; }

        [Display(Name = "تلفن تماس")]
        [MaxLength(100, ErrorMessage = "{0} نمی تواند بیشتر از {1} کاراکتر باشد .")]
        public string? Tell { get; set; }

        [Display(Name = "آدرس ایمیل")]
        [MaxLength(100, ErrorMessage = "{0} نمی تواند بیشتر از {1} کاراکتر باشد .")]
        public string? Email { get; set; }

        [Display(Name = "متن دیدگاه")]
        [Required(ErrorMessage = "لطفا {0} را وارد کنید")]
        [MaxLength(2000, ErrorMessage = "{0} نمی تواند بیشتر از {1} کاراکتر باشد .")]
        public string? Comment { get; set; }

        //date
        [Display(Name = "تاریخ ارسال")] 
        public DateTime? SendDate { get; set; } = MyDate.GetCurrentDate();

        //setting
        [Display(Name = "وضعیت تایید")] 
        public bool? IsAccept { get; set; } = false;


        //relation 
        [Display(Name = "کاربر")]
        public int? UserRefId { get; set; }

        [ForeignKey("UserRefId")]
        public virtual Users? User { get; set; }

        [Display(Name = "مقاله")]
        public int? BlogRefId { get; set; }

        [ForeignKey("BlogRefId")]
        public virtual Blog? Blog { get; set; }
        
    }
}
