using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Exo_9_V2.Models;
using Exo_9_V2.Data;


namespace Exo_9_V2.Pages.Clients
{
    [Authorize(Roles = "Admin")]
    public class CreateModel : PageModel
    {
        private readonly _AppDBContext _context;

        public CreateModel(_AppDBContext context)
        {
            _context = context;
        }

        [BindProperty]
        public Client Client { get; set; }

        public IActionResult OnGet()
        {
            return Page();
        }

        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.Clients.Add(Client);
            await _context.SaveChangesAsync();
            return RedirectToPage("./Index");
        }
    }
}