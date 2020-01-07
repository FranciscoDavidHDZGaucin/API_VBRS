using Newtonsoft.Json.Linq;
using OTRA_API_008.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace OTRA_API_008.Controllers
{
    public class VTS_TOTALESController : ApiController
    {

        public JArray Get(int typeres )
        {
            VTS_TOTALES VSTOTALES = new VTS_TOTALES();
            JArray result = new JArray(); 
            if (typeres == 21202025) {
                result =  VSTOTALES.VTS_TODAS_TTAL_GRAFIC_COSTOS();
            }
            if (typeres == 21202027)
            {
                result=  VSTOTALES.VTS_TODAS_NORMALIZADAS();
            }
            return result;
        }


    }
}
