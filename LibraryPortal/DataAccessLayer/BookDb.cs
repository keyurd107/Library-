using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer
{
    class BookDb
    {
        public int Id { get; set; }
        [StringLength(255)]
        public string Isbn { get; set; }
        [Required]
        [StringLength(255)]
        public string Title { get; set; }
        [Required]
        [StringLength(255)]
        public string Author { get; set; }
        [Required]
        [DataType(DataType.Date)]
        public DateTime Publish { get; set; }
        [Required]
        public double Price { get; set; }
    }
}
