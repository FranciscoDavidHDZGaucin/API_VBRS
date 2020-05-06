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
    public class TB_VRS_VENTAS_VS_GOPC
    {
        public FILTRO _FILTRO_CNTRL = new FILTRO();
        public List<VTS_AND_NCQV> _ResObjeto = null;
        private SqlDataReader drd;
        public TB_VRS_VENTAS_VS_GOPC()
        {

            _FILTRO_CNTRL = GET_FILTRO();
            //CALL_SP_VENTASVRSNC();
        }

        public FILTRO GET_FILTRO()
        {
            FILTRO objfiltro = new FILTRO();
            SqlDataReader drd;
            try
            {

                using (SqlConnection CONEC = new SqlConnection(@"Data Source=SRV-DBGW;Initial Catalog=JUPITER;User ID=sa;Password=DB@gr0V3rs@"))
                {
                    CONEC.Open();
                    using (SqlCommand COMAND = new SqlCommand("SELECT [api_consulta] ,[nombre] ,[ini_fecha],[fin_fecha] FROM [JUPITER].[dbo].[TB_RSGD_FILTRO_API]  WHERE api_consulta = 'VTS_AND_GOPC' ", CONEC))
                    {
                        drd = COMAND.ExecuteReader();
                        if (drd.Read())
                        {

                            objfiltro.api_consulta = drd["api_consulta"].ToString();
                            objfiltro.nombre = drd["nombre"].ToString();
                            objfiltro.ini_fecha = Convert.ToDateTime(drd["ini_fecha"]);
                            objfiltro.fin_fecha = Convert.ToDateTime(drd["fin_fecha"]);
                        }


                    }

                }



            }
            catch (Exception E)
            {

                objfiltro = null;

            }

            return objfiltro;

        }

        public Newtonsoft.Json.Linq.JArray CALL_SP_TB_VTSVSGOPC()
        {
            DataTable VRSGOPC = new DataTable();
            List<OBJ_VTSGOPC> _TB_VTSGOPC = new List<OBJ_VTSGOPC>();

            try
            {

                using (SqlConnection CONEECT = new SqlConnection(@"Data Source=192.168.101.22;Initial Catalog=AGROVERSA_PRODUCTIVA;User ID=sa;Password=DB@gr0V3rs@"))
                {
                    CONEECT.Open();
                    using (SqlCommand COMANDO = new SqlCommand("SP_VRS_VENTASVSGOPC_BY_FECHA_001", CONEECT))
                    {
                        COMANDO.CommandType = CommandType.StoredProcedure;
                        COMANDO.Parameters.Add("@INI_FCH", SqlDbType.DateTime);
                        COMANDO.Parameters["@INI_FCH"].Value = _FILTRO_CNTRL.ini_fecha;


                        COMANDO.Parameters.Add("@FIN_FCH", SqlDbType.DateTime);
                        COMANDO.Parameters["@FIN_FCH"].Value = _FILTRO_CNTRL.fin_fecha;


                        drd = COMANDO.ExecuteReader();
                        while (drd.Read())
                        {
                                        OBJ_VTSGOPC VTSGOPC = new OBJ_VTSGOPC
                                        {
                                            NUM_DOCTO = Convert.ToInt32(drd["NUM_DOCTO"]),
                                            CLAS_PROD = Convert.ToString(drd["CLAS_PROD"]),
                                            TIPO_DOCTO = Convert.ToString(drd["TIPO_DOCTO"]),
                                            REMISION = Convert.ToString(drd["REMISION"]),
                                            SKU_PRODUCTO = Convert.ToString(drd["SKU_PRODUCTO"]),
                                            NOM_PRODUCTO = Convert.ToString(drd["NOM_PRODUCTO"]),
                                            MES = Convert.ToInt32(drd["MES"]),
                                            ANIO = Convert.ToInt32(drd["ANIO"]),
                                            COD_CLIENTE = Convert.ToString(drd["COD_CLIENTE"]),
                                            NOM_CLIENTE = Convert.ToString(drd["NOM_CLIENTE"]),
                                            CCOD_AGENTE = Convert.ToString(drd["CCOD_AGENTE"]),
                                            NOM_AGENTE = Convert.ToString(drd["NOM_AGENTE"]),
                                            CANTIDAD = Convert.ToInt32(drd["CANTIDAD"]),
                                            COSTO = Convert.ToDouble(drd["COSTO"]),
                                            MONTO = Convert.ToDouble(drd["MONTO"]),
                                            CMG = Convert.ToDouble(drd["CMG"]),
                                            SEM_PROGRAMADA = Convert.ToInt32(drd["SEM_PROGRAMADA"]),
                                            CLAS_CREDITO = Convert.ToString(drd["CLAS_CREDITO"]),
                                            FECHA_DOCTO = Convert.ToDateTime(drd["FECHA_DOCTO"]),
                                            UN = Convert.ToString(drd["UN"])

                                        };

                            _TB_VTSGOPC.Add(VTSGOPC);

                            }

                    }
                 }

            }
            catch (Exception e)
            {
                _TB_VTSGOPC = new List<OBJ_VTSGOPC>();

            }

            var jsonresult = JsonConvert.SerializeObject(_TB_VTSGOPC);
            JArray Areglo_JSON = JArray.Parse(jsonresult);

            return Areglo_JSON;
        }





    }

    public class OBJ_VTSGOPC {
        public Int32 NUM_DOCTO { get; set; }
        public string CLAS_PROD { get; set; }
        public string TIPO_DOCTO { get; set; }
        public string REMISION { get; set; }
        public string SKU_PRODUCTO { get; set; }
        public string NOM_PRODUCTO { get; set; }
        public Int32 MES { get; set; }
        public Int32 ANIO { get; set; }
        public string COD_CLIENTE { get; set; }
        public string NOM_CLIENTE { get; set; }
        public string CCOD_AGENTE { get; set; }
        public string NOM_AGENTE { get; set; }
        public double CANTIDAD { get; set; }
        public double COSTO { get; set; }
        public double MONTO { get; set; }
        public double CMG { get; set; }
        public Int32 SEM_PROGRAMADA { get; set; }
        public string CLAS_CREDITO { get; set; }
        public DateTime FECHA_DOCTO { get; set; }
       public string  UN {get ;set ;}





    }









}