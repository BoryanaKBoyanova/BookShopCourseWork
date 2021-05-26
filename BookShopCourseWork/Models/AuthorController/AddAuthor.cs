namespace BookShopCourseWork.Models.AuthorController
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;
    using System.ComponentModel.DataAnnotations;

    public class AddAuthor
    {
        [Required]
        public string FirstName {get; set;}
        [Required]
        public string LastName {get; set;}
       
    }
}
