using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;
using SpaceXSolution.Models;

namespace SpaceXSolution.Infrastructure
{
    public class SpaceXLaunchPadData : ISpaceXLaunchPadData
    {
        private readonly HttpClient _client;
        private readonly ILogger _logger;

        public SpaceXLaunchPadData(HttpClient httpClient, ILoggerFactory logger)
        {
            _logger = logger.CreateLogger("SDCAPIExample.Infrastructure.SpaceXAPIService");

            httpClient.BaseAddress = new Uri("https://api.spacexdata.com");
            httpClient.DefaultRequestHeaders.Add("Accept", "application/vnd.github.v3+json");
            httpClient.DefaultRequestHeaders.Add("User-Agent", "HttpClientFactory-Sample");
            _client = httpClient;
        }

        public async Task<List<SpaceXLaunchPad>> GetDataAsync(SpaceXLaunchPadFilter filter)
        {
            try
            {
                var jsonresponse = ""; 
                if(Int32.Parse(filter.Limit) != 0)
                {
                    jsonresponse = await _client.GetStringAsync("/v2/launchpads?limit=" + Int32.Parse(filter.Limit));
                } else
                {
                    jsonresponse = await _client.GetStringAsync("/v2/launchpads");
                }
                _logger.LogDebug("Http request successful");

                return JsonConvert.DeserializeObject<List<SpaceXLaunchPad>>(jsonresponse); ;
            }
            catch (Exception ex)
            {
                _logger.LogError("Http request failed: {errormessage}", ex.Message);
                return null;
            }

        }

        //Implement a DB solution for the SpaceXLaunchPadData interface
        //public async Task<List<SpaceXLaunchPad>> GetDataAsync()
        //{
        //    //db solution - assumption that dbcontext has been injected via the controller************** 
        //    //replace spacex api call with this. only changes that are needed in the api
        //    try
        //    {
        //        //create a list from table context that would be available here, may need some tweeking
        //        //assumes a spacexlaunchpad table
        //        sxlp = _context.spacexlaunchpad.tolist();
        //        _logger.logdebug("created launchpad info from db table);
        //    }
        //    catch (exception ex)
        //    {
        //        _logger.logerror("db retrieval failed: {errormessage}", ex.message);
        //    }
        //    //end db solution modification***************************************************************
        //}
    }
}
