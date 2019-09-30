using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using Microsoft.Extensions.Logging;
using SpaceXSolution.Models;
using SpaceXSolution.Infrastructure;

namespace SpaceXSolution.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SpaceXLaunchPadController : ControllerBase
    {
        //inject the logger
        private readonly ILogger _logger;
        private readonly ISpaceXLaunchPadData _spacexlaunchpaddata;
        public SpaceXLaunchPadController(ILoggerFactory logger, ISpaceXLaunchPadData spacexlaunchpaddata)
        {
            _logger = logger.CreateLogger("SDCAPIExample.Controllers.SpaceXLaunchPadController");
            _spacexlaunchpaddata = spacexlaunchpaddata;
        }

        // GET: api/SpaceXLaunchPad
        [HttpGet("getlpinfo")]
        public async Task<ActionResult> GetLPInfo([FromQuery]SpaceXLaunchPadFilter filter)
        {
            List<SpaceXLaunchPad> sxlp = new List<SpaceXLaunchPad>();
            sxlp = await _spacexlaunchpaddata.GetDataAsync(filter);
            //return require data to client
            List<SDCLaunchPadInfo> sdcobj = new List<SDCLaunchPadInfo>();
            foreach (var record in sxlp)
            {
                sdcobj.Add(new SDCLaunchPadInfo() { Id = record.Id, Full_name = record.Full_name, Status = record.Status });
            }
            if (filter.Status != null && filter.Status != "all")
            {
                List<SDCLaunchPadInfo> filteredsdcobj = sdcobj.Where(p => p.Status == filter.Status).ToList();
                return new ObjectResult(filteredsdcobj);
            }

            return new ObjectResult(sdcobj);
        }

        // GET: api/SpaceXLaunchPad/5
        [HttpGet("{id}", Name = "Get")]
        public string Get(int id)
        {
            return "value";
        }

      
    }
}
