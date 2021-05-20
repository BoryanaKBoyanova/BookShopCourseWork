namespace BookShopCourseWork.Models.BookController
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;
    using System.ComponentModel.DataAnnotations;

    public class GenreGetBooks
    {
        [Required]
        public string GenreName { get; set; }
    }
}
