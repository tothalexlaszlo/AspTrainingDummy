using System.Web;
using System.Web.Mvc;
using Training.MvcFrontend.Filters;

namespace Training.MvcFrontend
{
    public class FilterConfig
    {
        public static void RegisterGlobalFilters(GlobalFilterCollection filters)
        {
            filters.Add(new HandleErrorAttribute());
            //filters.Add(new OfflineFilterAttribute()); // igy a filter minden egyes controllerén le fog futni
        }
    }
}
