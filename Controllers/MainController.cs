using Portfolio;
using proTnsWeb.Filters;
using proTnsWeb.Models;
using proTnsWeb.Models.Services;
using System.Web.Mvc;

namespace proTnsWeb.Controllers
{
    [LoginFilter]
	public class MainController : Controller
    {
        private readonly Dashboard dashboardService = new Dashboard();
        private readonly Common ComService = new Common();
        public ActionResult Index()
		{
            try
            {
                // Login 여부 확인
                 if (Session["User"] == null)
                {
                    return null;
                }
                else
                {
                    if ((Session["User"] as User).UserID == null)
                    {
                        return null;
                    }

                    string ynMFA = CommonLib.GetAppValue("YN_MFA");
                    if ("Y".Equals(ynMFA))
                    {
                        if (!(Session["User"] as User).MFAPASS)
                        {
                            Session["User"] = null;
                            return RedirectToAction("Index", "Login");
                        }
                    }                    
                }

                ViewData["name"] = (Session["User"] as User).UserName;
                ViewData["id"] = (Session["User"] as User).UserID;
                ViewData["depart"] = (Session["User"] as User).DepartName;
                ViewData["lvl"] = (Session["User"] as User).PermissionLvl;
                ViewData["IsManagerPage"] = (Session["User"] as User).IsManagerPage;
                ViewData["LocationSope"] = (Session["User"] as User).LocationSope;

                ViewBag.Title = "Home";
                Session["selMenuKey"] = ""; //메뉴 선택 해제                             

                return View();                
            }
            catch
            {
                return null;
            }
		}        

        /// <summary>
        /// 기본 데이터(쿼리가 간단한) 하나의 프로시저에서 조회함
        /// </summary>
        /// <returns></returns>
        public JsonResult GetBasicData()
        {            
            return Json(dashboardService.GetBasicData());
        }        

        /// <summary>
        /// 일자별 VM  할당 시간 조회
        /// </summary>
        /// <returns></returns>
        public JsonResult GetDailyVMAllocation()
        {
            return Json(dashboardService.GetDailyVMAllocation());
        }

        /// <summary>
        /// 일자별 사용자 연결 시간 조회
        /// </summary>
        /// <returns></returns>
        public JsonResult GetDailyUserConnection()
        {
            return Json(dashboardService.GetDailyUserConnection());
        }

        /// <summary>
        /// Task 조회
        /// </summary>
        /// <returns></returns>
        public JsonResult GetTask()
        {            
            return Json(dashboardService.GetTask());
        }

        /// <summary>
        /// 시간당 VM 접속 수 조회
        /// </summary>
        /// <returns></returns>
        public JsonResult GetTimeVMConnectCnt()
        {            
            return Json(dashboardService.GetTimeVMConnectCnt());
        }

        /// <summary>
        /// 타입별 비용 (현재월 기준)
        /// </summary>
        /// <returns></returns>
        public JsonResult GetTypeCost()
        {            
            return Json(dashboardService.GetTypeCost());
        }
    }
}