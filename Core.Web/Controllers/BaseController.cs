using Core.Web.libs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Core.Web.Controllers
{
    public class BaseController : Controller
    {
        protected override void Initialize(System.Web.Routing.RequestContext requestContext)
        {
            if (!requestContext.HttpContext.Request.IsAuthenticated)
            {
                requestContext.HttpContext.Response.Redirect(GetLoginUrl(requestContext));
            }
            var controller = requestContext.RouteData.Values["controller"].ToString().Trim().ToUpper();
            var action = requestContext.RouteData.Values["action"].ToString().Trim().ToUpper();
            var currentAcc = Global.CurrentAccount;

            if (currentAcc != null)
            {
                var isHasPermision = true;
               // var isHasPermision = CheckPermisionController(currentAcc.Id, controller, action);
                if (!isHasPermision)
                {
                    requestContext.HttpContext.Response.Clear();
                    requestContext.HttpContext.Response.Redirect("/AccessDenied/Index");
                    requestContext.HttpContext.Response.End();
                }
            }
            else if (controller != "AUTHENTICATION" && action != "LOGIN")
            {
                requestContext.HttpContext.Response.Redirect(GetLoginUrl(requestContext));
            }
            base.Initialize(requestContext);
        }

         string GetLoginUrl(System.Web.Routing.RequestContext requestContext)
        {
            var redirectUrl = requestContext.HttpContext.Server.UrlEncode(requestContext.HttpContext.Request.Url.PathAndQuery);
            return string.Format("/Authentication/Login?RedirectUrl={0}", redirectUrl);
        }
    }
}