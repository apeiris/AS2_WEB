using AS2_WEB.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;

namespace AS2_WEB.Pages.Partnerships
{
    public class DeleteModel : PageModel
    {
        private readonly AS2_WEB.Data.AS2DBContext _context;
        private readonly ILogger<DeleteModel> _logger;

        public DeleteModel(AS2_WEB.Data.AS2DBContext context,ILogger<DeleteModel>logger)
        {
            _context = context;
            _logger = logger;
        }

        [BindProperty]
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

        //public async Task<IActionResult> OnPostAsync(int id)
        //{
        //    if (id == null || _context.Partnerships == null)
        //    {
        //        return NotFound();
        //    }
        //    var partnership = await _context.Partnerships.FindAsync(id);

        //    if (partnership != null)
        //    {
        //        Partnership = partnership;
        //        _context.Partnerships.Remove(Partnership);
        //        await _context.SaveChangesAsync();
        //    }
        //    return RedirectToPage("/Index", new { Fragment = "partnership" });
        //}
        [HttpPost]
        [ValidateAntiForgeryToken]
        public  async Task<IActionResult> OnPostAsync(  string? action 
                                                        ,string? id
                                                        ,string? name
                                                        ,string? sender
                                                        ,string? receiver
                                                        ,string? implementation_flavour
            )
        {
            if (ModelState.IsValid)// do only if __RequestVerificationToken is present
            {
                switch (action.ToLower())

                {
                    case "delete_sendmail":
                        _logger.LogInformation("Doin delete_sendmail");
                        break;
                    case "delete":
                        _logger.LogInformation($"doing delet only");
                        break;
                    default:
                        
                        break;
                }
                // do your stuff here
                Console.WriteLine($"AntifogeryToken={Request.Form["__RequestVerificationToken"]}");
                return RedirectToPage("/Index", new { Fragment = "partnership" });
            }
            return Page();
        }
        
        

    }
}
