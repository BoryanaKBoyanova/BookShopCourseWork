namespace BookShopCourseWork.Models.AuthorController
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;
    using System.ComponentModel.DataAnnotations;

    public class UpdateAuthorBook
    {
        [Required]
        [Range(1, Int32.MaxValue, ErrorMessage = "Author Id must be bigger than 0!")]
        [Display(Name = "Author Id")]
        public int AuthorId {get; set;}
        [Required]
        [Range(1, Int32.MaxValue, ErrorMessage = "Book Id must be bigger than 0!")]
        [Display(Name = "Book Id")]
        public int BookId {get; set;}

        [Required]
        [Display(Name = "Operation")]
        public string Operation {get; set;}
    }
}