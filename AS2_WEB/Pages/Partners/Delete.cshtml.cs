using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using AS2_WEB.Data;
using AS2_WEB.Models;

namespace AS2_WEB.Pages.Partner
{
    public class DeleteModel : PageModel
    {
        private readonly AS2_WEB.Data.AS2_WEBContext _context;

        public DeleteModel(AS2_WEB.Data.AS2_WEBContext context)
        {
            _context = context;
        }

        [BindProperty]
      public Models.Partner Partner { get; set; } = default!;

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null || _context.Partner == null)
            {
                return NotFound();
            }

            var partner = await _context.Partner.FirstOrDefaultAsync(m => m.Partner_ID == id);

            if (partner == null)
            {
                return NotFound();
            }
            else 
            {
                Partner = partner;
            }
            return Page();
        }

        public async Task<IActionResult> OnPostAsync(int? id)
        {
            if (id == null || _context.Partner == null)
            {
                return NotFound();
            }
            var partner = await _context.Partner.FindAsync(id);

            if (partner != null)
            {
                Partner = partner;
                _context.Partner.Remove(Partner);
                await _context.SaveChangesAsync();
            }

            return RedirectToPage("./Index");
        }
    }
}
