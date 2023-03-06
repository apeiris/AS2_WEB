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

namespace AS2_WEB.Pages.Partners
{
    public class EditModel : PageModel
    {
        private readonly AS2_WEB.Data.AS2_WEBContext _context;

        public EditModel(AS2_WEB.Data.AS2_WEBContext context)
        {
            _context = context;
        }

        [BindProperty]
        public Partner Partner { get; set; } = default!;

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null || _context.Partner == null)
            {
                return NotFound();
            }

            var partner =  await _context.Partner.FirstOrDefaultAsync(m => m.Partner_ID == id);
            if (partner == null)
            {
                return NotFound();
            }
            Partner = partner;
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

            _context.Attach(Partner).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!PartnerExists(Partner.Partner_ID))
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

        private bool PartnerExists(int id)
        {
          return (_context.Partner?.Any(e => e.Partner_ID == id)).GetValueOrDefault();
        }
    }
}
