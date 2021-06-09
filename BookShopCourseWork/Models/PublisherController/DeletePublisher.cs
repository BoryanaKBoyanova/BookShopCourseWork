namespace BookShopCourseWork.Models.PublisherController
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;
    using System.ComponentModel.DataAnnotations;

    public class DeletePublisher
    {
        [Required]
        public int PublisherId { get; set; }
       
    }
}