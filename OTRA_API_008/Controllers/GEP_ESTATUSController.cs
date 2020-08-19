using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System.Data;
using System.Data.SqlClient;
namespace OTRA_API_008.Models
{
    public class GEP_ESTATUSController : ApiController
    {
        public Newtonsoft.Json.Linq.JArray Get ( string  typo_filtro )
        {
            GEP_ESTAUS_ALL GEP_ESTATUS  = new GEP_ESTAUS_ALL();
            JArray result = new JArray();

            if (typo_filtro.Equals("PEDIDOS"))
            {
                result = GEP_ESTATUS.GEP_ESTATUS_PEDIDOS();


            }
            if (typo_filtro.Equals("LOGISTICA"))
            {
                

                result = GEP_ESTATUS.GEP_ESTATUS_LOGISTICA();
            }
            if (typo_filtro.Equals("TRANSPORTE") )
            {


                result = GEP_ESTATUS.GEP_ESTATUS_TRASNPORTE();
            }

           
            return result;
        }
    }
}
