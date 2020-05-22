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
    public class API_PRESUPUESTO_MENSUALController : ApiController
    {

        public Newtonsoft.Json.Linq.JArray Get()
        {
            API_PRESUPUESTO_MENSUAL ApiPresu = new API_PRESUPUESTO_MENSUAL();
            JArray result = new JArray();
            result = ApiPresu.PRESUPUESTO();
            return result;
        }

    }
}