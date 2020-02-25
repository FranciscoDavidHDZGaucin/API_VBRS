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
    public class VTS_FECHAController : ApiController
    {

        public JArray Get(DateTime ini, DateTime fin)
        {
            VRS_VTS_FECHA VTSFECHA= new VRS_VTS_FECHA();
            JArray result = new JArray();
            var date1 = new DateTime(2020, 2, 1);
            var date2 = new DateTime(2020, 2, 17);
            result = VTSFECHA.VTS_TODAS_NORMALIZADAS(ini, fin);
            
            return result;
        }

    }
}
