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
            base.Initialize(requestContext);
        }

        private string GetLoginUrl(System.Web.Routing.RequestContext requestContext)
        {
            var redirectUrl = requestContext.HttpContext.Server.UrlEncode(requestContext.HttpContext.Request.Url.PathAndQuery);
            return string.Format("/Authentication/Login?RedirectUrl={0}", redirectUrl);
        }
    }
}