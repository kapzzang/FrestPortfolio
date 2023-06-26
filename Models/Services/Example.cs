using System;
using System.Collections.Generic;
using System.Data;
using Portfolio;
using System.Linq;

namespace proTnsWeb.Models.Services
{
    public class Example
    {
        private static List<TestData> testDataList = new List<TestData>();

        //동적쿼리 예제 조회
        public Dictionary<string, object> ExampleListSearch(Dictionary<string, object> parameter)
        {
            Common ComService = new Common();
            
            //그리드 정보 데이터
            string PAGE = parameter.ContainsKey("PAGE") ? parameter["PAGE"] != null ? parameter["PAGE"].ToString() : "" : "";
            string PAGESIZE = parameter.ContainsKey("PAGESIZE") ? parameter["PAGESIZE"] != null ? parameter["PAGESIZE"].ToString() : "" : "";
            string SORTFIELD = parameter.ContainsKey("SORTFIELD") ? parameter["SORTFIELD"] != null ? parameter["SORTFIELD"].ToString() : "" : "";
            string SORTDIR = parameter.ContainsKey("SORTDIR") ? parameter["SORTDIR"] != null ? parameter["SORTDIR"].ToString() : "" : "";
            string FILTER = parameter.ContainsKey("FILTER") ? parameter["FILTER"] != null ? parameter["FILTER"].ToString() : "" : "";

            //엑셀 다운로드 타입
            string TY_EXCEL = parameter.ContainsKey("excelType") ? parameter["excelType"] != null ? parameter["excelType"].ToString() : "" : "";
            string sQuery = string.Format(@"EXEC [dbo].[uspn_ExampleListSearch]
                                                 @PAGE = N'{0}'
                                                , @PAGESIZE = N'{1}'
                                                , @SORTFIELD = N'{2}'
                                                , @SORTDIR = N'{3}'
                                                , @FILTER = N'{4}'
                                                , @TY_EXCEL = N'{5}'
                                          "
                                                , PAGE
                                                , PAGESIZE
                                                , SORTFIELD
                                                , SORTDIR
                                                , FILTER
                                                , TY_EXCEL
                                      );

            return ComService.DataSearch(sQuery, "ExampleListSearch", null, null);
        }

        //동적쿼리 아닌 예제 조회
        public Dictionary<string, object> ExampleListSearch2(Dictionary<string, object> parameter)
        {
            Common ComService = new Common();

            //그리드 정보 데이터
            string TEST1 = parameter.ContainsKey("TEST1") ? parameter["TEST1"] != null ? parameter["TEST1"].ToString() : "" : "";
            string TEST2 = parameter.ContainsKey("TEST2") ? parameter["TEST2"] != null ? parameter["TEST2"].ToString() : "" : "";            
            
            string sQuery = string.Format(@"EXEC [dbo].[uspn_ExampleListSearch2]
                                                 @TEST1 = N'{0}'
                                                , @TEST2 = N'{1}'                                                
                                          "
                                                , TEST1
                                                , TEST2                                                
                                      );

            return ComService.DataSearch(sQuery, "ExampleListSearch2", null, null);
        }

        /// <summary>
        /// 알림 데이터 넣기 예제
        /// </summary>
        /// <param name="parameter"></param>
        /// <returns></returns>
        public Dictionary<string, object> MessageDataInsert(Dictionary<string, object> parameter)
        {
            Common ComService = new Common();

            Dictionary<string, object> result = new Dictionary<string, object>();

            string UserID = parameter.ContainsKey("UserID") ? parameter["UserID"] != null ? parameter["UserID"].ToString() : "" : "";
            string IPAddress = parameter.ContainsKey("IPAddress") ? parameter["IPAddress"] != null ? parameter["IPAddress"].ToString() : "" : "";

            string ds_Category = parameter.ContainsKey("ds_Category") ? parameter["ds_Category"] != null ? parameter["ds_Category"].ToString() : "" : "";
            string ds_Title = parameter.ContainsKey("ds_Title") ? parameter["ds_Title"] != null ? parameter["ds_Title"].ToString() : "" : "";
            string ds_Content = parameter.ContainsKey("ds_Content") ? parameter["ds_Content"] != null ? parameter["ds_Content"].ToString() : "" : "";            

            try
            {
                DataSet ds = new DataSet();

                string sQuery = string.Format(@"EXEC [dbo].[usp_MessageDataInsert]                                                  
                                                @UserID = N'{0}'
                                            ,@IPAddress = N'{1}'
                                            ,@ds_Category = N'{2}'
                                            ,@ds_Title = N'{3}'                                                
                                            ,@ds_Content = N'{4}'                                               
                                                                                        
                                            "
                                            , UserID
                                            , IPAddress
                                            , ds_Category
                                            , ds_Title
                                            , ds_Content
                                        );

                using (DBHelper dbhelper = new DBHelper())
                {
                    ds = dbhelper.ExecuteSql(sQuery, "");
                }

                string msg = (string)ds.Tables[0].Rows[0]["RESULT_MSG"];
                bool successYn = Convert.ToBoolean(ds.Tables[1].Rows[0]["successYn"]);
                result.Add("msg", msg);
                result.Add("successYn", successYn);
                return result;
            }
            catch (Exception ex)
            {
                result.Add("msg", "Error : " + ex.ToString());
                result.Add("successYn", false);
            }
            return result;
        }

        #region CRUD
        /// <summary>
        /// 추가(post)
        /// </summary>
        /// <param name="parameter"></param>
        /// <returns></returns>
        public Dictionary<string, object> PostData(Dictionary<string, object> parameter)
        {
            Common ComService = new Common();

            Dictionary<string, object> result = new Dictionary<string, object>();

            string test1 = parameter.ContainsKey("M_test1") ? parameter["M_test1"]?.ToString() ?? "" : "";
            string test2 = parameter.ContainsKey("M_test2") ? parameter["M_test2"]?.ToString() ?? "" : "";
            string ID_USER = parameter.ContainsKey("ID_USER") ? parameter["ID_USER"]?.ToString() ?? "" : "";
            

            try
            {
                TestData testData = new TestData();

                if (testDataList.Count > 0)
                {                    
                    int maxKey = testDataList.Max(obj => obj.KEY_TEST);
                    testData.KEY_TEST = maxKey + 1;
                }
                else
                {
                    testData.KEY_TEST = 1;
                }

                testData.test1 = test1;
                testData.test2 = test2;
                testData.ID_REG = ID_USER;
                testData.DT_REG = DateTime.Now.ToString("yyyy-MM-dd hh:mm:ss tt");

                testDataList.Add(testData);
                
                result.Add("msg", "추가 되었습니다.");
                result.Add("successYn", true);
                return result;
            }
            catch (Exception ex)
            {
                result.Add("msg", "Error : " + ex.ToString());
                result.Add("successYn", false);
            }
            return result;
        }

        /// <summary>
        /// 조회
        /// </summary>
        /// <param name="parameter"></param>
        /// <returns></returns>
        public Dictionary<string, object> SearchData(Dictionary<string, object> parameter)
        {
            Dictionary<string, object> result = new Dictionary<string, object>();

            string test1 = parameter.ContainsKey("test1") ? parameter["test1"]?.ToString() ?? "" : "";

            List<TestData> data = testDataList.Where(obj => obj.test1.Contains(test1)).ToList();
            result.Add("data", data);
            result.Add("total", data.Count);
            return result;
        }

        /// <summary>
        /// 수정
        /// </summary>
        /// <param name="parameter"></param>
        /// <returns></returns>
        public Dictionary<string, object> PutData(Dictionary<string, object> parameter)
        {
            Common ComService = new Common();

            Dictionary<string, object> result = new Dictionary<string, object>();

            int keyTest = parameter.ContainsKey("M_KEY_D") ? int.Parse(parameter["M_KEY_D"]?.ToString() ?? "") : 0;
            string test1 = parameter.ContainsKey("M_test1_D") ? parameter["M_test1_D"]?.ToString() ?? "" : "";
            string test2 = parameter.ContainsKey("M_test2_D") ? parameter["M_test2_D"]?.ToString() ?? "" : "";
            string ID_USER = parameter.ContainsKey("ID_USER") ? parameter["ID_USER"]?.ToString() ?? "" : "";


            try
            {
                TestData searchResult = testDataList.FirstOrDefault(obj => obj.KEY_TEST == keyTest);
                if (searchResult != null)
                {                    
                    searchResult.test1 = test1;
                    searchResult.test2 = test2;
                    searchResult.ID_UPT = ID_USER;
                    searchResult.DT_UPT = DateTime.Now.ToString("yyyy-MM-dd hh:mm:ss tt");
                }

                result.Add("msg", "수정 되었습니다.");
                result.Add("successYn", true);
                return result;
            }
            catch (Exception ex)
            {
                result.Add("msg", "Error : " + ex.ToString());
                result.Add("successYn", false);
            }
            return result;
        }

        /// <summary>
        /// 삭제
        /// </summary>
        /// <param name="rowData"></param>
        /// <returns></returns>
        public Dictionary<string, object> DelData(string[] rowData)
        {
            Common comService = new Common();
            Dictionary<string, object> result = new Dictionary<string, object>();
            List<Dictionary<string, object>> errList = new List<Dictionary<string, object>>();

            try
            {
                for (int i = 0; i < rowData.Length; i++)
                {
                    var param = comService.ParameterDataSet(rowData[i]);                    
                    int KEY_TEST = param.ContainsKey("KEY_TEST") ? int.Parse(param["KEY_TEST"]?.ToString() ?? "") : 0;

                    testDataList.RemoveAll(obj => obj.KEY_TEST == KEY_TEST);
                }
                result.Add("msg", "삭제 되었습니다.");
                result.Add("successYn", true);
                return result;
            }
            catch (Exception ex)
            {
                result.Add("msg", "Error : " + ex.ToString());
                result.Add("successYn", false);
            }
            return result;
        }
        #endregion
    }
}
