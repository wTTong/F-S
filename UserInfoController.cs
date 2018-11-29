using FunShow.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;

namespace FunShow.Controllers
{
    public class UserInfoController : Controller
    {
        IUserInfo ius = new EF_UserInfo();
        // GET: UsrInfo
        public ActionResult Index()
        {
            return View();
        }
        public ActionResult Login()
        {
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Login([Bind(Include ="UsrId,UsrPwd")] Usr us)
        {
            Usr user=ius.login(us.UsrId, us.UsrPwd);
            if(user!=null)
            {
                Session["User_id"] = user.UsrId;
                Session["User_Name"] = user.UsrName;
                Session["Role"] = user.UsrFlag;
                FormsAuthenticationTicket ticket = new FormsAuthenticationTicket(
                1,
                user.UsrName,
                DateTime.Now,
                DateTime.Now.AddDays(7),
                false,
                "Users");
                var cookie = new HttpCookie(FormsAuthentication.FormsCookieName, FormsAuthentication.Encrypt(ticket));
                cookie.HttpOnly = true;
                HttpContext.Response.Cookies.Add(cookie);
                return RedirectToAction("Index", "Home");
            }
            return View();

        }
    }
}