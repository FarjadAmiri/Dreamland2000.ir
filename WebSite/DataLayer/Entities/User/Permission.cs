using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace WebSite.DataLayer.Entities.User
{
    public class Permission
    {
        [Key()]
        [Display(Name = "شناسه")]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int Id { get; set; }

        [Display(Name = "عنوان")]
        [Required(ErrorMessage = "لطفا {0} را وارد کنید")]
        [MaxLength(100, ErrorMessage = "{0} نمی تواند بیشتر از {1} کاراکتر باشد .")]
        public string? Title { get; set; }

        [Display(Name = "ترتیب نمایش")]
        public int? Sort { get; set; }

        //relations 
        [Display(Name = "Parent")]
        public int? ParentRefId { get; set; }

        [ForeignKey("ParentRefId")]
        public virtual Permission? Parent { get; set; }

        public virtual ICollection<PermissionJoinRole>? RoleList { get; set; }
        
    }
}
