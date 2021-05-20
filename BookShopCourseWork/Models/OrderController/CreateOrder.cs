namespace BookShopCourseWork.Models.OrderController
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;
    using System.ComponentModel.DataAnnotations;
    using Newtonsoft.Json;


    public class CreateOrder
    {
        
        [Required]
        public string City {get; set;}
        [Required]
        public string Address {get; set;}
        public string Notes {get; set;}

        [Required]
        public string BooksAndQuantity {get; set;}

        public Dictionary<int, int> BooksAndQuantityParsed {get; set;}
       
    }
}
