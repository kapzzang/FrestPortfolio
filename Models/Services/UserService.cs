using System;
using System.Data;
using Portfolio;

namespace proTnsWeb.Models.Services
{
    public interface IUserService
	{
		User Authentication(string userid, string username, string IP, string lang);
	}

	public class UserService : IUserService
	{	
		public User Authentication(string userid, string username, string IP, string lang)
		{
			try
			{
				User user = new User();

				// 사용자 정보 검색
				string sQuery = string.Format(@"EXEC uspn_Select_UserPermission
													 @plang = N'{0}'
													,@pUserID = N'{1}'
													,@pIPAddress = N'{2}'"
													, lang
													, userid
													, IP
													);
				DBHelper dbhelper = new DBHelper();
				DataSet ds = new DataSet();

				ds = dbhelper.ExecuteSql(sQuery, "");

				string result = "";

				if (ds.Tables.Count == 1)
				{
					// Table 1 접속 결과
					result = ds.Tables[0].Rows[0][0].ToString();
					throw new Exception(result);
				}
				else if (ds.Tables.Count == 3)
				{
					// Table 1 접속 결과
					result = ds.Tables[0].Rows[0][0].ToString();

					if (result.ToUpper() != "PASS")
					{
						throw new Exception(result);
					}

					// Table 2 관리자 정보
					DataTable dt_Users = ds.Tables[1];
					if (dt_Users.Rows.Count > 0)
					{
						for (int i = 0; i < dt_Users.Rows.Count; i++)
						{
							user.UserID = dt_Users.Rows[i]["UserID"].ToString();
							user.UserName = dt_Users.Rows[i]["UserName"].ToString();
							user.DepartName = dt_Users.Rows[i]["DepartName"].ToString();
							user.PermissionLvl = int.Parse(dt_Users.Rows[i]["PermissionLvl"].ToString());
							user.IsManagerPage = dt_Users.Rows[i]["IsManagerPage"].ToString();
							user.LocationSope = int.Parse(dt_Users.Rows[i]["LocationSope"].ToString());
						}
					}
					else
					{
						throw new Exception("LogonAuth_NoAdmin");
					}

					// Table 3 HomeMenu
					try
					{
						DataTable dt_HomeMenu = ds.Tables[2];
						if (dt_HomeMenu.Rows.Count > 0)
						{
							user.HomeMenu = new Menu();
							user.HomeMenu.key_Menu = dt_HomeMenu.Rows[0]["key_Menu"].ToString();
							user.HomeMenu.nm_Menu = dt_HomeMenu.Rows[0]["nm_Menu"].ToString();
							user.HomeMenu.ds_MenuTooltip = dt_HomeMenu.Rows[0]["ds_MenuTooltip"].ToString();
							user.HomeMenu.ds_Icon = dt_HomeMenu.Rows[0]["ds_Icon"].ToString();
							user.HomeMenu.url_Menu = dt_HomeMenu.Rows[0]["url_Menu"].ToString();
							user.HomeMenu.key_MenuParent = dt_HomeMenu.Rows[0]["key_MenuParent"].ToString();
							user.HomeMenu.id_Page = dt_HomeMenu.Rows[0]["id_Page"].ToString();
							user.HomeMenu.ds_Menu_Path = dt_HomeMenu.Rows[0]["ds_Menu_Path"].ToString();
						}
					}
					catch
					{
						System.Diagnostics.EventLog.WriteEntry("Application", "error Menu empty", System.Diagnostics.EventLogEntryType.Information);
						throw new Exception("LogonAuth_MenuEmpty");
					}
				}
				else
				{
					System.Diagnostics.EventLog.WriteEntry("Application", "errorAuth : uspn_Select_UserPermission Data Error", System.Diagnostics.EventLogEntryType.Information);
					//throw new AuthenticationException();
					throw new Exception("LogonAuth_ErrorAuth");
				}

				return user;
			}
			catch(Exception ex)
			{
				System.Diagnostics.EventLog.WriteEntry("Application", "error Models.Services Authentication ex  : " + ex.ToString(), System.Diagnostics.EventLogEntryType.Information);
				//throw new AuthenticationException();
				throw ex;	// new Exception("errorAuth2");
			}
		}
	}

	public class AuthenticationException : Exception
	{
	}

	public class UserNotExistsException : Exception
	{
	}
}