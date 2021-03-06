﻿using Core.Business.EF;
using Core.Business.Object;
using Core.Service.Users;
using Core.Web.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;

namespace Core.Web.Controllers
{
    public partial class AccountController : Controller
    {
        #region Fields
         readonly IUserService _userService;
        #endregion

        #region Constructor
        public AccountController(IUserService userService)
        {
            this._userService = userService;
        }
        #endregion

        #region Methods       
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
                var acc = new CoreUser();
                bool checkLogin = _userService.LogIn(model.UserName, model.Password, ref acc);
                if (checkLogin)
                {
                    acc.Password = string.Empty;
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
         ActionResult RedirectToLocal(string returnUrl)
        {
            if (Url.IsLocalUrl(returnUrl))
            {
                return Redirect(returnUrl);
            }
            return RedirectToAction("Index", "Home");
        }
        #endregion
    }

}
