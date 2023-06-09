using proTnsWeb.Models.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;
using System.Threading;
using proTnsWeb.Models;
using Portfolio;

namespace proTnsWeb.Controllers
{
    public class LoginController : Controller
	{
		private readonly IUserService service;
        private readonly Common ComService = new Common();

		HttpApplication httpApplication = new HttpApplication();

		public LoginController(IUserService service)
		{
			this.service = service;
		}

		public ActionResult Index()
		{
            if(Session["User"] != null)
			{
                CommonLib.WriteLog("LoginController Index() Session[User] Not NULL Redirect ~/ ", "");
                return Redirect("~/");
			}

            return View();
        }

        public ActionResult SignOut()
        {
            CommonLib.WriteLog("LoginController SignOut", "");
            Session.RemoveAll();
            CommonLib.WriteLog("LoginController SignOut RemoveAll", "");
            FormsAuthentication.SignOut();
            CommonLib.WriteLog("LoginController SignOut SignOut Redirect ~/Login", "");
            return Redirect("~/Login");
        }        

        [HttpPost]
		public ActionResult SignOn(string param)
		{
            CommonLib.WriteLog("LoginController SignOn() Start");

            var parameter = ComService.ParameterDataSet(param);
            string userid = parameter.ContainsKey("userid") ? parameter["userid"] != null ? parameter["userid"].ToString() : "" : "";
            string passwd = parameter.ContainsKey("passwd") ? parameter["passwd"] != null ? parameter["passwd"].ToString() : "" : "";        
            
            Dictionary<string, object> result = new Dictionary<string, object>();

            #region 포트폴리오용 인증
            try
            {
                //사용자 정보
                User user = new User();
                user.UserID = userid;
                user.UserName = userid;
                user.DepartName = "테스트부서";
                user.PermissionLvl = 1;               

                Session["User"] = user;

                result.Add("result", true);                
                result.Add("resulturl", this.Url.Content("~/"));
            }
            catch (Exception ex)
            {
                CommonLib.WriteLog("protns Login ex : " + ex.ToString(), "");
                result.Add("result", false);
                string str_resultmsg = "로그인 오류!";
                string str_resultmsgtip = ex.Message.Replace("\"", "'");
                str_resultmsgtip = str_resultmsgtip.Replace("\r\n", "");
                result.Add("resultmsg", str_resultmsg);
                result.Add("resultmsgtip", str_resultmsgtip);
                result.Add("resulturl", "");
            }
            #endregion

            return Json(result);
		}		
    }
}