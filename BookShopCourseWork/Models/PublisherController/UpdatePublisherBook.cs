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
        public int PublisherId { get; set; }

        [Required]
        [Range(1, Int32.MaxValue, ErrorMessage = "Book Id must be bigger than 0!")]
        public int BookId { get; set; }

        [Required]
        public string Operation {get; set;}
       
    }
}
