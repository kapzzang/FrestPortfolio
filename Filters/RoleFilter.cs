using Portfolio;
using proTnsWeb.Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Web;
using System.Web.Mvc;

namespace proTnsWeb.Filters
{
	public class RoleFilter : ActionFilterAttribute, IAuthorizationFilter
	{
		public void OnAuthorization(AuthorizationContext filterContext)
		{
			CommonLib.WriteLog("RoleFilter OnActionExecuting", "");
			try
			{				
				string sessionId = HttpContext.Current.Session.SessionID;
				string pageId = Path.GetFileName(HttpContext.Current.Request.FilePath); //현재 이동 되는 페이지의 pageId

				List<Menu> userMenuList = new List<Menu>(); //현재 사용자의 허용 메뉴 리스트
				userMenuList = filterContext.HttpContext.Session["_Menu"] as List<Menu> ?? userMenuList; //히스토리 세션 담기	
				Boolean roleCheck = true;

				for (int i = 0; i < userMenuList.Count; i++)
				{
					if (pageId.Equals(userMenuList[i].id_Page))
					{
						roleCheck = false;
					}
				}

				//메뉴 권한자가 아니면
				if (roleCheck)
				{
					filterContext.HttpContext.Response.Redirect("~/Login/SignOut");
				}
			}
			catch (Exception ex)
			{
				CommonLib.WriteLog("RoleFilter OnActionExecuting ex : " + ex.Message, "", true);
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