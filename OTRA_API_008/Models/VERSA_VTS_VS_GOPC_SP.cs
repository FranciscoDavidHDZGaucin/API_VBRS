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
    public class VERSA_VTS_VS_GOPC_SP  
    {
        public FILTRO _FILTRO_CNTRL = new FILTRO();
        public List<VTS_AND_NCQV> _ResObjeto = null;
        private SqlDataReader drd;
        // private SqlDataReader DRD;

        string fech_real = "";

        private  DateTime NOWDAY = DateTime.Now;
        private DateTime  YEARS_MENOS = DateTime.Now.AddYears(-1);



        public VERSA_VTS_VS_GOPC_SP()
        {

            _FILTRO_CNTRL = GET_FILTRO();
            CALL_SP_VENTASVRSNC();
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

        public Newtonsoft.Json.Linq.JArray CALL_SP_VENTASVRSNC()
        {
            DataTable ventas_vrs = new DataTable();
            List<VTS_AND_NCQV> LISTAREULTADO = new List<VTS_AND_NCQV>();
            try
            {
               

                using (SqlConnection CONEECT = new SqlConnection(@"Data Source=192.168.101.22;Initial Catalog=AGROVERSA_PRODUCTIVA;User ID=sa;Password=DB@gr0V3rs@"))
                {
                    CONEECT.Open();
                    using (SqlCommand COMANDO = new SqlCommand("SP_VRS_VENTAS_AND_NCQV", CONEECT))
                    {

                        COMANDO.CommandType = CommandType.StoredProcedure;
                        COMANDO.Parameters.Add("@INI_FCH", SqlDbType.DateTime);
                        COMANDO.Parameters["@INI_FCH"].Value ="2020-02-01";// _FILTRO_CNTRL.ini_fecha;


                        COMANDO.Parameters.Add("@FIN_FCH", SqlDbType.DateTime);
                        COMANDO.Parameters["@FIN_FCH"].Value = NOWDAY;// _FILTRO_CNTRL.fin_fecha;



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
                            fech_real = Convert.ToDateTime(drd["FECHA_REAL"]).ToString("yyyy-MM-dd");


                                VTS_AND_NCQV ROW_OBJT  = new VTS_AND_NCQV
                                {

                                    NUM_DOCTO = Convert.ToInt32(drd["NUM_DOCTO"]),
                                    CLAS_PROD = Convert.ToString(drd["CLAS_PROD"]),
                                    TIPO_DOCTO = Convert.ToString(drd["TIPO_DOCTO"]),
                                    SKU_PRODUCTO = Convert.ToString(drd["SKU_PRODUCTO"]),
                                    NOM_PRODUCTO = Convert.ToString(drd["NOM_PRODUCTO"]),
                                    MES = Convert.ToInt32(drd["MES"]),
                                    ANIO = Convert.ToInt32(drd["ANIO"]),
                                    COD_CLIENTE = drd["COD_CLIENTE"].ToString(),
                                    NOM_CLIENTE = drd["NOM_CLIENTE"].ToString(),
                                    CCOD_AGENTE = Convert.ToInt32(drd["CCOD_AGENTE"]),
                                    NOM_AGENTE = drd["NOM_AGENTE"].ToString(),
                                    CANTIDAD = Convert.ToInt32(drd["CANTIDAD"]),

                                    COSTO = Convert.ToDouble(drd["COSTO"]),
                                    MONTO = Convert.ToDouble(drd["MONTO"]),
                                    CMG = Convert.ToDouble(drd["CMG"]),

                                   


                                 SEM_PROGRAMADA = Convert.ToInt32(drd["SEM_PROGRAMADA"]),

                                    CLAS_CREDITO = drd["CLAS_CREDITO"].ToString(),

                                    FECHA_DOCTO = Convert.ToDateTime(drd["FECHA_DOCTO"]),
                                    FECHA_REAL = fech_real,
                                    UN = drd["UN"].ToString(),
                                    REMISION = drd["REMISION"].ToString(),
                                    CLASIFICACION = drd["CLASIFICACION"].ToString(),
                                    DIVISION = drd["DIVISION"].ToString(),
                                    FAMILIA = drd["FAMILIA"].ToString(),
                                    LINEA = drd["LINEA"].ToString(),
                                    MARCA = drd["MARCA"].ToString(),
                                    PORTAFOLIO = drd["PORTAFOLIO"].ToString()
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

        public Newtonsoft.Json.Linq.JArray CALL_SP_VENTASVRSNC_2019()
        {
            DataTable ventas_vrs = new DataTable();
            List<VTS_AND_NCQV> LISTAREULTADO = new List<VTS_AND_NCQV>();
            try
            {


                using (SqlConnection CONEECT = new SqlConnection(@"Data Source=192.168.101.22;Initial Catalog=AGROVERSA_PRODUCTIVA;User ID=sa;Password=DB@gr0V3rs@"))
                {
                    CONEECT.Open();
                    using (SqlCommand COMANDO = new SqlCommand("SP_VRS_VENTAS_AND_NCQV", CONEECT))
                    {

                        COMANDO.CommandType = CommandType.StoredProcedure;
                        COMANDO.Parameters.Add("@INI_FCH", SqlDbType.DateTime);
                        COMANDO.Parameters["@INI_FCH"].Value = "2019-01-01";// _FILTRO_CNTRL.ini_fecha;


                        COMANDO.Parameters.Add("@FIN_FCH", SqlDbType.DateTime);
                        COMANDO.Parameters["@FIN_FCH"].Value = "2019-12-31";// _FILTRO_CNTRL.fin_fecha;



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
                            fech_real = Convert.ToDateTime(drd["FECHA_REAL"]).ToString("yyyy-MM-dd");


                            VTS_AND_NCQV ROW_OBJT = new VTS_AND_NCQV
                            {

                                NUM_DOCTO = Convert.ToInt32(drd["NUM_DOCTO"]),
                                CLAS_PROD = Convert.ToString(drd["CLAS_PROD"]),
                                TIPO_DOCTO = Convert.ToString(drd["TIPO_DOCTO"]),
                                SKU_PRODUCTO = Convert.ToString(drd["SKU_PRODUCTO"]),
                                NOM_PRODUCTO = Convert.ToString(drd["NOM_PRODUCTO"]),
                                MES = Convert.ToInt32(drd["MES"]),
                                ANIO = Convert.ToInt32(drd["ANIO"]),
                                COD_CLIENTE = drd["COD_CLIENTE"].ToString(),
                                NOM_CLIENTE = drd["NOM_CLIENTE"].ToString(),
                                CCOD_AGENTE = Convert.ToInt32(drd["CCOD_AGENTE"]),
                                NOM_AGENTE = drd["NOM_AGENTE"].ToString(),
                                CANTIDAD = Convert.ToInt32(drd["CANTIDAD"]),

                                COSTO = Convert.ToDouble(drd["COSTO"]),
                                MONTO = Convert.ToDouble(drd["MONTO"]),
                                CMG = Convert.ToDouble(drd["CMG"]),




                                SEM_PROGRAMADA = Convert.ToInt32(drd["SEM_PROGRAMADA"]),

                                CLAS_CREDITO = drd["CLAS_CREDITO"].ToString(),

                                FECHA_DOCTO = Convert.ToDateTime(drd["FECHA_DOCTO"]),
                                FECHA_REAL = fech_real,
                                UN = drd["UN"].ToString(),
                                REMISION = drd["REMISION"].ToString(),
                                CLASIFICACION = drd["CLASIFICACION"].ToString(),
                                DIVISION = drd["DIVISION"].ToString(),
                                FAMILIA = drd["FAMILIA"].ToString(),
                                LINEA = drd["LINEA"].ToString(),
                                MARCA = drd["MARCA"].ToString(),
                                PORTAFOLIO = drd["PORTAFOLIO"].ToString()
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

       

        public Newtonsoft.Json.Linq.JArray CALL_SP_VENTASVRSNC_2015()
        {
            DataTable ventas_vrs = new DataTable();
            List<VTS_AND_NCQV> LISTAREULTADO = new List<VTS_AND_NCQV>();
            try
            {


                using (SqlConnection CONEECT = new SqlConnection(@"Data Source=192.168.101.22;Initial Catalog=AGROVERSA_PRODUCTIVA;User ID=sa;Password=DB@gr0V3rs@"))
                {
                    CONEECT.Open();
                    using (SqlCommand COMANDO = new SqlCommand("SP_VRS_VENTAS_AND_NCQV", CONEECT))
                    {

                        COMANDO.CommandType = CommandType.StoredProcedure;
                        COMANDO.Parameters.Add("@INI_FCH", SqlDbType.DateTime);
                        COMANDO.Parameters["@INI_FCH"].Value = "2015-01-01";// _FILTRO_CNTRL.ini_fecha;


                        COMANDO.Parameters.Add("@FIN_FCH", SqlDbType.DateTime);
                        COMANDO.Parameters["@FIN_FCH"].Value = "2015-12-31";// _FILTRO_CNTRL.fin_fecha;



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
                            fech_real = Convert.ToDateTime(drd["FECHA_REAL"]).ToString("yyyy-MM-dd");


                            VTS_AND_NCQV ROW_OBJT = new VTS_AND_NCQV
                            {

                                NUM_DOCTO = Convert.ToInt32(drd["NUM_DOCTO"]),
                                CLAS_PROD = Convert.ToString(drd["CLAS_PROD"]),
                                TIPO_DOCTO = Convert.ToString(drd["TIPO_DOCTO"]),
                                SKU_PRODUCTO = Convert.ToString(drd["SKU_PRODUCTO"]),
                                NOM_PRODUCTO = Convert.ToString(drd["NOM_PRODUCTO"]),
                                MES = Convert.ToInt32(drd["MES"]),
                                ANIO = Convert.ToInt32(drd["ANIO"]),
                                COD_CLIENTE = drd["COD_CLIENTE"].ToString(),
                                NOM_CLIENTE = drd["NOM_CLIENTE"].ToString(),
                                CCOD_AGENTE = Convert.ToInt32(drd["CCOD_AGENTE"]),
                                NOM_AGENTE = drd["NOM_AGENTE"].ToString(),
                                CANTIDAD = Convert.ToInt32(drd["CANTIDAD"]),

                                COSTO = Convert.ToDouble(drd["COSTO"]),
                                MONTO = Convert.ToDouble(drd["MONTO"]),
                                CMG = Convert.ToDouble(drd["CMG"]),




                                SEM_PROGRAMADA = Convert.ToInt32(drd["SEM_PROGRAMADA"]),

                                CLAS_CREDITO = drd["CLAS_CREDITO"].ToString(),

                                FECHA_DOCTO = Convert.ToDateTime(drd["FECHA_DOCTO"]),
                                FECHA_REAL = fech_real,
                                UN = drd["UN"].ToString(),
                                REMISION = drd["REMISION"].ToString(),
                                CLASIFICACION = drd["CLASIFICACION"].ToString(),
                                DIVISION = drd["DIVISION"].ToString(),
                                FAMILIA = drd["FAMILIA"].ToString(),
                                LINEA = drd["LINEA"].ToString(),
                                MARCA = drd["MARCA"].ToString(),
                                PORTAFOLIO = drd["PORTAFOLIO"].ToString()
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

        public Newtonsoft.Json.Linq.JArray CALL_SP_VENTASVRSNC_2016()
        {
            DataTable ventas_vrs = new DataTable();
            List<VTS_AND_NCQV> LISTAREULTADO = new List<VTS_AND_NCQV>();
            try
            {


                using (SqlConnection CONEECT = new SqlConnection(@"Data Source=192.168.101.22;Initial Catalog=AGROVERSA_PRODUCTIVA;User ID=sa;Password=DB@gr0V3rs@"))
                {
                    CONEECT.Open();
                    using (SqlCommand COMANDO = new SqlCommand("SP_VRS_VENTAS_AND_NCQV", CONEECT))
                    {

                        COMANDO.CommandType = CommandType.StoredProcedure;
                        COMANDO.Parameters.Add("@INI_FCH", SqlDbType.DateTime);
                        COMANDO.Parameters["@INI_FCH"].Value = "2016-01-01";// _FILTRO_CNTRL.ini_fecha;


                        COMANDO.Parameters.Add("@FIN_FCH", SqlDbType.DateTime);
                        COMANDO.Parameters["@FIN_FCH"].Value = "2016-12-31";// _FILTRO_CNTRL.fin_fecha;



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
                            fech_real = Convert.ToDateTime(drd["FECHA_REAL"]).ToString("yyyy-MM-dd");


                            VTS_AND_NCQV ROW_OBJT = new VTS_AND_NCQV
                            {

                                NUM_DOCTO = Convert.ToInt32(drd["NUM_DOCTO"]),
                                CLAS_PROD = Convert.ToString(drd["CLAS_PROD"]),
                                TIPO_DOCTO = Convert.ToString(drd["TIPO_DOCTO"]),
                                SKU_PRODUCTO = Convert.ToString(drd["SKU_PRODUCTO"]),
                                NOM_PRODUCTO = Convert.ToString(drd["NOM_PRODUCTO"]),
                                MES = Convert.ToInt32(drd["MES"]),
                                ANIO = Convert.ToInt32(drd["ANIO"]),
                                COD_CLIENTE = drd["COD_CLIENTE"].ToString(),
                                NOM_CLIENTE = drd["NOM_CLIENTE"].ToString(),
                                CCOD_AGENTE = Convert.ToInt32(drd["CCOD_AGENTE"]),
                                NOM_AGENTE = drd["NOM_AGENTE"].ToString(),
                                CANTIDAD = Convert.ToInt32(drd["CANTIDAD"]),

                                COSTO = Convert.ToDouble(drd["COSTO"]),
                                MONTO = Convert.ToDouble(drd["MONTO"]),
                                CMG = Convert.ToDouble(drd["CMG"]),




                                SEM_PROGRAMADA = Convert.ToInt32(drd["SEM_PROGRAMADA"]),

                                CLAS_CREDITO = drd["CLAS_CREDITO"].ToString(),

                                FECHA_DOCTO = Convert.ToDateTime(drd["FECHA_DOCTO"]),
                                FECHA_REAL = fech_real,
                                UN = drd["UN"].ToString(),
                                REMISION = drd["REMISION"].ToString(),
                                CLASIFICACION = drd["CLASIFICACION"].ToString(),
                                DIVISION = drd["DIVISION"].ToString(),
                                FAMILIA = drd["FAMILIA"].ToString(),
                                LINEA = drd["LINEA"].ToString(),
                                MARCA = drd["MARCA"].ToString(),
                                PORTAFOLIO = drd["PORTAFOLIO"].ToString()
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

        public Newtonsoft.Json.Linq.JArray CALL_SP_VENTASVRSNC_2017()
        {
            DataTable ventas_vrs = new DataTable();
            List<VTS_AND_NCQV> LISTAREULTADO = new List<VTS_AND_NCQV>();
            try
            {


                using (SqlConnection CONEECT = new SqlConnection(@"Data Source=192.168.101.22;Initial Catalog=AGROVERSA_PRODUCTIVA;User ID=sa;Password=DB@gr0V3rs@"))
                {
                    CONEECT.Open();
                    using (SqlCommand COMANDO = new SqlCommand("SP_VRS_VENTAS_AND_NCQV", CONEECT))
                    {

                        COMANDO.CommandType = CommandType.StoredProcedure;
                        COMANDO.Parameters.Add("@INI_FCH", SqlDbType.DateTime);
                        COMANDO.Parameters["@INI_FCH"].Value = "2017-01-01";// _FILTRO_CNTRL.ini_fecha;


                        COMANDO.Parameters.Add("@FIN_FCH", SqlDbType.DateTime);
                        COMANDO.Parameters["@FIN_FCH"].Value = "2017-12-31";// _FILTRO_CNTRL.fin_fecha;



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
                            fech_real = Convert.ToDateTime(drd["FECHA_REAL"]).ToString("yyyy-MM-dd");


                            VTS_AND_NCQV ROW_OBJT = new VTS_AND_NCQV
                            {

                                NUM_DOCTO = Convert.ToInt32(drd["NUM_DOCTO"]),
                                CLAS_PROD = Convert.ToString(drd["CLAS_PROD"]),
                                TIPO_DOCTO = Convert.ToString(drd["TIPO_DOCTO"]),
                                SKU_PRODUCTO = Convert.ToString(drd["SKU_PRODUCTO"]),
                                NOM_PRODUCTO = Convert.ToString(drd["NOM_PRODUCTO"]),
                                MES = Convert.ToInt32(drd["MES"]),
                                ANIO = Convert.ToInt32(drd["ANIO"]),
                                COD_CLIENTE = drd["COD_CLIENTE"].ToString(),
                                NOM_CLIENTE = drd["NOM_CLIENTE"].ToString(),
                                CCOD_AGENTE = Convert.ToInt32(drd["CCOD_AGENTE"]),
                                NOM_AGENTE = drd["NOM_AGENTE"].ToString(),
                                CANTIDAD = Convert.ToInt32(drd["CANTIDAD"]),

                                COSTO = Convert.ToDouble(drd["COSTO"]),
                                MONTO = Convert.ToDouble(drd["MONTO"]),
                                CMG = Convert.ToDouble(drd["CMG"]),




                                SEM_PROGRAMADA = Convert.ToInt32(drd["SEM_PROGRAMADA"]),

                                CLAS_CREDITO = drd["CLAS_CREDITO"].ToString(),

                                FECHA_DOCTO = Convert.ToDateTime(drd["FECHA_DOCTO"]),
                                FECHA_REAL = fech_real,
                                UN = drd["UN"].ToString(),
                                REMISION = drd["REMISION"].ToString(),
                                CLASIFICACION = drd["CLASIFICACION"].ToString(),
                                DIVISION = drd["DIVISION"].ToString(),
                                FAMILIA = drd["FAMILIA"].ToString(),
                                LINEA = drd["LINEA"].ToString(),
                                MARCA = drd["MARCA"].ToString(),
                                PORTAFOLIO = drd["PORTAFOLIO"].ToString()
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

        public Newtonsoft.Json.Linq.JArray CALL_SP_VENTASVRSNC_2018()
        {
            DataTable ventas_vrs = new DataTable();
            List<VTS_AND_NCQV> LISTAREULTADO = new List<VTS_AND_NCQV>();
            try
            {


                using (SqlConnection CONEECT = new SqlConnection(@"Data Source=192.168.101.22;Initial Catalog=AGROVERSA_PRODUCTIVA;User ID=sa;Password=DB@gr0V3rs@"))
                {
                    CONEECT.Open();
                    using (SqlCommand COMANDO = new SqlCommand("SP_VRS_VENTAS_AND_NCQV", CONEECT))
                    {

                        COMANDO.CommandType = CommandType.StoredProcedure;
                        COMANDO.Parameters.Add("@INI_FCH", SqlDbType.DateTime);
                        COMANDO.Parameters["@INI_FCH"].Value = "2018-01-01";// _FILTRO_CNTRL.ini_fecha;


                        COMANDO.Parameters.Add("@FIN_FCH", SqlDbType.DateTime);
                        COMANDO.Parameters["@FIN_FCH"].Value = "2018-12-31";// _FILTRO_CNTRL.fin_fecha;



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
                            fech_real = Convert.ToDateTime(drd["FECHA_REAL"]).ToString("yyyy-MM-dd");


                            VTS_AND_NCQV ROW_OBJT = new VTS_AND_NCQV
                            {

                                NUM_DOCTO = Convert.ToInt32(drd["NUM_DOCTO"]),
                                CLAS_PROD = Convert.ToString(drd["CLAS_PROD"]),
                                TIPO_DOCTO = Convert.ToString(drd["TIPO_DOCTO"]),
                                SKU_PRODUCTO = Convert.ToString(drd["SKU_PRODUCTO"]),
                                NOM_PRODUCTO = Convert.ToString(drd["NOM_PRODUCTO"]),
                                MES = Convert.ToInt32(drd["MES"]),
                                ANIO = Convert.ToInt32(drd["ANIO"]),
                                COD_CLIENTE = drd["COD_CLIENTE"].ToString(),
                                NOM_CLIENTE = drd["NOM_CLIENTE"].ToString(),
                                CCOD_AGENTE = Convert.ToInt32(drd["CCOD_AGENTE"]),
                                NOM_AGENTE = drd["NOM_AGENTE"].ToString(),
                                CANTIDAD = Convert.ToInt32(drd["CANTIDAD"]),

                                COSTO = Convert.ToDouble(drd["COSTO"]),
                                MONTO = Convert.ToDouble(drd["MONTO"]),
                                CMG = Convert.ToDouble(drd["CMG"]),




                                SEM_PROGRAMADA = Convert.ToInt32(drd["SEM_PROGRAMADA"]),

                                CLAS_CREDITO = drd["CLAS_CREDITO"].ToString(),

                                FECHA_DOCTO = Convert.ToDateTime(drd["FECHA_DOCTO"]),
                                FECHA_REAL = fech_real,
                                UN = drd["UN"].ToString(),
                                REMISION = drd["REMISION"].ToString(),
                                CLASIFICACION = drd["CLASIFICACION"].ToString(),
                                DIVISION = drd["DIVISION"].ToString(),
                                FAMILIA = drd["FAMILIA"].ToString(),
                                LINEA = drd["LINEA"].ToString(),
                                MARCA = drd["MARCA"].ToString(),
                                PORTAFOLIO = drd["PORTAFOLIO"].ToString()
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
                                         CLAS_PROD = Convert.ToString(DRD["CLAS_PROD"]) ,
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

    public class FILTRO
    {
        public string api_consulta { get; set; }
        public string nombre { get; set; }
        public DateTime ini_fecha { get; set; }
        public DateTime fin_fecha { get; set; }
    
    }

    public class VTS_AND_NCQV
    {
        public Int32 NUM_DOCTO { get; set; }
        public string CLAS_PROD { get; set; }
        public string TIPO_DOCTO { get; set; }
        public string SKU_PRODUCTO { get; set; }
        public string NOM_PRODUCTO { get; set; }
        public Int32 MES { get; set; }
        public Int32 ANIO { get; set; }
        public string COD_CLIENTE { get; set; }
        public string NOM_CLIENTE { get; set; }
        public int CCOD_AGENTE { get; set; }
        public string NOM_AGENTE { get; set; }
        public int CANTIDAD { get; set; }
        public double  COSTO { get; set; }
        public double MONTO { get; set; }
        public double   CMG { get; set; }
        public int SEM_PROGRAMADA { get; set; }
        public string CLAS_CREDITO { get; set; }
        public DateTime FECHA_DOCTO { get; set; }
        public string UN { get; set; }
       
        public string REMISION { get; set; }
        public string CLASIFICACION { get; set; }
        public string DIVISION { get; set; }
        public string FAMILIA { get; set; }
        public string LINEA { get; set; }
        public string MARCA { get; set; }
        public string PORTAFOLIO { get; set; }
        public string PRESENTACION { get; set; }
        public string FECHA_REAL { get; set; }
    }

   

}