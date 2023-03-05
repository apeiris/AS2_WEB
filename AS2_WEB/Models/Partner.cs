using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace AS2_WEB.Models
{
    public class Partner
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Partner_ID { get; set; }
        public string PartnerName { get; set; }
        public string AS2_ID { get; set; }
        public string X509_Alias { get; set; }
        public string Email { get; set; }
        [Column(TypeName = "datetime")]
        [DatabaseGenerated(DatabaseGeneratedOption.Computed)]
        public DateTime LastCU_Time { get; set; }
    }
}
