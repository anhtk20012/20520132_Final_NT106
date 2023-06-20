using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Server.Models
{
    [Table("StaffTable")]
    public class StaffTable
    {
        [Key]
        public int staffid { get; set; }
        [Required]
        [StringLength(50)]
        public string staffname { get; set; }
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
        [StringLength(50)]
        public string staffdesignation { get; set; }
        public int salary { get; set; }
        [StringLength(50)]
        public string shifttime { get; set; }
        [StringLength(50)]
        public string IDtype { get; set; }
        [StringLength(50)]
        public string IDProof { get; set; }
        public byte[] photo { get; set; }
    }
}
