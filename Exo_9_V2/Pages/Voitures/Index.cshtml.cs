using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using Exo_9_V2.Data;
using Exo_9_V2.Models;

namespace Exo_9_V2.Pages.Voitures
{
    [Authorize]
    public class IndexModel : PageModel
    {
        private readonly _AppDBContext _context;

        public IndexModel(_AppDBContext context)
        {
            _context = context;
        }

        public IList<Voiture> Voitures { get; set; }

        public async Task OnGetAsync()
        {
            Voitures = await _context.Voitures
                .Include(v => v.Client)
                .ToListAsync();
        }
    }
}