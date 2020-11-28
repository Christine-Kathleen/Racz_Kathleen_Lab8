using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Racz_Kathleen_Lab8B.Data;
using Racz_Kathleen_Lab8B.Models;

namespace Racz_Kathleen_Lab8B.Pages.BookCategories
{
    public class EditModel : PageModel
    {
        private readonly Racz_Kathleen_Lab8B.Data.Racz_Kathleen_Lab8BContext _context;

        public EditModel(Racz_Kathleen_Lab8B.Data.Racz_Kathleen_Lab8BContext context)
        {
            _context = context;
        }

        [BindProperty]
        public BookCategory BookCategory { get; set; }

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            BookCategory = await _context.BookCategory
                .Include(b => b.Book)
                .Include(b => b.Category).FirstOrDefaultAsync(m => m.ID == id);

            if (BookCategory == null)
            {
                return NotFound();
            }
           ViewData["BookID"] = new SelectList(_context.Book, "ID", "TitlePlusAuthor");
           ViewData["CategoryID"] = new SelectList(_context.Category, "ID", "CategoryName");
            return Page();
        }

        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://aka.ms/RazorPagesCRUD.
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.Attach(BookCategory).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!BookCategoryExists(BookCategory.ID))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return RedirectToPage("./Index");
        }

        private bool BookCategoryExists(int id)
        {
            return _context.BookCategory.Any(e => e.ID == id);
        }
    }
}
