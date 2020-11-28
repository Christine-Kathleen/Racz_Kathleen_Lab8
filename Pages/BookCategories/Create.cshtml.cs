using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Racz_Kathleen_Lab8B.Data;
using Racz_Kathleen_Lab8B.Models;

namespace Racz_Kathleen_Lab8B.Pages.BookCategories
{
    public class CreateModel : PageModel
    {
        private readonly Racz_Kathleen_Lab8B.Data.Racz_Kathleen_Lab8BContext _context;

        public CreateModel(Racz_Kathleen_Lab8B.Data.Racz_Kathleen_Lab8BContext context)
        {
            _context = context;
        }

        public IActionResult OnGet()
        {
        ViewData["BookID"] = new SelectList(_context.Book, "ID", "TitlePlusAuthor");
        ViewData["CategoryID"] = new SelectList(_context.Category, "ID", "CategoryName");
            return Page();
        }

        [BindProperty]
        public BookCategory BookCategory { get; set; }

        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://aka.ms/RazorPagesCRUD.
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.BookCategory.Add(BookCategory);
            await _context.SaveChangesAsync();

            return RedirectToPage("./Index");
        }
    }
}
