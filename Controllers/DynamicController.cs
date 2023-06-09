using Portfolio;
using proTnsWeb.Filters;
using proTnsWeb.Models;
using proTnsWeb.Models.Services;
using System;
using System.Collections.Generic;
using System.Web.Mvc;

namespace proTnsWeb.Controllers
{
    [LoginFilter]
    public class DynamicController : Controller
    {
        private readonly Common ComService = new Common();

        [RoleFilter]
        public ActionResult PageCommon(string page, string pageId)
        {
            try { 
            CommonLib.WriteLog("DynamicController PageCommon Step 1 Setting ViewData", "");
            ViewData["name"] = (Session["User"] as User).UserName;
            ViewData["id"] = (Session["User"] as User).UserID;
            ViewData["depart"] = (Session["User"] as User).DepartName;
            ViewData["lvl"] = (Session["User"] as User).PermissionLvl;
            ViewData["IsManagerPage"] = (Session["User"] as User).IsManagerPage;
            ViewData["LocationSope"] = (Session["User"] as User).LocationSope;
                
            CommonLib.WriteLog("DynamicController PageCommon Step 2 Menu moveAndBack", "");
            if (!"menu".Equals(Session["moveAndBack"].ToString()))
            {
                Session["moveAndBack"] = "move"; // 페이지 이동(상세 또는 목록 이동)시 세션에 move라는 값을 넣어준다 (검색조건을 히스토리세션에 가져올지 일반 파라미터로 넘어간걸 세팅 해줄지 결정해주는 중요한 세션)  
                List<Menu> menu = new List<Menu>();
                menu = Session["_Menu"] as List<Menu>;

                for (int i = 0; i < menu.Count; i++)
                {
                    if (menu[i].id_Page == page)
                    {
                        Session["selMenuKey"] = menu[i].key_Menu;                        
                    }
                }
            }
            
            CommonLib.WriteLog("DynamicController PageCommon Step 3 Setting Param", "");            

            string userId = (Session["User"] as User).UserID;

            Dictionary<string, object> list = new Dictionary<string, object>();
            Dictionary<string, object> parameter = new Dictionary<string, object>();
            parameter.Add("ProcedureID", page);
            parameter.Add("userId", userId);
            parameter.Add("pageId", pageId);
            ViewData["ID_PAGE"] = pageId;

            list = ComService.DisplayControl(parameter);
            ViewBag.searchArea = Json(list["searchArea"]); //검색조건
            ViewBag.pageFunction = Json(list["pageFunction"]); //페이지에서 사용되는 펑션            
            ViewBag.etcConfigValue = Json(list["etcConfigValue"]); // 기타 설정값
            ViewBag.gridConfigValue = Json(list["gridConfigValue"]); // 그리드 설정값
            ViewBag.gridColSetType = list["gridColSetType"].ToString(); //그리드 컬럼 세팅 타입
            ViewBag.modal = Json(list["modal"]); // 다이얼로그       
            ViewBag.gridColData = Json(list["gridColData"]); // 그리드컬럼           
                
            CommonLib.WriteLog("DynamicController PageCommon Step 4 Setting Menu", "");

            ViewBag.Title = Session["selMenuNm"].ToString() ?? "";

            }
            catch (Exception ex)
            {
                CommonLib.WriteLog("DynamicController PageCommon ex : " + ex.Message, "", true);
                return Redirect("~/");
            }

            CommonLib.WriteLog("DynamicController PageCommon Step 5 Fin Goto CommonPage", "");
            return View("CommonPage");
        }

        //조회
        [HttpPost]
        public JsonResult DynamicSearch(string param)
        {
            var parameter = ComService.ParameterDataSet(param);
            parameter.Add("LANG", "ko-kr");
            parameter.Add("TIMEZONE_MM", Session["timezoneMM"]);
            parameter.Add("ID_USER", (Session["User"] as User).UserID);
            parameter.Add("IP_ADDRESS", (Session["User"] as User).IPAddress);            
            Dictionary<string, object> list = new Dictionary<string, object>();
            list = ComService.DynamicSearch(parameter);

            return ComService.JsonMaxLength(Json(list));
        }
    }
}