﻿// ------------------------------------------------------------
//  Licensed under the MIT License (MIT). See License.txt in the repo root for license information.
// ------------------------------------------------------------

namespace Xray.Controllers
{
    using Microsoft.AspNetCore.Mvc;
    using Services;
    using System.Collections.Generic;
    using System.Threading.Tasks;
    using Xray.Models;

    [Route("api/[controller]")]
    public class ApplicationController : Controller
    {
        private readonly IClusterInformationService clusterInfoService;

        public ApplicationController(IClusterInformationService historyService)
        {
            this.clusterInfoService = historyService;
        }

        [HttpGet("{nodeName}")]
        public Task<IEnumerable<DeployedApplicationModel>> Get(string nodeName)
        {
            return this.clusterInfoService.GetApplicationMetrics(nodeName, null);
        }

        [HttpGet("{nodeName}/{appTypeFilter}")]
        public Task<IEnumerable<DeployedApplicationModel>> Get(string nodeName, string appTypeFilter)
        {
            return this.clusterInfoService.GetApplicationMetrics(nodeName, appTypeFilter);
        }
    }
}