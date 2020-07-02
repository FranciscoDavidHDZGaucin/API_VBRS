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
    public class apiOBJETIVO_AGENTESController : ApiController
    {

        public Newtonsoft.Json.Linq.JArray Get()
        {
            apiOBJETIVO_AGENTES ApiObjetivo = new apiOBJETIVO_AGENTES();
            JArray result = new JArray();
            result = ApiObjetivo.objetivoAGENTES();
            return result;
        }

    }
}