using MySql.Data.MySqlClient;
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
    public class api_QtyFillRate
    {

        private SqlDataReader drd;


        public Newtonsoft.Json.Linq.JArray QtyFillRate_DETALLE_PEDIDOS()
        {

            DataTable dtvts = new DataTable();
            try
            {
                using (SqlConnection CONECT = new SqlConnection(@"Data Source=192.168.101.22;Initial Catalog=AGROVERSA_PRODUCTIVA;User ID=sa;Password=DB@gr0V3rs@"))
                {
                    CONECT.Open();
                    using (SqlCommand COMANDO = new SqlCommand("SELECT * FROM VW_QtyFillRate_DETALLE_PEDIDOS", CONECT))


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

        public Newtonsoft.Json.Linq.JArray QtyFillRate_FACTURA()
        {

            DataTable dtvts = new DataTable();
            try
            {
                using (SqlConnection CONECT = new SqlConnection(@"Data Source=192.168.101.22;Initial Catalog=AGROVERSA_PRODUCTIVA;User ID=sa;Password=DB@gr0V3rs@"))
                {
                    CONECT.Open();
                    using (SqlCommand COMANDO = new SqlCommand("SELECT * FROM VW_QtyFillRate_FACTURA", CONECT))


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

        public Newtonsoft.Json.Linq.JArray QtyFillRate_REPT_LOG_PEDIDOS()
        {

            DataTable dtvts = new DataTable();
            try
            {
                using (SqlConnection CONECT = new SqlConnection(@"Data Source=192.168.101.22;Initial Catalog=AGROVERSA_PRODUCTIVA;User ID=sa;Password=DB@gr0V3rs@"))
                {
                    CONECT.Open();
                    using (SqlCommand COMANDO = new SqlCommand("SELECT * FROM VW_QtyFillRate_REPT_LOG_PEDIDOS", CONECT))


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
        public Newtonsoft.Json.Linq.JArray QtyFillRate_REPORTE_LOGISTICA_UNES()
        {
            Boolean CTRL_RECARGA = false;
            DataTable dtvts = new DataTable();
            try
            {
                using (MySqlConnection myconector = new MySqlConnection(@"server=192.168.101.5; database=pedidos;user id=root; password=avsa0543;"))
                {
                    myconector.Open();
                    using (MySqlCommand spgentabla = new MySqlCommand("SP_Qty_Fill_Rate_FACTURAS_REPT_LOGIS_CON_PRODUCTOS", myconector))
                    {
                        spgentabla.CommandType = CommandType.StoredProcedure;

                        DataTable dt_table = new DataTable();

                        MySqlDataAdapter ADP_MY = new MySqlDataAdapter(spgentabla);
                        ADP_MY.Fill(dt_table);

                        foreach (DataRow ROW in dt_table.Rows)
                        {
                            if (Convert.ToInt32(ROW["ERROR"]) == 3333)
                            {
                                CTRL_RECARGA = true;
                            }
                        }

                    }

                }
                if (CTRL_RECARGA)
                {
                    using (SqlConnection CONECT = new SqlConnection(@"Data Source=192.168.101.22;Initial Catalog=AGROVERSA_PRODUCTIVA;User ID=sa;Password=DB@gr0V3rs@"))
                    {
                        CONECT.Open();
                        using (SqlCommand COMANDO = new SqlCommand("SELECT *  FROM [AGROVERSA_PRODUCTIVA].[dbo].[VW_QtyFillRate_REPT_LOG_PEDIDOS_RECARGA_UNES]", CONECT))
                        {
                            dtvts.Load(COMANDO.ExecuteReader());

                        }
                    }
                }
                else {
                    dtvts = new DataTable();
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