using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Mvc.Rendering;
using AS2_WEB.Data;
using AS2_WEB.Models;
using Microsoft.Data.SqlClient;
using Microsoft.Extensions.Configuration;
using System.Configuration;

namespace AS2_WEB.Pages.Partnerships
{
    public class CreateModel : PageModel
    {
        private readonly AS2_WEB.Data.AS2DBContext _context;
        private readonly IConfiguration _config;
        public CreateModel(AS2_WEB.Data.AS2DBContext context)
        {
            _context = context;
        }

        public List<string> partnerNames { get; set; }
        public List<SelectListItem> ImplementationFlavours { get; set; }
        public async Task<IActionResult> OnGetAsync()
        {
            var connection = new SqlConnection(_context.Database.GetConnectionString());
            var flavours = new List<SelectListItem>();
            try
            {
                await connection.OpenAsync();
                var command = new SqlCommand("select * from dbo.ftImplementationFlavours()", connection);
                var reader = await command.ExecuteReaderAsync();
                while (await reader.ReadAsync())
                {
                    var key = reader.GetString(0);
                    var title = reader.GetString(1);
                    flavours.Add(new SelectListItem { Value = key, Text = title });
                }
                reader.Close();
            }
            finally
            {
                await connection.CloseAsync();
            }
            ImplementationFlavours = flavours;



            partnerNames = await _context.Partners.Select(n => n.PartnerName).ToListAsync();
            /// <summary>
            /// This is an action method in an ASP.NET Core MVC controller.
            /// It is called when an HTTP GET request is made to the controller. 
            /// It is responsible for returning an IActionResult, 
            /// which is an object that represents the result of an action method.
            /// This result can be a view, a redirect, a file, or a JSON object.
            /// </summary>
            /// <returns></returns>
            return Page();
        }

        [BindProperty]
        public Partnership Partnership { get; set; } = default!;
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid) return Page();
            if (_context.Partnerships == null || Partnership == null) return Page();
            _context.Partnerships.Add(Partnership);
            await _context.SaveChangesAsync();
            return RedirectToPage("/Index");
        }
    }
}
