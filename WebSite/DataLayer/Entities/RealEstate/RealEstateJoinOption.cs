using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace WebSite.DataLayer.Entities.RealEstate
{
    public class RealEstateJoinOption
    {
        [Key]
        public int JoinId { get; set; }

        public int? RealEstateRefId { get; set; }

        public int? OptionRefId { get; set; }


       //relation
        [ForeignKey("RealEstateRefId")]
        public virtual RealEstate? RealEstate { get; set; }

        [ForeignKey("OptionRefId")]
        public virtual RealEstateOption? Option { get; set; }
    }
}
