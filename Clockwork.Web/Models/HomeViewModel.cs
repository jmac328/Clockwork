using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;



namespace Clockwork.Web.Models
{
    public class HomeViewModel
    {
        public int SelectedTimeZone { get; set; }
        public string TimeZoneName { get; set; }
        public int TimeZoneValue { get; set; }
        public List<TimeZones> TimeZoneList { get; set; }
    }

    public class TimeZones
    {
        public int TimeZoneId { get; set; }
        public string TimeZoneName { get; set; }
        public int TimeZoneValue { get; set; }
        public List<TimeZones> TimeZoneList { get; set; }
    }

    public class CurrentTimeQueryViewModel
    {
        public int CurrentTimeQueryId { get; set; }
        public DateTime Time { get; set; }
        public string ClientIp { get; set; }
        public DateTime UTCTime { get; set; }
        public string SelectedTimeZone { get; set; }
        public List<CurrentTimeQueryViewModel> TimeQueriesList { get; set; }
    }
}