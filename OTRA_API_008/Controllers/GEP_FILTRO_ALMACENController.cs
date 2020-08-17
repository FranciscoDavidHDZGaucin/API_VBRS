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
    public class GEP_FILTRO_ALMACENController : ApiController
    {
        public Newtonsoft.Json.Linq.JArray Get(String SKY, String NOM, Int32 AGE)
        {
            GEP_FILTRO_ALMACEN Api_filtro_Almacen = new GEP_FILTRO_ALMACEN();





            return Api_filtro_Almacen.FILTRO_ALMACEN(SKY, NOM, AGE);
        }
    }
}