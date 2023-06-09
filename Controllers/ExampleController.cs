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
    }
}