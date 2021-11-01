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
    public class api_VW_REPORTE_INVENTARIO_BIController : ApiController
    {

        public Newtonsoft.Json.Linq.JArray Get()
        {
            api_VW_REPORTE_INVENTARIO_BI Progr = new api_VW_REPORTE_INVENTARIO_BI();
            JArray result = new JArray();
            result = Progr.INVENTARIO();
            return result;
        }
    }
}