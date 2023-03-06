using AS2_WEB.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Data.SqlClient;

namespace AS2_WEB.Pages
{
    public class IndexModel : PageModel
    {
        public List<Partner> Partners { get; set; }
        public List<Partnership> Partnerships { get; set; }
        public void OnGet()
        {
            using (SqlConnection connection = new SqlConnection("Server=192.168.86.31,1434;Database=AS2;User Id=sa;Password=Ap@22051954;TrustServerCertificate=true;"))
            {
                connection.Open();
                using (SqlCommand command = new SqlCommand("SELECT * FROM Partners", connection))
                {
                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        Partners = new List<Partner>();
                        while (reader.Read())
                        {
                            Partner partner = new Partner();
                            partner.Partner_ID = (int)reader["Partner_ID"];
                            partner.PartnerName = (string)reader["PartnerName"];
                            partner.AS2_ID = (string)reader["AS2_ID"];
                            partner.X509_Alias = (string)reader["X509_Alias"];
                            partner.Email = (string)reader["Email"];
                            partner.LastCU_Time = (DateTime)reader["LastCU_Time"];
                            Partners.Add(partner);
                        }
                    }
                }

                using (SqlCommand command = new SqlCommand("SELECT * FROM Partnerships", connection))
                {
                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        Partnerships = new List<Partnership>();
                        while (reader.Read())
                        {
                            Partnership partnership = new Partnership();
                            partnership.partnershipID = (int)reader["partnershipID"];
                            partnership.name = (string)reader["name"];
                            partnership.sender = (string)reader["sender"];
                            partnership.receiver = (string)reader["receiver"];
                            partnership.implementation_flavour = (string)reader["implementation_flavour"];
                            partnership.pollerConfig = (bool?)reader["pollerConfig"];
                            partnership.LastCU_Time = (DateTime?)reader["LastCU_Time"];
                            Partnerships.Add(partnership);
                        }
                    }
                }
            }
        }
    }
}
