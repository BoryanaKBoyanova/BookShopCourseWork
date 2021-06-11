namespace BookShopCourseWork.Models.PublisherController
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;
    using System.ComponentModel.DataAnnotations;

    public class UpdatePublisherBook
    {
        [Required]
        [Range(1, Int32.MaxValue, ErrorMessage = "Publisher Id must be bigger than 0!")]
        [Display(Name ="Publisher Id")]
        public int PublisherId { get; set; }

        [Required]
        [Range(1, Int32.MaxValue, ErrorMessage = "Book Id must be bigger than 0!")]
        [Display(Name ="Book Id")]
        public int BookId { get; set; }
       
    }
}
