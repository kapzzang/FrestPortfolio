using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using proTns;
using System.Data;

namespace proTnsWeb.Models.Services
{
	public interface IMenuService
    {        
        IList<Menu> GetMenuData();
    }

    public class MenuService : IMenuService
    {
        public MenuService()
        {
        }
        
        public IList<Menu> GetMenuData()
        {
            List<Menu> menuList = new List<Menu>();

            // Level 1 menus
            Menu menu1 = new Menu()
            {
                key_Menu = "0",
                nm_Menu = "Main",
                ds_MenuTooltip = "Main",
                ds_Icon = "home",
                url_Menu = "~/",
                key_MenuParent = "top",
                id_Page = "Index",
                ds_Menu_Path = "0"
            };
            menuList.Add(menu1);

            Menu menu2 = new Menu()
            {
                key_Menu = "1",
                nm_Menu = "예제",
                ds_MenuTooltip = "Example",
                ds_Icon = "list",
                url_Menu = "",
                key_MenuParent = "0", 
                id_Page = "",
                ds_Menu_Path = "1"
            };
            menuList.Add(menu2);

            // Level 2 menus
            Menu menu3 = new Menu()
            {
                key_Menu = "01",
                nm_Menu = "FormWizard",
                ds_MenuTooltip = "FormWizard",
                ds_Icon = "list",
                url_Menu = "~/Example/PageCommon/FormWizard",
                key_MenuParent = "1", 
                id_Page = "FormWizard",
                ds_Menu_Path = "1|01"
            };
            menuList.Add(menu3);

            Menu menu4 = new Menu()
            {
                key_Menu = "02",
                nm_Menu = "CRUD",
                ds_MenuTooltip = "CRUD",
                ds_Icon = "users",
                url_Menu = "~/Example/PageCommon/CRUD",
                key_MenuParent = "1", 
                id_Page = "CRUD",
                ds_Menu_Path = "1|02"
            };
            menuList.Add(menu4);

            Menu menu5 = new Menu()
            {
                key_Menu = "03",
                nm_Menu = "게시판",
                ds_MenuTooltip = "Board",
                ds_Icon = "list",
                url_Menu = "~/Board/PageCommon/Board",
                key_MenuParent = "1",
                id_Page = "Board",
                ds_Menu_Path = "1|03"
            };
            menuList.Add(menu5);

            Menu menu6 = new Menu()
            {
                key_Menu = "04",
                nm_Menu = "설정",
                ds_MenuTooltip = "Setting",
                ds_Icon = "gears",
                url_Menu = "",
                key_MenuParent = "1",
                id_Page = "",
                ds_Menu_Path = "1|04"
            };
            menuList.Add(menu6);

            Menu menu7 = new Menu()
            {
                key_Menu = "041",
                nm_Menu = "메뉴관리",
                ds_MenuTooltip = "MenuManagement",
                ds_Icon = "list",
                url_Menu = "~/Example/PageCommon/MenuManagement",
                key_MenuParent = "04",
                id_Page = "MenuManagement",
                ds_Menu_Path = "1|04|041"
            };
            menuList.Add(menu7);
            return menuList;
        }
    }
}