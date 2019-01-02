using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;

namespace Filter.Infrastructure
{
    public class RangeExeptionAttribute : FilterAttribute, IExceptionFilter
    {
        public void OnException(ExceptionContext filterContext)
        {
           if(!filterContext.ExceptionHandled && filterContext.Exception is ArgumentOutOfRangeException) {
                //filterContext.Result = new RedirectResult("~/Content/RangeErrorPage.html");
                int val =(int)((ArgumentOutOfRangeException)filterContext.Exception).ActualValue; //here is 50
                filterContext.Result = new ViewResult{
                    ViewName = "RangeError",
                    ViewData = new ViewDataDictionary<int>(val)
                };

                filterContext.ExceptionHandled = true;
            }
        }
    }
}