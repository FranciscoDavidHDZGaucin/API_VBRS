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
    public class api_LPREGIONAL_MXN
    {
        private SqlDataReader drd;

        public List<DataTable> _RES_TOTALES = null;

        public Newtonsoft.Json.Linq.JArray LPREGIONALMXN()
        {

            DataTable dtvts = new DataTable();
            try
            {
                using (SqlConnection CONECT = new SqlConnection(@"Data Source=192.168.101.22;Initial Catalog=BDSALESFORCE20200526;User ID=sa;Password=DB@gr0V3rs@"))
                {
                    CONECT.Open();
                    using (SqlCommand COMANDO = new SqlCommand("SELECT  dbo.OITM.ItemCode, dbo.OITM.ItemName, dbo.OITM.ItmsGrpCod, dbo.ITM1.Price, dbo.ITM1.Currency, dbo.ITM1.PriceList FROM dbo.OITM INNER JOIN  dbo.ITM1 ON dbo.OITM.ItemCode = dbo.ITM1.ItemCode WHERE  (dbo.OITM.ItmsGrpCod = 104 OR dbo.OITM.ItmsGrpCod = 135 OR dbo.OITM.ItmsGrpCod = 136 OR dbo.OITM.ItmsGrpCod = 103) AND (dbo.OITM.frozenFor = 'N') AND (dbo.ITM1.PriceList = 10) AND (dbo.ITM1.Price > 0) AND(dbo.ITM1.Currency = 'MXP') ORDER BY dbo.OITM.ItemName", CONECT))


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