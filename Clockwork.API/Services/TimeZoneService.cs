using Clockwork.API.Models;
using System;
using System.Collections.Generic;
using Microsoft.Data.Sqlite;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using System.Threading.Tasks;

namespace Clockwork.API.Services
{
  
    public class TimeZoneService
    {
        public static int AdjustedTime (int hour, int timeZoneValue)
        {
            var newHour = (hour + timeZoneValue) % 24;

            return newHour;
        }

        public static List<string> GetAllTimeZones()
        {
            List<string> timeZones = new List<string>();
            List<TimeZoneInfo> zones = new List<TimeZoneInfo>();
            zones = TimeZoneInfo.GetSystemTimeZones().ToList();

            foreach(var zone in zones)
            {
                timeZones.Add(zone.Id);
            }
            return timeZones;
        }

        public static DateTime GetTime(string name)
        {
            var timeZone = TimeZoneInfo.FindSystemTimeZoneById(name);
            var currentTime = TimeZoneInfo.ConvertTimeFromUtc(DateTime.UtcNow, timeZone);
            
            return currentTime;
        }
    }
}

