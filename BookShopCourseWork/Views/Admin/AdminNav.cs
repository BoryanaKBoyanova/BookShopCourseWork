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

        public static string CreateBookNavClass(ViewContext viewContext) => PageNavClass(viewContext, CreateBook);
        public static string EditBookNavClass(ViewContext viewContext) => PageNavClass(viewContext, EditBook);
        private static string PageNavClass(ViewContext viewContext, string page)
        {
            var activePage = viewContext.ViewData["ActivePage"] as string
                ?? System.IO.Path.GetFileNameWithoutExtension(viewContext.ActionDescriptor.DisplayName);
            return string.Equals(activePage, page, StringComparison.OrdinalIgnoreCase) ? "text-secondary bg-primary" : null;
        }

    }
}