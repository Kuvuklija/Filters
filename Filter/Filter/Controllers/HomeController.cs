using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Filter.Infrastructure;

namespace Filter.Controllers
{
    public class HomeController : Controller
    {
        //passing Razor
        //[CustomAuth(false)] //applied to class CustomAuthAttributes
        [Authorize(Users ="admin")] //built-in aythorization
        [OutputCache(Duration =60)]
        public string Index()
        {
            return "This is the Index action on the Home controller";
        }
    }
}
