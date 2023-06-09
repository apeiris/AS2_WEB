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
    public class DetailsModel : PageModel
    {
        private readonly AS2_WEB.Data.AS2DBContext _context;

        public DetailsModel(AS2_WEB.Data.AS2DBContext context)
        {
            _context = context;
        }

      public Partner Partner { get; set; } = default!; 

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null || _context.Partners == null)
            {
                return NotFound();
            }

            var partner = await _context.Partners.FirstOrDefaultAsync(m => m.Partner_ID == id);
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
    }
}
