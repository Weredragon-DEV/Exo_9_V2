using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Exo_9_V2.Data;
using Exo_9_V2.Models;
using Microsoft.EntityFrameworkCore;

namespace Exo_9_V2.Pages.Voitures
{
    [Authorize(Roles = "Admin,Utilisateur")]
    public class DeleteModel : PageModel
    {
        private readonly _AppDBContext _context;

        public DeleteModel(_AppDBContext context)
        {
            _context = context;
        }

        [BindProperty]
        public Voiture Voiture { get; set; }

        public async Task<IActionResult> OnGetAsync(int id)
        {
            Voiture = await _context.Voitures
                .Include(v => v.Client)
                .FirstOrDefaultAsync(m => m.Id == id);

            if (Voiture == null)
            {
                return NotFound();
            }

            return Page();
        }

        public async Task<IActionResult> OnPostAsync()
        {
            if (Voiture != null)
            {
                _context.Voitures.Remove(Voiture);
                await _context.SaveChangesAsync();
            }

            return RedirectToPage("./Index");
        }
    }
}