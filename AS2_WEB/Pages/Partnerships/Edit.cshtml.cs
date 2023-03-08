using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using AS2_WEB.Data;
using AS2_WEB.Models;
using Microsoft.Data.SqlClient;
using Microsoft.CodeAnalysis.Elfie.Extensions;

namespace AS2_WEB.Pages.Partnerships
{
    public class EditModel : PageModel
    {
        private readonly AS2_WEB.Data.AS2DBContext _context;
        public EditModel(AS2_WEB.Data.AS2DBContext context)
        {
            _context = context;
        }
        [BindProperty]
        public Partnership Partnership { get; set; } = default!;
        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null || _context.Partnerships == null)
            {
                return NotFound();
            }

            var partnership =  await _context.Partnerships.FirstOrDefaultAsync(m => m.partnershipID == id);
            if (partnership == null)
            {
                return NotFound();
            }
            Partnership = partnership;
            return Page();
        }

        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see https://aka.ms/RazorPagesCRUD.
        /*
        //public async Task<IActionResult> OnPostAsync()
        //{
        //    if (!ModelState.IsValid)
        //    {
        //        return Page();
        //    }

        //    _context.Attach(Partnership).State = EntityState.Modified;

        //    try
        //    {
        //        await _context.SaveChangesAsync();
        //    }
        //    catch (DbUpdateConcurrencyException)
        //    {
        //        if (!PartnershipExists(Partnership.partnershipID))
        //        {
        //            return NotFound();
        //        }
        //        else
        //        {
        //            throw;
        //        }
        //    }

        //    return RedirectToPage("./Index");
        //}
        */

        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            try
            {
                var connection = _context.Database.GetDbConnection();
                await connection.OpenAsync();

                using (var command = connection.CreateCommand())
                {
                    command.CommandText = "PartnershipUpdate";
                    command.CommandType = System.Data.CommandType.StoredProcedure;

                    command.Parameters.Add(new SqlParameter("@partnershipID", System.Data.SqlDbType.Int) { Value = Partnership.partnershipID });
                    command.Parameters.Add(new SqlParameter("@name", System.Data.SqlDbType.VarChar, 50) { Value = Partnership.name });
                    command.Parameters.Add(new SqlParameter("@sender", System.Data.SqlDbType.VarChar, 50) { Value = Partnership.sender });
                    command.Parameters.Add(new SqlParameter("@receiver", System.Data.SqlDbType.VarChar, 50) { Value = Partnership.receiver });
                    command.Parameters.Add(new SqlParameter("@implementation_flavour", System.Data.SqlDbType.VarChar, 50) { Value = Partnership.implementation_flavour });
                    command.Parameters.Add(new SqlParameter("@pollerConfig", System.Data.SqlDbType.Bit) { Value = Partnership.pollerConfig });

                    await command.ExecuteNonQueryAsync();
                }
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!PartnershipExists(Partnership.partnershipID))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return RedirectToPage("/Index",new {Fragment="partnership" });
        }


        private bool PartnershipExists(int id)
        {
          return (_context.Partnerships?.Any(e => e.partnershipID == id)).GetValueOrDefault();
        }
    }
}
