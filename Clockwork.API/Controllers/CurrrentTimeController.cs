﻿using System;
using Microsoft.AspNetCore.Mvc;
using Clockwork.API.Models;
using Clockwork.API.Services;
using Microsoft.AspNetCore.Authorization;
using System.Collections.Generic;
using System.Linq;

namespace Clockwork.API.Controllers
{
   
    public class CurrentTimeController : Controller
    {
        [Route("api/currenttime")]
        [HttpGet]
        public IActionResult Get()
        {
            var utcTime = DateTime.UtcNow;
            var serverTime = DateTime.Now;
            var ip = this.HttpContext.Connection.RemoteIpAddress.ToString();

            var returnVal = new CurrentTimeQuery
            {
                UTCTime = utcTime,
                ClientIp = ip,
                Time = serverTime,
                SelectedTimeZone = TimeZoneInfo.Local.DisplayName
            };

            using (var db = new ClockworkContext())
            {
                db.CurrentTimeQueries.Add(returnVal);
                var count = db.SaveChanges();
                Console.WriteLine("{0} records saved to database", count);

                Console.WriteLine();
                foreach (var CurrentTimeQuery in db.CurrentTimeQueries)
                {
                    Console.WriteLine(" - {0}", CurrentTimeQuery.UTCTime);
                }
            }

            return Ok(returnVal);
        }

        [Route("api/timeZones")]
        [HttpGet]
        public IActionResult GetAllTimeZones()
        {
            try
            {
                return Ok(TimeZoneService.GetAllTimeZones());
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [Route("api/timeByZone/{timezonename}")]
        [HttpGet]
        public IActionResult GetTimeByZone([FromRoute(Name = "timezonename")]string timeZoneName)
        {
            var currentTime = TimeZoneService.GetTime(timeZoneName);

            var utcTime = DateTime.UtcNow;
            var serverTime = DateTime.Now;
            var ip = this.HttpContext.Connection.RemoteIpAddress.ToString();

            var returnVal = new CurrentTimeQuery
            {
                UTCTime = utcTime,
                ClientIp = ip,
                Time = serverTime,
                SelectedTimeZone = timeZoneName
            };

            using (var db = new ClockworkContext())
            {
                db.CurrentTimeQueries.Add(returnVal);
                var count = db.SaveChanges();
                Console.WriteLine("{0} records saved to database", count);

                Console.WriteLine();
                foreach (var CurrentTimeQuery in db.CurrentTimeQueries)
                {
                    Console.WriteLine(" - {0}", CurrentTimeQuery.UTCTime);
                }
            }


            try
            {
                return Ok(currentTime.ToString());
                //return Ok(TimeZoneService.GetTime(timeZoneName));
                //return Ok(TimeZoneService.AdjustedCurrentTime(DateTime.UtcNow, timeZoneValue));
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [Route("api/getall")]
        [HttpGet]
        public IActionResult GetAllRequests()
        {
            try
            {
                var returnVal = new List<CurrentTimeQuery>();

                using (var db = new ClockworkContext())
                {
                    returnVal.AddRange(db.CurrentTimeQueries.ToList());
                }

                return Ok(returnVal);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}
