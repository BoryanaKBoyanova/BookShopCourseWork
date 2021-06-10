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
        [MinLength(2, ErrorMessage = "Author first name must be minimum 2 symbols!")]
        [MaxLength(25, ErrorMessage = "Author first name must be maximum 25 symbols!")]
        [Display(Name = "First name")]
        public string FirstName {get; set;}

        [Required]
        [MinLength(2, ErrorMessage = "Author last name must be minimum 2 symbols!")]
        [MaxLength(25, ErrorMessage = "Author last name must be maximum 25 symbols!")]
        [Display(Name = "Last name")]
        public string LastName {get; set;}
    }
}
