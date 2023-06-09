using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace proTnsWeb.Models
{
    public class Menu
    {
        public string key_Menu { get; set; }
        public string nm_Menu { get; set; }
        public string ds_MenuTooltip { get; set; }
        public string ds_Icon { get; set; }
        public string url_Menu { get; set; }
        public string key_MenuParent { get; set; }
		public string id_Page { get; set; }
		public string ds_Menu_Path { get; set; }
    }
}