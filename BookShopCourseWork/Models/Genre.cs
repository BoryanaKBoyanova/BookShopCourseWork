namespace BookShopCourseWork.Models
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;
    using System.ComponentModel.DataAnnotations;

    public class Genre
    {
        public int Id { get; set; }

        [Required]
        public string GenreName { get; set; }

        public ICollection<Book> Books { get; set; }
    }
}
