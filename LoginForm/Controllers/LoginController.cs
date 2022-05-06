using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using LoginForm.Models;

namespace LoginForm.Controllers
{
    public class LoginController : Controller
    {
        // GET: Login
        
        public ActionResult Login()
        {
            return View();
        }

        public List<UserModel> PutValue()
        {
            var users = new List<UserModel>
            {
                new UserModel{id=1,username="afia@gmail.com",password="abc123"},
                new UserModel{id=2,username="ratin@gmail.com",password="xyz546"},
                new UserModel{id=3,username="purba@gmail.com",password="pnpc465"},
                new UserModel{id=4,username="imtiaz@gmail.com",password="urt324"}
            };

            return users;
        }
        

        [HttpPost]
       
        public ActionResult Verify(UserModel usr)
        {
            var user = PutValue();

            var ue = user.Where(u => u.username.Equals(usr.username));

            var up = ue.Where(p => p.password.Equals(usr.password));

            ModelState.Clear();
            if (up.Count() == 1)
            {
                ViewBag.message = "Login Success";
                return View("LoginSuccess");
            }
            if ((ue.Count() == 1) && (up.Count() != 1))
            {
                ViewBag.message = "Login Failed.Incorrect Password";
                return View("Login");
            }
            else
            {
                ViewBag.message = "Login Failed.Incorrect Username";
                return View("Login");
            }
        }
    }

}
