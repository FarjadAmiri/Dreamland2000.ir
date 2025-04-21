using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace WebSite.DataLayer.Entities.User
{
   public class Role
    {
        [Key()]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int Id { get; set; }

        [Display(Name = "عنوان")]
        [Required(ErrorMessage = "لطفا {0} را وارد کنید")]
        [MaxLength(100, ErrorMessage = "{0} نمی تواند بیشتر از {1} کاراکتر باشد .")]
        public string? Title { get; set; }

        [Display(Name = "ترتیب نمایش")]
        public int? Sort { get; set; }

       //relations 
        public virtual ICollection<UserJoinRole>? UserList { get; set; }
        public virtual ICollection<PermissionJoinRole>? PermissionList { get; set; }
        
    }
}
