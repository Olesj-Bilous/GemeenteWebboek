using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ForumWeb
{
    public static class ListExtensions
    {
        public static List<SelectListItem> ToSelectList<T>(this List<T> list, Func<T, string> toValue, Func<T, string> toText)
        {
            return list.Select(i => new SelectListItem { Value = toValue(i), Text = toText(i) }).ToList();
        }
    }
}
