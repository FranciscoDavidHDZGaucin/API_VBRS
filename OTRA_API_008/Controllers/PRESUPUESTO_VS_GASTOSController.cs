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
    public class PRESUPUESTO_VS_GASTOSController : ApiController
    {

        public Newtonsoft.Json.Linq.JArray Get()
        {
            apiPRESUPUESTO_VS_GASTOS PRESUP_GAST = new apiPRESUPUESTO_VS_GASTOS();
            JArray result = new JArray();
            result = PRESUP_GAST.PRESUPUESTO_GASTOS();
            return result;
        }

    }
}