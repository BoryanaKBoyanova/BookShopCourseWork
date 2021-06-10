using System.Collections.Generic;

namespace BookShopCourseWork.Models.AdminController
{
    public class MessagesFailed
    {
        public string CreateBook => "Failed to create book!";
        public string EditBook => "Failed to edit book!";
        public string BookAuthorConnected => "Failed to connect author to book!";
        public string BookAuthorDisconnected => "Failed to disconnect author from book!";
    }
}