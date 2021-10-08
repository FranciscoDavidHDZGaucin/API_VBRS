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
    public class api_SAC_GEP_FOLIOS
    {
        private SqlDataReader drd;

        public List<DataTable> _RES_TOTALES = null;

        public Newtonsoft.Json.Linq.JArray GEP()
        {

            DataTable dtvts = new DataTable();
            try
            {
                using (SqlConnection CONECT = new SqlConnection(@"Data Source=192.168.101.154;Initial Catalog=JUPITER;User ID=sa;Password=DB@gr0V3rs@"))
                {
                    CONECT.Open();
                    using (SqlCommand COMANDO = new SqlCommand("SP_GET_GEP_FILTROS", CONECT))


                    {
                        string date = DateTime.Now.ToString("yyyy'-'MM'-'dd");
                        COMANDO.CommandType = CommandType.StoredProcedure;
                        COMANDO.Parameters.Add("@FLTR_TIPO_DOCTO", SqlDbType.VarChar).Value = "FOLIOS";
                        COMANDO.Parameters.Add("@NUM_AGENTE", SqlDbType.BigInt).Value = 11;
                        COMANDO.Parameters.Add("@CVE_CLIENTE", SqlDbType.VarChar).Value = "TODOS";
                        COMANDO.Parameters.Add("@EST_PEDIDO", SqlDbType.VarChar).Value = "TODOS";
                        COMANDO.Parameters.Add("@EST_LOGISTICA", SqlDbType.VarChar).Value = "TODOS";
                        COMANDO.Parameters.Add("@TYPE_TRANSPORTE", SqlDbType.VarChar).Value = "TODOS";
                        COMANDO.Parameters.Add("@SKU_PROD", SqlDbType.NVarChar).Value = "SKU";
                        COMANDO.Parameters.Add("@NOMBRE_PRODUCT", SqlDbType.NVarChar).Value = "NOMBRE";
                        COMANDO.Parameters.Add("@FACTURA", SqlDbType.BigInt).Value = 0;
                        COMANDO.Parameters.Add("@DESTINOS", SqlDbType.NVarChar).Value = "TODOS";
                        COMANDO.Parameters.Add("@TIPO_FECHA", SqlDbType.NVarChar).Value = "TODOS";
                        COMANDO.Parameters.Add("@INI_FEHC", SqlDbType.NVarChar).Value = "2020-01-01";
                        COMANDO.Parameters.Add("@FIN_FECH", SqlDbType.NVarChar).Value = date;
                        COMANDO.Parameters.Add("@FILTRO_AGENTE", SqlDbType.BigInt).Value = 0;
                        COMANDO.Parameters.Add("@ZONA", SqlDbType.NVarChar).Value = "TODOS";
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