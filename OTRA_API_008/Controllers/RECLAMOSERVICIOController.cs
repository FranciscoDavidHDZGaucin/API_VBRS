using OTRA_API_008.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace OTRA_API_008.Controllers
{
    public class RECLAMOSERVICIOController : ApiController
    {

        public int Get(int folio)
        {

            RECLAMOS_BD_MAIL SENRECLAMO = new RECLAMOS_BD_MAIL();
            return SENRECLAMO.SEND_MAIL_SERVICIO(folio);

        }


    }
}
