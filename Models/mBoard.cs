using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace proTnsWeb.Models
{
    public class mBoard
    {
        public List<BoardConfig> BoardConfigList { get; set; }
        public List<BoardData> BoardList { get; set; }
    }

    public class BoardConfig
    {

        public int SortOrder { get; set; }
        public string BoardKey { get; set; }
        public string BoardTitle { get; set; }
        public string Collapsed { get; set; }
        public string BoxColor { get; set; }
        
    }

    public class BoardData
    {
        
        public int BoardSID { get; set; }
        public string BoardKey { get; set; }
        public int wNum { get; set; }
        public string wUser { get; set; }
        public string wTitle { get; set; }
        public string wContent { get; set; }
        public string wPlainContent { get; set; }
        public string wfileName { get; set; }
        public string wfileExt { get; set; }
        public int wfileSize { get; set; }
        public DateTime wDate { get; set; }
        public int wReadCount { get; set; }
        public string delFlg { get; set; }
        public long SiteID { get; set; }
        public long GroupID { get; set; }
        public string wDateYYMMDD { get; set; }

    }
}