using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace WebSite.DataLayer.Entities.User
{
    public class PermissionJoinRole
    {
        [Key()]
        [Display(Name = "شناسه")]
        public int JoinId { get; set; }

        [Display(Name = "مجوز")]
        public int? PermissionRefId { get; set; }

        [Display(Name = "نقش")]
        public int? RoleRefId { get; set; }

        //relation
        [ForeignKey("PermissionRefId")]
        public virtual Permission? Permission { get; set; }

        [ForeignKey("RoleRefId")]
        public virtual Role? Role { get; set; }
        

    }
}
