using Core.DataAccess.Object;
using Core.Service;
using Core.Service.Users;
using Core.Web.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;

namespace Core.Controllers
{
    public partial class AccountController : Controller
    {
        private readonly IUserService _userService;
        
        public AccountController(IUserService userService)
        {
            this._userService = userService;
        }
        // GET: Account
        [AllowAnonymous]
        public ActionResult Index(string returnUrl)
        {
            ViewBag.ReturnUrl = returnUrl;
            return View();
        }
        [HttpPost]
        [AllowAnonymous]
        [ValidateAntiForgeryToken]
        public ActionResult Index(LoginModel model, string returnUrl)
        {
            if (ModelState.IsValid)
            {
                var acc = new User();
                bool checkLogin = _userService.LogIn(model.UserName, model.Password, ref acc);
                if (checkLogin)
                {
                    acc.PassWord = string.Empty;
                    var json = Newtonsoft.Json.JsonConvert.SerializeObject(acc);
                    FormsAuthentication.SetAuthCookie(json, true);
                }
                else
                {
                    ModelState.AddModelError("", "Thông tin tài khoản và mật khẩu không chính xác.");
                }
                return RedirectToLocal(returnUrl);
            }            
            return View(model);
        }
        public ActionResult Logoff(string returnUrl)
        {
            FormsAuthentication.SignOut();
            Session.Abandon();
            return RedirectToLocal("/Admin/Login/Index");

        }
        private ActionResult RedirectToLocal(string returnUrl)
        {
            if (Url.IsLocalUrl(returnUrl))
            {
                return Redirect(returnUrl);
            }
            return RedirectToAction("Index", "Home");
        }
    }

}
