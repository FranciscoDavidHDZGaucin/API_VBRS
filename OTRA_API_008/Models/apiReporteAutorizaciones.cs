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
    public class apiReporteAutorizaciones
    {
        public FILTRO _FILTRO_CNTRL = new FILTRO();
        public List<REPORTE_AUTO> _ResObjeto = null;
        private SqlDataReader drd;
        // private SqlDataReader DRD;

        string fech_real = "";

        private DateTime NOWDAY = DateTime.Now;
        private DateTime YEARS_MENOS = DateTime.Now.AddYears(-1);



        public apiReporteAutorizaciones()
        {

            _FILTRO_CNTRL = GET_FILTRO();
            CALL_SP_REPORTE();
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
                    using (SqlCommand COMAND = new SqlCommand("SELECT[api_consulta] ,[nombre] ,[ini_fecha],[fin_fecha] FROM[JUPITER].[dbo].[TB_RSGD_FILTRO_API]  WHERE api_consulta = 'VTS_AND_GOPC' ", CONEC))
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

        public Newtonsoft.Json.Linq.JArray CALL_SP_REPORTE()
        {
            DataTable ventas_vrs = new DataTable();
            List<REPORTE_AUTO> LISTAREULTADO = new List<REPORTE_AUTO>();
            try
            {


                using (SqlConnection CONEECT = new SqlConnection(@"Data Source=192.168.101.22;Initial Catalog=AGROVERSA_PRODUCTIVA;User ID=sa;Password=DB@gr0V3rs@"))
                {
                    CONEECT.Open();
                    using (SqlCommand COMANDO = new SqlCommand("SP_REPORTE_AUTORIZACION", CONEECT))
                    {

                        COMANDO.CommandType = CommandType.StoredProcedure;
                        COMANDO.Parameters.Add("@TYPEDOCTO_INTPUT", SqlDbType.VarChar);
                        COMANDO.Parameters["@TYPEDOCTO_INTPUT"].Value = "SDEVC";
                        COMANDO.Parameters.Add("@usu", SqlDbType.Int);
                        COMANDO.Parameters["@usu"].Value = 32;
                        COMANDO.Parameters.Add("@FECHA_INICIO", SqlDbType.DateTime);
                        COMANDO.Parameters["@FECHA_INICIO"].Value = "2020-01-01";// _FILTRO_CNTRL.ini_fecha;


                        COMANDO.Parameters.Add("@FECHA_FIN", SqlDbType.DateTime);
                        COMANDO.Parameters["@FECHA_FIN"].Value = NOWDAY;// _FILTRO_CNTRL.fin_fecha;



                        drd = COMANDO.ExecuteReader();

                        //ventas_vrs.Columns.Add("NUM_DOCTO", typeof(Int32));
                        //ventas_vrs.Columns.Add("CLAS_PROD", typeof(string));
                        //ventas_vrs.Columns.Add("TIPO_DOCTO", typeof(string));
                        //ventas_vrs.Columns.Add("SKU_PRODUCTO", typeof(string));
                        //ventas_vrs.Columns.Add("NOM_PRODUCTO", typeof(string));
                        //ventas_vrs.Columns.Add("MES", typeof(Int32));
                        //ventas_vrs.Columns.Add("ANIO", typeof(Int32));

                        while (drd.Read())
                        {


                            REPORTE_AUTO ROW_OBJT = new REPORTE_AUTO
                            {

                                NUM_DOC = Convert.ToString(drd["NUM_DOC"]),
                                NoREF = Convert.ToString(drd["NoREF"]),
                                FECHA_CREACION = Convert.ToString(drd["FECHA_CREACION"]),
                                HORA_CREACION = Convert.ToString(drd["HORA_CREACION"]),
                                FECHA_AUTORIZA = Convert.ToString(drd["FECHA_AUTORIZA"]),
                                HORA_AUTORIZO = Convert.ToString(drd["HORA_AUTORIZO"]),
                                CardCode = Convert.ToString(drd["CardCode"]),
                                CardName = drd["CardName"].ToString(),
                                comments = drd["comments"].ToString(),
                                UserSign = Convert.ToString(drd["UserSign"]),
                                AUTORIZO = drd["AUTORIZO"].ToString(),
                                NUM_AUTORIZA = Convert.ToString(drd["NUM_AUTORIZA"]),

                                MINUTOS = Convert.ToString(drd["MINUTOS"]),
                                Cancelacion_Suplencia = Convert.ToString(drd["Cancelacion_Suplencia"]),
                               

                            };
                            LISTAREULTADO.Add(ROW_OBJT);
                            ///  ventas_vrs.Rows.Add(ROW_OBJT.NUM_DOCTO, ROW_OBJT.CLAS_PROD, ROW_OBJT.TIPO_DOCTO, ROW_OBJT.SKU_PRODUCTO, ROW_OBJT.NOM_PRODUCTO);///, obje.MES, obje.ANIO);



                        }






                    }



                }


            }
            catch (Exception e)
            {
                ventas_vrs = new DataTable();
            }
            var jsonresult = JsonConvert.SerializeObject(LISTAREULTADO);
            JArray Areglo_JSON = JArray.Parse(jsonresult);

            return Areglo_JSON;






        }





        private List<VTS_AND_NCQV> LIST_OBJETOS(DataTable ventas_vrs)
        {


            var _LISTA_VENTAS = (from DRD in ventas_vrs.AsEnumerable()
                                 select new VTS_AND_NCQV()
                                 {



                                     NUM_DOCTO = Convert.ToInt32(DRD["NUM_DOCTO"]),
                                     CLAS_PROD = Convert.ToString(DRD["CLAS_PROD"]),
                                     TIPO_DOCTO = Convert.ToString(DRD["TIPO_DOCTO"]),
                                     SKU_PRODUCTO = Convert.ToString(DRD["SKU_PRODUCTO"]),
                                     NOM_PRODUCTO = Convert.ToString(DRD["NOM_PRODUCTO"]),
                                     MES = Convert.ToInt32(DRD["MES"]),
                                     ANIO = Convert.ToInt32(DRD["ANIO"]) //,
                                                                         //COD_CLIENTE = DRD["COD_CLIENTE"].ToString(),
                                                                         //NOM_CLIENTE = DRD["NOM_CLIENTE"].ToString(),
                                                                         //CCOD_AGENTE = Convert.ToInt32(DRD["CCOD_AGENTE"]),
                                                                         //NOM_AGENTE = DRD["NOM_AGENTE"].ToString(),
                                                                         //CANTIDAD = Convert.ToInt32(DRD["CANTIDAD"]),

                                     //COSTO = Convert.ToDecimal(DRD["NUM_DOCTO"]),
                                     //MONTO = Convert.ToDecimal(DRD["NUM_DOCTO"]),
                                     //CMG = Convert.ToDecimal(DRD["NUM_DOCTO"]),
                                     //SEM_PROGRAMADA = Convert.ToInt32(DRD["SEM_PROGRAMADA"]),

                                     /// CLAS_CREDITO = DRD["CLAS_CREDITO"].ToString(),

                                     // FECHA_DOCTO = Convert.ToDateTime(DRD["FECHA_DOCTO"]),
                                     //UN = DRD["UN"].ToString(),
                                     //REMISION = DRD["REMISION"].ToString(),
                                     //CLASIFICACION = DRD["CLASIFICACION"].ToString(),
                                     //DIVISION = DRD["DIVISION"].ToString(),
                                     //FAMILIA = DRD["FAMILIA"].ToString(),
                                     //LINEA = DRD["LINEA"].ToString(),
                                     //MARCA = DRD["MARCA"].ToString(),
                                     //PORTAFOLIO = DRD["PORTAFOLIO"].ToString()

                                 }



                                                 ).ToList();




            return _LISTA_VENTAS;


        }
    }

    public class FILTRO_REP
    {
        public string api_consulta { get; set; }
        public string nombre { get; set; }
        public DateTime ini_fecha { get; set; }
        public DateTime fin_fecha { get; set; }

    }

    public class REPORTE_AUTO
    {
        public string NUM_DOC { get; set; }
        public string NoREF { get; set; }
        public string FECHA_CREACION { get; set; }
        public string HORA_CREACION { get; set; }
        public string FECHA_AUTORIZA { get; set; }
        public string HORA_AUTORIZO { get; set; }
        public string CardCode { get; set; }
        public string CardName { get; set; }
        public string comments { get; set; }
        public string UserSign { get; set; }
        public string AUTORIZO { get; set; }
        public string NUM_AUTORIZA { get; set; }
        public string MINUTOS { get; set; }
        public string Cancelacion_Suplencia { get; set; }
        
    }
}