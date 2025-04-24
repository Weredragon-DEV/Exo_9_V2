using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Exo_9_V2.Data;
using Exo_9_V2.Models;

namespace Exo_9_V2.Pages.Voitures
{
    [Authorize(Roles = "Admin,Utilisateur")]
    public class EditModel : PageModel
    {
        private readonly _AppDBContext _context;

        public EditModel(_AppDBContext context)
        {
            _context = context;
        }

        [BindProperty]
        public Voiture Voiture { get; set; }

        public SelectList ClientsList { get; set; }

        public async Task<IActionResult> OnGetAsync(int id)
        {
            Voiture = await _context.Voitures.FindAsync(id);
            if (Voiture == null)
            {
                return NotFound();
            }

            ClientsList = new SelectList(_context.Clients.ToList(), "Id", "Nom");
            return Page();
        }

        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                ClientsList = new SelectList(_context.Clients.ToList(), "Id", "Nom");
                return Page();
            }

            _context.Attach(Voiture).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!_context.Voitures.Any(e => e.Id == Voiture.Id))
                {
                    return NotFound();
                }
                throw;
            }

            return RedirectToPage("./Index");
        }
    }
}