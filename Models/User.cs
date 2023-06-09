using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace proTnsWeb.Models
{
	public class User
	{
		public string UserID { get; set; }
		public string UserName { get; set; }		
		public string DepartName { get; set; }
		public int PermissionLvl { get; set; }
		public string IsManagerPage { get; set; }
        public int LocationSope { get; set; }
		public string IPAddress { get; set; }

        public Menu HomeMenu { get; set; }

		//2023.04.19 MFA key추가
		public string MFAKey { get; set; }
		public bool MFAPASS { get; set; }
	}
	public class LogonResult
	{
		public bool m_blLogonSuccess = false;
		public string m_strResult = "";
		public string m_strLogonUrl = "";
		public string m_strEx = "";
	}
}