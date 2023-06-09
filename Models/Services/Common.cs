using Newtonsoft.Json.Linq;
using Newtonsoft.Json;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Web.Mvc;
using System.ServiceProcess;
using System.Data.SqlClient;
using Portfolio;

namespace proTnsWeb.Models.Services
{
    public class Common
    {
        // 다국어 리소스 리스트 조회
        public DataSet GetResourceLangDataSet()
        {
            string sQuery = "EXEC uspn_GetResourceLang";
            DBHelper dbhelper = new DBHelper();
            DataSet ds = new DataSet();

            ds = dbhelper.ExecuteSql(sQuery, "");

            return ds;
        }

        //DropDown
        public Dictionary<string, object> DropDownListSearch(Dictionary<string, object> parameter)
        {
            Common ComService = new Common();

            string QUERY_DD = parameter.ContainsKey("QUERY_DD") ? parameter["QUERY_DD"] != null ? parameter["QUERY_DD"].ToString() : "" : ""; //드롭다운 값을 조회할 쿼리문

            string sQuery = QUERY_DD;

            return ComService.DataSearch(sQuery, "DropDownListSearch", parameter, null);
        }

        //MultiSelect
        public Dictionary<string, object> MultiSelectListSearch(Dictionary<string, object> parameter)
        {
            Common ComService = new Common();

            string QUERY_MS = parameter.ContainsKey("QUERY_MS") ? parameter["QUERY_MS"] != null ? parameter["QUERY_MS"].ToString() : "" : ""; //드롭다운 값을 조회할 쿼리문

            string sQuery = QUERY_MS;

            return ComService.DataSearch(sQuery, "MultiSelectListSearch", parameter, null);
        }

        //드롭다운 및 멀티셀렉트 동적쿼리 화면이 아닌 직접 만든 화면에서 가져오는 경우 사용
        public Dictionary<string, object> ComDDMTSearch(Dictionary<string, object> parameter)
        {
            Common ComService = new Common();

            string param = parameter.ContainsKey("param") ? parameter["param"] != null ? parameter["param"].ToString() : "" : ""; //실행 할 sp의 명 (앞에 usp_를 뺀)
            string TY_PRE = parameter.ContainsKey("TY_PRE") ? parameter["TY_PRE"] != null ? parameter["TY_PRE"].ToString() : "" : ""; //값이 Y면 SP_NAME 접두어가 uspn으로 변경

            //변수명 (현재 최대 10개까지만 지원)
            string vName1 = parameter.ContainsKey("vName1") ? parameter["vName1"] != null ? parameter["vName1"].ToString() : "" : "";
            string vName2 = parameter.ContainsKey("vName2") ? parameter["vName2"] != null ? parameter["vName2"].ToString() : "" : "";
            string vName3 = parameter.ContainsKey("vName3") ? parameter["vName3"] != null ? parameter["vName3"].ToString() : "" : "";
            string vName4 = parameter.ContainsKey("vName4") ? parameter["vName4"] != null ? parameter["vName4"].ToString() : "" : "";
            string vName5 = parameter.ContainsKey("vName5") ? parameter["vName5"] != null ? parameter["vName5"].ToString() : "" : "";
            string vName6 = parameter.ContainsKey("vName6") ? parameter["vName6"] != null ? parameter["vName6"].ToString() : "" : "";
            string vName7 = parameter.ContainsKey("vName7") ? parameter["vName7"] != null ? parameter["vName7"].ToString() : "" : "";
            string vName8 = parameter.ContainsKey("vName8") ? parameter["vName8"] != null ? parameter["vName8"].ToString() : "" : "";
            string vName9 = parameter.ContainsKey("vName9") ? parameter["vName9"] != null ? parameter["vName9"].ToString() : "" : "";
            string vName10 = parameter.ContainsKey("vName10") ? parameter["vName10"] != null ? parameter["vName10"].ToString() : "" : "";

            //변수 값 (현재 최대 10개까지만 지원)
            string vVal1 = parameter.ContainsKey("vVal1") ? parameter["vVal1"] != null ? parameter["vVal1"].ToString() : "" : "";
            string vVal2 = parameter.ContainsKey("vVal2") ? parameter["vVal2"] != null ? parameter["vVal2"].ToString() : "" : "";
            string vVal3 = parameter.ContainsKey("vVal3") ? parameter["vVal3"] != null ? parameter["vVal3"].ToString() : "" : "";
            string vVal4 = parameter.ContainsKey("vVal4") ? parameter["vVal4"] != null ? parameter["vVal4"].ToString() : "" : "";
            string vVal5 = parameter.ContainsKey("vVal5") ? parameter["vVal5"] != null ? parameter["vVal5"].ToString() : "" : "";
            string vVal6 = parameter.ContainsKey("vVal6") ? parameter["vVal6"] != null ? parameter["vVal6"].ToString() : "" : "";
            string vVal7 = parameter.ContainsKey("vVal7") ? parameter["vVal7"] != null ? parameter["vVal7"].ToString() : "" : "";
            string vVal8 = parameter.ContainsKey("vVal8") ? parameter["vVal8"] != null ? parameter["vVal8"].ToString() : "" : "";
            string vVal9 = parameter.ContainsKey("vVal9") ? parameter["vVal9"] != null ? parameter["vVal9"].ToString() : "" : "";
            string vVal10 = parameter.ContainsKey("vVal10") ? parameter["vVal10"] != null ? parameter["vVal10"].ToString() : "" : "";

            string sQuery = string.Format(@"EXEC [dbo].[usp_ComDDMTSearch]
                                                    @SP_NAME = N'{0}'
                                                   ,@TY_PRE = N'{1}'
                                                   ,@vName1  = N'{2}'
                                                   ,@vName2  = N'{3}'
                                                   ,@vName3  = N'{4}'
                                                   ,@vName4  = N'{5}'
                                                   ,@vName5  = N'{6}'
                                                   ,@vName6  = N'{7}'
                                                   ,@vName7  = N'{8}'
                                                   ,@vName8  = N'{9}'
                                                   ,@vName9  = N'{10}'
                                                   ,@vName10   = N'{11}'                                                  
                                                   ,@vVal1   = N'{12}'
                                                   ,@vVal2   = N'{13}'
                                                   ,@vVal3   = N'{14}'
                                                   ,@vVal4   = N'{15}'
                                                   ,@vVal5   = N'{16}'
                                                   ,@vVal6   = N'{17}'
                                                   ,@vVal7   = N'{18}'
                                                   ,@vVal8   = N'{19}'
                                                   ,@vVal9   = N'{20}'
                                                   ,@vVal10   = N'{21}'
                                                   "
                                                    , param
                                                    , TY_PRE
                                                    , vName1
                                                    , vName2
                                                    , vName3
                                                    , vName4
                                                    , vName5
                                                    , vName6
                                                    , vName7
                                                    , vName8
                                                    , vName9
                                                    , vName10
                                                    , vVal1
                                                    , vVal2
                                                    , vVal3
                                                    , vVal4
                                                    , vVal5
                                                    , vVal6
                                                    , vVal7
                                                    , vVal8
                                                    , vVal9
                                                    , vVal10
                                                   );

            return ComService.DataSearch(sQuery, "ComDDMTSearch", parameter, null);
        }

        //json 타입형 string 값을 parameter 로 변경 하는 메서드
        public Dictionary<string, object> ParameterDataSet(string param)
        {
            JObject jsonData = JObject.Parse(param);



            Dictionary<string, object> parameter = new Dictionary<string, object>();
            foreach (var item in jsonData)
            {
                string key = item.Key;

                string filterString = "";
                if ("FILTER".Equals(key))
                {
                    foreach (var filterItem in item.Value.First)
                    {
                        foreach (var valItem in filterItem)
                        {
                            if ("gte".Equals(valItem["operator"].ToString()))
                            {
                                string date = string.Format("{0:yyyy-MM-dd}", Convert.ToDateTime(valItem["value"]).AddDays(1));
                                filterString += " AND " + valItem["field"].ToString() + " >= ''" + date + "''";
                            }
                            else
                            {
                                //특수문자 치환하기
                                var val = SpecialCharReplace(valItem["value"].ToString());
                                filterString += " AND " + valItem["field"].ToString() + " LIKE ''%''+''" + val + "''+''%''";
                            }
                        }
                    }
                    parameter.Add(key, filterString);
                }
                else
                {
                    //파라미터 값의 타입에 따라 sql 인젝션 방지 수정 추가
                    //배열 형태로 데이터가 들어왔을 경우 ArrayList로 변환하여 파라미터 추가 2022.09.01                    
                    //2022-09-06 MOD HS ArrayList 변환과정 생략을 위해 string배열로 변경
                    if (item.Value.GetType().Name == "JArray")
                    {
                        string[] JArr = (string[])item.Value.ToObject(typeof(string[]));
                        string[] valArr = new string[JArr.Length];

                        for (int i = 0; i < JArr.Length; i++)
                        {
                            //sql 인젝션 방지
                            valArr[i] = SqlInjectionReplace(JArr[i]);
                        }

                        parameter.Add(key, valArr);
                    }
                    else
                    {
                        //sql 인젝션 방지
                        //2023.03.23.ksh 그리드 컬럼 저장 시 true 가 True되어 그리드 show/hide기능이 안되어 추가함
                        if ("True".Equals(item.Value.ToString()) || "False".Equals(item.Value.ToString()))
                        {
                            parameter.Add(key, SqlInjectionReplace(item.Value.ToString().ToLower()));
                        }
                        else
                        {
                            parameter.Add(key, SqlInjectionReplace(item.Value.ToString()));
                        }                        
                    }
                }
            }
            return parameter;
        }

        //formData 파라미터로 만들기
        public Dictionary<string, object> formParamSet(string formString)
        {

            Dictionary<string, object> parameter = new Dictionary<string, object>();
            if (!string.IsNullOrEmpty(formString))
            {
                string[] formSplit1 = formString.Split(new string[] { "&" }, 0); // jumpData split Data 1차
                string[] formSplit2; //2차 split 변수

                Dictionary<string, object> formData = new Dictionary<string, object>();

                for (int i = 0; i < formSplit1.Length; i++)
                {
                    formSplit2 = formSplit1[i].Split(new string[] { "=" }, 0);
                    formData.Add(formSplit2[0], formSplit2[1]);
                }
                parameter.Add("formData", formData);
            }
            else
            {
                parameter.Add("formData", null);
            }
            return parameter;
        }

        /// <summary>
        /// formData를 session에 담기(히스토리로 사용)
        /// </summary>
        /// <param name="parameter"></param>
        /// <param name="currentSessionData"></param>
        /// <param name="pageId"></param>
        /// <returns></returns>
        public List<Dictionary<string, object>> sessionDataSet(Dictionary<string, object> parameter, List<Dictionary<string, object>> currentSessionData, string pageId)
        {
            Dictionary<string, object> pageData = new Dictionary<string, object>();
            pageData.Add(pageId, parameter);

            //똑같은 히스토리가 쌓여도 되는 방식으로...
            if (currentSessionData.Count > 5)
            { //최대 5개의 history를 가지고있는다
                currentSessionData.RemoveAt(0);
                currentSessionData.Add(pageData);
            }
            else
            {
                currentSessionData.Add(pageData);
            }
            return currentSessionData;
        }

        /// <summary>
        ///  Json데이터 MaxLength조정 결과값이 많으면 기본 length보다 길어져 에러처리를 위해 사용
        /// </summary>
        /// <param name="jsonData">json데이터</param>
        /// <returns>jsonResult</returns>		
        public JsonResult JsonMaxLength(JsonResult jsonData)
        {
            jsonData.MaxJsonLength = 2147483647; //해당 숫자는 제공해주는 최대값
            return jsonData;
        }

        /// <summary>
        /// 페이지 ID에 해당되는 Session[_menu] 데이터 가져오기
        /// </summary>
        /// <param name="pageId"></param>
        /// <param name="menuData"></param>
        /// <returns></returns>
        public Menu PageIdGetMenuData(string pageId, List<Menu> menuDataList)
        {
            Menu menuData = new Menu();
            //컴퓨터 상세 페이지 일 경우 (추후 이런 페이지가 많이 질 경우 테이블생성,컬럼추가 등 관리할 수 있도록 수정필요)
            if ("ComputerDetail".Equals(pageId))
            {
                menuData.nm_Menu = "컴퓨터 상세";
                menuData.url_Menu = "~/Common/MoveDetailPage/ComputerDetail";
            }
            else
            {
                for (int i = 0; i < menuDataList.Count; i++)
                {
                    if (pageId.Equals(menuDataList[i].id_Page))
                    {
                        menuData = menuDataList[i];
                    }
                }
            }
            return menuData;
        }


        //화면제어
        public Dictionary<string, object> DisplayControl(Dictionary<string, object> parameter)
        {
            Common ComService = new Common();
            Dictionary<string, object> lists = new Dictionary<string, object>();

            string ProcedureID = parameter.ContainsKey("ProcedureID") ? parameter["ProcedureID"] != null ? parameter["ProcedureID"].ToString() : "" : "";
            string userId = parameter.ContainsKey("userId") ? parameter["userId"] != null ? parameter["userId"].ToString() : "" : "";
            string pageId = parameter.ContainsKey("pageId") ? parameter["pageId"] != null ? parameter["pageId"].ToString() : "" : "";

            string type = "config"; //화면 환경설정 조회            

            string sQuery = string.Format(@"EXEC [dbo].[" + ProcedureID + "] @TYPE = N'{0}', @ID_USER = N'{1}', @ID_PROCEDURE = N'{2}', @ID_PAGE = N'{3}'"
                                                    , type
                                                    , userId
                                                    , ProcedureID
                                                    , pageId
                                                );

            return ComService.DataSearch(sQuery, "DisplayControl", null, null);
        }


        /// <summary>
        /// 공통 데이터 조회 메서드
        /// </summary>
        /// <param name="sQuery"></param> 실행할 쿼리문
        /// <param name="execMethodNm"></param> DataSearch를 실행 시키는 메서드명
        /// <param name="parameter"></param> 데이터 조회시 사용 하던 parameter
        /// <param name="listData"></param> 이미 만들어진 Dictionary에 추가로 넣어야되는경우 인자값으로 Dictionary를 넘겨준다. (window10현황에서 사용중)
        /// <returns></returns>
        //데이터 조회
        public Dictionary<string, object> DataSearch(string sQuery, string execMethodNm, Dictionary<string, object> parameter, Dictionary<string, object> listData)
        {
            return DataSearch(sQuery, execMethodNm, parameter, listData, "");
        }

        public Dictionary<string, object> DataSearch(string sQuery, string execMethodNm, Dictionary<string, object> parameter, Dictionary<string, object> listData, string DatabaseName)
        {
            Dictionary<string, object> lists = new Dictionary<string, object>();
            string DBName = String.IsNullOrEmpty(DatabaseName) ? "" : DatabaseName;

            if (listData != null)
            {
                lists = listData;
            }

            try
            {
                using (DBHelper dbhelper = new DBHelper(DBName))
                {
                    DataSet ds = new DataSet();
                    ds = dbhelper.ExecuteSql(sQuery, "");
                    if (ds.Tables.Count > 0)
                    {
                        for (int k = 0; k < ds.Tables.Count; k++)
                        {
                            List<Dictionary<string, object>> list = new List<Dictionary<string, object>>();
                            DataTable table1 = ds.Tables[k];
                            DataRow[] rows = table1.Select();
                            DataColumnCollection cols = table1.Columns;

                            for (int i = 0; i < rows.Length; i++)
                            {
                                Dictionary<string, object> data = new Dictionary<string, object>();
                                for (int j = 0; j < cols.Count; j++)
                                {
                                    //타입이 DateTime & 'UTC_'로 시작하는 경우 타임존을 적용하여 view로 보낸다
                                    if (("DateTime".Equals(rows[i][j].GetType().Name)) && (cols[j].ColumnName.ToUpper().Substring(0, 4) == "UTC_"))
                                    {
                                        int timeZone = Convert.ToInt16(parameter["timezoneMM"]);
                                        DateTime dt = Convert.ToDateTime(rows[i][j]);
                                        dt = dt.AddMinutes(+timeZone);
                                        data.Add(cols[j].ToString(), dt);
                                    }
                                    //@*@ 예약어가 존재 시 Resources에서 데이터를 가져와 치환해준다.
                                    else if (rows[i][j].ToString().IndexOf("@*@") != -1)
                                    {
                                        //동적 화면제어일때 데이터 넘어오는 형식이 다르므로 소스를 변경함
                                        //동적 화면제어 데이터 중 검색조건 부분을 가져올때 데이터 형태가 string (test,test1)이렇게 넘어옴
                                        //split을 통해 각각 해당값을 치환 후 다시 string 형태로 만들어 데이터로 넣어줌                                        
                                        string[] row = rows[i][j].ToString().Split(',');
                                        string stringText = "";
                                        for (int rowLen = 0; rowLen < row.Length; rowLen++)
                                        {
                                            string resoruceText = row[rowLen].ToString().Replace("@*@", "");
                                            string resoruce = "";
                                            if (row[rowLen].ToString().IndexOf("@*@") != -1)
                                            {
                                                resoruce = Portfolio.Resources.GetString(resoruceText);
                                            }
                                            else
                                            {
                                                resoruce = resoruceText;
                                            }

                                            if (rowLen > 0)
                                            {
                                                stringText += ",";
                                            }
                                            stringText += resoruce;
                                        }
                                        data.Add(cols[j].ToString(), stringText);
                                    }
                                    //ESCAPEHTML_로 시작하는 컬럼중 15자 보다 큰경우 HtmlDecode한 값을 리턴
                                    else if (cols[j].ColumnName.Length > 15)
                                    {
                                        if (cols[j].ColumnName.ToUpper().Substring(0, 11) == "ESCAPEHTML_")
                                            data.Add(cols[j].ToString(), System.Web.HttpUtility.HtmlDecode(rows[i][j].ToString()));
                                        else
                                            data.Add(cols[j].ToString(), rows[i][j]);
                                    }
                                    else
                                    {
                                        if (("DateTime".Equals(rows[i][j].GetType().Name)))
                                        {
                                            data.Add(cols[j].ToString(), rows[i][j]);
                                        }
                                        else
                                        {
                                            data.Add(cols[j].ToString(), rows[i][j].ToString());
                                        }
                                    }
                                }

                                list.Add(data);
                            }

                            //DataSearch 함수를 사용하는 함수명에 따라 분기
                            if ("DisplayControl".Equals(execMethodNm))
                            {
                                if (k == 0) { lists.Add("searchArea", list); } //검색조건
                                if (k == 1) { lists.Add("pageFunction", list); } //페이지에서 사용되는 펑션                                                                   
                                if (k == 2) { lists.Add("etcConfigValue", list); } //기타 설정값
                                if (k == 3) { lists.Add("gridConfigValue", list); } //그리드 설정값 
                                if (k == 4) { lists.Add("gridColSetType", list[0]["colSetType"]); } //그리드 컬럼 세팅 타입 구분값        
                                if (k == 5) { lists.Add("modal", list); } //다이얼로그 설정값
                                if (k == 6) { lists.Add("gridColData", list); } //그리드컬럼 데이터
                            }                           
                            else if ("TableToJson".Equals(execMethodNm))
                            {
                                lists.Add("Table" + k.ToString(), list);
                            }
                            else if ("BoardList".Equals(execMethodNm))
                            {
                                if (k == 0) { lists.Add("data", list); }
                                if (k == 1) { lists.Add("comment", list); }
                                if (k == 2) { lists.Add("attachfile", list); }
                            }
                            else
                            {
                                if (k == 0) { lists.Add("data", list); }
                                if (k == 1) { lists.Add("total", list); }
                            }
                        }

                        //lists에 페이지 펑션이 있는 경우만 실행
                        if (lists.ContainsKey("pageFunction")) { 
                            //드롭다운     
                            List<Dictionary<string, object>> pageFunction = new List<Dictionary<string, object>>();
                            pageFunction = lists["pageFunction"] as List<Dictionary<string, object>>;
                            if (pageFunction[0].ContainsKey("QUERY_DD") && !string.IsNullOrEmpty(pageFunction[0]["QUERY_DD"].ToString()))
                            {

                                List<Dictionary<string, object>> dropDownList = new List<Dictionary<string, object>>();
                                string[] dropList = pageFunction[0]["QUERY_DD"].ToString().Split('&');
                                string ddJsonStr = "";
                                for (int i = 0; i < dropList.Length; i++)
                                {
                                    Dictionary<string, object> queryParam = new Dictionary<string, object>();
                                    queryParam.Add("QUERY_DD", dropList[i]);
                                    Dictionary<string, object> dropDown = new Dictionary<string, object>();
                                    dropDown = DropDownListSearch(queryParam);
                                    ddJsonStr += JsonConvert.SerializeObject(dropDown);
                                    if (i != dropList.Length - 1)
                                    {
                                        ddJsonStr += "**";
                                    }
                                }
                                pageFunction[0].Add("DDList", ddJsonStr);
                            }
                            //멀티셀렉트
                            if (pageFunction[0].ContainsKey("QUERY_MS") && !string.IsNullOrEmpty(pageFunction[0]["QUERY_MS"].ToString()))
                            {

                                List<Dictionary<string, object>> multiSelect = new List<Dictionary<string, object>>();
                                string[] multiList = pageFunction[0]["QUERY_MS"].ToString().Split('&');
                                string msJsonStr = "";
                                for (int i = 0; i < multiList.Length; i++)
                                {
                                    Dictionary<string, object> queryParam = new Dictionary<string, object>();
                                    queryParam.Add("QUERY_MS", multiList[i]);
                                    Dictionary<string, object> multisel = new Dictionary<string, object>();
                                    multisel = MultiSelectListSearch(queryParam);
                                    msJsonStr += JsonConvert.SerializeObject(multisel);
                                    if (i != multiList.Length - 1)
                                    {
                                        msJsonStr += "**";
                                    }
                                }
                                pageFunction[0].Add("MSList", msJsonStr);
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                System.Diagnostics.EventLog.WriteEntry("Application", execMethodNm + "  : " + ex.ToString(), System.Diagnostics.EventLogEntryType.Information);
            }

            return lists;
        }

        /// <summary>
        /// 날짜 파라미터를 TimeZone을 추가하여 변환 해주는 메서드
        /// DB에 있는 날짜 데이터는 GMT 0 날짜 데이터이므로 현재 지역에 알맞게 검색 하려면 timeZone을 빼줘야한다.
        /// </summary>
        /// <param name="date"></param>
        /// <param name="timeZone"></param>
        /// <param name="type">시작일 S 종료일 E</param>
        /// <returns></returns>
        public string TimeZoneChange(string date, int timeZone, string type)
        {
            string dateTz = "";
            if ("S".Equals(type))
            {
                dateTz = date + " 00:00:00";
            }
            else
            {
                dateTz = date + " 23:59:59";
            }

            DateTime dt = Convert.ToDateTime(dateTz);
            dt = dt.AddMinutes(-timeZone);
            dateTz = dt.ToString("yyyy-MM-dd HH:mm:ss");
            return dateTz;
        }


        /// <summary>
        /// 사용자 그리드 컬럼 저장
        /// </summary>
        /// <param name="param">그리드컬럼 정보</param>
        /// <returns></returns>
        public int GridColumnSave(List<String> param, string id_user, string id_page, string lang)
        {
            int result = 0;

            try
            {
                //컬럼 데이터 만큼 반복
                for (int i = 0; i < param.Count; i++)
                {
                    int colSort = i; //컬럼 순서 변수
                    string field = null; // 필드 변수
                    Dictionary<string, object> columnData = ParameterDataSet(param[i]); //string 타입에 json형 데이터를 변환

                    //컬럼 데이터 안에 있는 데이터 만큼 반복
                    foreach (var item in columnData)
                    {
                        string key = item.Key;
                        string value = item.Value.ToString();
                        string attribute = null;
                        string attributeValue = null; //빈값을 가질수 있음

                        //데이터가 row단위로 쌓여야함
                        //key값이 field일 경우 필드 컬럼에 필드를 넣어줘야 되므로 field에 먼저 값을 채워둠
                        //해당 조건으로 인해 field명이 바뀔때마다 field 정보가 바뀔수 있음
                        if ("field".Equals(key))
                        {
                            field = value;
                        }
                        else
                        {
                            attribute = key;
                            attributeValue = value;
                        }

                        //속성 값이 존재 할때만 데이터를 넣어줌 (필드 마다 맨처음은 속성데이터가 없으므로 체크해줘야함)
                        if (!String.IsNullOrEmpty(attribute))
                        {
                            //여기에 insert 하는 프로시저를...
                            string sQuery = string.Format(@"EXEC [dbo].[uspn_SetGridColumns]
                                                           @Lang = N'{0}'
                                                          ,@id_page = N'{1}'
                                                          ,@id_user = N'{2}'
                                                          ,@colSort = N'{3}'
                                                          ,@field = N'{4}'
                                                          ,@attribute = N'{5}'
                                                          ,@attributeValue = N'{6}'
                                                          ", lang, id_page, id_user, colSort, field, attribute, attributeValue);
                            using (DBHelper dbhelper = new DBHelper())
                            {
                                DataSet ds = new DataSet();
                                ds = dbhelper.ExecuteSql(sQuery, "");
                                result = 1;
                            }
                        }
                    }
                }
            }

            catch (Exception ex)
            {
                System.Diagnostics.EventLog.WriteEntry("Application", "GridColumnSave  : " + ex.ToString(), System.Diagnostics.EventLogEntryType.Information);
            }
            return result;
        }

        /// <summary>
        /// 그리드 컬럼 초기화
        /// </summary>
        /// <param name="id_user"></param>
        /// <param name="id_page"></param>
        /// <returns></returns>
        public int GridColumnReset(string id_user, string id_page)
        {
            string sQuery = string.Format(@"EXEC [dbo].[uspn_GridColumnsReset] @id_user = N'{0}', @id_page = N'{1}'", id_user, id_page);
            int result = 0; // 성공이면 1 아니면 0
            try
            {
                using (DBHelper dbhelper = new DBHelper())
                {
                    DataSet ds = new DataSet();
                    ds = dbhelper.ExecuteSql(sQuery, "");
                    result = 1;
                }
            }
            catch (Exception ex)
            {
                System.Diagnostics.EventLog.WriteEntry("Application", "GridColumnReset  : " + ex.ToString(), System.Diagnostics.EventLogEntryType.Information);
            }
            return result;
        }

        //그리드 컬럼 검색
        public Dictionary<string, object> GridColumnSearch(Dictionary<string, object> parameter)
        {
            Common ComService = new Common();

            string pageId = parameter.ContainsKey("pageId") ? parameter["pageId"] != null ? parameter["pageId"].ToString() : "" : "";
            string userId = parameter.ContainsKey("userId") ? parameter["userId"] != null ? parameter["userId"].ToString() : "" : "";

            string sQuery = string.Format(@"EXEC [dbo].[uspn_GetGridColumn]                                                    
                                                     @pageId = N'{0}'
                                                    ,@userId = N'{1}'
                                                   "
                                                    , pageId
                                                    , userId
                                             );

            return ComService.DataSearch(sQuery, "GridColumnSearch", parameter, null);
        }

        //동적 화면 검색
        public Dictionary<string, object> DynamicSearch(Dictionary<string, object> parameter)
        {
            Common ComService = new Common();

            //히스토리 기록
            string IP_ADDRESS = parameter.ContainsKey("IP_ADDRESS") ? parameter["IP_ADDRESS"] != null ? parameter["IP_ADDRESS"].ToString() : "" : "";

            string TYPE = "data"; //동적 프로시저 데이터 조회 타입설정
            string ID_PROCEDURE = parameter.ContainsKey("ID_PROCEDURE") ? parameter["ID_PROCEDURE"] != null ? parameter["ID_PROCEDURE"].ToString() : "" : "";
            string ID_PAGE = parameter.ContainsKey("ID_PAGE") ? parameter["ID_PAGE"] != null ? parameter["ID_PAGE"].ToString() : "" : "";
            string LANG = parameter.ContainsKey("LANG") ? parameter["LANG"] != null ? parameter["LANG"].ToString() : "" : ""; // 언어 default : ko-kr  , en-us : 영어
            string ID_USER = parameter.ContainsKey("ID_USER") ? parameter["ID_USER"] != null ? parameter["ID_USER"].ToString() : "" : "";

            //그리드 정보 데이터
            string PAGE = parameter.ContainsKey("PAGE") ? parameter["PAGE"] != null ? parameter["PAGE"].ToString() : "" : "";
            string PAGESIZE = parameter.ContainsKey("PAGESIZE") ? parameter["PAGESIZE"] != null ? parameter["PAGESIZE"].ToString() : "" : "";
            string SORTFIELD = parameter.ContainsKey("SORTFIELD") ? parameter["SORTFIELD"] != null ? parameter["SORTFIELD"].ToString() : "" : "";
            string SORTDIR = parameter.ContainsKey("SORTDIR") ? parameter["SORTDIR"] != null ? parameter["SORTDIR"].ToString() : "" : "";
            string FILTER = parameter.ContainsKey("FILTER") ? parameter["FILTER"] != null ? parameter["FILTER"].ToString() : "" : "";

            //엑셀 다운로드 타입
            string TY_EXCEL = parameter.ContainsKey("excelType") ? parameter["excelType"] != null ? parameter["excelType"].ToString() : "" : "";

            //검색조건 데이터 (현재 최대 8개까지만 지원)
            string CONDITION1 = parameter.ContainsKey("CONDITION1") ? parameter["CONDITION1"] != null ? parameter["CONDITION1"].ToString() : "" : "";
            string CONDITION2 = parameter.ContainsKey("CONDITION2") ? parameter["CONDITION2"] != null ? parameter["CONDITION2"].ToString() : "" : "";
            string CONDITION3 = parameter.ContainsKey("CONDITION3") ? parameter["CONDITION3"] != null ? parameter["CONDITION3"].ToString() : "" : "";
            string CONDITION4 = parameter.ContainsKey("CONDITION4") ? parameter["CONDITION4"] != null ? parameter["CONDITION4"].ToString() : "" : "";
            string CONDITION5 = parameter.ContainsKey("CONDITION5") ? parameter["CONDITION5"] != null ? parameter["CONDITION5"].ToString() : "" : "";
            string CONDITION6 = parameter.ContainsKey("CONDITION6") ? parameter["CONDITION6"] != null ? parameter["CONDITION6"].ToString() : "" : "";
            string CONDITION7 = parameter.ContainsKey("CONDITION7") ? parameter["CONDITION7"] != null ? parameter["CONDITION7"].ToString() : "" : "";
            string CONDITION8 = parameter.ContainsKey("CONDITION8") ? parameter["CONDITION8"] != null ? parameter["CONDITION8"].ToString() : "" : "";            

            string sQuery = string.Format(@"EXEC [dbo].[{0}]
                                                 @ID_PAGE = N'{1}'
                                                ,@TYPE = N'{2}'
                                                ,@PAGE = N'{3}'
                                                ,@PAGESIZE = N'{4}'
                                                ,@SORTFIELD = N'{5}'
                                                ,@SORTDIR = N'{6}'
                                                ,@FILTER = N'{7}'          
                                                ,@TY_EXCEL = N'{8}'
                                                ,@LANG = N'{9}'
                                                ,@ID_USER = N'{10}'
                                                ,@IP_ADDRESS = N'{11}'
                                                ,@CONDITION1 = N'{12}'
                                                ,@CONDITION2 = N'{13}'
                                                ,@CONDITION3 = N'{14}'
                                                ,@CONDITION4 = N'{15}'
                                                ,@CONDITION5 = N'{16}'
                                                ,@CONDITION6 = N'{17}'
                                                ,@CONDITION7 = N'{18}'
                                                ,@CONDITION8 = N'{19}'                                                
                                                "
                                                , ID_PROCEDURE
                                                , ID_PAGE
                                                , TYPE
                                                , PAGE
                                                , PAGESIZE
                                                , SORTFIELD
                                                , SORTDIR
                                                , FILTER
                                                , TY_EXCEL
                                                , LANG
                                                , ID_USER
                                                , IP_ADDRESS
                                                , CONDITION1
                                                , CONDITION2
                                                , CONDITION3
                                                , CONDITION4
                                                , CONDITION5
                                                , CONDITION6
                                                , CONDITION7
                                                , CONDITION8                                                
                                                );

            return ComService.DataSearch(sQuery, "DynamicSearch", parameter, null);
        }

        //DataSet Dictionary 변환
        public Dictionary<string, object> DataSetToDictionary(DataSet ds)
        {
            ArrayList dataArr = new ArrayList();
            if (ds.Tables.Count > 0)
            {
                if (ds.Tables[0].Rows.Count > 0)
                {
                    try
                    {
                        for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
                        {
                            Dictionary<string, object> dataList = new Dictionary<string, object>();
                            foreach (DataColumn serverInfo in ds.Tables[0].Columns)

                            {
                                dataList.Add(serverInfo.ColumnName.ToString(), ds.Tables[0].Rows[i][serverInfo.ColumnName.ToString()].ToString());
                            }

                            dataArr.Add(dataList);

                        }
                    }
                    catch (Exception ex)
                    {
                        System.Diagnostics.EventLog.WriteEntry("Application", "DataSetToDictionary  : " + ex.ToString(), System.Diagnostics.EventLogEntryType.Information);
                    }
                }


                //그리드 데이터
                Dictionary<string, object> rs = new Dictionary<string, object>();
                rs.Add("data", dataArr);

                //그리드 카운트
                Dictionary<string, object> total = new Dictionary<string, object>();
                total.Add("TOTAL", ds.Tables[0].Rows.Count);

                ArrayList totalArr = new ArrayList();
                totalArr.Add(total);
                rs.Add("total", totalArr);

                return rs;
            }
            return null;
        }

        //서버 날짜 조회
        public Dictionary<string, object> GetDate(Dictionary<string, object> parameter)
        {
            Common ComService = new Common();

            string type = parameter.ContainsKey("type") ? parameter["type"] != null ? parameter["type"].ToString() : "" : "";
            string num = parameter.ContainsKey("num") ? parameter["num"] != null ? parameter["num"].ToString() : "" : "";

            string sQuery = string.Format(@"EXEC [dbo].[uspn_GetDate]                                                    
                                                     @type = N'{0}'
                                                    ,@num = N'{1}'
                                                   "
                                                    , type
                                                    , num
                                             );

            return ComService.DataSearch(sQuery, "GetDate", parameter, null);
        }

        /// <summary>
        /// SQL 인젝션 방지 
        /// </summary>
        /// <param name="str"></param>
        /// <returns></returns>
        public string SqlInjectionReplace(string str)
        {      
            if (str.IndexOf("''''") != -1)
            {
                str = str.Replace("''''", "");
            }

            if (str.IndexOf("\"\"") != -1)
            {
                str = str.Replace("\"\"", "");
            }

            return str;
        }

        /// <summary>
        /// 특수문자 치환하기
        /// 검색 시 특수문자를 포함하여 검색 하고 싶을때 필요
        /// </summary>
        /// <param name="str"></param>
        /// <returns></returns>
        public string SpecialCharReplace(string str)
        {
            if (str.IndexOf('[') != -1)
            {
                str = str.Replace("[", "[[]");
            }

            if (str.IndexOf('%') != -1)
            {
                str = str.Replace("%", "[%]");
            }

            if (str.IndexOf('_') != -1)
            {
                str = str.Replace("_", "[_]");
            }         

            return str;
        }

        /// <summary>
        /// 사용자 검색
        /// </summary>
        /// <param name="parameter"></param>
        /// <returns></returns>
        public Dictionary<string, object> SearchUser(Dictionary<string, object> parameter)
        {
            Common ComService = new Common();

            //그리드 정보 데이터
            string PAGE = parameter.ContainsKey("PAGE") ? parameter["PAGE"] != null ? parameter["PAGE"].ToString() : "" : "";
            string PAGESIZE = parameter.ContainsKey("PAGESIZE") ? parameter["PAGESIZE"] != null ? parameter["PAGESIZE"].ToString() : "" : "";
            string SORTFIELD = parameter.ContainsKey("SORTFIELD") ? parameter["SORTFIELD"] != null ? parameter["SORTFIELD"].ToString() : "" : "";
            string SORTDIR = parameter.ContainsKey("SORTDIR") ? parameter["SORTDIR"] != null ? parameter["SORTDIR"].ToString() : "" : "";
            string FILTER = parameter.ContainsKey("FILTER") ? parameter["FILTER"] != null ? parameter["FILTER"].ToString() : "" : "";
            string TY_EXCEL = parameter.ContainsKey("TY_EXCEL") ? parameter["TY_EXCEL"] != null ? parameter["TY_EXCEL"].ToString() : "" : "";

            //검색조건
            string userName = parameter.ContainsKey("userName") ? parameter["userName"] != null ? parameter["userName"].ToString() : "" : "";
            string deptName = parameter.ContainsKey("deptName") ? parameter["deptName"] != null ? parameter["deptName"].ToString() : "" : "";

            string sQuery = string.Format(@"EXEC [dbo].[usp_SearchUser]                                                                                                          
                                                      @PAGE = N'{0}'
                                                     ,@PAGESIZE = N'{1}'
                                                     ,@SORTFIELD = N'{2}'
                                                     ,@SORTDIR = N'{3}'
                                                     ,@FILTER = N'{4}'
                                                     ,@TY_EXCEL = N'{5}' 
                                                     ,@userName = N'{6}'      
                                                     ,@deptName = N'{7}'      
                                                   "
                                                    , PAGE
                                                    , PAGESIZE
                                                    , SORTFIELD
                                                    , SORTDIR
                                                    , FILTER
                                                    , TY_EXCEL
                                                    , userName
                                                    , deptName
                                             );

            return ComService.DataSearch(sQuery, "SearchUser", parameter, null);
        }

        /// <summary>
        /// 부서 검색
        /// </summary>
        /// <param name="parameter"></param>
        /// <returns></returns>
        public Dictionary<string, object> SearchDept(Dictionary<string, object> parameter)
        {
            Common ComService = new Common();

            //검색조건            
            string deptNm = parameter.ContainsKey("deptNm") ? parameter["deptNm"] != null ? parameter["deptNm"].ToString() : "" : "";

            string sQuery = string.Format(@"EXEC [dbo].[uspn_GetVdiOrg]                                                                                                          
                                                      @DEPT_NM = N'{0}'                                                      
                                                   "
                                                    , deptNm
                                             );

            return ComService.DataSearch(sQuery, "SearchDept", parameter, null);
        }

        /// <summary>
        /// 서비스 상태 세팅
        /// </summary>
        /// <param name="serviceName"></param>
        /// <returns></returns>
        public string GetServiceStatus(string serviceName)
        {
            ServiceController sc = new ServiceController(serviceName);

            CommonLib.WriteLog("GetServiceStatus serviceName : " + serviceName);

            string serviceStatus = "";

            switch (sc.Status)
            {
                case ServiceControllerStatus.Running:
                    serviceStatus = "Running";
                    break;
                case ServiceControllerStatus.Stopped:
                    serviceStatus = "Stopped";
                    break;
                case ServiceControllerStatus.Paused:
                    serviceStatus = "Paused";
                    break;
                case ServiceControllerStatus.StopPending:
                    serviceStatus = "Stopping";
                    break;
                case ServiceControllerStatus.StartPending:
                    serviceStatus = "Starting";
                    break;
                default:
                    serviceStatus = "Status Changing";
                    break;
            }
            CommonLib.WriteLog("GetServiceStatus serviceStatus : " + serviceStatus);
            return serviceStatus;
        }

        /// <summary>
        /// sqlDataReader를 string에 담기
        /// 일단 공통 부분으로 생각되어 공통 모델쪽에 추가함
        /// </summary>
        /// <param name="read"></param>
        /// <returns></returns>
        public string sqlDataReaderRead(SqlDataReader read)
        {
            string result = "";
            while (read.Read())
            {
                result = read[0].ToString();
            }
            return result;
        }
    }
}
