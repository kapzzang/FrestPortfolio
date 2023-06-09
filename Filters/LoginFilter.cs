using Portfolio;
using proTnsWeb.Models;
using System;
using System.Security.Authentication;
using System.Threading;
using System.Web;
using System.Web.Mvc;

namespace proTnsWeb.Filters
{
    public class LoginFilter : ActionFilterAttribute, IActionFilter, IExceptionFilter
	{
		public override void OnActionExecuting(ActionExecutingContext filterContext)
		{
			CommonLib.WriteLog("LoginFilter OnActionExecuting", "");
			try
			{
				CommonLib.WriteLog("LoginFilter OnActionExecuting Step1", "");
				string sessionId = HttpContext.Current.Session.SessionID;

				CommonLib.WriteLog("LoginFilter OnActionExecuting Step2", "");
				if (filterContext.HttpContext.Session["User"] == null)
				{
					CommonLib.WriteLog("LoginFilter OnActionExecuting Step2-1", "");
					if (filterContext.HttpContext.Request.IsAjaxRequest())
					{
						try
						{
							CommonLib.WriteLog("LoginFilter OnActionExecuting Step2-2", "");
							throw new AuthenticationException();
						}
						catch
						{
							CommonLib.WriteLog("LoginFilter OnActionExecuting Step2-3", "");
							filterContext.HttpContext.Response.Redirect("~/Login/SignOut");
						}
					}
					else
					{
						CommonLib.WriteLog("LoginFilter OnActionExecuting Step2-4", "");
						filterContext.HttpContext.Response.Redirect("~/Login/SignOut");
					}
				}
				else
				{
					CommonLib.WriteLog("LoginFilter OnActionExecuting Step2-5", "");
					try
					{
						// Session 시간 설정 SessionCheckLoginStatus 아닐때만!
						if (filterContext.ActionDescriptor.ActionName.ToString() != "SessionCheckLoginStatus")
							filterContext.HttpContext.Session["SessionStartDateTime"] = DateTime.Now;
						// Session 시간 체크
						DateTime dtST = (DateTime)filterContext.HttpContext.Session["SessionStartDateTime"];
						if (DateTime.Now > dtST.AddMinutes(filterContext.HttpContext.Session.Timeout))
						{
							CommonLib.WriteLog("LoginFilter OnActionExecuting Step2-6 else Session Timeout & Redirect Login/SignOut", "");
							//filterContext.HttpContext.Response.Redirect("~/Login/SignOut");
							filterContext.Result = new RedirectResult("~/Login/SignOut"); 
							return;
						}

						// 디버그일때 로그 기록
						if (CommonLib.IsDebug)
						{
							string SActionName = filterContext.ActionDescriptor.ActionName;
							User SeU = (User)filterContext.HttpContext.Session["User"];
							CommonLib.WriteLog("LoginFilter OnActionExecuting Step2-6 else SessionTime         :" + DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss:fff") + ", UserID : " + SeU.UserID, "");
							CommonLib.WriteLog("LoginFilter OnActionExecuting Step2-6 else SessionStartDateTime:" + dtST.ToString("yyyy-MM-dd HH:mm:ss:fff"), "");
							CommonLib.WriteLog("LoginFilter OnActionExecuting Step2-6 else Session.Timeout     :" + filterContext.HttpContext.Session.Timeout.ToString(), "");
						}
					}
					catch
					{
						CommonLib.WriteLog("LoginFilter OnActionExecuting Step2-7 else UserID No ", "");
					}
				}
				CommonLib.WriteLog("LoginFilter OnActionExecuting Step3 Get lang", "");
				// 다국어 설정 - 세션 lang에 설정된 언어로 변경
				if (HttpContext.Current.Session["lang"] == null)
					HttpContext.Current.Session["lang"] = Thread.CurrentThread.CurrentUICulture.ToString().ToLower();

				CommonLib.WriteLog("LoginFilter OnActionExecuting Step4 Setting lang", "");
				Thread.CurrentThread.CurrentCulture = System.Globalization.CultureInfo.CreateSpecificCulture((string)HttpContext.Current.Session["lang"]);
				Thread.CurrentThread.CurrentUICulture = System.Threading.Thread.CurrentThread.CurrentCulture;
				// 다국어 설정 - 끝
				CommonLib.WriteLog("LoginFilter OnActionExecuting Step5 Fin", "");
			}
			catch (Exception ex)
			{
				CommonLib.WriteLog("LoginFilter OnActionExecuting ex : " + ex.Message, "", true);
			}

		}

		/*
		public override void OnResultExecuting(ResultExecutingContext filterContext)
		{
			filterContext.HttpContext.Response.Cache.SetCacheability(HttpCacheability.NoCache);
		}
		*/

		void IExceptionFilter.OnException(ExceptionContext filterContext)
		{
			CommonLib.WriteLog("LoginFilter OnException", "");
			try
			{
				if (filterContext.Exception is AuthenticationException)
				{
					filterContext.HttpContext.Response.StatusCode = 401;
					filterContext.HttpContext.Response.StatusDescription = "Authentication";
					CommonLib.WriteLog("LoginFilter OnException : Authentication", "");
				}
				else
				{
					filterContext.HttpContext.Response.StatusCode = 500;
					filterContext.HttpContext.Response.StatusDescription = "Exception";
					CommonLib.WriteLog("LoginFilter OnException : Exception" , "");
				}
				CommonLib.WriteLog("LoginFilter OnException Redirect Login", "");
				filterContext.Result = new RedirectResult("~/Login/SignOut");
				filterContext.ExceptionHandled = true;
			}
			catch (Exception ex)
			{
				CommonLib.WriteLog("LoginFilter OnException ex : " + ex.Message, "", true);
			}
		}

	}
}