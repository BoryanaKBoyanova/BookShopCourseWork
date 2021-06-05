namespace BookShopCourseWork.Models.BookController
{
    using System.ComponentModel.DataAnnotations;

    public class EditBook
    {
        [Required]

        public int Id { get; set; }

        [Required]
        public string Title { get; set; }

        [Required]
        public string Description { get; set; }

        [Required]
        public double Price { get; set; }

        [Required]
        public string ImgUrl { get; set; }
       
    }
}
