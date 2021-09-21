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
    public class api_Logistica_Fletes_TR_RFController : ApiController
    {

        public Newtonsoft.Json.Linq.JArray Get()
        {
            api_Logistica_Fletes_TR_RF FLETES = new api_Logistica_Fletes_TR_RF();
            JArray result = new JArray();
            result = FLETES.Fletes();
            return result;
        }
    }
}