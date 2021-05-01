namespace BookShopCourseWork.Models
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;
    using System.ComponentModel.DataAnnotations;

    public class Order
    {
        public int Id { get; set; }

        [Required]
        public string Status { get; set; }

        [Required]
        public int UserId { get; set; }

        public IList<OrderBook> OrderBooks { get; set; }

        [Required]
        public string City { get; set; }

        [Required]
        public string Address { get; set; }  

        public string Notes { get; set; }
    }
}
