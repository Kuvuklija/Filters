using System.Web.Security;
using System.Security.Principal;
using System.Web.Routing;
using System.Web.Mvc.Filters;
using System.Web.Mvc;

namespace Filter.Infrastructure
{
    public class GoogleAuthAttribute : FilterAttribute, IAuthenticationFilter
    {
        public void OnAuthentication(AuthenticationContext filterContext)
        {
            IIdentity ident = filterContext.Principal.Identity;
            if(!ident.IsAuthenticated || !ident.Name.EndsWith("google.com")) {
                filterContext.Result = new HttpUnauthorizedResult();
            }
        }
        //two chalenge: before action List and after List,but before rendering view
        public void OnAuthenticationChallenge(AuthenticationChallengeContext filterContext)
        {
            if (filterContext.Result == null || filterContext.Result is HttpUnauthorizedResult) {
                filterContext.Result = new RedirectToRouteResult(new RouteValueDictionary {
                {"controller", "GoogleAccount"},
                {"action","Login"},
                {"returnUrl",filterContext.HttpContext.Request.RawUrl}
                });
            }
            else {
                FormsAuthentication.SignOut(); //after reseting page we have to authorization again, becouse IsAuthenticated=false
            }
        }
    }
}