namespace BookShopCourseWork.Models.GenreController
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;
    using System.ComponentModel.DataAnnotations;

    public class UpdateGenreBook
    {
        [Required]
        [Display(Name = "Genre Id")]
        public int GenreId { get; set; }

        [Required]
        [Display(Name = "Book Id")]
        public int BookId { get; set; }

        [Required]
        [Display(Name = "Operation")]
        public string Operation {get; set;}
       
    }
}
