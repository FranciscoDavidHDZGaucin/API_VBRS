using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace OTRA_API_008.Controllers
{
    public class REPORTE_OTIFController : ApiController
    {

        public JArray Get()
        {
            Models.api_REPORTE_OTIF otif = new Models.api_REPORTE_OTIF();
            JArray result = new JArray();
            
                result = otif.REPORTE_OTIF_DOS_MESES();
            
            return result;
        }



    }
}
