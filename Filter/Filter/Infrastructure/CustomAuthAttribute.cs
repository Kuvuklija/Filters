using System;
using System.Collections.Generic;
using System.Web.Mvc;
using System.Web;


namespace Filter.Infrastructure
{
    public class CustomAuthAttribute:AuthorizeAttribute
    {
        private bool localAllowed;

        public CustomAuthAttribute(bool allowedParam) {
            localAllowed = allowedParam;
        }

        protected override bool AuthorizeCore(HttpContextBase httpContext)
        {
            if (httpContext.Request.IsLocal) {
                return localAllowed;
            }else {
                return true;
            }
        }
    }
}