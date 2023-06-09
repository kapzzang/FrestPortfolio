using Portfolio;
using proTnsWeb.Models;
using System;
using System.Web.Mvc;

namespace proTnsWeb.Filters
{
    public class AdminFilter : ActionFilterAttribute, IActionFilter
	{
		public override void OnActionExecuting(ActionExecutingContext filterContext)
		{
			
            CommonLib.WriteLog("AdminFilter OnActionExecuting", "");
			try
			{
				var user = filterContext.HttpContext.Session["User"] as User;
				if (user == null)
				{
					filterContext.HttpContext.Response.Redirect("~/Login/SignOut");
				}

				if (user.IsManagerPage != "1")
				{
					filterContext.HttpContext.Response.Redirect("~/Login/SignOut");
				}
			}
			catch(Exception ex)
			{
				CommonLib.WriteLog("AdminFilter OnActionExecuting ex : " + ex.Message, "", true);
			}
		}

		/*
		public override void OnResultExecuting(ResultExecutingContext filterContext)
		{
			filterContext.HttpContext.Response.Cache.SetCacheability(HttpCacheability.NoCache);
		}
		*/
	}
}