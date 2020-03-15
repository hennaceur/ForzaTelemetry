using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Telemetry.API.Controller
{
    public class Endpoint : ControllerBase
    {
        [Route("api/telemetry")]
        [HttpGet]
        public async Action<> Get()
        {

        }
    }
}
