using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using Racz_Kathleen_Lab8B.Data;
using Racz_Kathleen_Lab8B.Models;

namespace Racz_Kathleen_Lab8B.Pages.Categories
{
    public class IndexModel : PageModel
    {
        private readonly Racz_Kathleen_Lab8B.Data.Racz_Kathleen_Lab8BContext _context;

        public IndexModel(Racz_Kathleen_Lab8B.Data.Racz_Kathleen_Lab8BContext context)
        {
            _context = context;
        }

        public IList<Category> Category { get;set; }

        public async Task OnGetAsync()
        {
            Category = await _context.Category.ToListAsync();
        }
    }
}
