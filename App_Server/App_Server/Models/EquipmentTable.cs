using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Server.Models
{
    [Table("EquipmentTable")]
    public class EquipmentTable
    {
        [Key]
        public int EquipmentID { get; set; }
        [Required]
        [StringLength(50)]
        public string EquipmentName { get; set; }
        [StringLength(50)]
        public string EquipmentType { get; set; }
        [StringLength(50)]
        public string EquipmentQuantity { get; set; }
        [StringLength(50)]
        public string EquipmentWeight { get; set; }
        [StringLength(50)]
        public string EquipmentCost { get; set; }
        public DateTime PurchasedDate { get; set; }
    }
}
