using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace WebSite.DataLayer.Entities.User
{
    public class UserJoinRole
    {
        [Key]
        public int JoinId { get; set; }

        public int UserRefId { get; set; }

        public int RoleRefId { get; set; }


        //relation
        [ForeignKey("UserRefId")]
        public virtual Users? User { get; set; }

        [ForeignKey("RoleRefId")]
        public virtual Role? Role { get; set; }


    }
}
