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
    public class api_SAC_RECLAMOS_CALIDAD
    {
        private SqlDataReader drd;

        public List<DataTable> _RES_TOTALES = null;

        public Newtonsoft.Json.Linq.JArray RECLAMOS()
        {

            DataTable dtvts = new DataTable();
            try
            {
                using (SqlConnection CONECT = new SqlConnection(@"Data Source=192.168.101.154;Initial Catalog=JUPITER;User ID=sa;Password=DB@gr0V3rs@"))
                {
                    CONECT.Open();
                    using (SqlCommand COMANDO = new SqlCommand("SELECT [FOLIO], [FACTURA], [nom_prod], [cve_prod], [cant_sur], [cant_re], [fecha_surtido], [CLIENTE], [FECHA], [MOTIVO], [REQUIERE], [MASTER_WEB], [ESTATUS], [ABIERTO], [PROGRESO], [CIERRE_INTERNO], [CIERRE_EXTERNO], [ZONA], [SICUMPLE_CIERRE_EXTERNO], [SICUMPLE_CIERRE_INTERNO], [DIAS_CIERRE_EXTERNO], [DIAS_CIERRE_INTERNO], [NOMBRE_AGENTE], [lote], [costo],[UNE] FROM [VW_RECLAMOS_CALIDAD_PIBOTE] ORDER BY [FOLIO] DESC", CONECT))


                    {
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