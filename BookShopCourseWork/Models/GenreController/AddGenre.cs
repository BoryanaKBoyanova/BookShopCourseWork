namespace BookShopCourseWork.Models.GenreController
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;
    using System.ComponentModel.DataAnnotations;

    public class AddGenre
    {
        [Required]
        [MinLength(3, ErrorMessage = "Genre name must be minimum 3 symbols!")]
        [MaxLength(25, ErrorMessage = "Genre name must be maximum 25 symbols!")]
        [Display(Name = "Genre name")]
        public string GenreName {get; set;}
    }
}