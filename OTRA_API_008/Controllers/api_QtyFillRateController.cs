using Newtonsoft.Json.Linq;
using OTRA_API_008.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace OTRA_API_008.Controllers
{
    public class api_QtyFillRateController : ApiController
    {
        public Newtonsoft.Json.Linq.JArray Get(string TIPO)
        {
            api_QtyFillRate Main_objt = new api_QtyFillRate();
            JArray result = new JArray();
            switch (TIPO)
            {
                case "PEDIDOS":

                    result = Main_objt.QtyFillRate_DETALLE_PEDIDOS(); 
                    break;
                case "FACTURAS":
                    result = Main_objt.QtyFillRate_FACTURA();

                    break;
                case "REPORTE":
                    result = Main_objt.QtyFillRate_REPT_LOG_PEDIDOS(); 

                    break;

                case "UNES_REPORTE":
                    result = Main_objt.QtyFillRate_REPORTE_LOGISTICA_UNES();
                    break;
                case "FACTURAS_BACK":
                    result = Main_objt.QtyFillRate_FACTURAS_BACK_ORDER();
                    break;

                case "PEDIDOSCANTIDAD_ORIGINAL":
                    result = Main_objt.QtyFillRate_DETALLE_PEDIDOS_CANTIDA_ORIGINAL_FACTURADA();
                        break;

            }


            return result; 

        }



    }
}
