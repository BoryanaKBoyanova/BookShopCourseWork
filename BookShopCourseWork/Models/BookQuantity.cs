namespace BookShopCourseWork.Models
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;
    using System.ComponentModel.DataAnnotations;

    public class BookQuantity
    {
        public int Id {get; set;}
        public Book Book {get; set;}

        public int BookId {get; set;}

        public int Quantity {get; set;}

        public int OrderId {get; set;}
    }
}
