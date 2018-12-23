using System;
using System.Web.Security;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Filter.Controllers
{
    public class AccountController : Controller
    {
        // GET: Account
        public ActionResult Login(){
            return View();
        }

    [HttpPost]
    public ActionResult Login(string username, string password, string returnUrl) {
      bool result = FormsAuthentication.Authenticate(username, password);
      if (result) {
        FormsAuthentication.SetAuthCookie(username, false);
        return Redirect(returnUrl ?? Url.Action("Index", "Admin"));
      }else {
        ModelState.AddModelError("", "Incorrect username or password");
        return View();
      }
    }



    }
}
