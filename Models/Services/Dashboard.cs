namespace proTnsWeb.Models.Services
{

    public class Dashboard 
    {

        /// <summary>
        /// 기본 데이터(쿼리가 간단한) 하나의 프로시저에서 조회함
        /// </summary>
        /// <returns></returns>
        public object GetBasicData()
        {
            object result = new
            {
                Table0 = new[]
                {
                    new { TotalCost = "24138" }
                },
                Table1 = new[]
                {
                    new { userCnt = "18" },
                    new { userCnt = "93" }
                },
                Table2 = new[]
                {
                    new { TOTAL = "9", RUNNING = "1" }
                }
            };
            return result;
        }

        /// <summary>
        /// 일자별 VM  할당 시간 조회
        /// </summary>
        /// <returns></returns>
        public object GetDailyVMAllocation()
        {
            var result = new
            {
                Table0 = new[]
                {
                    new { StatsDate = "2023-03-14", categories = "03-14", series = "94" },
                    new { StatsDate = "2023-03-16", categories = "03-16", series = "29" },
                    new { StatsDate = "2023-03-17", categories = "03-17", series = "20" },
                    new { StatsDate = "2023-03-21", categories = "03-21", series = "267" },
                    new { StatsDate = "2023-03-23", categories = "03-23", series = "876" },
                    new { StatsDate = "2023-04-03", categories = "04-03", series = "47" },
                    new { StatsDate = "2023-04-04", categories = "04-04", series = "52" },
                    new { StatsDate = "2023-04-05", categories = "04-05", series = "222" },
                    new { StatsDate = "2023-04-06", categories = "04-06", series = "198" },
                    new { StatsDate = "2023-04-07", categories = "04-07", series = "480" },
                    new { StatsDate = "2023-04-08", categories = "04-08", series = "1440" },
                    new { StatsDate = "2023-04-09", categories = "04-09", series = "1440" },
                    new { StatsDate = "2023-04-10", categories = "04-10", series = "475" },
                    new { StatsDate = "2023-04-11", categories = "04-11", series = "244" },
                    new { StatsDate = "2023-04-12", categories = "04-12", series = "250" },
                    new { StatsDate = "2023-04-14", categories = "04-14", series = "41" },
                    new { StatsDate = "2023-04-17", categories = "04-17", series = "16" },
                    new { StatsDate = "2023-04-19", categories = "04-19", series = "399" },
                    new { StatsDate = "2023-04-21", categories = "04-21", series = "40" },
                    new { StatsDate = "2023-04-22", categories = "04-22", series = "421" },
                    new { StatsDate = "2023-04-23", categories = "04-23", series = "420" },
                    new { StatsDate = "2023-04-24", categories = "04-24", series = "898" },
                    new { StatsDate = "2023-04-25", categories = "04-25", series = "1345" },
                    new { StatsDate = "2023-04-26", categories = "04-26", series = "943" },
                    new { StatsDate = "2023-04-27", categories = "04-27", series = "1027" },
                    new { StatsDate = "2023-04-28", categories = "04-28", series = "342" },
                    new { StatsDate = "2023-05-01", categories = "05-01", series = "421" },
                    new { StatsDate = "2023-05-02", categories = "05-02", series = "582" },
                    new { StatsDate = "2023-05-03", categories = "05-03", series = "713" },
                    new { StatsDate = "2023-05-04", categories = "05-04", series = "473" },
                    new { StatsDate = "2023-05-05", categories = "05-05", series = "420" },
                    new { StatsDate = "2023-05-08", categories = "05-08", series = "420" },
                    new { StatsDate = "2023-05-09", categories = "05-09", series = "420" },
                    new { StatsDate = "2023-05-10", categories = "05-10", series = "521" },
                    new { StatsDate = "2023-05-11", categories = "05-11", series = "419" },
                    new { StatsDate = "2023-05-12", categories = "05-12", series = "457" },
                    new { StatsDate = "2023-05-15", categories = "05-15", series = "139" },
                    new { StatsDate = "2023-05-18", categories = "05-18", series = "1463" },
                    new { StatsDate = "2023-05-19", categories = "05-19", series = "815" },
                    new { StatsDate = "2023-05-22", categories = "05-22", series = "421" },
                    new { StatsDate = "2023-05-23", categories = "05-23", series = "449" },
                    new { StatsDate = "2023-05-24", categories = "05-24", series = "186" },
                    new { StatsDate = "2023-05-25", categories = "05-25", series = "988" },
                    new { StatsDate = "2023-05-26", categories = "05-26", series = "420" },
                    new { StatsDate = "2023-05-29", categories = "05-29", series = "421" },
                    new { StatsDate = "2023-05-30", categories = "05-30", series = "488" },
                    new { StatsDate = "2023-05-31", categories = "05-31", series = "427" },
                    new { StatsDate = "2023-06-01", categories = "06-01", series = "247" },
                    new { StatsDate = "2023-06-05", categories = "06-05", series = "421" },
                    new { StatsDate = "2023-06-06", categories = "06-06", series = "421" },
                    new { StatsDate = "2023-06-07", categories = "06-07", series = "420" },
                    new { StatsDate = "2023-06-08", categories = "06-08", series = "419" }
                }
            };
            return result;
        }

        /// <summary>
        /// 일자별 사용자 연결 시간 조회
        /// </summary>
        /// <returns></returns>
        public object GetDailyUserConnection()
        {
            var result = new
            {
                Table0 = new[]
                {
                    new { StatsDate = "2023-03-14", categories = "03-14", series = "0" },
                    new { StatsDate = "2023-03-16", categories = "03-16", series = "0" },
                    new { StatsDate = "2023-03-17", categories = "03-17", series = "0" },
                    new { StatsDate = "2023-03-21", categories = "03-21", series = "0" },
                    new { StatsDate = "2023-03-23", categories = "03-23", series = "0" },
                    new { StatsDate = "2023-04-03", categories = "04-03", series = "0" },
                    new { StatsDate = "2023-04-04", categories = "04-04", series = "0" },
                    new { StatsDate = "2023-04-05", categories = "04-05", series = "0" },
                    new { StatsDate = "2023-04-06", categories = "04-06", series = "0" },
                    new { StatsDate = "2023-04-07", categories = "04-07", series = "0" },
                    new { StatsDate = "2023-04-08", categories = "04-08", series = "0" },
                    new { StatsDate = "2023-04-09", categories = "04-09", series = "0" },
                    new { StatsDate = "2023-04-10", categories = "04-10", series = "0" },
                    new { StatsDate = "2023-04-11", categories = "04-11", series = "88" },
                    new { StatsDate = "2023-04-12", categories = "04-12", series = "89" },
                    new { StatsDate = "2023-04-14", categories = "04-14", series = "22" },
                    new { StatsDate = "2023-04-17", categories = "04-17", series = "13" },
                    new { StatsDate = "2023-04-19", categories = "04-19", series = "32" },
                    new { StatsDate = "2023-04-21", categories = "04-21", series = "0" },
                    new { StatsDate = "2023-04-22", categories = "04-22", series = "0" },
                    new { StatsDate = "2023-04-23", categories = "04-23", series = "0" },
                    new { StatsDate = "2023-04-24", categories = "04-24", series = "12" },
                    new { StatsDate = "2023-04-25", categories = "04-25", series = "43" },
                    new { StatsDate = "2023-04-26", categories = "04-26", series = "177" },
                    new { StatsDate = "2023-04-27", categories = "04-27", series = "28" },
                    new { StatsDate = "2023-04-28", categories = "04-28", series = "119" },
                    new { StatsDate = "2023-05-01", categories = "05-01", series = "0" },
                    new { StatsDate = "2023-05-02", categories = "05-02", series = "152" },
                    new { StatsDate = "2023-05-03", categories = "05-03", series = "119" },
                    new { StatsDate = "2023-05-04", categories = "05-04", series = "166" },
                    new { StatsDate = "2023-05-05", categories = "05-05", series = "0" },
                    new { StatsDate = "2023-05-08", categories = "05-08", series = "0" },
                    new { StatsDate = "2023-05-09", categories = "05-09", series = "0" },
                    new { StatsDate = "2023-05-10", categories = "05-10", series = "110" },
                    new { StatsDate = "2023-05-11", categories = "05-11", series = "0" },
                    new { StatsDate = "2023-05-12", categories = "05-12", series = "30" },
                    new { StatsDate = "2023-05-15", categories = "05-15", series = "28" },
                    new { StatsDate = "2023-05-18", categories = "05-18", series = "35" },
                    new { StatsDate = "2023-05-19", categories = "05-19", series = "37" },
                    new { StatsDate = "2023-05-22", categories = "05-22", series = "0" },
                    new { StatsDate = "2023-05-23", categories = "05-23", series = "0" },
                    new { StatsDate = "2023-05-24", categories = "05-24", series = "0" },
                    new { StatsDate = "2023-05-25", categories = "05-25", series = "0" },
                    new { StatsDate = "2023-05-26", categories = "05-26", series = "0" },
                    new { StatsDate = "2023-05-29", categories = "05-29", series = "0" },
                    new { StatsDate = "2023-05-30", categories = "05-30", series = "0" },
                    new { StatsDate = "2023-05-31", categories = "05-31", series = "0" },
                    new { StatsDate = "2023-06-01", categories = "06-01", series = "0" },
                    new { StatsDate = "2023-06-05", categories = "06-05", series = "0" },
                    new { StatsDate = "2023-06-06", categories = "06-06", series = "0" },
                    new { StatsDate = "2023-06-07", categories = "06-07", series = "0" },
                    new { StatsDate = "2023-06-08", categories = "06-08", series = "0" }
                }
            };
            return result;
        }

        /// <summary>
        /// Task 조회
        /// </summary>
        /// <returns></returns>
        public object GetTask()
        {
            object result = new[]
            {
                new { DTM_LOG = "2023-06-09 04:00:03", DS_CATEGORY = "일정동기화", DS_CONTENT = "전체 동기화 자동 종료", STATUSImg = "success" },
                new { DTM_LOG = "2023-06-09 04:00:02", DS_CATEGORY = "일정동기화", DS_CONTENT = "전체 동기화 자동 시작", STATUSImg = "danger" },
                new { DTM_LOG = "2023-06-09 01:05:02", DS_CATEGORY = "일정동기화", DS_CONTENT = "일자별 현황 자동 시작", STATUSImg = "success" },
                new { DTM_LOG = "2023-06-09 01:05:02", DS_CATEGORY = "일정동기화", DS_CONTENT = "일자별 현황 자동 종료", STATUSImg = "success" },
                new { DTM_LOG = "2023-06-08 04:00:02", DS_CATEGORY = "일정동기화", DS_CONTENT = "전체 동기화 자동 종료", STATUSImg = "success" },
                new { DTM_LOG = "2023-06-08 04:00:01", DS_CATEGORY = "일정동기화", DS_CONTENT = "전체 동기화 자동 시작", STATUSImg = "danger" },
                new { DTM_LOG = "2023-06-08 01:05:02", DS_CATEGORY = "일정동기화", DS_CONTENT = "일자별 현황 자동 시작", STATUSImg = "success" },
                new { DTM_LOG = "2023-06-08 01:05:02", DS_CATEGORY = "일정동기화", DS_CONTENT = "일자별 현황 자동 종료", STATUSImg = "success" },
                new { DTM_LOG = "2023-06-07 04:00:01", DS_CATEGORY = "일정동기화", DS_CONTENT = "전체 동기화 자동 종료", STATUSImg = "success" },
                new { DTM_LOG = "2023-06-07 04:00:00", DS_CATEGORY = "일정동기화", DS_CONTENT = "전체 동기화 자동 시작", STATUSImg = "success" }
            };

            return result;

        }

        /// <summary>
        /// 시간당 VM 접속 수 조회
        /// </summary>
        /// <returns></returns>
        public object GetTimeVMConnectCnt()
        {
            object result = new
            {
                Table0 = new[]
                {
                    new
                    {
                        H = "0",
                        TODAY_VM_CONNECTIONS = 10,
                        YESTERDAY_VM_CONNECTIONS = 20,
                        AVG_VM_CONNECTIONS = 15
                    },
                    new
                    {
                        H = "1",
                        TODAY_VM_CONNECTIONS = 20,
                        YESTERDAY_VM_CONNECTIONS = 20,
                        AVG_VM_CONNECTIONS = 10
                    },
                    new
                    {
                        H = "2",
                        TODAY_VM_CONNECTIONS = 100,
                        YESTERDAY_VM_CONNECTIONS = 200,
                        AVG_VM_CONNECTIONS = 150
                    },
                    new
                    {
                        H = "3",
                        TODAY_VM_CONNECTIONS = 50,
                        YESTERDAY_VM_CONNECTIONS = 100,
                        AVG_VM_CONNECTIONS = 75
                    },
                    new
                    {
                        H = "4",
                        TODAY_VM_CONNECTIONS = 30,
                        YESTERDAY_VM_CONNECTIONS = 60,
                        AVG_VM_CONNECTIONS = 45
                    },
                    new
                    {
                        H = "5",
                        TODAY_VM_CONNECTIONS = 40,
                        YESTERDAY_VM_CONNECTIONS = 60,
                        AVG_VM_CONNECTIONS = 50
                    },
                    new
                    {
                        H = "6",
                        TODAY_VM_CONNECTIONS = 300,
                        YESTERDAY_VM_CONNECTIONS = 100,
                        AVG_VM_CONNECTIONS = 200
                    },
                    new
                    {
                        H = "7",
                        TODAY_VM_CONNECTIONS = 50,
                        YESTERDAY_VM_CONNECTIONS = 30,
                        AVG_VM_CONNECTIONS = 40
                    },
                    new
                    {
                        H = "8",
                        TODAY_VM_CONNECTIONS = 110,
                        YESTERDAY_VM_CONNECTIONS = 70,
                        AVG_VM_CONNECTIONS = 90
                    },
                    new
                    {
                        H = "9",
                        TODAY_VM_CONNECTIONS = 200,
                        YESTERDAY_VM_CONNECTIONS = 100,
                        AVG_VM_CONNECTIONS = 150
                    },
                    new
                    {
                        H = "10",
                        TODAY_VM_CONNECTIONS = 20,
                        YESTERDAY_VM_CONNECTIONS = 10,
                        AVG_VM_CONNECTIONS = 15
                    },
                    new
                    {
                        H = "11",
                        TODAY_VM_CONNECTIONS = 10,
                        YESTERDAY_VM_CONNECTIONS = 10,
                        AVG_VM_CONNECTIONS = 10
                    }
                }
            };
            return result;
        }

        /// <summary>
        /// 타입별 비용 (현재월 기준)
        /// </summary>
        /// <returns></returns>
        public object GetTypeCost()
        {
            var data1 = new[]
            {
                new { ResourceType = "DISKS", TotalCost = "14930" },
                new { ResourceType = "IMAGES", TotalCost = "899" },
                new { ResourceType = "STORAGEACCOUNTS", TotalCost = "2050" },
                new { ResourceType = "VIRTUALMACHINES", TotalCost = "6259" },
                new { ResourceType = "Total", TotalCost = "24138" }
            };

            var data2 = new[]
                        {
                new { CurrentMonth = "2023-06" }
            };

            var result = new
            {
                Table0 = data1,
                Table1 = data2
            };
            return result;
        }
    }
}