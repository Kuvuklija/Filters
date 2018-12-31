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
        [Authorize(Users = "admin")] //built-in aythorization
        [OutputCache(Duration = 60)]
        public string Index()
        {
            return "This is the Index action on the Home controller";
        }

        [GoogleAuth]
        [Authorize(Users = "vadim@google.com")]
        public string List() {
            return "This is the List action on the Home controller";
        }

        [RangeExeption]
        public string RangeTest(int id) {
            if (id > 100)
                return String.Format("The id value is {0}", id);
            else {
                throw new ArgumentOutOfRangeException("id",id,"Fuck!");
            }
        }
    }
}
