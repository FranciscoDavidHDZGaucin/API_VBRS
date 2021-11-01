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
    public class api_VW_REPORTE_INVENTARIO_BI
    {
        private SqlDataReader drd;

        public List<DataTable> _RES_TOTALES = null;

        public Newtonsoft.Json.Linq.JArray INVENTARIO()
        {

            DataTable dtvts = new DataTable();
            try
            {
                using (SqlConnection CONECT = new SqlConnection(@"Data Source=192.168.101.22;Initial Catalog=AGROVERSA_PRODUCTIVA;User ID=sa;Password=DB@gr0V3rs@"))
                {
                    CONECT.Open();
                    using (SqlCommand COMANDO = new SqlCommand(" SELECT T1.[NUMERO_ARTICULO], T1.[DESCRIPCION_ARTICULO], T1.[Unidad], T1.[BatchNum], T1.[FECHA_CREACION], T1.[FECHA_VENCIMIENTO], T1.[CODIGO_ALMACEN], T1.[NOMBRE_DE_ALMACEN], T1.[CIUDAD], T1.[Status], T1.[NOMBRE_GRUPO], T1.[DIVISION], T1.[FAMILIA], T1.[LINEA], T1.[LINEA_FAMILIA], T1.[Clasificacion_General], T1.[CANTIDAD], T1.[PRECIO_PROMEDIO], T1.[CostoTotal] FROM [AGROVERSA_PRODUCTIVA].[dbo].[vw_REPORTE_INVENTARIO] T1   where T1.[NOMBRE_GRUPO] = 'P. TERMINADO'", CONECT))


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