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
    public class VTS_DETALLEController : ApiController
    {

        public Newtonsoft.Json.Linq.JArray Get()
        {
            VTS_DETALLE VTSDETALLE = new VTS_DETALLE();
            JArray result = new JArray();
            result = VTSDETALLE.VTS_SP_DETALLE();
            return result;
        }

    }
}