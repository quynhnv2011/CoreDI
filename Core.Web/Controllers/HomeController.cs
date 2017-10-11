using Core.Service;
using Core.Service.Users;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Core.Web.Controllers
{
    public class HomeController : Controller
    {
        #region Fields
        readonly IUserService _userService;
        #endregion

        #region Constructor
        public HomeController(IUserService userService)
        {
            this._userService = userService;
        }
        #endregion
        public ActionResult Index()
        {
            var all = _userService.GetAllUser().ToList();
            return View();
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
    }
}