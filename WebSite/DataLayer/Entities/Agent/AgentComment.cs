using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using WebSite.Core.Utility;
using WebSite.DataLayer.Entities.User;

namespace WebSite.DataLayer.Entities.Agent
{
    public class AgentComment
    {

        [Key]
        [Display(Name = "شناسه")]
        public int Id { get; set; }

        [Display(Name = "نام")]
        [Required(ErrorMessage = "لطفا {0} را وارد کنید")]
        [MaxLength(100, ErrorMessage = "{0} نمی تواند بیشتر از {1} کاراکتر باشد .")]
        public string? Name { get; set; }

        [Display(Name = "تلفن")]
        [MaxLength(100, ErrorMessage = "{0} نمی تواند بیشتر از {1} کاراکتر باشد .")]
        public string? Tell { get; set; }

        [Display(Name = "ایمیل")]
        [MaxLength(100, ErrorMessage = "{0} نمی تواند بیشتر از {1} کاراکتر باشد .")]
        public string? Email { get; set; }

        [Display(Name = "دیدگاه")]
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

        [Display(Name = "کارشناس")]
        public int? AgentRefId { get; set; }

        [ForeignKey("AgentRefId")]
        public virtual Agent? Agent { get; set; }
    }
}
