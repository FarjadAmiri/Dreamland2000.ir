using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using WebSite.Core.Utility;
using WebSite.DataLayer.Entities.User;

namespace WebSite.DataLayer.Entities.Agent
{
    public class AgentMessage
    {
        [Key]
        [Required()]
        public int Id { get; set; }

        //sender
        [Display(Name = "نام")]
        [MaxLength(100, ErrorMessage = "{0} نمی تواند بیشتر از {1} کاراکتر باشد .")]
        public string? SenderName { get; set; }

        //contact
        [Display(Name = "تلفن")]
        [MaxLength(100, ErrorMessage = "{0} نمی تواند بیشتر از {1} کاراکتر باشد .")]
        public string? SenderTell { get; set; }

        [Display(Name = "ایمیل")]
        [MaxLength(100, ErrorMessage = "{0} نمی تواند بیشتر از {1} کاراکتر باشد .")]
        public string? SenderEmail { get; set; }
      

        [Display(Name = "پیام")]
        [MaxLength(5000, ErrorMessage = "{0} نمی تواند بیشتر از {1} کاراکتر باشد .")]
        public string? Message { get; set; }

        //send date
        [Display(Name = "تاریخ ارسال")]
        public DateTime? SendDate { get; set; } = MyDate.GetCurrentDate();

        //setting
        [Display(Name = "وضعیت آرشیو")]
        public bool? IsArchive { get; set; } = false;

        [Display(Name = "وضعیت پاسخ")]
        public bool? IsAnswer { get; set; } = false;

        //relation
        //agent
        [Display(Name = "کارشناس")]
        public int? AgentRefId { get; set; }

        [ForeignKey("AgentRefId")]
        public virtual Agent? Agent{ get; set; }

        //user
        [Display(Name = "کاربر")]
        public int? UserRefId { get; set; }

        [ForeignKey("UserRefId")]
        public virtual Users? User{ get; set; }
    }
}
