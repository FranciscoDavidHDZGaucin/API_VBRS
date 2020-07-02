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
    public class apiREPORTE_PEDIDOS_FOLIOSController : ApiController
    {

        public Newtonsoft.Json.Linq.JArray Get()
        {
            apiREPORTE_PEDIDOS_FOLIOS ApiObjetivo = new apiREPORTE_PEDIDOS_FOLIOS();
            JArray result = new JArray();
            result = ApiObjetivo.REPORTE_PED_FOLIOS();
            return result;
        }
    }
}