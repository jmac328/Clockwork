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

        public static string AdjustedCurrentTime (DateTime time, int timeZoneValue)
        {
            var result = "";
            var hour = AdjustedTime(time.TimeOfDay.Hours, timeZoneValue);

            result = "The current time is " + hour + ":" + time.TimeOfDay.Minutes + ":" + time.TimeOfDay.Seconds + " The date is " + time.Month + "/" + time.Day + "/" + time.Year;

            return result;
        }

        public static List<string> GetTimeZones()
        {
            using (var connection = new SqliteConnection("Data Source=clockwork.db"))
            {
                connection.Open();

                var command = connection.CreateCommand();
                command.CommandText = @"Select TimeZoneName from TimeZones";

                var timeZones = new List<string>();

                using (var reader = command.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        var timeZoneName = reader.GetString(0);
                        timeZones.Add(timeZoneName);
                    }
                }
                return timeZones;
            }
        }

        public static int GetTimeZoneValue(string timeZoneName)
        {
            using (var connection = new SqliteConnection("Data Source=clockwork.db"))
            {
                connection.Open();

                var command = connection.CreateCommand();
                command.CommandText = $@"Select TimeZoneValue from TimeZones where TimeZoneName = '{ timeZoneName }'";

                var timeZoneValue = 0;

                using (var reader = command.ExecuteReader())
                {
                    while (reader.Read())
                    {
                       timeZoneValue = reader.GetInt32(0);  
                    }
                }
                return timeZoneValue;
            }
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

