using System;
using System.Data;
using System.Threading;
using System.Web;
using System.Web.Mvc;
using System.Web.Optimization;
using System.Web.Routing;
using System.Data.SqlClient;
using Portfolio;

namespace proTnsWeb
{
    public class MvcApplication : System.Web.HttpApplication
    {
        string DBConn = "";

        protected void Application_Start()
        {
            MvcHandler.DisableMvcResponseHeader = true;

            AreaRegistration.RegisterAllAreas();
            UnityMvcActivator.Start();
            FilterConfig.RegisterGlobalFilters(GlobalFilters.Filters);
            RouteConfig.RegisterRoutes(RouteTable.Routes);
            BundleConfig.RegisterBundles(BundleTable.Bundles);

            CommonLib.WriteLog("Application_Start 1 AdminWeb", "",true);

            //DBHelper dbhelper = new DBHelper("Chat");
            //DBConn = dbhelper.getDBConStrDBName(dbhelper.m_DB);
            //CommonLib.WriteLog("DBConn : "+ DBConn, "", true);
            //SqlDependency.Start(DBConn);

            // MinorCode List
            //try
            //{
            //    CommonLib.WriteLog("Application_Start GetMinorCodeDataSet ", "", true);
            //    DataSet dsMinor = GetMinorCodeDataSet();

            //    foreach (DataRow dr in dsMinor.Tables[0].Rows)
            //    {
            //        string dMinorCode = dr["MinorCode"].ToString();
            //        Application[dMinorCode] = dr["ds_Value"].ToString();
            //    }
            //}
            //catch (Exception ex)
            //{
            //    CommonLib.WriteLog("Application_Start GetMinorCodeDataSet Error ex:" + ex.Message, true);
            //}

            // Debug Mode 설정
            // 디버그 여부
            try
            {
                Application["IsDebug"] = System.Web.Compilation.AppSettingsExpressionBuilder.GetAppSetting("IsDebug").ToString();
                if (Application["IsDebug"].ToString() == "Y")
                    CommonLib.IsDebug = true;
            }
            catch
            {
                Application["IsDebug"] = "N";
            }
            CommonLib.WriteLog("Application_Start Application[IsDebug] : " + Application["IsDebug"].ToString() , "", true);
            CommonLib.WriteLog("Application_Start CommonLib.IsDebug : " + CommonLib.IsDebug.ToString() , "", true);           


            // 다국어 리소스 조회
            //try
            //{
            //    CommonLib.WriteLog("Application_Start GetResourceLangDataSet ", "", true);
            //    Portfolio.Resources.TblResource = GetResourceLangDataSet();
            //}
            //catch (Exception ex)
            //{
            //    CommonLib.WriteLog("Application_Start GetResourceLangDataSet Error ex:" + ex.Message, true);
            //}            
        }

		protected void Application_BeginRequest(object sender, EventArgs e)
        {
            var application = sender as HttpApplication;
            if (application != null && application.Context != null)
            {
                application.Context.Response.Headers.Remove("Server");
            }
            // 브라우저 캐싱 방지 
            // https://qastack.kr/programming/1160105/disable-browser-cache-for-entire-asp-net-website
            Response.Cache.SetCacheability(HttpCacheability.NoCache);
            Response.Cache.SetExpires(DateTime.UtcNow.AddHours(-1));
            Response.Cache.SetNoStore();
        }

        protected void Application_End()
        {
            //Stop SQL dependency
            //SqlDependency.Stop(DBConn);
        }

        // 세션 lang 설정
        protected void Session_Start(Object sender, EventArgs e)
        {
            // Code that runs when a new session is started 
            string sessionId = Session.SessionID;

            HttpContext.Current.Session["lang"] = Thread.CurrentThread.CurrentUICulture.ToString().ToLower();           

            // 세션 Default
            HttpContext.Current.Session["timezoneUTC"] = "";

            HttpContext.Current.Session["User"] = null;
        }

        // MinorCode 조회
        DataSet GetMinorCodeDataSet()
        {
            string sQuery = string.Format(@"EXEC [dbo].[uspn_GetMinorCode] @majorCode = N'Default'");
            DBHelper dbhelper = new DBHelper();
            DataSet ds = new DataSet();

            ds = dbhelper.ExecuteSql(sQuery, "");

            return ds;
        }

        // 다국어 리소스 리스트 조회
        DataSet GetResourceLangDataSet()
        {
            string sQuery = "EXEC uspn_GetResourceLang";
            DBHelper dbhelper = new DBHelper();
            DataSet ds = new DataSet();

            ds = dbhelper.ExecuteSql(sQuery, "");

            return ds;
        }
    }
}
