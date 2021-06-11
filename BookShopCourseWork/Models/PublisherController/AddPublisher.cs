namespace BookShopCourseWork.Models.PublisherController
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;
    using System.ComponentModel.DataAnnotations;

    public class AddPublisher
    {
        [Required]
        [Display(Name ="Publisher name")]
        public string PublisherName { get; set; }
       
    }
}