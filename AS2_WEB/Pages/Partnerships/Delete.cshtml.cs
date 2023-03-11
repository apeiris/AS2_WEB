using AS2_WEB.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using SendGrid.Helpers.Mail;
using SendGrid;
using System.Net.Mail;
using System.Net;

namespace AS2_WEB.Pages.Partnerships
{
    public class DeleteModel : PageModel
    {
        private readonly AS2_WEB.Data.AS2DBContext _context;
        private readonly ILogger<DeleteModel> log;
        private readonly IConfiguration _config;

        public DeleteModel(AS2_WEB.Data.AS2DBContext context, ILogger<DeleteModel> logger,IConfiguration config)
        {
            _context = context;
            log = logger;
            _config= config;
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

        //}
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> OnPostAsync(string? action
                                                        , int? id
                                                        , string? name
                                                        , string? sender
                                                        , string? receiver
                                                        , string? implementation_flavour
            )
        {
            if (ModelState.IsValid)// do only if __RequestVerificationToken is present
            {
                var from = new EmailAddress("mapeiris@hotmail.com", "Sender Name");
                var to = new EmailAddress("mapeiris@hotmail.com");
                var msg = MailHelper.CreateSingleEmail(from, to, "testing Sendgrid", "test messagssse", "test message");

                switch (action.ToLower())

                {
                    case "ssendmail": // Send using Twillio SendGrid
                     
                        // TwillioEmailSender twillioEmailSender = new TwillioEmailSender();
                        
                        var apiKey = _config.GetValue<string>("SendGridApiKey");
                        var client = new SendGrid.SendGridClient(apiKey);
                      
                                var response = await client.SendEmailAsync(msg);
                        log.LogTrace($"email sent status={response.Body} Code={response.StatusCode}");
                        return RedirectToPage("/Index");
                        break;
                       // HSendMail
                    case "hsendmail":// send using Hotmail
                                     //  var smtpHost = "smtp.live.com";
                        log.LogTrace("sending email via hotmail");
                        var smtpHost = "localhost";
                        var smtpPort = 465;
                        var smtpUsername = "mapeiris@hotmail.com";
                      //  var smtpPassword ="22051954";

                        using (var hclient = new SmtpClient())
                        {
                            hclient.EnableSsl = true;
                           hclient.UseDefaultCredentials = false;
                            hclient.Host = smtpHost;
                            hclient.Port = smtpPort;
                         //   hclient.Credentials = new NetworkCredential(smtpUsername, smtpPassword);

                             var hfrom = new MailAddress(smtpUsername, "Your Name");
                            var hto = new MailAddress("mapeiris@gmail.com");
                            var hmessage = new MailMessage(hfrom, hto);
                            hmessage.Subject = $"this is test email: {DateTime.Now}";
                            hmessage.Body = "this is a test message";
                           
                             hclient.Send(hmessage);
                            log.LogTrace(hmessage.Subject);
                        }

                        return RedirectToPage("/Index");
                        
                        break;
                    case "delete":
                        log.LogCritical($"doing delete");
                        if (id == null || _context.Partnerships == null)
                        {
                            return NotFound();
                        }
                        var partnership = await _context.Partnerships.FindAsync(id);

                        if (partnership != null)
                        {
                            Partnership = partnership;
                            _context.Partnerships.Remove(Partnership);
                            await _context.SaveChangesAsync();
                            return RedirectToPage("/Index", new { Fragment = "partnership" });
                        }
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
