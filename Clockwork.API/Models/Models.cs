using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using Microsoft.EntityFrameworkCore;

namespace Clockwork.API.Models
{
    public class ClockworkContext : DbContext
    {
        public DbSet<CurrentTimeQuery> CurrentTimeQueries { get; set; }
        public DbSet<TimeZones> TimeZone { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlite("Data Source=clockwork.db");
        }
    }

    public class CurrentTimeQuery
    {
        public int CurrentTimeQueryId { get; set; }
        public DateTime Time { get; set; }
        public string ClientIp { get; set; }
        public DateTime UTCTime { get; set; }
        public string SelectedTimeZone { get; set; }
    }

    public class TimeZones
    {
        [Key]
        public int TimeZoneId { get; set; }
        public string TimeZoneName { get; set; }
        public int TimeZoneValue { get; set; }
        public List<TimeZones> TimeZoneList { get; set; }
    }
}
