using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace OTRA_API_008.Models
{
    public class USUARIO
    {

        /// VVariables de Control  

        private String _USUARIO;
        private String _PASS;
        public Boolean EXIS_USU = false;
        public JObject JSON_RES;



        public USUARIO(String usu, String clave)
        {

            this._USUARIO = usu;
            this._PASS = clave;
            OBTENER_USUARIO();

        }
        private void OBTENER_USUARIO()
        {
            try
            {
                using (SqlConnection CONECT = new SqlConnection(@"Data Source=SRV-DBGW;Initial Catalog=JUPITER;User ID=sa;Password=DB@gr0V3rs@"))
                {
                    CONECT.Open();
                    using (SqlCommand COMANDO = new SqlCommand("sp_VALIDA_USU_NET", CONECT))
                    {

                        COMANDO.CommandType = CommandType.StoredProcedure;
                        COMANDO.Parameters.Add("@EMAIL_REV_CONESP", SqlDbType.VarChar, 100);
                        COMANDO.Parameters.Add("@CLAVE_REV_CONESP", SqlDbType.VarChar, 100);

                        COMANDO.Parameters["@EMAIL_REV_CONESP"].Value = F_USUARIO;
                        COMANDO.Parameters["@CLAVE_REV_CONESP"].Value = F_CLAVE;

                        SqlParameter JSON_OBJT = new SqlParameter("@JSON_OBJT", SqlDbType.NVarChar, -1);
                        JSON_OBJT.Direction = ParameterDirection.Output;

                        COMANDO.Parameters.Add(JSON_OBJT);

                        COMANDO.ExecuteScalar();
                        if (!Convert.IsDBNull(JSON_OBJT.Value))
                        {
                            JArray Res_JSON_OBJT = JArray.Parse(JSON_OBJT.Value.ToString());

                            foreach (JObject elem in Res_JSON_OBJT)
                            {
                                var exite = (int)elem["EXISTE"];
                                elem.CreateReader();
                                if (exite > 0)
                                {
                                    EXIS_USU = true;
                                    JSON_RES = elem;

                                }
                                else
                                {
                                    EXIS_USU = false;

                                }

                            }


                        }



                        ///######################################################################################################################

                    }

                }

            }
            catch (Exception e)
            {

            }

        }

        private string F_USUARIO
        {
            get
            {

                return _USUARIO;
            }
            set
            {
                _USUARIO = F_USUARIO;
            }

        }
        private string F_CLAVE
        {

            get { return this._PASS; }
            set { this._PASS = F_CLAVE; }


        }
        public JObject F_RESUTADO_STRIGN
        {

            get { return JSON_RES; }

        }



    }
}