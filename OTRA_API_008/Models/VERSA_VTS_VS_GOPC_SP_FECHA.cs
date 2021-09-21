using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace OTRA_API_008.Models
{
    public class VERSA_VTS_VS_GOPC_SP_FECHA
    {
        private SqlDataReader drd;

        private DateTime NOWDAY = DateTime.Now;

        public List<DataTable> _RES_TOTALES = null;

        public Newtonsoft.Json.Linq.JArray VTS_FECHA_VTS()
        {

            DataTable dtvts = new DataTable();
            try
            {
                using (SqlConnection CONECT = new SqlConnection(@"Data Source=192.168.101.22;Initial Catalog=AGROVERSA_PRODUCTIVA;User ID=sa;Password=DB@gr0V3rs@"))
                {
                    CONECT.Open();
                    using (SqlCommand COMANDO = new SqlCommand("SP_VRS_VENTAS_AND_NCQV_FECHA", CONECT))
                        
                    {
                        COMANDO.CommandType = CommandType.StoredProcedure;
                        COMANDO.Parameters.Add("@INI_FCH", SqlDbType.DateTime);
                        COMANDO.Parameters["@INI_FCH"].Value = "2021-02-01";// _FILTRO_CNTRL.ini_fecha;


                        COMANDO.Parameters.Add("@FIN_FCH", SqlDbType.DateTime);
                        COMANDO.Parameters["@FIN_FCH"].Value = NOWDAY;// _FILTRO_CNTRL.fin_fecha;

                        dtvts.Load(COMANDO.ExecuteReader());




                    }
                }

            }
            catch (Exception e)
            {
                dtvts = new DataTable();
            }
            var jsonresult = JsonConvert.SerializeObject(dtvts);
            JArray Areglo_JSON = JArray.Parse(jsonresult);

            return Areglo_JSON;
        }
    }
}