using proTnsWeb.Filters;
using proTnsWeb.Models;
using proTnsWeb.Models.Services;
using System.Collections.Generic;
using System.Web.Mvc;

namespace proTnsWeb.Controllers
{
    [LoginFilter]
    public class ExampleController : Controller
    {
        private readonly Common ComService = new Common();
        private readonly Example ExampleService = new Example();        

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

        /// <summary>
        /// 동적쿼리 예제 조회
        /// </summary>
        /// <param name="param"></param>
        /// <returns></returns>
        [HttpPost]
        public JsonResult ExampleListSearch(string param)
        {
            var parameter = ComService.ParameterDataSet(param);           
            Dictionary<string, object> list = new Dictionary<string, object>();
            list = ExampleService.ExampleListSearch(parameter);

            return ComService.JsonMaxLength(Json(list));
        }
        
        /// <summary>
        /// 동적쿼리 아닌 예제 조회
        /// </summary>
        /// <param name="param"></param>
        /// <returns></returns>
        [HttpPost]
        public JsonResult ExampleListSearch2(string param)
        {
            var parameter = ComService.ParameterDataSet(param);
            Dictionary<string, object> list = new Dictionary<string, object>();
            list = ExampleService.ExampleListSearch2(parameter);

            return ComService.JsonMaxLength(Json(list));
        }

        /// <summary>
        /// 데이터보내기 FORM
        /// </summary>
        /// <param name="param"></param>
        /// <returns></returns>
        [HttpPost]
        public JsonResult ExampleFormDataSend(string param)
        {
            var parameter = ComService.ParameterDataSet(param);
            return ComService.JsonMaxLength(Json(parameter));
        }

        /// <summary>
        /// 알림 데이터 넣기 예제
        /// </summary>
        /// <param name="param"></param>
        /// <returns></returns>
        public JsonResult MessageDataInsert(string param)
        {
            var parameter = ComService.ParameterDataSet(param);
            Dictionary<string, object> list = new Dictionary<string, object>();
            list = ExampleService.MessageDataInsert(parameter);

            return ComService.JsonMaxLength(Json(list));
        }

        #region CRUD
        /// <summary>
        /// 추가 (post)
        /// </summary>
        /// <param name="param"></param>
        /// <returns></returns>
        [HttpPost]
        public JsonResult PostData(string param)
        {
            var parameter = ComService.ParameterDataSet(param);
            parameter.Add("ID_USER", (Session["User"] as User).UserID);
            Dictionary<string, object> list = new Dictionary<string, object>();
            list = ExampleService.PostData(parameter);

            return ComService.JsonMaxLength(Json(list));
        }
        
        /// <summary>
        /// 조회
        /// </summary>
        /// <param name="param"></param>
        /// <returns></returns>
        public JsonResult SearchData(string param)
        {
            var parameter = ComService.ParameterDataSet(param);
            Dictionary<string, object> list = new Dictionary<string, object>();
            list = ExampleService.SearchData(parameter);

            return ComService.JsonMaxLength(Json(list));
        }

        /// <summary>
        /// 수정
        /// </summary>
        /// <param name="param"></param>
        /// <returns></returns>
        public JsonResult PutData(string param)
        {
            var parameter = ComService.ParameterDataSet(param);
            parameter.Add("ID_USER", (Session["User"] as User).UserID);
            Dictionary<string, object> list = new Dictionary<string, object>();
            list = ExampleService.PutData(parameter);

            return ComService.JsonMaxLength(Json(list));
        }

        /// <summary>
        /// 삭제
        /// </summary>
        /// <param name="param"></param>
        /// <returns></returns>
        public JsonResult DelData(string[] rowData)
        {            
            Dictionary<string, object> list = new Dictionary<string, object>();
            list = ExampleService.DelData(rowData);

            return ComService.JsonMaxLength(Json(list));
        }

        #endregion
    }
}