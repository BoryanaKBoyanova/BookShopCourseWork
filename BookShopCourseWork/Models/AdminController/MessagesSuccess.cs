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
        
        public string BookPublisherConnected => "Book has changed it's publisher successfully!";
        public string AddPublisher => "Publisher has been added successfully!";
        public string DeletePublisher => "Publisher has been deleted successfully!";
        
        public string BookGenreConnected => "Book has been connected to genre seccessfully!";
        public string BookGenreDisconnected => "Book has been desconnected from genre successfully!";
        public string AddGenre => "Genre has been added successfully!";
        public string DeleteGenre => "Genre has been deleted successfully!";
    }
}