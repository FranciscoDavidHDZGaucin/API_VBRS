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
    public class apiTB_RSGDController : ApiController
    {

        public Newtonsoft.Json.Linq.JArray Get()
        {
            apiTB_RSGD ApiRSGD = new apiTB_RSGD();
            JArray result = new JArray();
            result = ApiRSGD.RSGD();
            return result;
        }

    }
}