using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Training.MvcFrontend.Filters
{
    //[AttributeUsage(AttributeTargets.Class] // csak osztályra lehet használni 
    //[AttributeUsage(AttributeTargets.Method)] // csak methodusokra lehet használni
    public class OfflineFilterAttribute : ActionFilterAttribute
    {
        //public override void OnActionExecuted(ActionExecutedContext filterContext)
        //{
        //    base.OnActionExecuted(filterContext);
        //}

        public override void OnActionExecuting(ActionExecutingContext filterContext)
        {
            if (DateTime.Now.Hour==13 && 
                !(
                   filterContext.RouteData.Values["controller"].ToString() == "Home" && 
                   filterContext.RouteData.Values["action"].ToString() == "Offline")
               )
            {
                filterContext.Result =
                    new RedirectToRouteResult(new System.Web.Routing.RouteValueDictionary{
                        {"controller", "Home" },
                        {"action", "Offline" }
                    });
            }
            else
                base.OnActionExecuting(filterContext);
        }
    }
}