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
    public class vwCAT_PRODUCTOSController : ApiController
    {

        public Newtonsoft.Json.Linq.JArray Get()
        {
            vwCAT_PRODUCTOS PRODUCTOS = new vwCAT_PRODUCTOS();
            JArray result = new JArray();
            result = PRODUCTOS.CAT_PRODUCTOS();
            return result;
        }



    }

}