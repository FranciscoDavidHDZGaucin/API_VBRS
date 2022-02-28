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
    public class api_VENTAS_ANIOS_PASADOS_2015_2017Controller : ApiController
    {
        public Newtonsoft.Json.Linq.JArray Get()
        {
            api_VENTAS_ANIOS_PASADOS_2015_2017 gopc_plan = new api_VENTAS_ANIOS_PASADOS_2015_2017();
            JArray result = new JArray();
            result = gopc_plan.PLAN_MAESTRO();
            return result;
        }
    }
}