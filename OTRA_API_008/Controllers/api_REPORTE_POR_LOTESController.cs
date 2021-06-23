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
    public class api_REPORTE_POR_LOTESController : ApiController
    {

        public Newtonsoft.Json.Linq.JArray Get()
        {
            api_REPORTE_POR_LOTES REPORTE = new api_REPORTE_POR_LOTES();
            JArray result = new JArray();
            result = REPORTE.REPORTE();
            return result;
        }
    }
}