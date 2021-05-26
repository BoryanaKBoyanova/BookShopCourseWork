namespace BookShopCourseWork.Models.AuthorController
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;
    using System.ComponentModel.DataAnnotations;

    public class DeleteAuthor
    {
        [Required]
        public int AuthorId {get; set;}
       
    }
}
