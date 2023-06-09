using proTnsWeb.Filters;
using proTnsWeb.Models;
using proTnsWeb.Models.Services;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.IO;
using System.Web.Mvc;
using Portfolio;

namespace FileUploadDownload.Controllers
{
    [LoginFilter]
    public class FilesController : Controller
    {
        private readonly Board service = new Board();
        private readonly Common ComService = new Common();

        #region 참고자료 - 주석처리
        /*
                string conString = "Server=localhost;DataBase=ProTnsVDIxSF;UID=sa;PWD=Prossw0rd";  // Data Source=.;Initial Catalog =DemoTest; integrated security=true;";

                // GET: Files
                public ActionResult Index(FileUpload model)
                {
                    List<FileUpload> list = new List<FileUpload>();
                    DataTable dtFiles = GetFileDetails();
                    foreach (DataRow dr in dtFiles.Rows)
                    {
                        list.Add(new FileUpload
                        {
                            FileId = @dr["SQLID"].ToString(),
                            FileName = @dr["FILENAME"].ToString(),
                            FileUrl = @dr["FILEURL"].ToString()
                        });
                    }
                    model.FileList = list;
                    return View(model);
                }

                [HttpPost]
                public ActionResult Index(HttpPostedFileBase files)
                {
                    FileUpload model = new FileUpload();
                    List<FileUpload> list = new List<FileUpload>();
                    DataTable dtFiles = GetFileDetails();
                    foreach (DataRow dr in dtFiles.Rows)
                    {
                        list.Add(new FileUpload
                        {
                            FileId = @dr["SQLID"].ToString(),
                            FileName = @dr["FILENAME"].ToString(),
                            FileUrl = @dr["FILEURL"].ToString()
                        });
                    }
                    model.FileList = list;

                    if (files != null)
                    {
                        var Extension = Path.GetExtension(files.FileName);
                        var fileName = "my-file-" + DateTime.Now.ToString("yyyyMMddHHmmssfff") + Extension;
                        string path = Path.Combine(Server.MapPath("~/UploadedFiles"), fileName);
                        model.FileUrl = Url.Content(Path.Combine("~/UploadedFiles/", fileName));
                        model.FileName = fileName;

                        if (SaveFile(model))
                        {
                            files.SaveAs(path);
                            TempData["AlertMessage"] = "Uploaded Successfully !!";
                            return RedirectToAction("Index", "Files");
                        }
                        else
                        {
                            ModelState.AddModelError("", "Error In Add File. Please Try Again !!!");
                        }
                    }
                    else
                    {
                        ModelState.AddModelError("", "Please Choose Correct File Type !!");
                        return View(model);
                    }
                    return RedirectToAction("Index", "Files");
                }

                private DataTable GetFileDetails()
                {
                    DataTable dtData = new DataTable();
                    SqlConnection con = new SqlConnection(conString);
                    con.Open();
                    SqlCommand command = new SqlCommand("Select * From tblFileDetails", con); 
                    SqlDataAdapter da = new SqlDataAdapter(command);
                    da.Fill(dtData);
                    con.Close();
                    return dtData;
                }

                private bool SaveFile(FileUpload model)
                {
                    string strQry = "INSERT INTO tblFileDetails (FileName,FileUrl) VALUES('" +
                        model.FileName + "','" + model.FileUrl + "')";
                    SqlConnection con = new SqlConnection(conString);
                    con.Open();
                    SqlCommand command = new SqlCommand(strQry, con);
                    int numResult = command.ExecuteNonQuery();
                    con.Close();
                    if (numResult > 0)
                        return true;
                    else
                        return false;
                }

                // 비동기 파일 Upload
                public ActionResult Save(IEnumerable<HttpPostedFileBase> AsyncDocumentsFiles, string KeyValue)
                {

                    if (AsyncDocumentsFiles != null)
                    {
                        foreach (var file in AsyncDocumentsFiles)
                        {
                            FileUpload model = new FileUpload();

                            var Extension = Path.GetExtension(file.FileName);
                            var fileName = "my-file-" + DateTime.Now.ToString("yyyyMMddHHmmssfff") + Extension;
                            //string path = Path.Combine(Server.MapPath("~/UploadedFiles"), fileName);
                            string path = Path.Combine(@"D:\_iTemp\Uploadf\", fileName);
                
                            model.FileUrl = Url.Content(Path.Combine("~/UploadedFiles/", fileName));
                            model.FileName = fileName;

                            //if (SaveFile(model))          // DB저장
                            {
                                file.SaveAs(path);
                                //TempData["AlertMessage"] = "Uploaded Successfully !!";
                                //return RedirectToAction("Index", "Files");
                            }

                            //FileStream fs = new FileStream(file.FileName, FileMode.Open, FileAccess.Read);
                            //BinaryReader br = new BinaryReader(fs);
                            //Byte[] bytes = br.ReadBytes((Int32)fs.Length);
                            //var fileUpload = new FileUpload()
                            //{
                            //    CreatedOn = DateTime.Now,
                            //    Filename = file.FileName,
                            //    FileContent = bytes
                            //};
                            //br.Close();
                            //fs.Close();
                            //cotext.FileUploads.Add(fileUpload);
                            //cotext.SaveChanges();
                        }
                    }
                    // Return an empty string to signify success
                    return Content("");


                    //if (AsyncDocumentsFiles != null)
                    //{
                    //    using (CSharpcornerEntities cotext = new CSharpcornerEntities())
                    //    {
                    //        foreach (var file in AsyncDocumentsFiles)
                    //        {
                    //            FileStream fs = new FileStream(file.FileName, FileMode.Open, FileAccess.Read);
                    //            BinaryReader br = new BinaryReader(fs);
                    //            Byte[] bytes = br.ReadBytes((Int32)fs.Length);
                    //            var fileUpload = new FileUpload()
                    //            {
                    //                CreatedOn = DateTime.Now,
                    //                FileName = file.FileName,
                    //                FileContent = bytes
                    //            };
                    //            br.Close();
                    //            fs.Close();
                    //            cotext.FileUploads.Add(fileUpload);
                    //            cotext.SaveChanges();
                    //        }
                    //    }
                    //}


                    // Return an empty string to signify success
                    return Content("");
                }

                // Board 첨부파일
                public ActionResult SaveBoard(IEnumerable<HttpPostedFileBase> AsyncDocumentsFiles, string KeyValue)
                {
                    try
                    {

                        if (AsyncDocumentsFiles != null)
                        {
                            foreach (var file in AsyncDocumentsFiles)
                            {
                                FileUpload model = new FileUpload();

                                var Extension = Path.GetExtension(file.FileName);
                                var fileName = "Board_" + DateTime.Now.ToString("yyyyMMddHHmmssfff") + Extension;
                                string path = Path.Combine(Server.MapPath("~/UploadedFiles"), fileName);

                                model.FileUrl = Url.Content(Path.Combine("~/UploadedFiles/", fileName));
                                model.FileName = fileName;

                                // Save
                                file.SaveAs(path);
                            }
                        }
                        return Json(new { result = "OK" }, "text/plain");
                    }
                    catch (Exception ex)
                    {
                        return Json(new { result = "Error", errMsg = ex.Message }, "text/plain");
                    }
                }

        */
        #endregion

        #region 파일 다운로드   
        // 게시판 첨부파일 파일위치로 다운로드
        public ActionResult DownloadFilePath(string filePath)
        {
            string fullName = Server.MapPath("~" + filePath);

            byte[] fileBytes = GetFile(fullName);
            return File(fileBytes, System.Net.Mime.MediaTypeNames.Application.Octet, filePath);
        }       

        //  File Download를 위한 FileStream 정보
        byte[] GetFile(string s)
        {
            System.IO.FileStream fs = System.IO.File.OpenRead(s);
            byte[] data = new byte[fs.Length];
            int br = fs.Read(data, 0, data.Length);
            if (br != fs.Length)
                throw new System.IO.IOException(s);
            return data;
        }

        //게시판 첨부파일 조회
        public Dictionary<string, object> BoardFileInfo(string wFileNum)
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
            parameter.Add("wFileNum", wFileNum);

            List<Dictionary<string, object>> list = new List<Dictionary<string, object>>();
            list = service.Get_BoardFileInfo(parameter);

            return list[0];
        }

        #endregion      


        #region New 다운로드
        /// <summary>
        /// 조회된 파라미터를 넘겨 다운로드
        /// </summary>
        /// <param name="param"></param>
        /// <returns></returns>
        public ActionResult FileDownload(string param)
        {
            //string fullName = Server.MapPath("~" + wfilePath);
            //string fullName = HttpContext.Application["BoardAttatchPath"].ToString() + wfilePath;            
            var parameter = ComService.ParameterDataSet(param);

            byte[] fileBytes = GetFile(parameter["path"].ToString());
            return File(fileBytes, System.Net.Mime.MediaTypeNames.Application.Octet, parameter["name"].ToString());
        }
        #endregion

        #region New Remove
        /// <summary>
        /// 파일 삭제 (게시판)
        /// </summary>
        /// <param name="param"></param>
        /// <returns></returns>
        public string FileRemove(string param)
        {            
            var parameter = ComService.ParameterDataSet(param);
            
            string wNum = parameter["wNum"].ToString();
            string wFileNum = parameter["wFileNum"].ToString();
            string path = parameter["path"].ToString();
            
            try
            {
                DBHelper dbhelper = new DBHelper();
                string sConn = "";
                sConn = dbhelper.getDBConStrings();


                SqlConnection sqlCon = new SqlConnection(sConn);
                SqlCommand cmd = new SqlCommand();
                cmd.Connection = sqlCon;
                //DB연결
                sqlCon.Open();
                //기존 게시판에 있던 파일 초기화
                string fileDeleteQuery = string.Format("DELETE tbx_BoardFile WHERE wNum = '{0}' AND wFileNum = '{1}'", wNum, wFileNum);
                cmd.CommandText = fileDeleteQuery;
                cmd.ExecuteNonQuery();

                //실제 파일 삭제                           
                FileInfo file = new FileInfo(path);
                file.Delete();
                CommonLib.WriteLog("File Deleted Successfully");
               

                sqlCon.Close();
            }
            catch(Exception ex)
            {
                System.Diagnostics.EventLog.WriteEntry("Application", "FileRemove  : " + ex.ToString(), System.Diagnostics.EventLogEntryType.Information);
                CommonLib.WriteLog("Error FileRemove : " + ex.ToString());                
            }
            return "1";
        }
        #endregion
    }
}