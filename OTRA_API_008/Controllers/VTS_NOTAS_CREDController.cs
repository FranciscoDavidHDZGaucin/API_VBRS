using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using OTRA_API_008.Models;
using System.Data;
using System.Data.SqlClient;

namespace OTRA_API_008.Controllers
{
    public class VTS_NOTAS_CREDController : ApiController
    {
        public JArray Get(DateTime ini, DateTime fin)
        {
            VRS_VTS_NOTA_CRED VTSFECHA = new VRS_VTS_NOTA_CRED();
            JArray result = new JArray();
            var date1 = new DateTime(2020, 2, 1);
            var date2 = new DateTime(2020, 2, 17);
            result = VTSFECHA.VTS_NOTA_CRED(ini, fin);

            return result;
        }
    }
}
