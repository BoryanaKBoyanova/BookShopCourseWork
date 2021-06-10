using System.Collections.Generic;

namespace BookShopCourseWork.Models.AdminController
{
    public class MessagesSuccess
    {
        public string CreateBook => "Book has been created successfully!";
        public string EditBook => "Book has been edited successfully!";
        public string BookAuthorConnected => "Book has been connected to author successfully!";
        public string BookAuthorDisconnected => "Book has been desconnected from author successfully!";
        public string AddAuthor => "Author has been added successfully!";
        public string DeleteAuthor => "Author has been deleted successfully!";
        public string AddPublisher => "Publisher has been added successfully!";
        public string DeletePublisher => "Publisher has been deleted successfully!";
        public string AddGenre => "Genre has been added successfully!";
        public string DeleteGenre => "Genre has been deleted successfully!";
    }
}