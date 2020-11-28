using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Racz_Kathleen_Lab8B.Models
{

        public class Book
        {
            public int ID { get; set; }
        
            [Display(Name="Book Title")]
            public string Title { get; set; }
            public string Author { get; set; }

            public string TitlePlusAuthor { get { return Title + " by " + Author; } }

            [Column(TypeName ="decimal(6,2)")]
            public decimal Price { get; set; }

            [DataType(DataType.Date)]
            public DateTime PublishingDate { get; set; }

            public int PublisherID { get; set; }

            public Publisher publisher { get; set; }

            public ICollection<BookCategory> bookCategories { get; set; }
        }
}
