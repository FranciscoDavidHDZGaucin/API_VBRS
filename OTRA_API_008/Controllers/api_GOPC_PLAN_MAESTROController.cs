﻿using System;
using System.Collections.Generic;
using OTRA_API_008.Models;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System.Data;
using System.Data.SqlClient;

namespace OTRA_API_008.Controllers
{
    public class api_GOPC_PLAN_MAESTROController : ApiController
    {

        public Newtonsoft.Json.Linq.JArray Get()
        {
            api_GOPC_PLAN_MAESTRO gopc_plan = new api_GOPC_PLAN_MAESTRO();
            JArray result = new JArray();
            result = gopc_plan.PLAN_MAESTRO();
            return result;
        }

    }
}