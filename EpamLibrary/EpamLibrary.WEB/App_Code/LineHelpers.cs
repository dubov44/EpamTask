using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web;
using System.Web.Mvc;

namespace EpamLibrary.WEB.App_Code
{
    public static class LineHelpers
    {
        public static MvcHtmlString Nl2Br(this HtmlHelper htmlHelper, string text)
        {
            if (string.IsNullOrEmpty(text))
                return MvcHtmlString.Create(text);
            else
            {
                StringBuilder builder = new StringBuilder();
                string[] lines = text.Split('\n');
                for (int i = 0; i < lines.Length; i++)
                {
                    if (i > 0)
                        builder.Append("<br/>\n");
                    builder.Append(HttpUtility.HtmlEncode(lines[i]));
                }
                return MvcHtmlString.Create(builder.ToString());
            }
        }
        public static MvcHtmlString CreateImage(this HtmlHelper html,
           string address, string stylesToImg)
        {
            var img = new TagBuilder("img");
            img.MergeAttribute("id", "bookImage");
            img.AddCssClass(stylesToImg);
            img.MergeAttribute("alt", "hover");
            img.MergeAttribute("src", address);
            return new MvcHtmlString(img.ToString());
        }
    }
}