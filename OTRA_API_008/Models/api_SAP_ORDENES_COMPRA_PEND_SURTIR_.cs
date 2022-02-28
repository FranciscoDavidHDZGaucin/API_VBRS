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
    public class api_SAP_ORDENES_COMPRA_PEND_SURTIR
    {

        private SqlDataReader drd;
        private DateTime NOWDAY = DateTime.Now;
        private DateTime MONTHS_MENOS = DateTime.Now.AddMonths(-6);
        public List<DataTable> _RES_TOTALES = null;

        public Newtonsoft.Json.Linq.JArray ORDENES_COMPRA()
        {
  

        DataTable dtvts = new DataTable();
        try
        {
            using (SqlConnection CONECT = new SqlConnection(@"Data Source=192.168.101.22;Initial Catalog=AGROVERSA_PRODUCTIVA;User ID=sa;Password=DB@gr0V3rs@"))
            {
                CONECT.Open();

                using (SqlCommand COMANDO = new SqlCommand("SELECT T0.[DocNum], T0.[DocDate], T0.[CardName], T1.[ItemCode], T1.[Dscription], T1.[Quantity], T1.[OpenQty], T1.[Price], T1.[Rate],T1.[OpenQty]*T1.[Price] AS TotalPendiente, T1.[Currency],IIF(T1.[Currency] = 'USD', (T1.[Price] * T1.[OpenQty]) * T1.[Rate], T1.[OpenQty] * T1.[Price]) AS TotalPendientePesos, T0.Comments, T1.FreeTxt FROM OPOR T0  INNER JOIN POR1 T1 ON T0.[DocEntry] = T1.[DocEntry] WHERE T0.[DocDate] >= '2022-01-01' AND  T0.[DocDate] <='2022-02-28' AND T1.[OpenQty] > 0", CONECT))


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
