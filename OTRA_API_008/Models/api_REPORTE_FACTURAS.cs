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
    public class api_REPORTE_FACTURAS
    {
        private SqlDataReader drd;

        public List<DataTable> _RES_TOTALES = null;

        public Newtonsoft.Json.Linq.JArray REPORTE()
        {

            DataTable dtvts = new DataTable();
            try
            {
                using (SqlConnection CONECT = new SqlConnection(@"Data Source=192.168.101.154;Initial Catalog=INEFABLE;User ID=sa;Password=DB@gr0V3rs@"))
                {
                    CONECT.Open();
                    using (SqlCommand COMANDO = new SqlCommand(@"SELECT  T1.DocNum, T1.CardCode, T1.CardName,CONVERT(varchar,T1.DocDate,23) as date,(select STUFF(STUFF(STUFF(T0.CreateTS, 1, 0, REPLICATE('0', 6 - LEN(T0.createTS))),3,0,':'),6,0,':')from [VM-SQL\SAP].AGROVERSA_PRODUCTIVA.dbo.OINV T0 WHERE T1.DocNum = T0.DocNum) as hora , T1.DocTotal,T2.U_NAME, T3.ZONA, T3.COD_ZONA, T3.Division_Comercial FROM  [VM-SQL\SAP].AGROVERSA_PRODUCTIVA.dbo.OINV AS T1 INNER JOIN [VM-SQL\SAP].AGROVERSA_PRODUCTIVA.dbo.OUSR AS T2 ON T1.UserSign = T2.USERID INNER JOIN vwCAT_AGENTES AS T3 ON T3.COD_ZONA = T1.SlpCode WHERE YEAR(T1.DocDate)>=2019 and T1.CANCELED = 'N'", CONECT))


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