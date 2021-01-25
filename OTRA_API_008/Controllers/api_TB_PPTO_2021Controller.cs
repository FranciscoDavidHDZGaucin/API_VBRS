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
    public class api_TB_PPTO_2021Controller : ApiController
    {

        public Newtonsoft.Json.Linq.JArray Get()
        {
            api_TB_PPTO_2021 ppto = new api_TB_PPTO_2021();
            JArray result = new JArray();
            result = ppto.TB_PPT0_2021();
            return result;
        }
    }
}