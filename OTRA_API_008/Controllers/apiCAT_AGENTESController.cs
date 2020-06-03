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
    public class apiCAT_AGENTESController : ApiController
    {

        public Newtonsoft.Json.Linq.JArray Get()
        {
            apiCAT_AGENTES Apigente = new apiCAT_AGENTES();
            JArray result = new JArray();
            result = Apigente.AGENTES();
            return result;
        }
    }
}