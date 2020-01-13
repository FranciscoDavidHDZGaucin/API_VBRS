using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace OTRA_API_008.Models
{
    public class RECLAMOS_BD_MAIL
    {

        public int SEND_MAIL_CALIDAD(int FOLIO)
        {
            int resultado = 00;
            try
            {
                using (SqlConnection CONNECT = new SqlConnection(@"Data Source=SRV-DBGW;Initial Catalog=JUPITER;User ID=sa;Password=DB@gr0V3rs@"))
                {
                    CONNECT.Open();
                    using (SqlCommand commando = new SqlCommand("SP_SAC_RECLAMO_CALIDAD", CONNECT))
                    {
                        commando.CommandType = CommandType.StoredProcedure;
                        commando.Parameters.Add("@FOLIOBRS", SqlDbType.Int);

                        commando.Parameters["@FOLIOBRS"].Value = FOLIO;
                        commando.ExecuteScalar();

                        resultado = 88;
                    }




                }


            }
            catch (Exception e)
            {
                resultado = 23;


            }

            return resultado;
        }
        public int SEND_MAIL_SERVICIO(int FOLIO)
        {
            int resultado = 00;
            try
            {
                using (SqlConnection CONNECT = new SqlConnection(@"Data Source=SRV-DBGW;Initial Catalog=JUPITER;User ID=sa;Password=DB@gr0V3rs@"))
                {
                    CONNECT.Open();
                    using (SqlCommand commando = new SqlCommand("SP_SAC_SERVICIO_EMAIL", CONNECT))
                    {
                        commando.CommandType = CommandType.StoredProcedure;
                        commando.Parameters.Add("@FOLIOBRS", SqlDbType.Int);

                        commando.Parameters["@FOLIOBRS"].Value = FOLIO;
                        commando.ExecuteScalar();

                        resultado = 88;
                    }




                }


            }
            catch (Exception e)
            {
                resultado = 23;


            }

            return resultado;




        }




    }
}