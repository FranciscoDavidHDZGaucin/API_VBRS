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
    public class PRESUPUESTO_DIMController : ApiController
    {


        public Newtonsoft.Json.Linq.JArray Get()
        {
            PRESUPUESTO_DIM PRESUP_DIM = new PRESUPUESTO_DIM();
            JArray result = new JArray();
            result = PRESUP_DIM.DIM_PRESU();
            return result;
        }


    }
}