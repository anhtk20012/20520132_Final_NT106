using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Server.Models
{
    [Table("GymDetails")]
    public class GymDetails
    {
        [Key]
        public string GymEmailID { get; set; }
        [Required]
        [StringLength(50)]
        public string Password { get; set; }
        [StringLength(50)]
        public string GymName { get; set; }
    }
}
