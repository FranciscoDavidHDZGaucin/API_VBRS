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
    public class VTS_TOTLS_GOPCController : ApiController
    {
        public JArray Get(string  INI , string FIN ) {

            VTS_TOTLS_GOPC GOPTTLS = new VTS_TOTLS_GOPC();
            JArray result = new JArray();
            DateTime date_INI = Convert.ToDateTime(INI);
            DateTime date_FIN = Convert.ToDateTime(FIN);
            result = GOPTTLS.GOPC_TOTALES(date_INI, date_FIN);
            return result;

        }


    }
}
