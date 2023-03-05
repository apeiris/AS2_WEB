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

namespace AS2_WEB.Pages.Partnership
{
    public class EditModel : PageModel
    {
        private readonly AS2_WEB.Data.AS2_WEBContext _context;

        public EditModel(AS2_WEB.Data.AS2_WEBContext context)
        {
            _context = context;
        }

        [BindProperty]
        public Models.Partnership Partnership { get; set; } = default!;

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null || _context.Partnership == null)
            {
                return NotFound();
            }

            var partnership =  await _context.Partnership.FirstOrDefaultAsync(m => m.partnershipID == id);
            if (partnership == null)
            {
                return NotFound();
            }
            Partnership = partnership;
            return Page();
        }

        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see https://aka.ms/RazorPagesCRUD.
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.Attach(Partnership).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
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

            return RedirectToPage("./Index");
        }

        private bool PartnershipExists(int id)
        {
          return (_context.Partnership?.Any(e => e.partnershipID == id)).GetValueOrDefault();
        }
    }
}
