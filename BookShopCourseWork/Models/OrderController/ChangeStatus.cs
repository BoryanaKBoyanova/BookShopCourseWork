namespace BookShopCourseWork.Models.OrderController
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;
    using System.ComponentModel.DataAnnotations;
    using Newtonsoft.Json;


    public class ChangeStatus
    {
        
        [Required]
        public int OrderId {get; set;}

        [Required]
        public string Status {get; set;}
       
    }
}
