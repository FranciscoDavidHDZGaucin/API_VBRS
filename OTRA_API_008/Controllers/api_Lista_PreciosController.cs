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
    public class api_Lista_PreciosController : ApiController
    {

        public Newtonsoft.Json.Linq.JArray Get()
        {
            api_Lista_Precios LP = new api_Lista_Precios();
            JArray result = new JArray();
            result = LP.LPRECIOS();
            return result;
        }
    }
}