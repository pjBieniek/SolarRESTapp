﻿using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using InfluxData.Net.Common.Enums;
using InfluxData.Net.InfluxDb;
using InfluxData.Net.InfluxDb.Models.Responses;
using Microsoft.AspNetCore.Mvc;

namespace SolarApp.API.Controllers
{
    [Route("api/influx")]
    [ApiController]
    public class InfluxController : ControllerBase
    {
        private InfluxDbClient clientDb;

        public InfluxController()
        {
            var infuxUrl = "http://localhost:8086/";
            var infuxUser = "admin";
            var infuxPwd = "admin";

            clientDb = new InfluxDbClient(infuxUrl, infuxUser, infuxPwd, InfluxDbVersion.Latest);
        }

        [HttpGet("databases")]
        public async Task<IEnumerable<Database>> ReadDatabases()
        {
            var response = await clientDb.Database.GetDatabasesAsync();
            return response;
        }

        [HttpGet("databases/telegrafAllData")] // dodać limit do body
        public async Task<List<Serie>> GetTelegraf(int limit=1000)
        {
            //string instanceLimit = "_Total";
            var queries = new[]
            {
              $" SELECT * FROM win_cpu where instance = '_Total' order by time desc limit {limit};" 
              };
            var dbName = "telegraf";

            var response = await clientDb.Client.QueryAsync(queries, dbName);
            var series = response.ToList();
            var list = series[0].Values; // Extract the first data from the collection

            Response.Headers.Add("Access-Control-Allow-Origin", "*");
            var info_model = list.FirstOrDefault();

            return series;
        }

        [HttpGet("databases/telegraf")]
        public async Task<List<Serie>> GetTelegrafDetail(string field, int limit=30)
        {
            //string instanceLimit = "_Total";

            var queries = new[]
            {
              $" SELECT time, {field} FROM win_cpu where instance = '_Total' order by time desc limit {limit}"
              };
            var dbName = "telegraf";

            var response = await clientDb.Client.QueryAsync(queries, dbName);
            var series = response.ToList();
            var list = series[0].Values;
            // Extract the first data from the collection
            Response.Headers.Add("Access-Control-Allow-Origin", "*");
            var info_model = list.FirstOrDefault();

            return series;
        }


    }
}