namespace BookShopCourseWork.Models.BookController
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;
    using System.ComponentModel.DataAnnotations;

    public class DeleteBook
    {
        [Required]
        public int BookId { get; set; }
       
    }
}
