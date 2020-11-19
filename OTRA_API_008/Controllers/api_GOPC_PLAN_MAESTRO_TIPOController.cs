using System;
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
    public class api_GOPC_PLAN_MAESTRO_TIPOController : ApiController
    {
        public Newtonsoft.Json.Linq.JArray Get(String tipo)
        {
            api_GOPC_PLAN_MAESTRO_TIPO gopc_plan = new api_GOPC_PLAN_MAESTRO_TIPO();
            JArray result = new JArray();
            result = gopc_plan.PLAN_MAESTRO(tipo);
            return result;
        }
    }
}