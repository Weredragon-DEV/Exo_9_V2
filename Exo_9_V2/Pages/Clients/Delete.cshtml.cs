﻿using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Exo_9_V2.Models;
using Exo_9_V2.Data;


namespace Exo_9_V2.Pages.Clients
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
        public Client Client { get; set; }

        public async Task<IActionResult> OnGetAsync(int id)
        {
            Client = await _context.Clients.FindAsync(id);

            if (Client == null)
            {
                return NotFound();
            }

            return Page();
        }

        public async Task<IActionResult> OnPostAsync()
        {
            if (Client != null)
            {
                _context.Clients.Remove(Client);
                await _context.SaveChangesAsync();
            }

            return RedirectToPage("./Index");
        }
    }
}