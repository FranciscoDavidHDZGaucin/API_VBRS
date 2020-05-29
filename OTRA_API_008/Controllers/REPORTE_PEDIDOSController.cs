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
    public class REPORTE_PEDIDOSController : ApiController
    {


        public Newtonsoft.Json.Linq.JArray Get()
        {
            apiREPORTE_PEDIDOS REPORT_PEDIDOS = new apiREPORTE_PEDIDOS();
            JArray result = new JArray();
            result = REPORT_PEDIDOS.REP_PEDIDOS();
            return result;
        }

    }
}