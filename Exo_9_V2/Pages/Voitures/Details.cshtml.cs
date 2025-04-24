using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using Exo_9_V2.Data;
using Exo_9_V2.Models;

namespace Exo_9_V2.Pages.Voitures
{
    [Authorize]
    public class DetailsModel : PageModel
    {
        private readonly _AppDBContext _context;

        public DetailsModel(_AppDBContext context)
        {
            _context = context;
        }

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
    }
}