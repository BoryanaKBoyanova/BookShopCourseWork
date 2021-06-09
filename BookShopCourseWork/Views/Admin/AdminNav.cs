using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace BookShopCourseWork.Views.Admin
{
    public static class AdminNav
    {
        public static string CreateBook => "CreateBook";
        public static string EditBook => "EditBook";

        public static string ViewOrders => "ViewOrders";

        public static string FindOrderById => "FindOrderById";

        public static string UpdateAuthorBook => "UpdateAuthorBook";

        public static string Books => "Books";
        public static string Orders => "Orders";

        public static string Authors => "Authors";

        public static string CreateBookNavClass(ViewContext viewContext) => PageNavClass(viewContext, CreateBook);
        public static string EditBookNavClass(ViewContext viewContext) => PageNavClass(viewContext, EditBook);

        public static string ViewOrdersNavClass(ViewContext viewContext) => PageNavClass(viewContext, ViewOrders);
        public static string FindOrderByIdNavClass(ViewContext viewContext) => PageNavClass(viewContext, FindOrderById);
        public static string UpdateAuthorBookNavClass(ViewContext viewContext) => PageNavClass(viewContext, UpdateAuthorBook);

        public static string BooksNavClassTab(ViewContext viewContext) => PageNavClassTab(viewContext, Books);
        public static string BooksButtonTab(ViewContext viewContext) => ButtonTab(viewContext, Books);

        public static string OrdersNavClassTab(ViewContext viewContext) => PageNavClassTab(viewContext, Orders);

        public static string OrdersButtonTab(ViewContext viewContext) => ButtonTab(viewContext, Orders);

        public static string AuthorsNavClassTab(ViewContext viewContext) => PageNavClassTab(viewContext, Authors);

        public static string AuthorsButtonTab(ViewContext viewContext) => ButtonTab(viewContext, Authors);

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