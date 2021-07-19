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
    public class api_GASTOS_ASIENTOS_CONT
    {

        private SqlDataReader drd;

        public List<DataTable> _RES_TOTALES = null;

        public Newtonsoft.Json.Linq.JArray ASIENTOS()
        {

            DataTable dtvts = new DataTable();
            try
            {
                using (SqlConnection CONECT = new SqlConnection(@"Data Source=192.168.101.22;Initial Catalog=BDSALESFORCE20200526;User ID=sa;Password=DB@gr0V3rs@"))
                {
                    CONECT.Open();
                    using (SqlCommand COMANDO = new SqlCommand("select T1.Account, T1.TransId, T1.LineMemo, T1.Debit, T1.Credit,T1.SYSDeb, T1.SYSCred, T1.FCDebit, T1.FCCredit, T1.FCDebit - T1.FCCredit as totdebcred,T1.FCCurrency as [G/L Foreign Currency] from OJDT T0 inner join JDT1 T1 ON T0.TransId = T1.TransId where T1.RefDate >='2021-07-01' and T1.RefDate <= GETDATE()", CONECT))


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