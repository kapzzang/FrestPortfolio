using proTns;
using proTnsWeb.Filters;
using proTnsWeb.Models;
using proTnsWeb.Models.Services;
using System;
using System.Collections.Generic;
using System.IO;
using System.Web.Mvc;
using System.Net;
using System.Security.Claims;
using System.Text;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using Portfolio;

namespace proTnsWeb.Controllers
{
    [LoginFilter]
    public class CommonController : Controller
    {
        private readonly Common commonService = new Common();
		private readonly IMenuService service;	
        
        //드롭다운 리스트 검색
        [HttpPost]
        public JsonResult DropDownListSearch(string param)
        {
			var parameter = commonService.ParameterDataSet(param);			

            Dictionary<string, object> list = new Dictionary<string, object>();
            list = commonService.DropDownListSearch(parameter);
			return commonService.JsonMaxLength(Json(list));
		}

		//멀티셀렉트 리스트 검색
		[HttpPost]
		public JsonResult MultiSelectListSearch(string param)
		{
			var parameter = commonService.ParameterDataSet(param);

			Dictionary<string, object> list = new Dictionary<string, object>();
			list = commonService.MultiSelectListSearch(parameter);
			return commonService.JsonMaxLength(Json(list));
		}

		//드롭다운 및 멀티셀렉트 동적쿼리 화면이 아닌 직접 만든 화면에서 가져오는 경우 사용
		[HttpPost]
		public JsonResult ComDDMTSearch(string param)
		{
			var parameter = commonService.ParameterDataSet(param);

			Dictionary<string, object> list = new Dictionary<string, object>();
			list = commonService.ComDDMTSearch(parameter);
			return commonService.JsonMaxLength(Json(list));
		}

		/// <summary>
		/// 현재 페이지에서 벗어날때마다 세션 history에 값을 담아둔다(검색조건)
		/// </summary>
		/// <param name="param"></param>
		[HttpPost]
		public void PageHistorySet(string param){
			//string formString = Server.UrlDecode(param); //인코딩 된 한글을 디코딩하여 다시 변수에 담는다. --- 한글 더 테스트 후 삭제예정
			Dictionary<string, object> parameter = commonService.ParameterDataSet(param);
			List<Dictionary<string, object>> currentSessionData = new List<Dictionary<string, object>>();
			currentSessionData = Session["history"] as List<Dictionary<string, object>> ?? currentSessionData;
			Session["history"] = commonService.sessionDataSet(parameter, currentSessionData, Path.GetFileName(Request.UrlReferrer.LocalPath));
		}

		/// <summary>
		/// 페이지 접근 시 세션 history에 있는 값 가져오기
		/// </summary>
		/// <returns></returns>
		[HttpPost]
		public JsonResult PageHistoryGet()
		{
			List<Dictionary<string, object>> historyData = new List<Dictionary<string, object>>(); //히스토리 담는 변수
			Dictionary<string, object> beforeData = new Dictionary<string, object>(); // 히스토리중 이전 페이지 값 담는 변수
			string pageId = Path.GetFileName(Request.UrlReferrer.LocalPath); //넘어온 페이지의 id
			historyData = Session["history"] as List<Dictionary<string, object>> ?? historyData; //히스토리 세션 담기
			if(Session["historyMove"] != null){
				//int index = historyData.Count > 4 ? (int)Session["historyMove"] -1 : (int)Session["historyMove"]; //Session["history"] 값이 5이상일 때부터 삭제추가 되므로 그에 맞춰서 index도 변경				
				int index = (int)Session["historyMove"];
					if (historyData.Count > 5){ 
						if (index > 0){
						index = index - 1;
					}
				}
				beforeData = historyData[index] ?? beforeData;
				string key = "";
				foreach (KeyValuePair<string, object> items in beforeData)
				{ //key값 추출
					key = items.Key;
				}
				beforeData = beforeData.ContainsKey(key) ? beforeData[key] as Dictionary<string, object> : beforeData; //key값의 pageid가 있는경우
			}
			else if ("back".Equals(Session["moveAndBack"].ToString())){ //moveAndBack 값에 따라 제어											 
				for(int i = 0; i < historyData.Count; i++){
					if(historyData[i].ContainsKey(pageId)){//해당 페이지의 key가 존재하면
						beforeData = historyData[i] ?? beforeData;
						beforeData = beforeData[pageId] as Dictionary<string, object> ?? beforeData;
					}
				}
			}else if("move".Equals(Session["moveAndBack"].ToString())){
				beforeData = historyData.Count > 0 ? historyData[historyData.Count - 1] : beforeData; //page move 상태이므로 바로 담긴 히스토리 세션 값을 담는다
				string key = "";
				foreach(KeyValuePair<string,object> items in beforeData){ //key값 추출
					key = items.Key;
				}				
				beforeData = beforeData.ContainsKey(key) ? beforeData[key] as Dictionary<string, object> : beforeData; //key값의 pageid가 있는경우
			}else{
				
			}
			Session.Remove("historyMove"); //해당 세션 삭제
			Session["moveAndBack"] = "back"; //기본값 back으로 변경
			return commonService.JsonMaxLength(Json(beforeData));
		}

		/// <summary>
		/// 히스토리 List page명(메뉴명)을 Session["_menu"]에서 추출하여 Session["history"]에 있는 순서대로 데이터를 return
		/// </summary>
		/// <returns></returns>
		[HttpPost]
		public JsonResult HistoryList()
		{
			List<Menu> menuDataList = new List<Menu>(); //메뉴데이터를 담는 변수
			List<Dictionary<string, object>> historyData = new List<Dictionary<string, object>>(); //히스토리 담는 변수						
			historyData = Session["history"] as List<Dictionary<string, object>> ?? historyData; //히스토리 세션 담기			
			string pageId = "";

			int index = 0;//초기값			
			if(historyData.Count > 5){
				index = 1; //초기값 변경 6개부터 하나씩 밀리는 형태로 5개만 보여야됨
			}
			for(int i = index; i < historyData.Count; i++){
				foreach (KeyValuePair<string, object> items in historyData[i])
				{
					pageId = items.Key; //세션 히스토리안에 있는 pageId 즉 key값을 추출
				}
				menuDataList.Add(commonService.PageIdGetMenuData(pageId, Session["_Menu"] as List<Menu>));
			}			
			return commonService.JsonMaxLength(Json(menuDataList));
		}

		/// <summary>
		/// 히스토리 버튼 클릭 시 해당 페이지로 이동
		/// </summary>
		/// <param name="index"></param>
		/// <returns></returns>
		[HttpPost]
		public JsonResult HistoryMove(int index)
		{
			List<Menu> menuDataList = new List<Menu>(); //메뉴데이터를 담는 변수
			List<Dictionary<string, object>> historyData = new List<Dictionary<string, object>>(); //히스토리 담는 변수						
			historyData = Session["history"] as List<Dictionary<string, object>> ?? historyData; //히스토리 세션 담기	
			string pageId = "";
			if(historyData.Count > 5)
			{				
				index = index + 1;							
			}
			foreach (KeyValuePair<string, object> items in historyData[index])
			{
				pageId = items.Key; //세션 히스토리안에 있는 pageId 즉 key값을 추출
			}
			menuDataList.Add(commonService.PageIdGetMenuData(pageId, Session["_Menu"] as List<Menu>));
			Session["historyMove"] = index; //Session["history"]에 있는 검색 조건 중 몇번 째 값을 가져올지 담는다
			return commonService.JsonMaxLength(Json(menuDataList));
		}

		/// <summary>
		/// 현재 사용자가 해당 page의 권한을 가지고 있는 체크하는 메서드
		/// </summary>
		/// <param name="pageId"></param>
		/// <returns></returns>
		[HttpPost]
		public JsonResult UserMenuRoleCheck(string pageId)
		{			
			List<Menu> userMenuList = new List<Menu>(); //현재 사용자의 허용 메뉴 리스트
			userMenuList = Session["_Menu"] as List<Menu> ?? userMenuList; //히스토리 세션 담기	
			Boolean roleCheck = false;

			for(int i = 0; i < userMenuList.Count; i++){
				if(pageId.Equals(userMenuList[i].id_Page)){
					roleCheck = true;
				}
			}
			return commonService.JsonMaxLength(Json(roleCheck));
		}

		/// <summary>
		/// 메뉴로 이동시  Session["moveAndBack"]값을 menu로 변경하여 메뉴 이동시에는  histroy 세션에서 검색조건 가져오지 않게 
		/// </summary>
		[HttpPost]
		public string SessionMoveAndBackChange(string selMenuKey, string selMenuNm, string type)
		{			
			string rs = "";

			//type이 있을 시 (추후에 type에 따라 정의 지금은 토큰을 만들어 url로 이동하는거 밖에 없음)
			if (!type.IsNullOrEmpty())
            {
				//jwt 토큰 생성
				rs = GenerateJwtToken();
            }

			try
			{
				Session["selMenuKey"] = selMenuKey.ToString(); //선택한 메뉴key을 세션에 넣기
				Session["selMenuNm"] = selMenuNm.ToString(); //선택한 메뉴명을 세션에 넣기				
				Session["moveAndBack"] = "menu";
			}
			catch(Exception ex)
			{				
				CommonLib.WriteLog("SessionMoveAndBackChange : " + ex.Message);				
			}
			return rs;
		}

		/// <summary>
		/// 사용자 그리드 컬럼 저장
		/// </summary>
		/// <param name="param">그리드컬럼 정보</param>
		/// <returns></returns>
		[HttpPost]
        public int GridColumnSave(List<String> param)
        {
            string id_user = (Session["User"] as User).UserID.ToString(); //사용자
            string id_page = Path.GetFileName(Request.UrlReferrer.LocalPath); //현재 페이지 id
			string lang = Session["lang"].ToString();
			return commonService.GridColumnSave(param, id_user, id_page, lang);
        }

        /// <summary>
        /// 그리드 컬럼 초기화
        /// </summary>
        /// <param name="param"></param>
        /// <returns></returns>
        [HttpPost]
        public int GridColumnReset()
        {
            string id_user = (Session["User"] as User).UserID.ToString(); //사용자
            string id_page = Path.GetFileName(Request.UrlReferrer.LocalPath); //현재 페이지 id
            return commonService.GridColumnReset(id_user, id_page);
        }

        /// <summary>
        /// 그리드컬럼 조회
        /// </summary>
        /// <param name="param"></param>
        /// <returns></returns>
        [HttpPost]
        public JsonResult GridColumnSearch()
        {
            Dictionary<string, object> parameter = new Dictionary<string, object>();
            parameter.Add("userId", (Session["User"] as User).UserID);
            string pageId = Path.GetFileName(Request.UrlReferrer.LocalPath);
            parameter.Add("pageId", pageId);
            Dictionary<string, object> list = new Dictionary<string, object>();
            list = commonService.GridColumnSearch(parameter);

            return commonService.JsonMaxLength(Json(list));
        }		

		/// <summary>
		/// 서버에서 날짜 가져오기
		/// </summary>
		/// <param name="param"></param>
		/// <returns></returns>
		[HttpPost]
		public JsonResult GetDate(string param)
		{
			var parameter = commonService.ParameterDataSet(param);			
			Dictionary<string, object> list = new Dictionary<string, object>();
			list = commonService.GetDate(parameter);

			return commonService.JsonMaxLength(Json(list));
		}

		/// <summary>
		/// Session Alive Check 
		/// </summary>
		[HttpPost]
		public int SessionCheckLoginStatus()
		{
			CommonLib.WriteLog("CommonController SessionCheckLoginStatus", "");
			return 1;
		}

		/// <summary>
		/// 사용자 검색
		/// </summary>
		/// <param name="param"></param>
		/// <returns></returns>
		[HttpPost]
		public JsonResult SearchUser(string param)
		{
			var parameter = commonService.ParameterDataSet(param);

			Dictionary<string, object> list = new Dictionary<string, object>();
			list = commonService.SearchUser(parameter);
			return commonService.JsonMaxLength(Json(list));
		}

		/// <summary>
		/// 부서 검색
		/// </summary>
		/// <param name="param"></param>
		/// <returns></returns>
		[HttpPost]
		public JsonResult SearchDept(string deptNm)
		{		
			return commonService.JsonMaxLength(Json(commonService.SearchDept(deptNm)));
		}

		/// <summary>
		/// 공통 세션 파라메터
		/// </summary>
		public string CommonParamQuery()
		{
			return string.Format(@"
                            @LANG = N'{0}' ,
                            @ID_USER = N'{1}' ,
                            @IP_ADDRESS = N'{2}'
                            ",
							Session["lang"].ToString(),
							(Session["User"] as User).UserID.ToString(),
							(Session["User"] as User).IPAddress.ToString()
							);
		}

		/// <summary>		
		/// 세션값중에 공통으로 사용되는 파라미터를 추가하면됨
		/// </summary>
		/// <param name="param"></param>
		/// <returns></returns>
		public Dictionary<string, object> SetSessionParam(string param)
        {
			var parameter = commonService.ParameterDataSet(param);
			parameter.Add("UserID", (Session["User"] as User).UserID);
			parameter.Add("IPAddress", (Session["User"] as User).IPAddress);
			return parameter;
		}

		/// <summary>
		/// 토큰생성
		/// </summary>		
		/// <returns></returns>
		public string GenerateJwtToken()
		{
			CommonLib.WriteLog("GenerateJwtToken Start");
			string jwt = "";
			try
            {
				string id = (Session["User"] as User).UserID;
				//현재 사용자의 id를 토큰 claim 값으로 생성
				List<Claim> claimList = new List<Claim>
				{
					new Claim("id", id)
				};

				//토큰 secret key로 사용할 문자열을 인코딩
				byte[] secret = Encoding.UTF8.GetBytes("Azure_Virtual_Desktop_Token_JWT_secret"); //해당key는 임의로 바꿔되나 받는 쪽에서도 똑같은 key를 사용해야함

				//secret key를 통해 SymmetricSecurityKey 생성
				SymmetricSecurityKey key = new SymmetricSecurityKey(secret);

				string algorithm = SecurityAlgorithms.HmacSha256;

				//토큰인증시 사용할 sign을 만듬
				SigningCredentials signingCredentials = new SigningCredentials(key, algorithm);

				JwtSecurityToken token = new JwtSecurityToken
				(
					System.Web.Compilation.AppSettingsExpressionBuilder.GetAppSetting("AVDDomain").ToString(), //발급 도메인
					System.Web.Compilation.AppSettingsExpressionBuilder.GetAppSetting("ADSyncxWebDomain").ToString(), //받는 도메인
					claimList,//토큰안에 파라미터를 담은 list (복호화가 시워 노출되도 되는 데이터만 넣기)
					notBefore: DateTime.Now, //생성시간
					expires: DateTime.Now.AddMinutes(3), //만료시간
					signingCredentials //인증
				);

				//토큰생성
				jwt = new JwtSecurityTokenHandler().WriteToken(token);
				CommonLib.WriteLog("WriteToken");
			}
            catch(Exception ex) {
				CommonLib.WriteLog("Error GenerateJwtToken : " + ex.ToString()); ;
			}
			return jwt;
		}
	}
}
