﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Telemetry.API.Models;
using Telemetry.API.Service;

namespace Telemetry.API.Controller
{
    [Route("api/telemetry")]
    [ApiController]
    public class TelemetryModels : ControllerBase
    {
        private readonly Service.MongoService _models;
        public TelemetryModels(Service.MongoService models)
        {
            _models = models;
        }

        [HttpGet]
        public ActionResult<List<Models.TelemetryModels>> Get() => 
            _models.Get(); 
    }
}
