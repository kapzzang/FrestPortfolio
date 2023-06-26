using proTnsWeb.Filters;
using proTnsWeb.Models;
using proTnsWeb.Models.Services;
using System;
using System.Collections.Generic;
using System.Web.Mvc;
using System.Data;
using System.Web;
using Portfolio;

namespace proTnsWeb.Controllers
{
    [LoginFilter]
	public class BoardController : Controller
    {
        private readonly Board service = new Board();
        private readonly Common ComService = new Common();

        [LoginFilter]
        public ActionResult PageCommon(string page)
        {
            ViewData["name"] = (Session["User"] as User).UserName;
            ViewData["id"] = (Session["User"] as User).UserID;
            ViewData["depart"] = (Session["User"] as User).DepartName;
            ViewData["lvl"] = (Session["User"] as User).PermissionLvl;
            ViewData["IsManagerPage"] = (Session["User"] as User).IsManagerPage;
            ViewData["LocationSope"] = (Session["User"] as User).LocationSope;

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

            ViewBag.Title = Session["selMenuNm"].ToString() ?? "";

            return View(page);
        }

        //게시판 검색(게시판 관리 Open시 호출)
        public DataSet BoardConfig(string BoardKey)
        {
            Dictionary<string, object> parameter = new Dictionary<string, object>();
            parameter.Add("LANG", "ko-kr");
            parameter.Add("TIMEZONE_MM", Session["timezoneMM"]);
            parameter.Add("ID_USER", (Session["User"] as User).UserID);
            parameter.Add("IP_ADDRESS", (Session["User"] as User).IPAddress);
            parameter.Add("RoleID", Session["RoleID"]);
            parameter.Add("Role", Session["Role"]);
            parameter.Add("SiteID", Session["SiteID"]);
            parameter.Add("GroupID", Session["GroupID"]);
            
            parameter.Add("BoardKey", BoardKey);

            return service.Get_BoardConfig(parameter);           
        }


        //게시판 검색
        [HttpPost]
        public JsonResult BoardList(string param)
        {
            var parameter = ComService.ParameterDataSet(param);
            parameter.Add("LANG", "ko-kr");
            parameter.Add("TIMEZONE_MM", Session["timezoneMM"]);
            parameter.Add("ID_USER", (Session["User"] as User).UserID);
            parameter.Add("IP_ADDRESS", (Session["User"] as User).IPAddress);
            parameter.Add("RoleID", Session["RoleID"]);
            parameter.Add("Role", Session["Role"]);
            parameter.Add("SiteID", Session["SiteID"]);
            parameter.Add("GroupID", Session["GroupID"]);
            Dictionary<string, object> list = new Dictionary<string, object>();
            list = service.Get_BoardList(parameter);

            return ComService.JsonMaxLength(Json(list));
        }

        //게시글 조회
        [HttpPost]
        public JsonResult GetBoardDetail(string param)
        {
            var parameter = ComService.ParameterDataSet(param);
            parameter.Add("LANG", "ko-kr");            
            parameter.Add("ID_USER", (Session["User"] as User).UserID);
            parameter.Add("IP_ADDRESS", (Session["User"] as User).IPAddress);
            
            Dictionary<string, object> list = new Dictionary<string, object>();
            list = service.GetBoardDetail(parameter);

            return ComService.JsonMaxLength(Json(list));
        }        

        //게시글 등록/수정
        [HttpPost]
        public JsonResult SaveBoard(IEnumerable<HttpPostedFileBase> files, string param)
        {
            var parameter = ComService.ParameterDataSet(param);
            parameter.Add("LANG", "ko-kr");            
            parameter.Add("ID_USER", (Session["User"] as User).UserID);
            parameter.Add("IP_ADDRESS", (Session["User"] as User).IPAddress);

            Dictionary<string, object> list = new Dictionary<string, object>();
            list = service.Save_Board(files, parameter);
            
            return ComService.JsonMaxLength(Json(list));
        }

        //게시글 복사
        [HttpPost]
        public JsonResult CopyBoard(string param)
        {
            var parameter = ComService.ParameterDataSet(param);
            parameter.Add("LANG", "ko-kr");            
            parameter.Add("ID_USER", (Session["User"] as User).UserID);
            parameter.Add("IP_ADDRESS", (Session["User"] as User).IPAddress);
            Dictionary<string, object> list = new Dictionary<string, object>();

            list = service.CopyBoard(parameter);
            return ComService.JsonMaxLength(Json(list));
        }

        //게시글 삭제
        [HttpPost]
        public JsonResult DeleteBoard(string param)
        {
            var parameter = ComService.ParameterDataSet(param);
            parameter.Add("LANG", "ko-kr");            
            parameter.Add("ID_USER", (Session["User"] as User).UserID);
            parameter.Add("IP_ADDRESS", (Session["User"] as User).IPAddress);

            Dictionary<string, object> list = new Dictionary<string, object>();

            list = service.DeleteBoard(parameter);
            return ComService.JsonMaxLength(Json(list));
        }

        //덧글 등록
        [HttpPost]
        public int InsertBoardComment(string param)
        {
            var parameter = ComService.ParameterDataSet(param);
            parameter.Add("LANG", "ko-kr");
            parameter.Add("TIMEZONE_MM", Session["timezoneMM"]);
            parameter.Add("ID_USER", (Session["User"] as User).UserID);
            parameter.Add("IP_ADDRESS", (Session["User"] as User).IPAddress);
            parameter.Add("RoleID", Session["RoleID"]);
            parameter.Add("Role", Session["Role"]);
            parameter.Add("SiteID", Session["SiteID"]);
            parameter.Add("GroupID", Session["GroupID"]);

            return service.Insert_BoardComment(parameter);
        }
        
    }
}