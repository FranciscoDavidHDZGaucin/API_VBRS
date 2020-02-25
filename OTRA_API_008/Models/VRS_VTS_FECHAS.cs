using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System.Data;
using System.Data.SqlClient;

namespace OTRA_API_008.Models
{
    public class VRS_VTS_FECHAS
    {
        private Double TotMonto;


        private SqlDataReader drd;

        public List<DataTable> _RES_TOTALES = null;


        public Newtonsoft.Json.Linq.JArray GETVTS(DateTime IniFecha, DateTime FinFecha)
        {
            int resultado = 00;
            try
            {
                using (SqlConnection CONNECT = new SqlConnection(@"Data Source=SRV-DBGW;Initial Catalog=JUPITER;User ID=sa;Password=DB@gr0V3rs@"))
                {
                    CONNECT.Open();
                    using (SqlCommand commando = new SqlCommand("SP_VRS_VENTAS_BY_FECHA", CONNECT))
                    {
                        commando.CommandType = CommandType.StoredProcedure;
                        commando.Parameters.Add("@FechaIni", SqlDbType.DateTime);
                        commando.Parameters.Add("@FechaFin", SqlDbType.DateTime);

                        commando.Parameters["@FechaIni"].Value = IniFecha;
                        commando.Parameters["@FechaFin"].Value = FinFecha;
                        drd = commando.ExecuteReader();

                        if (drd.Read())
                        {

                            TotMonto = Convert.ToDouble(drd["MONTO"]);

                            object[] _objt_TotVenta = { "TotMonto", TotMonto };

                        }

                            resultado = 88;
                    }




                }


            }
            catch (Exception e)
            {
                resultado = 23;


            }

            return resultado;
        }
    }
}