using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Filter.Controllers
{
    public class HomeController : Controller
    {
        //passing Razor
        public string Index()
        {
            return "This is the Index action on the Home controller";
        }
    }
}
