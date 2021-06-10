using System.Collections.Generic;

namespace BookShopCourseWork.Models.AdminController
{
    public class MessagesFailed
    {
        public string CreateBook => "Failed to create book!";
        public string EditBook => "Failed to edit book!";
        public string BookAuthorConnected => "Failed to connect author to book!";
        public string BookAuthorDisconnected => "Failed to disconnect author from book!";
        public string AddAuthor => "Failed to add author!";
        public string DeleteAuthor => "Failed to delete author!";
        public string AddPublisher => "Failed to add publisher!";
        public string DeletePublisher => "Failed to delete publisher!";
        public string AddGenre => "Failed to add genre!";
        public string DeleteGenre => "Failed to delete genre!";
    }
}