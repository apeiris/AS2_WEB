using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace AS2_WEB.Models
{
    public class Partnership
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int partnershipID { get; set; }
        public string name { get; set; }
        public string sender { get; set; }
        public string receiver { get; set; }
        public string implementation_flavour { get; set; }
        public bool? pollerConfig { get; set; }
        [Column(TypeName = "datetime")]
        [DatabaseGenerated(DatabaseGeneratedOption.Computed)]
        public DateTime? LastCU_Time { get; set; }
    }
}
