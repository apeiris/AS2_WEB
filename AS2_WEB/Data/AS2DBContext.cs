using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using AS2_WEB.Models;
using Microsoft.Data.SqlClient;
using System.Data;
using Microsoft.Extensions.Configuration;

namespace AS2_WEB.Data
{
    public class AS2DBContext : DbContext
    {
        private IConfiguration _config;
        public DbSet<Partner> Partners { get; set; } 
        public AS2DBContext(DbContextOptions<AS2DBContext> options) : base(options)
        {
        }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {

                // optionsBuilder.UseSqlServer("Server=192.168.86.31,1434;Database=AS2;User Id=sa;Password=Ap@22051954;TrustServerCertificate=true;");
                optionsBuilder.UseSqlServer(_config.GetConnectionString("AS2_WEBContext"));
            }
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
          modelBuilder.Entity<Partner>().Property(c => c.Partner_ID).HasColumnName("Partner_ID");
          modelBuilder.Entity<Partner>().Property(c => c.PartnerName).HasColumnName("PartnerName");
        }
        /// <summary>
        /// The Sortby column accepts _ delimited suffix to indicate the sort order
        /// i.e PartnerName_ASC or PartnerName_DESC 
        /// </summary>
        /// <param name="sortByColumn"></param>
        /// <returns></returns>
        public List<Partner> GetPartners(string sortByColumn)
        {
            var partners = new List<Partner>();
            using (var connection = new SqlConnection(_config.GetConnectionString("AS2_WEBContext")))
            {
                connection.Open();
                using (var command = new SqlCommand("dbo.GetPartners", connection))
                {
                    command.CommandType = CommandType.StoredProcedure;
                    command.Parameters.AddWithValue("@sortBy", "Partner_Id");

                    using (var reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            var partner = new Partner
                            {
                                Partner_ID = reader.GetInt32(0),
                                PartnerName = reader.GetString(1),
                                AS2_ID = reader.GetString(2),
                                X509_Alias = reader.GetString(3),
                                Email = reader.GetString(4),
                                LastCU_Time = reader.GetDateTime(5)
                            };
                            partners.Add(partner);
                        }
                    }
                }
            }
            return partners;
        }
    }
}