using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using Racz_Kathleen_Lab8B.Data;
using Racz_Kathleen_Lab8B.Models;

namespace Racz_Kathleen_Lab8B.Pages.Publishers
{
    public class DetailsModel : PageModel
    {
        private readonly Racz_Kathleen_Lab8B.Data.Racz_Kathleen_Lab8BContext _context;

        public DetailsModel(Racz_Kathleen_Lab8B.Data.Racz_Kathleen_Lab8BContext context)
        {
            _context = context;
        }

        public Publisher Publisher { get; set; }

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            Publisher = await _context.Publisher.FirstOrDefaultAsync(m => m.ID == id);

            if (Publisher == null)
            {
                return NotFound();
            }
            return Page();
        }
    }
}
