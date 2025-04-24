using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Exo_9_V2.Data;
using Exo_9_V2.Models;

namespace Exo_9_V2.Pages.Voitures
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
        public Voiture Voiture { get; set; }

        public SelectList ClientsList { get; set; }

        public void OnGet()
        {
            ClientsList = new SelectList(_context.Clients.ToList(), "Id", "Nom");
        }

        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                ClientsList = new SelectList(_context.Clients.ToList(), "Id", "Nom");
                return Page();
            }

            _context.Voitures.Add(Voiture);
            await _context.SaveChangesAsync();
            return RedirectToPage("./Index");
        }
    }
}