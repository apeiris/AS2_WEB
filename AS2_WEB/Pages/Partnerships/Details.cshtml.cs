using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using AS2_WEB.Data;
using AS2_WEB.Models;

namespace AS2_WEB.Pages.Partnerships
{
    public class DetailsModel : PageModel
    {
        private readonly AS2_WEB.Data.AS2DBContext _context;

        public DetailsModel(AS2_WEB.Data.AS2DBContext context)
        {
            _context = context;
        }

      public Partnership Partnership { get; set; } = default!; 

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null || _context.Partnerships == null)
            {
                return NotFound();
            }

            var partnership = await _context.Partnerships.FirstOrDefaultAsync(m => m.partnershipID == id);
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
