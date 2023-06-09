using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;

namespace Portfolio
{
    public class DBHelper : IDisposable
    {
        public string m_str = "";
        public string m_DB = "";

        public DBHelper()
        {
            m_DB = "";
        }

        public DBHelper(string DatabaseName)
        {
            m_DB = DatabaseName;
        }

        public string getDBConStrDBName(string DatabaseName)
        {
            return getDBConString(DatabaseName);
        }

        public string getDBConStrings()
        {
            return getDBConString("");
        }
        
        private string getDBConString(string DatabaseName)
        {
            try
            {
                string strCon = "";                
                    //DatabaseName = DatabaseName.ToUpper();                    
#if DEBUG
                    // 디버그용 sql connection 
                    if (DatabaseName != "")
                    {
                        //strCon = CommonLib.GetAppValue(DatabaseName+ "_DBCONTEXT");
                        ConnectionStringSettings settings = ConfigurationManager.ConnectionStrings[DatabaseName];
                        strCon = settings.ConnectionString;
                    }
                    else
                    {
                        //strCon = CommonLib.GetAppValue("ApplicationDbContext");
                        //CommonLib.WriteLog("getDBConString : " + strCon, "");
                        ConnectionStringSettings settings = ConfigurationManager.ConnectionStrings["ApplicationDbContext"];
                        strCon = settings.ConnectionString;
                    }
#else                  
#endif
                         
                return strCon;
            }
            catch (Exception x)
            {
                CommonLib.WriteLog("Server: getDBConString " + x.Message, "", true);                
            }
            return "";
        }

        public Boolean ValidateSQL(DataSet ds, string sSql)
        {
            Boolean result = false;

            SqlConnection sqlCon = new SqlConnection(getDBConString(m_DB));
            
            try
            {
                sqlCon.Open();

                SqlDataAdapter sqlAdapter = new SqlDataAdapter(sSql, sqlCon);
                sqlAdapter.Fill(ds);
                result = true;
            }
            catch (Exception x)
            {
                // 에러 처리는 화면단에서...
                result = false;                
                CommonLib.WriteLog("Server : ValidateSQL Error : " + x.Message, "", true);                
            }
            finally
            {
                if (sqlCon != null)
                    sqlCon.Close();
            }
            return result;
        }

        public DataSet ExecuteSql(string sSql, string sConnName)
        {
            m_str = "";
            string sConn = "";
            sConn = getDBConString(m_DB);            

            SqlConnection sqlCon = new SqlConnection(sConn);
            DataSet eDataSet = new DataSet();
            try
            {
                sqlCon.Open();

                SqlDataAdapter sqlAdapter = new SqlDataAdapter(sSql, sqlCon);
                sqlAdapter.Fill(eDataSet);
            }
            catch (Exception x)
            {
                // 에러 처리는 화면단에서...
                CommonLib.WriteLog("Server : ExecuteSql Error : " + x.Message, "", true);
                throw x;                
            }
            finally
            {
                if (sqlCon != null)
                    sqlCon.Close();
            }
            return eDataSet;
        }

        public DataSet ExecuteSql(string sSql, string sConnName, int TimeOut)
        {
            m_str = "";
            string sConn = getDBConString(m_DB);

            SqlConnection sqlCon = new SqlConnection(sConn);
            SqlCommand command = new SqlCommand();
            DataSet eDataSet = new DataSet();
            try
            {
                sqlCon.Open();

                command.Connection = sqlCon;                
                command.CommandText = sSql;
                command.CommandTimeout = TimeOut;

                SqlDataAdapter sqlAdapter = new SqlDataAdapter(command);
                sqlAdapter.Fill(eDataSet);
            }
            catch (Exception x)
            {
                CommonLib.WriteLog("Server : ExecuteSql Error : " + x.Message, "", true);
                throw x;                
            }
            finally
            {
                if (sqlCon != null)
                    sqlCon.Close();
            }
            return eDataSet;
        }
        public DataSet ExecuteSql(string sSql, CommandType commType, Dictionary<string, object> dParams, string sConnName)
        {
            m_str = "";
            string sConn = getDBConString(m_DB);

            SqlConnection sqlCon = new SqlConnection(sConn);
            SqlCommand command = new SqlCommand();
            DataSet ds = new DataSet();
            try
            {

                sqlCon.Open();

                command.Connection = sqlCon;
                command.CommandType = commType;
                command.CommandText = sSql;
                command.CommandTimeout = 60000;

                foreach (KeyValuePair<string, object> kv in dParams)
                {
                    command.Parameters.Add(new SqlParameter(kv.Key, kv.Value));
                }
                
                SqlDataAdapter sqlAdapter = new SqlDataAdapter(command);
                sqlAdapter.Fill(ds);
            }
            catch (Exception x)
            {
                CommonLib.WriteLog("Server : ExecuteSql param Error : " + x.Message, "", true);
                throw x;                
            }
            finally
            {
                if (sqlCon != null)
                    sqlCon.Close();
            }
            return ds;
        }
        public int ExcuteNonSql(string sSql, string sConnName)
        {
            m_str = "";

            string sConn = "";
            sConn = getDBConString(m_DB);

            int iResult = -1;
            using (SqlConnection sqlCon = new SqlConnection(sConn))
            using (SqlCommand cmd = sqlCon.CreateCommand())
            {


                try
                {
                    cmd.CommandText = sSql;
                    cmd.CommandType = CommandType.Text;                   

                    sqlCon.Open();
                    iResult = cmd.ExecuteNonQuery();
                    
                    sqlCon.Close();
                }
                catch (Exception x)
                {
                    CommonLib.WriteLog("Server : ExcuteNonSql Error : " + x.Message, "", true);
                    throw x;                    
                }
                finally
                {
                    if (sqlCon != null)
                        sqlCon.Close();
                }
            }


            return iResult;
        }

        //Data Bulk Insert
        /// <summary>
        /// DataTable Bulk Insert
        /// </summary>
        /// <param name="nm_Table">테이블명</param>
        /// <param name="dt">Insert할 DataTable</param>
        /// <returns> OK or ErrorMessage </returns>
        public string ExecBulkInsert(string nm_Table, DataTable dt)
        {
            try
            {
                string sConn = "";    
                sConn = getDBConString(m_DB);
                
                using (SqlBulkCopy bc = new SqlBulkCopy(sConn, SqlBulkCopyOptions.TableLock))
                {
                    bc.DestinationTableName = nm_Table;
                    bc.BulkCopyTimeout = 600;
                    bc.WriteToServer(dt);

                    dt.Clear();
                }

                return "OK";
            }
            catch (Exception ex)
            {
                CommonLib.WriteLog("Server : ExecBulkInsert Error : " + ex.Message, "", true);
                return ex.Message;
            }
        }

        /// <summary>
        /// DataTable Bulk Insert
        /// </summary>
        /// <param name="nm_Table">테이블명</param>
        /// <param name="dt">Insert할 DataTable</param>
        /// <param name="IsTruncateTable">nm_Table 데이터 Truncate 여부(True/False)</param>
        /// <returns> OK or ErrorMessage </returns>
        public string ExecBulkInsert(string nm_Table, DataTable dt, bool IsTruncateTable)
        {
            try
            {
                string sConn = "";
                sConn = getDBConString(m_DB);

                // Table 초기화
                if (IsTruncateTable)
                {
                    string TruncateQuery = "DELETE FROM " + nm_Table + ";";
                    ExecuteSql(TruncateQuery, "");
                }
                // BulkInsert
                using (SqlBulkCopy bc = new SqlBulkCopy(sConn, SqlBulkCopyOptions.TableLock))
                {
                    bc.DestinationTableName = nm_Table;
                    bc.BulkCopyTimeout = 600;
                    bc.WriteToServer(dt);

                    dt.Clear();
                }

                return "OK";
            }
            catch (Exception ex)
            {
                CommonLib.WriteLog("Server : ExecBulkInsert IsTruncateTable Error : " + ex.Message, "", true);
                return ex.Message;
            }
        }

        /// <summary>
        /// DataTable Bulk Insert
        /// </summary>
        /// <param name="nm_Table">테이블명</param>
        /// <param name="dt">Insert할 DataTable</param>
        /// <param name="IsDeleteRow">nm_Table 데이터 중 필터에 해당하는 데이터 삭제 여부(True/False)</param>
        /// <param name="sFilter">nm_Table 데이터 중 삭제 데이터 필터(Option)</param>
        /// <returns> OK or ErrorMessage </returns>
        public string ExecBulkInsert(string nm_Table, DataTable dt, bool IsDeleteRow, string sFilter = "")
        {
            try
            {
                string sConn = "";
                sConn = getDBConString(m_DB);

                // 해당 데이터 삭제
                if (IsDeleteRow)
                {
                    string TruncateQuery = "DELETE FROM " + nm_Table + " " + sFilter + ";";                    
                    ExecuteSql(TruncateQuery, "");
                }

                // BulkInsert
                using (SqlBulkCopy bc = new SqlBulkCopy(sConn, SqlBulkCopyOptions.TableLock))
                {
                    bc.DestinationTableName = nm_Table;
                    bc.BulkCopyTimeout = 600;
                    bc.WriteToServer(dt);

                    dt.Clear();
                }

                return "OK";
            }
            catch (Exception ex)
            {
                CommonLib.WriteLog("Server : ExecBulkInsert IsDeleteRow_sFilter Error : " + ex.Message, "", true);
                return ex.Message;
            }
        }

        /// <summary>
        /// Delete Table
        /// </summary>
        /// <param name="nm_Table">데이터 삭제 할 테이블명</param>
        /// <returns> OK or ErrorMessage </returns>
        public string ExecDeleteTable(string nm_Table)
        {
            try
            {
                string sConn = "";
                sConn = getDBConString(m_DB);

                // Table 초기화
                string TruncateQuery = "DELETE FROM " + nm_Table + ";";
                ExecuteSql(TruncateQuery, "");

                return "OK";
            }
            catch (Exception ex)
            {
                return ex.Message;
            }

        }

        /// <summary>
        /// Delete Table
        /// </summary>
        /// <param name="nm_Table">데이터 삭제 할 테이블명</param>
        /// <param name="sFilter">nm_Table 데이터 중 삭제 데이터 필터(Option)</param>
        /// <returns> OK or ErrorMessage </returns>
        public string ExecDeleteTable(string nm_Table, string sFilter = "")
        {
            try
            {
                string sConn = "";
                sConn = getDBConString(m_DB);

                // Table 초기화
                string TruncateQuery = "DELETE FROM " + nm_Table + " " + sFilter + ";";
                ExecuteSql(TruncateQuery, "");
                return "OK";
            }
            catch (Exception ex)
            {
                return ex.Message;
            }

        }


        public void Dispose()
        {

        }
    }
}