using System;
using System.Collections.Generic;
using System.Linq;
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
    public class api_MES_spOTIF_Report
    {
        private SqlDataReader drd;


        public List<DataTable> _RTES_TOTALES = null;


    //    public Newtonsoft.Json.Linq.JArray MES_spOTIF_Report()
    //    {

    //        DataTable otif_dtb = new DataTable();
    //        try
    //        {
    //            using (SqlConnection conect = new SqlConnection(@"Data Source=192.168.101.22;Initial Catalog=MRP;User ID=sa;Password=DB@gr0V3rs@"))
    //            {
    //                conect.Open();
    //                using (SqlCommand spcomand = new SqlCommand("MES_spOTIF_Report", conect))
    //                {
    //                    spcomand.CommandType = CommandType.StoredProcedure;
    //                    spcomand.Parameters.Add("@DESDE", SqlDbType.Date).Value = ;
    //                    spcomand.Parameters.Add("@HASTA", SqlDbType.Date).Value = ;
    //                    spcomand.Parameters.Add("@Linea_id", SqlDbType.Int).Value =0 ;

    //}

    //            }

    //        }
    //        catch (Exception e)
    //        {

    //        }


    //    }





    }
}