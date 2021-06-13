namespace BookShopCourseWork.Models.GenreController
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;
    using System.ComponentModel.DataAnnotations;

    public class DeleteGenre
    {
        [Required]
        [Display(Name = "Genre Id")]
        public int GenreId { get; set; }
       
    }
}
