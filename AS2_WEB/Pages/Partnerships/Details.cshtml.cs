using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using AS2_WEB.Data;
using AS2_WEB.Models;

namespace AS2_WEB.Pages.Partnership
{
    public class DetailsModel : PageModel
    {
        private readonly AS2_WEB.Data.AS2_WEBContext _context;

        public DetailsModel(AS2_WEB.Data.AS2_WEBContext context)
        {
            _context = context;
        }

      public Models.Partnership Partnership { get; set; } = default!; 

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null || _context.Partnership == null)
            {
                return NotFound();
            }

            var partnership = await _context.Partnership.FirstOrDefaultAsync(m => m.partnershipID == id);
            if (partnership == null)
            {
                return NotFound();
            }
            else 
            {
                Partnership = partnership;
            }
            return Page();
        }
    }
}
