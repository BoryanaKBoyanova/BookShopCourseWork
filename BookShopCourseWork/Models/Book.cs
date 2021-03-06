namespace BookShopCourseWork.Models
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;
    using System.ComponentModel.DataAnnotations;

    public class Book
    {
        public int Id { get; set; }

        [Required]
        public string Title { get; set; }

        [Required]
        public string Description { get; set; }

        [Required]
        public double Price { get; set; }

        [Required]
        [Range(1, 2000)]
        public int Pages { get; set; }

        [Required]
        public string ImgUrl { get; set; }

        [Required]
        public DateTime PublishedOn { get; set; }

        public int PublisherId { get; set; }
        
        public Publisher Publisher { get; set; }
        public ICollection<Author> Authors { get; set; }

        public ICollection<Order> Orders { get; set; }

        public ICollection<Genre> Genres { get; set; }
    }
}
