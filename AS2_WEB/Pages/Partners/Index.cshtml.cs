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
    public class IndexModel : PageModel
    {
        private readonly AS2_WEB.Data.AS2_WEBContext _context;

        public IndexModel(AS2_WEB.Data.AS2_WEBContext context)
        {
            _context = context;
        }

        public IList<Models.Partner> Partner { get;set; } = default!;
        public List<Models.Partnership> Partnerships { get; set; }

public async Task<IActionResult> OnGetAsync()
{
            Partnerships = await _context.Partnership.ToListAsync();
            ViewData["Tab"]= "Partners";
    return Page();
}


       
    }
}
