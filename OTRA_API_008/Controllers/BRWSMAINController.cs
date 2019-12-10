using OTRA_API_008.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace OTRA_API_008.Controllers
{
    public class BRWSMAINController : ApiController
    {
       public  DocMain_VRS tbla = new DocMain_VRS();
        /*RETORNAR TODOS  LOS ELEMENTOS*/
        public Newtonsoft.Json.Linq.JArray Get()
        {
            
            return tbla.Get_Json_data();     

        }
        public Newtonsoft.Json.Linq.JArray Get(int ANIO)
        {

            return tbla.Get_Data_ANIO(ANIO);


        }

    }
}
