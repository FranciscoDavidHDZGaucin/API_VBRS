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
    public class api_FacturasProveedorxPagar
    {
        private SqlDataReader drd;

        public List<DataTable> _RES_TOTALES = null;

        public Newtonsoft.Json.Linq.JArray FACTURASPROVEE()
        {

            DataTable dtvts = new DataTable();
            try
            {
                using (SqlConnection CONECT = new SqlConnection(@"Data Source=192.168.101.22;Initial Catalog=AGROVERSA_PRODUCTIVA;User ID=sa;Password=DB@gr0V3rs@"))
                {
                    CONECT.Open();
                    using (SqlCommand COMANDO = new SqlCommand("SELECT T0.[NumAtCard] as Referencia,T0.[CardCode], T0.[CardName], T2.[GroupName],T0.[DocDueDate], T0.[TaxDate], T0.[DocTotal] - T0.[PaidToDate] as Pendiente_$, T0.[DocTotalFc] - T0.[PaidFc] as Pendiente_$$,T0.[DocCur], T0.[DocNum], T0.[DocStatus] FROM OPCH T0  inner join OCRD T1 ON T0.[CardCode] = T1.[CardCode]  INNER JOIN OCRG T2 ON T1.[GroupCode] = T2.[GroupCode]WHERE T0.[DocStatus] = 'O' and(T0.[DocTotal] - T0.[PaidToDate]) > 0", CONECT))


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