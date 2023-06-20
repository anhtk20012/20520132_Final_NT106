using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Runtime.CompilerServices;

namespace Server.Models
{
    [Table("Accounts")]
    public class Accounts
    {
        [Key]
        public int UserId { get; set; }
        [Required]
        [StringLength(50)]
        public string UserType { get; set; }
        [StringLength(50)] 
        public string UserName { get; set; }
        [StringLength(50)]
        public string UserEmailID { get; set; }
        [StringLength(50)]
        public string UserPassword { get; set; }
    }
}
