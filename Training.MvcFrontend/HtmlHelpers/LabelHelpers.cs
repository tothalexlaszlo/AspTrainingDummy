using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Training.MvcFrontend.HtmlHelpers
{
    public static class LabelHelpers
    {
        public static MvcHtmlString ItalicLabel(this HtmlHelper htmlHelper, string text)
        {
            var tagBuilder = new TagBuilder("label");
            tagBuilder.InnerHtml = text;
            tagBuilder.Attributes.Add("style", "font-style: italic");

            return new MvcHtmlString(tagBuilder.ToString());
        }
    }
}