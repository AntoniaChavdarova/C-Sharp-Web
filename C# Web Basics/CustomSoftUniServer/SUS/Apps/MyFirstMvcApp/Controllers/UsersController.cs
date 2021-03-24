using SUS.HTTP;
using SUS.MvcFramework;
using System;
using System.Collections.Generic;
using System.Text;

namespace MyFirstMvcApp.Controllers
{
    public class UsersController : Controller
    {
        public HttpResponse Register()
        {
            return this.View();
        }

        [HttpPost]
        public HttpResponse Login()
        {
            return this.View();
        }
    }
}
