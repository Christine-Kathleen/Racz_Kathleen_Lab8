using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Racz_Kathleen_Lab8B.Models;

namespace Racz_Kathleen_Lab8B.Data
{
    public class Racz_Kathleen_Lab8BContext : DbContext
    {
        public Racz_Kathleen_Lab8BContext (DbContextOptions<Racz_Kathleen_Lab8BContext> options)
            : base(options)
        {
        }

        public DbSet<Racz_Kathleen_Lab8B.Models.Book> Book { get; set; }

        public DbSet<Racz_Kathleen_Lab8B.Models.Publisher> Publisher { get; set; }

        public DbSet<Racz_Kathleen_Lab8B.Models.Category> Category { get; set; }

        public DbSet<Racz_Kathleen_Lab8B.Models.BookCategory> BookCategory { get; set; }
    }
}
