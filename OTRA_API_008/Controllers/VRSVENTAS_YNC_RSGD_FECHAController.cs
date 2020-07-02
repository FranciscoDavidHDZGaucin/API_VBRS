using OTRA_API_008.Models;
using System;
using System.Web.Http;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System.Data;
using System.Data.SqlClient;

namespace OTRA_API_008.Controllers
{
    public class VRSVENTAS_YNC_RSGD_FECHAController : ApiController
    {
        public Newtonsoft.Json.Linq.JArray Get()
        {
            VERSA_VTS_VS_GOPC_SP_FECHA VTSFECHA = new VERSA_VTS_VS_GOPC_SP_FECHA();
            JArray result = new JArray();
            result = VTSFECHA.VTS_FECHA_VTS();
            return result;
        }
    }
}