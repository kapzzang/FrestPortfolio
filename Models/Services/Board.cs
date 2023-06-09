using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Web;
using Portfolio;
using System.Data.SqlClient;
using System.IO;

namespace proTnsWeb.Models.Services
{
    public class Board
    {

        // 게시판 정보 조회
        public DataSet Get_BoardConfig(Dictionary<string, object> parameter)
        {
            Common ComService = new Common();

            //히스토리 기록
            string IP_ADDRESS = parameter.ContainsKey("IP_ADDRESS") ? parameter["IP_ADDRESS"] != null ? parameter["IP_ADDRESS"].ToString() : "" : "";
            string LANG = parameter.ContainsKey("LANG") ? parameter["LANG"] != null ? parameter["LANG"].ToString() : "" : ""; // 언어 default : ko-kr  , en-us : 영어
            string ID_USER = parameter.ContainsKey("ID_USER") ? parameter["ID_USER"] != null ? parameter["ID_USER"].ToString() : "" : "";

            //세션 공통값
            string RoleID = parameter.ContainsKey("RoleID") ? parameter["RoleID"] != null ? parameter["RoleID"].ToString() : "" : "";
            string Role = parameter.ContainsKey("Role") ? parameter["Role"] != null ? parameter["Role"].ToString() : "" : "";
            string SiteID = parameter.ContainsKey("SiteID") ? parameter["SiteID"] != null ? parameter["SiteID"].ToString() : "" : "";
            string GroupID = parameter.ContainsKey("GroupID") ? parameter["GroupID"] != null ? parameter["GroupID"].ToString() : "" : "";

            // 게시판 정보 검색
            string BoardKey = parameter.ContainsKey("BoardKey") ? parameter["BoardKey"] != null ? parameter["BoardKey"].ToString() : "" : "";

            string sQuery = string.Format(@"EXEC [dbo].[usp_Get_BoardConfig]
                                                @LANG = N'{0}'
                                                ,@ID_USER = N'{1}'
                                                ,@IP_ADDRESS = N'{2}'
                                                ,@RoleID = N'{3}'
                                                ,@Role = N'{4}'
                                                ,@SiteID = N'{5}'
                                                ,@GroupID = N'{6}'
                                                ,@BoardKey = N'{7}'
                                                "
                                                , LANG
                                                , ID_USER
                                                , IP_ADDRESS
                                                , RoleID
                                                , Role
                                                , SiteID
                                                , GroupID
                                                , BoardKey
                                                );

            DataSet ds = new DataSet();
            try
            {
                using (DBHelper dbhelper = new DBHelper())
                {
                    ds = dbhelper.ExecuteSql(sQuery, "");
                }
            }
            catch (Exception ex)
            {
                System.Diagnostics.EventLog.WriteEntry("Application", "Save_Board  : " + ex.ToString(), System.Diagnostics.EventLogEntryType.Information);
            }
            return ds;
            //return ComService.DataSearch(sQuery, "BoardConfig", parameter, null, "ProTnsBoard");
        }

        //User Web 게시판 조회
        public mBoard Get_BoardListTopX(Dictionary<string, object> parameter)
        {

            mBoard mBoard = new mBoard();
            //히스토리 기록
            string IP_ADDRESS = parameter.ContainsKey("IP_ADDRESS") ? parameter["IP_ADDRESS"] != null ? parameter["IP_ADDRESS"].ToString() : "" : "";
            string LANG = parameter.ContainsKey("LANG") ? parameter["LANG"] != null ? parameter["LANG"].ToString() : "" : ""; // 언어 default : ko-kr  , en-us : 영어
            string ID_USER = parameter.ContainsKey("ID_USER") ? parameter["ID_USER"] != null ? parameter["ID_USER"].ToString() : "" : "";

            //세션 공통값
            string RoleID = parameter.ContainsKey("RoleID") ? parameter["RoleID"] != null ? parameter["RoleID"].ToString() : "" : "";
            string Role = parameter.ContainsKey("Role") ? parameter["Role"] != null ? parameter["Role"].ToString() : "" : "";
            string SiteID = parameter.ContainsKey("SiteID") ? parameter["SiteID"] != null ? parameter["SiteID"].ToString() : "" : "";
            string GroupID = parameter.ContainsKey("GroupID") ? parameter["GroupID"] != null ? parameter["GroupID"].ToString() : "" : "";

            // 게시판 검색
            string TopX = parameter.ContainsKey("TopX") ? parameter["TopX"] != null ? parameter["TopX"].ToString() : "5" : "5";

            string sQuery = string.Format(@"EXEC [dbo].usp_Get_BoardListTopX
                                                @LANG = N'{0}'
                                                ,@ID_USER = N'{1}'
                                                ,@IP_ADDRESS = N'{2}'
                                                ,@RoleID = N'{3}'
                                                ,@Role = N'{4}'
                                                ,@SiteID = N'{5}'
                                                ,@GroupID = N'{6}'
                                                ,@TopX = N'{7}'
                                                "
                                                , LANG
                                                , ID_USER
                                                , IP_ADDRESS
                                                , RoleID
                                                , Role
                                                , SiteID
                                                , GroupID
                                                , TopX
                                                );

            using (DBHelper dbhelper = new DBHelper("ProTnsBoard"))
            {
                DataSet ds = new DataSet();
                ds = dbhelper.ExecuteSql(sQuery, "");

                if (ds.Tables.Count > 1)
                {
                    List<BoardConfig> BoardConfigs = new List<BoardConfig>();

                    foreach (DataRow drow in ds.Tables[0].Rows)
                    {
                        BoardConfig BoardConfig = new BoardConfig();

                        BoardConfig.SortOrder = Convert.ToInt32(drow["SortOrder"]);
                        BoardConfig.BoardKey = Convert.ToString(drow["BoardKey"]);
                        BoardConfig.BoardTitle = Convert.ToString(drow["BoardTitle"]);
                        BoardConfig.Collapsed = Convert.ToString(drow["Collapsed"]);
                        BoardConfig.BoxColor = Convert.ToString(drow["BoxColor"]);

                        BoardConfigs.Add(BoardConfig);
                    }

                    List<BoardData> BoardLists = new List<BoardData>();

                    foreach (DataRow drow in ds.Tables[1].Rows)
                    {
                        BoardData BoardData = new BoardData();

                        BoardData.BoardSID = Convert.ToInt32(drow["BoardSID"]);
                        BoardData.BoardKey = Convert.ToString(drow["BoardKey"]);
                        BoardData.wNum = Convert.ToInt32(drow["wNum"]);
                        BoardData.wUser = Convert.ToString(drow["wUser"]);
                        BoardData.wTitle = Convert.ToString(drow["wTitle"]);
                        BoardData.wContent = Convert.ToString(drow["wContent"]);
                        BoardData.wPlainContent = Convert.ToString(drow["wPlainContent"]);
                        BoardData.wfileName = Convert.ToString(drow["wfileName"]);
                        BoardData.wfileExt = Convert.ToString(drow["wfileExt"]);
                        BoardData.wfileSize = Convert.ToInt32(drow["wfileSize"]);
                        BoardData.wDate = Convert.ToDateTime(drow["wDate"]);
                        BoardData.wReadCount = Convert.ToInt32(drow["wReadCount"]);
                        BoardData.delFlg = Convert.ToString(drow["delFlg"]);
                        BoardData.SiteID = Convert.ToInt64(drow["SiteID"]);
                        BoardData.GroupID = Convert.ToInt64(drow["GroupID"]);
                        BoardData.wDateYYMMDD = Convert.ToString(drow["wDateYYMMDD"]);

                        BoardLists.Add(BoardData);
                    }

                    mBoard.BoardConfigList = BoardConfigs;
                    mBoard.BoardList = BoardLists;
                }
            }

            return mBoard;
        }

        //게시판 조회
        public Dictionary<string, object> Get_BoardList(Dictionary<string, object> parameter)
        {
            Common ComService = new Common();

            //히스토리 기록
            string IP_ADDRESS = parameter.ContainsKey("IP_ADDRESS") ? parameter["IP_ADDRESS"] != null ? parameter["IP_ADDRESS"].ToString() : "" : "";
            string LANG = parameter.ContainsKey("LANG") ? parameter["LANG"] != null ? parameter["LANG"].ToString() : "" : ""; // 언어 default : ko-kr  , en-us : 영어
            string ID_USER = parameter.ContainsKey("ID_USER") ? parameter["ID_USER"] != null ? parameter["ID_USER"].ToString() : "" : "";

            //그리드 정보 데이터
            string PAGE = parameter.ContainsKey("PAGE") ? parameter["PAGE"] != null ? parameter["PAGE"].ToString() : "" : "";
            string PAGESIZE = parameter.ContainsKey("PAGESIZE") ? parameter["PAGESIZE"] != null ? parameter["PAGESIZE"].ToString() : "" : "";
            string SORTFIELD = parameter.ContainsKey("SORTFIELD") ? parameter["SORTFIELD"] != null ? parameter["SORTFIELD"].ToString() : "" : "";
            string SORTDIR = parameter.ContainsKey("SORTDIR") ? parameter["SORTDIR"] != null ? parameter["SORTDIR"].ToString() : "" : "";
            string FILTER = parameter.ContainsKey("FILTER") ? parameter["FILTER"] != null ? parameter["FILTER"].ToString() : "" : "";

            //세션 공통값
            string RoleID = parameter.ContainsKey("RoleID") ? parameter["RoleID"] != null ? parameter["RoleID"].ToString() : "" : "";
            string Role = parameter.ContainsKey("Role") ? parameter["Role"] != null ? parameter["Role"].ToString() : "" : "";
            string SiteID = parameter.ContainsKey("SiteID") ? parameter["SiteID"] != null ? parameter["SiteID"].ToString() : "" : "";
            string GroupID = parameter.ContainsKey("GroupID") ? parameter["GroupID"] != null ? parameter["GroupID"].ToString() : "" : "";

            // 게시판 검색
            string BoardKey = parameter.ContainsKey("BoardKey") ? parameter["BoardKey"] != null ? parameter["BoardKey"].ToString() : "" : "";
            string SearchType = parameter.ContainsKey("SearchType") ? parameter["SearchType"] != null ? parameter["SearchType"].ToString() : "" : "";
            string SearchText = parameter.ContainsKey("SearchText") ? parameter["SearchText"] != null ? parameter["SearchText"].ToString() : "" : "";

            string sQuery = string.Format(@"EXEC [dbo].usp_Get_BoardList
                                                @LANG = N'{0}'
                                                ,@ID_USER = N'{1}'
                                                ,@IP_ADDRESS = N'{2}'
                                                ,@RoleID = N'{3}'
                                                ,@Role = N'{4}'
                                                ,@SiteID = N'{5}'
                                                ,@GroupID = N'{6}'
                                                ,@PAGE = N'{7}'
                                                ,@PAGESIZE = N'{8}'
                                                ,@SORTFIELD = N'{9}'
                                                ,@SORTDIR = N'{10}'
                                                ,@FILTER = N'{11}'  
                                                ,@BoardKey = N'{12}'
                                                ,@SearchType = N'{13}'
                                                ,@SearchText = N'{14}'
                                                "
                                                , LANG
                                                , ID_USER
                                                , IP_ADDRESS
                                                , RoleID
                                                , Role
                                                , SiteID
                                                , GroupID
                                                , PAGE
                                                , PAGESIZE
                                                , SORTFIELD
                                                , SORTDIR
                                                , FILTER
                                                , BoardKey
                                                , SearchType
                                                , SearchText
                                                );

            return ComService.DataSearch(sQuery, "Get_BoardList", parameter, null, "ProTnsBoard");
        }

        // 게시글 조회
        public Dictionary<string, object> GetBoardDetail(Dictionary<string, object> parameter)
        {
            Common ComService = new Common();

            //히스토리 기록
            string IP_ADDRESS = parameter.ContainsKey("IP_ADDRESS") ? parameter["IP_ADDRESS"] != null ? parameter["IP_ADDRESS"].ToString() : "" : "";
            string LANG = parameter.ContainsKey("LANG") ? parameter["LANG"] != null ? parameter["LANG"].ToString() : "" : ""; // 언어 default : ko-kr  , en-us : 영어
            string ID_USER = parameter.ContainsKey("ID_USER") ? parameter["ID_USER"] != null ? parameter["ID_USER"].ToString() : "" : "";            

            // 게시판 검색
            string BoardKey = parameter.ContainsKey("BoardKey") ? parameter["BoardKey"] != null ? parameter["BoardKey"].ToString() : "" : "";
            string wNum = parameter.ContainsKey("wNum") ? parameter["wNum"] != null ? parameter["wNum"].ToString() : "" : "";

            string sQuery = string.Format(@"EXEC [dbo].[uspn_Get_BoardDetail]
                                                @LANG = N'{0}'
                                                ,@ID_USER = N'{1}'
                                                ,@IP_ADDRESS = N'{2}'                                                
                                                ,@BoardKey = N'{3}'
                                                ,@wNum = N'{4}'
                                                "
                                                , LANG
                                                , ID_USER
                                                , IP_ADDRESS                                                
                                                , BoardKey
                                                , wNum
                                                );

            return ComService.DataSearch(sQuery, "BoardList", parameter, null, null);
        }       

        //게시글 등록/수정
        public Dictionary<string, object> Save_Board(IEnumerable<HttpPostedFileBase> files, Dictionary<string, object> parameter)
        {

            Common ComService = new Common();

            Dictionary<string, object> result = new Dictionary<string, object>();

            //히스토리 기록
            string LANG = parameter.ContainsKey("LANG") ? parameter["LANG"] != null ? parameter["LANG"].ToString() : "" : ""; // 언어 default : ko-kr  , en-us : 영어
            string IP_ADDRESS = parameter.ContainsKey("IP_ADDRESS") ? parameter["IP_ADDRESS"] != null ? parameter["IP_ADDRESS"].ToString() : "" : "";            
            string ID_USER = parameter.ContainsKey("ID_USER") ? parameter["ID_USER"] != null ? parameter["ID_USER"].ToString() : "" : "";

            // 게시판 데이터
            string BoardKey = parameter.ContainsKey("BoardKey") ? parameter["BoardKey"] != null ? parameter["BoardKey"].ToString() : "" : "";            
            string wNum = parameter.ContainsKey("wNum") ? parameter["wNum"] != null ? parameter["wNum"].ToString() : "" : "";
            string wTitle = parameter.ContainsKey("wTitle") ? parameter["wTitle"] != null ? parameter["wTitle"].ToString() : "" : "";
            string wContent = parameter.ContainsKey("wContent") ? parameter["wContent"] != null ? parameter["wContent"].ToString() : "" : "";
            string wPlainContent = parameter.ContainsKey("wPlainContent") ? parameter["wPlainContent"] != null ? parameter["wPlainContent"].ToString() : "" : "";

            string yn_Publish = parameter.ContainsKey("yn_Publish") ? parameter["yn_Publish"] != null ? parameter["yn_Publish"].ToString() : "" : "";
            string ExpireDate = parameter.ContainsKey("ExpireDate") ? parameter["ExpireDate"] != null ? parameter["ExpireDate"].ToString() : "" : "";

            string EnchImgwContent = "";
            try
            {
                // html Decoding
                string DecwContent = HttpUtility.HtmlDecode(wContent);
                // whitelist check
                string whitewContent = Portfolio.cHtmlSanitizer.Sanitize(DecwContent);
                // image style change
                string hImgwContent = Portfolio.cHtmlSanitizer.ImgAddStyle(whitewContent);
                // html Encoding                
                EnchImgwContent = HttpUtility.HtmlEncode(hImgwContent);

                // 게시판 내용 저장시 ' 변환                
                EnchImgwContent = EnchImgwContent.Replace("'", "''");
            }
            catch
            {
                // 게시판 내용 저장시 ' 변환                
                EnchImgwContent = wContent.Replace("'", "''");
            }
            wPlainContent = wPlainContent.Replace("'", "''");

            DBHelper dbhelper = new DBHelper();
            string sConn = "";
            sConn = dbhelper.getDBConStrings();


            SqlConnection sqlCon = new SqlConnection(sConn);
            SqlCommand cmd = new SqlCommand();
            cmd.Connection = sqlCon;
            //DB연결
            sqlCon.Open();

            CommonLib.WriteLog("**게시판 정보 저장 Start**");
            //트랜잭션 시작
            cmd.Transaction = cmd.Connection.BeginTransaction();

            string sQuery = string.Format(@"EXEC [dbo].[uspn_Save_Board]
                                                @LANG = N'{0}'
                                                ,@ID_USER = N'{1}'
                                                ,@IP_ADDRESS = N'{2}'                                                
                                                ,@BoardKey = N'{3}'
                                                ,@wNum = N'{4}'
                                                ,@wTitle = N'{5}'
                                                ,@wContent = N'{6}'
                                                ,@wPlainContent = N'{7}'                                                                                                
                                                ,@yn_Publish = N'{8}'
                                                ,@wExpireDate = N'{9}'
                                                "
                                                , LANG
                                                , ID_USER
                                                , IP_ADDRESS
                                                , BoardKey
                                                , wNum
                                                , wTitle
                                                , EnchImgwContent       //wContent
                                                , wPlainContent                                                
                                                , yn_Publish
                                                , ExpireDate
                                      );
            
            try
            {

                ArrayList saveBoardArr = new ArrayList();
                cmd.CommandText = sQuery;
                SqlDataReader saveBoardRD = cmd.ExecuteReader();
                do
                {
                    saveBoardArr.Add(ComService.sqlDataReaderRead(saveBoardRD));
                } while (saveBoardRD.NextResult());

                string msg = saveBoardArr[0].ToString();
                bool successYn = Convert.ToBoolean(saveBoardArr[1]);                
                //신규일때 wNum 받아오기
                if ("".Equals(wNum))
                {
                    wNum = saveBoardArr[2].ToString();
                }

                saveBoardRD.Close();                

                if (successYn && files != null)
                {
                    CommonLib.WriteLog("**Save_Board file Upload Start**");
                    try
                    {                       

                        foreach (var file in files)
                        {
                            //파일 명 중복방지
                            string fileNmStr = BoardKey + wNum + DateTime.Now.ToString("yyyyMMddHHmmss") + file.FileName;
                            string fileName = Path.GetFileName(file.FileName);
                            string Extension = Path.GetExtension(file.FileName);                                    
                            //실제경로
                            string path = Path.Combine(HttpContext.Current.Server.MapPath("~/file/Board"), fileNmStr);
                            //상대경로
                            string relativePath = "\\" + fileNmStr;

                            // File Size Byte
                            int wfileSize = file.ContentLength;

                            string nQuery = string.Format(@"EXEC [dbo].[uspn_Save_BoardFile]
                                                @LANG = N'{0}'
                                                ,@ID_USER = N'{1}'
                                                ,@IP_ADDRESS = N'{2}'                                                
                                                ,@BoardKey = N'{3}'
                                                ,@wNum = N'{4}'
                                                ,@wfileName = N'{5}'
                                                ,@wfileExt = N'{6}'
                                                ,@wfileSize = N'{7}'                                                                                                
                                                ,@wfilePath = N'{8}'                                                
                                                "
                                                , LANG
                                                , ID_USER
                                                , IP_ADDRESS
                                                , BoardKey
                                                , wNum
                                                , fileName
                                                , Extension
                                                , wfileSize
                                                , relativePath
                                      );

                            ArrayList uArr = new ArrayList();
                            cmd.CommandText = nQuery;
                            SqlDataReader uRD = cmd.ExecuteReader();
                            do
                            {
                                uArr.Add(ComService.sqlDataReaderRead(uRD));
                            } while (uRD.NextResult());
                            
                            bool successRs = Convert.ToBoolean(uArr[0]);

                            if (successRs)
                            {
                                // 파일 저장
                                file.SaveAs(path);
                                uRD.Close();
                                CommonLib.WriteLog("**File Save : "+fileName+" **");
                            }
                            else
                            {
                                msg = uArr[1].ToString();
                                CommonLib.WriteLog("**Fail File Save "+ fileName +" msg : "+msg+ " **");
                            }                            
                        }
                        CommonLib.WriteLog("**Save_Board file Upload END**");
                    }
                    catch (Exception ex)
                    {
                        CommonLib.WriteLog("Error Save_Board file upload : " + ex.ToString());
                        msg = "File upload failed.";
                        successYn = false;                        
                        
                        //오류 발생시 자동 rollback 되나 트랜잭션이 남아있으면 rollback 
                        if (cmd.Transaction != null)
                        {
                            cmd.Transaction.Rollback();
                        }
                    }
                }                
                result.Add("msg", msg);
                result.Add("successYn", successYn);
                //트랜잭션 Commit 
                cmd.Transaction.Commit();
                sqlCon.Close();
                CommonLib.WriteLog("게시판 등록 완료");
            }
            catch (Exception ex)
            {
                System.Diagnostics.EventLog.WriteEntry("Application", "Save_Board  : " + ex.ToString(), System.Diagnostics.EventLogEntryType.Information);
                CommonLib.WriteLog("Error Save_Board : " + ex.ToString());
                result.Add("msg", "Error : " + ex.ToString());
                result.Add("successYn", false);
            }
            return result;
        }

        //게시글 복사
        public Dictionary<string,object> CopyBoard(Dictionary<string, object> parameter)
        {
            Dictionary<string, object> result = new Dictionary<string, object>();

            //히스토리 기록
            string IP_ADDRESS = parameter.ContainsKey("IP_ADDRESS") ? parameter["IP_ADDRESS"] != null ? parameter["IP_ADDRESS"].ToString() : "" : "";
            string LANG = parameter.ContainsKey("LANG") ? parameter["LANG"] != null ? parameter["LANG"].ToString() : "" : ""; // 언어 default : ko-kr  , en-us : 영어
            string ID_USER = parameter.ContainsKey("ID_USER") ? parameter["ID_USER"] != null ? parameter["ID_USER"].ToString() : "" : "";

            // 게시판 데이터
            string BoardKey = parameter.ContainsKey("BoardKey") ? parameter["BoardKey"] != null ? parameter["BoardKey"].ToString() : "" : "";
            string wNum = parameter.ContainsKey("wNum") ? parameter["wNum"] != null ? parameter["wNum"].ToString() : "" : "";

            string sQuery = string.Format(@"EXEC [dbo].[uspn_Copy_Board]
                                                @LANG = N'{0}'
                                                ,@ID_USER = N'{1}'
                                                ,@IP_ADDRESS = N'{2}'                                                
                                                ,@BoardKey = N'{3}'
                                                ,@wNum = N'{4}'
                                                "
                                                , LANG
                                                , ID_USER
                                                , IP_ADDRESS                                                
                                                , BoardKey
                                                , wNum
                                      );
            
            try
            {
                using (DBHelper dbhelper = new DBHelper())
                {
                    DataSet ds = new DataSet();
                    ds = dbhelper.ExecuteSql(sQuery, "");
                    string msg = (string)ds.Tables[0].Rows[0]["RESULT_MSG"];
                    bool successYn = Convert.ToBoolean(ds.Tables[1].Rows[0]["successYn"]);

                    result.Add("msg", msg);
                    result.Add("successYn", successYn);                    
                }
            }
            catch (Exception ex)
            {
                System.Diagnostics.EventLog.WriteEntry("Application", "CopyBoard  : " + ex.ToString(), System.Diagnostics.EventLogEntryType.Information);
                CommonLib.WriteLog("Error Borad Copy : " + ex.ToString());
                result.Add("msg", "Error : " + ex.ToString());
                result.Add("successYn", false);
            }
            return result;
        }

        //게시글 삭제
        public Dictionary<string,object> DeleteBoard(Dictionary<string, object> parameter)
        {
            Dictionary<string, object> result = new Dictionary<string, object>();

            //히스토리 기록
            string IP_ADDRESS = parameter.ContainsKey("IP_ADDRESS") ? parameter["IP_ADDRESS"] != null ? parameter["IP_ADDRESS"].ToString() : "" : "";
            string LANG = parameter.ContainsKey("LANG") ? parameter["LANG"] != null ? parameter["LANG"].ToString() : "" : ""; // 언어 default : ko-kr  , en-us : 영어
            string ID_USER = parameter.ContainsKey("ID_USER") ? parameter["ID_USER"] != null ? parameter["ID_USER"].ToString() : "" : "";

            // 게시판 데이터
            string BoardKey = parameter.ContainsKey("BoardKey") ? parameter["BoardKey"] != null ? parameter["BoardKey"].ToString() : "" : "";
            string wNum = parameter.ContainsKey("wNum") ? parameter["wNum"] != null ? parameter["wNum"].ToString() : "" : "";

            string sQuery = string.Format(@"EXEC [dbo].[uspn_Delete_Board]
                                                @LANG = N'{0}'
                                                ,@ID_USER = N'{1}'
                                                ,@IP_ADDRESS = N'{2}'                                               
                                                ,@BoardKey = N'{3}'
                                                ,@wNum = N'{4}'
                                                "
                                                , LANG
                                                , ID_USER
                                                , IP_ADDRESS                                               
                                                , BoardKey
                                                , wNum
                                      );
            try
            {
                using (DBHelper dbhelper = new DBHelper())
                {
                    DataSet ds = new DataSet();
                    ds = dbhelper.ExecuteSql(sQuery, "");
                    string msg = ds.Tables[0].Rows[0]["RESULT_MSG"].ToString();
                    bool successYn = Convert.ToBoolean(ds.Tables[1].Rows[0]["successYn"]);
                    
                    result.Add("msg", msg);
                    result.Add("successYn", successYn);
                }
            }
            catch (Exception ex)
            {
                System.Diagnostics.EventLog.WriteEntry("Application", "DeleteBoard  : " + ex.ToString(), System.Diagnostics.EventLogEntryType.Information);
                CommonLib.WriteLog("Error Borad Delete : " + ex.ToString());
                result.Add("msg", "Error : " + ex.ToString());
                result.Add("successYn", false);
            }
            return result;
        }

        //덧글 등록
        public int Insert_BoardComment(Dictionary<string, object> parameter)
        {
            //히스토리 기록
            string IP_ADDRESS = parameter.ContainsKey("IP_ADDRESS") ? parameter["IP_ADDRESS"] != null ? parameter["IP_ADDRESS"].ToString() : "" : "";

            string LANG = parameter.ContainsKey("LANG") ? parameter["LANG"] != null ? parameter["LANG"].ToString() : "" : ""; // 언어 default : ko-kr  , en-us : 영어
            string ID_USER = parameter.ContainsKey("ID_USER") ? parameter["ID_USER"] != null ? parameter["ID_USER"].ToString() : "" : "";

            //세션 공통값
            string RoleID = parameter.ContainsKey("RoleID") ? parameter["RoleID"] != null ? parameter["RoleID"].ToString() : "" : "";
            string Role = parameter.ContainsKey("Role") ? parameter["Role"] != null ? parameter["Role"].ToString() : "" : "";
            string SiteID = parameter.ContainsKey("SiteID") ? parameter["SiteID"] != null ? parameter["SiteID"].ToString() : "" : "";
            string GroupID = parameter.ContainsKey("GroupID") ? parameter["GroupID"] != null ? parameter["GroupID"].ToString() : "" : "";

            // 게시판 데이터
            string BoardKey = parameter.ContainsKey("BoardKey") ? parameter["BoardKey"] != null ? parameter["BoardKey"].ToString() : "" : "";
            string wNum = parameter.ContainsKey("wNum") ? parameter["wNum"] != null ? parameter["wNum"].ToString() : "" : "";
            string wCommentContent = parameter.ContainsKey("wCommentContent") ? parameter["wCommentContent"] != null ? parameter["wCommentContent"].ToString() : "" : "";

            // 게시판 내용 저장시 ' 변환
            wCommentContent = wCommentContent.Replace("'", "''");

            string sQuery = string.Format(@"EXEC [dbo].[usp_Insert_BoardComment]
                                                @LANG = N'{0}'
                                                ,@ID_USER = N'{1}'
                                                ,@IP_ADDRESS = N'{2}'
                                                ,@RoleID = N'{3}'
                                                ,@Role = N'{4}'
                                                ,@SiteID = N'{5}'
                                                ,@GroupID = N'{6}'
                                                ,@BoardKey = N'{7}'
                                                ,@wNum = N'{8}'
                                                ,@wCommentContent = N'{9}'
                                                "
                                                , LANG
                                                , ID_USER
                                                , IP_ADDRESS
                                                , RoleID
                                                , Role
                                                , SiteID
                                                , GroupID
                                                , BoardKey
                                                , wNum
                                                , wCommentContent
                                      );
            int result = 0;
            try
            {
                using (DBHelper dbhelper = new DBHelper("ProTnsBoard"))
                {
                    DataSet ds = new DataSet();
                    ds = dbhelper.ExecuteSql(sQuery, "");
                }
            }
            catch (Exception ex)
            {
                System.Diagnostics.EventLog.WriteEntry("Application", "Insert_BoardComment  : " + ex.ToString(), System.Diagnostics.EventLogEntryType.Information);
            }
            return result;
        }


        // 게시판 첨부파일 조회
        public List<Dictionary<string, object>> Get_BoardFileInfo(Dictionary<string, object> parameter)
        {
            Common ComService = new Common();

            //히스토리 기록
            string IP_ADDRESS = parameter.ContainsKey("IP_ADDRESS") ? parameter["IP_ADDRESS"] != null ? parameter["IP_ADDRESS"].ToString() : "" : "";
            string LANG = parameter.ContainsKey("LANG") ? parameter["LANG"] != null ? parameter["LANG"].ToString() : "" : ""; // 언어 default : ko-kr  , en-us : 영어
            string ID_USER = parameter.ContainsKey("ID_USER") ? parameter["ID_USER"] != null ? parameter["ID_USER"].ToString() : "" : "";

            //세션 공통값
            string RoleID = parameter.ContainsKey("RoleID") ? parameter["RoleID"] != null ? parameter["RoleID"].ToString() : "" : "";
            string Role = parameter.ContainsKey("Role") ? parameter["Role"] != null ? parameter["Role"].ToString() : "" : "";
            string SiteID = parameter.ContainsKey("SiteID") ? parameter["SiteID"] != null ? parameter["SiteID"].ToString() : "" : "";
            string GroupID = parameter.ContainsKey("GroupID") ? parameter["GroupID"] != null ? parameter["GroupID"].ToString() : "" : "";

            // 게시판 검색
            string wFileNum = parameter.ContainsKey("wFileNum") ? parameter["wFileNum"] != null ? parameter["wFileNum"].ToString() : "" : "";

            string sQuery = string.Format(@"EXEC [dbo].[usp_Get_BoardFileInfo]
                                                @LANG = N'{0}'
                                                ,@ID_USER = N'{1}'
                                                ,@IP_ADDRESS = N'{2}'
                                                ,@RoleID = N'{3}'
                                                ,@Role = N'{4}'
                                                ,@SiteID = N'{5}'
                                                ,@GroupID = N'{6}'
                                                ,@wFileNum = N'{7}'
                                                "
                                                , LANG
                                                , ID_USER
                                                , IP_ADDRESS
                                                , RoleID
                                                , Role
                                                , SiteID
                                                , GroupID
                                                , wFileNum
                                                );

            try
            {
                using (DBHelper dbhelper = new DBHelper("ProTnsBoard"))
                {
                    List<Dictionary<string, object>> list = new List<Dictionary<string, object>>();

                    DataSet ds = new DataSet();
                    ds = dbhelper.ExecuteSql(sQuery, "");

                    if (ds.Tables.Count == 1)
                    {
                        DataTable table1 = ds.Tables[0];
                        DataRow[] rows = table1.Select();
                        DataColumnCollection cols = table1.Columns;

                        for (int i = 0; i < rows.Length; i++)
                        {
                            Dictionary<string, object> data = new Dictionary<string, object>();
                            for (int j = 0; j < cols.Count; j++)
                            {

                                //ESCAPEHTML_로 시작하는 컬럼중 15자 보다 큰경우 HtmlDecode한 값을 리턴
                                if (cols[j].ColumnName.Length > 15)
                                {
                                    if (cols[j].ColumnName.ToUpper().Substring(0, 11) == "ESCAPEHTML_")
                                        data.Add(cols[j].ToString(), System.Web.HttpUtility.HtmlDecode(rows[i][j].ToString()));
                                    else
                                        data.Add(cols[j].ToString(), rows[i][j]);
                                }
                                else
                                {
                                    data.Add(cols[j].ToString(), rows[i][j].ToString());
                                }

                                list.Add(data);
                            }
                        }
                    }
                    return list;
                }
            }
            catch (Exception ex)
            {
                System.Diagnostics.EventLog.WriteEntry("Application", "BoardFileInfo  : " + ex.ToString(), System.Diagnostics.EventLogEntryType.Information);
            }
            return null;
        }

        // 게시판 첨부파일 임시 저장
        public int Save_BoardFile_Temporary(Dictionary<string, object> parameter)
        {
            //히스토리 기록
            string IP_ADDRESS = parameter.ContainsKey("IP_ADDRESS") ? parameter["IP_ADDRESS"] != null ? parameter["IP_ADDRESS"].ToString() : "" : "";

            string LANG = parameter.ContainsKey("LANG") ? parameter["LANG"] != null ? parameter["LANG"].ToString() : "" : ""; // 언어 default : ko-kr  , en-us : 영어
            string ID_USER = parameter.ContainsKey("ID_USER") ? parameter["ID_USER"] != null ? parameter["ID_USER"].ToString() : "" : "";

            //세션 공통값
            string RoleID = parameter.ContainsKey("RoleID") ? parameter["RoleID"] != null ? parameter["RoleID"].ToString() : "" : "";
            string Role = parameter.ContainsKey("Role") ? parameter["Role"] != null ? parameter["Role"].ToString() : "" : "";
            string SiteID = parameter.ContainsKey("SiteID") ? parameter["SiteID"] != null ? parameter["SiteID"].ToString() : "" : "";
            string GroupID = parameter.ContainsKey("GroupID") ? parameter["GroupID"] != null ? parameter["GroupID"].ToString() : "" : "";

            // 게시판 첨부파일 데이터
            string BoardKey = parameter.ContainsKey("BoardKey") ? parameter["BoardKey"] != null ? parameter["BoardKey"].ToString() : "" : "";
            string fileGUID = parameter.ContainsKey("fileGUID") ? parameter["fileGUID"] != null ? parameter["fileGUID"].ToString() : "" : "";
            string wNum = parameter.ContainsKey("wNum") ? parameter["wNum"] != null ? parameter["wNum"].ToString() : "" : "";

            string wFileNum = parameter.ContainsKey("wFileNum") ? parameter["wFileNum"] != null ? parameter["wFileNum"].ToString() : "" : "";
            string wfileUid = parameter.ContainsKey("wfileUid") ? parameter["wfileUid"] != null ? parameter["wfileUid"].ToString() : "" : "";

            string wfileName = parameter.ContainsKey("wfileName") ? parameter["wfileName"] != null ? parameter["wfileName"].ToString() : "" : "";
            string wfileExt = parameter.ContainsKey("wfileExt") ? parameter["wfileExt"] != null ? parameter["wfileExt"].ToString() : "" : "";
            string wfileSize = parameter.ContainsKey("wfileSize") ? parameter["wfileSize"] != null ? parameter["wfileSize"].ToString() : "" : "";
            string wfileName_Temporary = parameter.ContainsKey("wfileName_Temporary") ? parameter["wfileName_Temporary"] != null ? parameter["wfileName_Temporary"].ToString() : "" : "";
            string wfilePath_Temporary = parameter.ContainsKey("wfilePath_Temporary") ? parameter["wfilePath_Temporary"] != null ? parameter["wfilePath_Temporary"].ToString() : "" : "";
            string wfileAction = parameter.ContainsKey("wfileAction") ? parameter["wfileAction"] != null ? parameter["wfileAction"].ToString() : "" : "";


            string sQuery = string.Format(@"EXEC [dbo].[usp_Save_BoardFile_Temporary]
                                                @LANG = N'{0}'
                                                ,@ID_USER = N'{1}'
                                                ,@IP_ADDRESS = N'{2}'
                                                ,@RoleID = N'{3}'
                                                ,@Role = N'{4}'
                                                ,@SiteID = N'{5}'
                                                ,@GroupID = N'{6}'
                                                ,@BoardKey = N'{7}'
                                                ,@fileGUID = N'{8}'
                                                ,@wNum = N'{9}'
                                                ,@wFileNum = N'{10}'
                                                ,@wfileUid = N'{11}'
                                                ,@wfileName = N'{12}'
                                                ,@wfileExt = N'{13}'
                                                ,@wfileSize = N'{14}'
                                                ,@wfileName_Temporary = N'{15}'
                                                ,@wfilePath_Temporary = N'{16}'
                                                ,@wfileAction = N'{17}'
                                                "
                                                , LANG
                                                , ID_USER
                                                , IP_ADDRESS
                                                , RoleID
                                                , Role
                                                , SiteID
                                                , GroupID
                                                , BoardKey
                                                , fileGUID
                                                , wNum
                                                , wFileNum
                                                , wfileUid
                                                , wfileName
                                                , wfileExt
                                                , wfileSize
                                                , wfileName_Temporary
                                                , wfilePath_Temporary
                                                , wfileAction
                                      );
            int result = 0;
            try
            {
                using (DBHelper dbhelper = new DBHelper("ProTnsBoard"))
                {
                    DataSet ds = new DataSet();
                    ds = dbhelper.ExecuteSql(sQuery, "");

                    result = int.Parse(ds.Tables[0].Rows[0]["TmpID"].ToString());
                }
            }
            catch (Exception ex)
            {
                System.Diagnostics.EventLog.WriteEntry("Application", "Save_BoardFile_Temporary  : " + ex.ToString(), System.Diagnostics.EventLogEntryType.Information);
            }
            return result;
        }



    }
}
