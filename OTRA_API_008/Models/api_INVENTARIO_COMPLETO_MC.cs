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
    public class api_INVENTARIO_COMPLETO_MC
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
                    using (SqlCommand COMANDO = new SqlCommand(" SELECT [NUMERO_ARTICULO],[DESCRIPCION_ARTICULO],[Unidad],[BatchNum],[FECHA_CREACION],[FECHA_VENCIMIENTO],[CODIGO_ALMACEN],[NOMBRE_DE_ALMACEN],[CIUDAD],[Status],[NOMBRE_GRUPO],[DIVISION],[FAMILIA],[LINEA],[LINEA_FAMILIA],[Clasificacion_General],[CANTIDAD],[PRECIO_PROMEDIO],[CostoTotal] FROM [AGROVERSA_PRODUCTIVA].[dbo].[vw_REPORTE_INVENTARIO] ", CONECT))



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