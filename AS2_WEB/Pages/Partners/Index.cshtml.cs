﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using AS2_WEB.Data;
using AS2_WEB.Models;

namespace AS2_WEB.Pages.Partners
{
    public class IndexModel : PageModel
    {
        private readonly AS2_WEB.Data.AS2DBContext _context;

        public IndexModel(AS2_WEB.Data.AS2DBContext context)
        {
            _context = context;
        }

        public IList<Partner> Partner { get;set; } = default!;

        public async Task OnGetAsync()
        {
            if (_context.Partners != null)
            {
                Partner = await _context.Partners.ToListAsync();
            }
        }
    }
}
