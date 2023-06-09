using proTnsWeb.Models;
using proTnsWeb.Models.Services;
using System;
using System.Collections.Generic;
using System.Web.Mvc;
using System.Net;

namespace proTnsWeb.Controllers
{
    public class MenuController : Controller
    {
        private readonly IMenuService service;        

        public MenuController(IMenuService service)
        {
            this.service = service;
        }

        public virtual PartialViewResult Menu()
        {
            if (Session["User"] == null)
            {
                return null;
            }

            try
            {
                IEnumerable<Menu> Menu = null;

                if (Session["_Menu"] != null)
                {
                   Menu = (IEnumerable<Menu>)Session["_Menu"];
                }
                else
                {
                    //접속자 ip가져오기
                    string strUserIPv4 = String.Empty;
                    foreach (IPAddress ip in Dns.GetHostAddresses(Dns.GetHostName()))
                    {
                        if (ip.AddressFamily.ToString() == "InterNetwork")
                        {
                            strUserIPv4 = ip.ToString();
                            break;
                        }
                    }
                    string lang = Session["lang"].ToString();
                    string UserID = (Session["User"] as User).UserID.ToString();
                    Menu = service.GetMenuData();
                    Session["_Menu"] = Menu;
                }
                return PartialView("_Menu", Menu);
            }
            catch
            {
                return null;
            }
        }

        public void MenuReset()
        {
            Session["_Menu"] = null;
            Menu();            
        }
    }
}