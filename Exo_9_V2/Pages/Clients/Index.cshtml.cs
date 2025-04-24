using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using Exo_9_V2.Models;
using Exo_9_V2.Data;


namespace Exo_9_V2.Pages.Clients
{
    [Authorize]
    public class IndexModel : PageModel
    {
        private readonly _AppDBContext _context;

        public IndexModel(_AppDBContext context)
        {
            _context = context;
        }

        public IList<Client> Clients { get; set; }

        public async Task OnGetAsync()
        {
            Clients = await _context.Clients.ToListAsync();
        }
    }
}