using Microsoft.EntityFrameworkCore.Storage.ValueConversion.Internal;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Threading.Tasks.Dataflow;

namespace Server.Models
{
    [Table("MemberTable")]
    public class MemberTable
    {
        [Key]
        public int memberid { get; set; }
        [Required]
        [StringLength(50)]
        public string membername { get; set; }
        [StringLength(50)]
        public string fathername { get; set; }
        [StringLength(50)]
        public string gender { get; set; }
        public int age { get; set; }
        [StringLength(50)]
        public string phoneNo { get; set; }
        [StringLength(50)]
        public string Emailid { get; set; }
        [StringLength(150)]
        public string Address { get; set; }
        public DateTime joiningDate { get; set; }
        public DateTime renewaldate { get; set; }
        [StringLength(50)]
        public string membershiptype { get; set; }
        public int feepaid { get; set; }
        [StringLength(50)]
        public string timings { get; set; }
        public byte[] photo { get; set; }
    }
}
