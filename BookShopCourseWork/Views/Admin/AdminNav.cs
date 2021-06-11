using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace BookShopCourseWork.Views.Admin
{
    public static class AdminNav
    {
        
        public static string Books => "Books";
        public static string Orders => "Orders";
        public static string Authors => "Authors";
        public static string Publishers => "Publishers";
        public static string Genres => "Genres";

        public static string CreateBook => "CreateBook";
        public static string EditBook => "EditBook";

        public static string ViewOrders => "ViewOrders";
        public static string FindOrderById => "FindOrderById";

        public static string UpdateAuthorBook => "UpdateAuthorBook";
        public static string ViewAllAuthors => "ViewAllAuthors";
        public static string AddAuthor => "AddAuthor";
        public static string DeleteAuthor => "DeleteAuthor";
        
        public static string UpdatePublisherBook => "UpdatePublisherBook";
        public static string ViewAllPublishers => "ViewAllPublishers";
        public static string AddPublisher => "AddPublisher";
        public static string DeletePublisher => "DeletePublisher";

        public static string UpdateGenreBook => "UpdateGenreBook";
        public static string ViewAllGenres => "ViewAllGenres";
        public static string AddGenre => "AddGenre";
        public static string DeleteGenre => "DeleteGenre";

        public static string BooksNavClassTab(ViewContext viewContext) => PageNavClassTab(viewContext, Books);
        public static string OrdersNavClassTab(ViewContext viewContext) => PageNavClassTab(viewContext, Orders);
        public static string AuthorsNavClassTab(ViewContext viewContext) => PageNavClassTab(viewContext, Authors);
        public static string PublishersNavClassTab(ViewContext viewContext) => PageNavClassTab(viewContext, Publishers);
        public static string GenresNavClassTab(ViewContext viewContext) => PageNavClassTab(viewContext, Genres);

        public static string BooksButtonTab(ViewContext viewContext) => ButtonTab(viewContext, Books);
        public static string OrdersButtonTab(ViewContext viewContext) => ButtonTab(viewContext, Orders);
        public static string AuthorsButtonTab(ViewContext viewContext) => ButtonTab(viewContext, Authors);
        public static string PublishersButtonTab(ViewContext viewContext) => ButtonTab(viewContext, Publishers);
        public static string GenresButtonTab(ViewContext viewContext) => ButtonTab(viewContext, Genres);

        public static string CreateBookNavClass(ViewContext viewContext) => PageNavClass(viewContext, CreateBook);
        public static string EditBookNavClass(ViewContext viewContext) => PageNavClass(viewContext, EditBook);

        public static string ViewOrdersNavClass(ViewContext viewContext) => PageNavClass(viewContext, ViewOrders);
        public static string FindOrderByIdNavClass(ViewContext viewContext) => PageNavClass(viewContext, FindOrderById);
        
        public static string UpdateAuthorBookNavClass(ViewContext viewContext) => PageNavClass(viewContext, UpdateAuthorBook);
        public static string ViewAllAuthorsNavClass(ViewContext viewContext) => PageNavClass(viewContext, ViewAllAuthors);
        public static string AddAuthorNavClass(ViewContext viewContext) => PageNavClass(viewContext, AddAuthor);
        public static string DeleteAuthorNavClass(ViewContext viewContext) => PageNavClass(viewContext, DeleteAuthor);
        
        public static string UpdatePublisherBookNavClass(ViewContext viewContext) => PageNavClass(viewContext, UpdatePublisherBook);
        public static string ViewAllPublishersNavClass(ViewContext viewContext) => PageNavClass(viewContext, ViewAllPublishers);
        public static string AddPublisherNavClass(ViewContext viewContext) => PageNavClass(viewContext, AddPublisher);
        public static string DeletePublisherNavClass(ViewContext viewContext) => PageNavClass(viewContext, DeletePublisher);        

        public static string UpdateGenreBookNavClass(ViewContext viewContext) => PageNavClass(viewContext, UpdateGenreBook);
        public static string ViewAllGenresNavClass(ViewContext viewContext) => PageNavClass(viewContext, ViewAllGenres);
        public static string AddGenreNavClass(ViewContext viewContext) => PageNavClass(viewContext, AddGenre);
        public static string DeleteGenreNavClass(ViewContext viewContext) => PageNavClass(viewContext, DeleteGenre);

        private static string PageNavClass(ViewContext viewContext, string page)
        {
            var activePage = viewContext.ViewData["ActivePage"] as string
                ?? System.IO.Path.GetFileNameWithoutExtension(viewContext.ActionDescriptor.DisplayName);
            return string.Equals(activePage, page, StringComparison.OrdinalIgnoreCase) ? "text-secondary bg-primary" : null;
        }
        private static string ButtonTab(ViewContext viewContext, string tab)
        {
            var activeTab = viewContext.ViewData["ActiveTab"] as string
                ?? System.IO.Path.GetFileNameWithoutExtension(viewContext.ActionDescriptor.DisplayName);
            return string.Equals(activeTab, tab, StringComparison.OrdinalIgnoreCase) ? null : "collapsed";
        }
        private static string PageNavClassTab(ViewContext viewContext, string tab)
        {
            var activeTab = viewContext.ViewData["ActiveTab"] as string
                ?? System.IO.Path.GetFileNameWithoutExtension(viewContext.ActionDescriptor.DisplayName);
            return string.Equals(activeTab, tab, StringComparison.OrdinalIgnoreCase) ? "show" : "collapsed";
        }

    }
}