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
        public int GenreId { get; set; }

        [Required]
        public int BookId { get; set; }
       
    }
}
