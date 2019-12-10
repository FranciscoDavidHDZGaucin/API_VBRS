﻿using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using Newtonsoft.Json.Linq;
using Newtonsoft.Json;

namespace OTRA_API_008.Models
{
    public class DocMain_VRS
    {

       
        public List<BRWS_DOCTO> _ResObjeto = null;
        public DataTable _Maintable = new DataTable();
        public JArray _MAIN_JARRAY = new JArray(); 

        public JArray Get_Json_data()
        {

            var jsonresult = JsonConvert.SerializeObject(_ResObjeto);
            JArray Areglo_JSON = JArray.Parse(jsonresult);

            return _MAIN_JARRAY =Areglo_JSON;

        }

        public DocMain_VRS()
        {
            Obtener_main_info();
            Get_Json_data();
        }

        private void Obtener_main_info()
        {
            using (MySqlConnection myconec = new MySqlConnection(@"server=192.168.101.5; database=pedidos;user id=root; password=avsa0543;"))
            {
                myconec.Open();
                using (MySqlCommand Selecttb = new MySqlCommand("SELECT * FROM   pedidos.vw_BRWS_PEDIDOS_ALL", myconec))
                {
                    
                    using (MySqlDataAdapter ADESELECT = new MySqlDataAdapter(Selecttb)     )
                    {

                       


                        ADESELECT.Fill(_Maintable);
                        _ResObjeto =  LIST_OBJETOS(_Maintable);

                    }


                }


            }




        }


        private List<BRWS_DOCTO> LIST_OBJETOS(DataTable RES )
        {
            var CONVERCION_LISTO = (from rw in RES.AsEnumerable()
                                    select new BRWS_DOCTO()
                                    {
                                             FOLIO = Convert.ToInt64(rw["folio"]) ,

                                             FECHA_CREACION =Convert.ToDateTime(rw["fecha_crea"]),
                                             ANIO = Convert.ToInt32(rw["anio"]),
                                        USUARIO = Convert.ToInt32(rw["USUARIO"]),
                                        TYPE_DOCTO = Convert.ToString(rw["TYPE_DOCTO"]),
                                        NAME_DOCTO = Convert.ToString(rw["NAME_DOCTO"])


                                    }


                                    ).ToList();

            return CONVERCION_LISTO;

        }
        public List<BRWS_DOCTO> OBJE_SOLO_PORYEAR(int ANIO)
        {
            var _ELEM_ANIOlist = (from rw in _Maintable.AsEnumerable()
                                  where rw.Field<int>("anio") == ANIO
                                  select new BRWS_DOCTO()
                                  {
                                      FOLIO = Convert.ToInt64(rw["folio"]),

                                      FECHA_CREACION = Convert.ToDateTime(rw["fecha_crea"]),
                                      ANIO = Convert.ToInt32(rw["anio"]),
                                      USUARIO = Convert.ToInt32(rw["USUARIO"]),
                                      TYPE_DOCTO = Convert.ToString(rw["TYPE_DOCTO"]),
                                      NAME_DOCTO = Convert.ToString(rw["NAME_DOCTO"])


                                  }


                              ).ToList();

            return _ELEM_ANIOlist;

        }
        public JArray Get_Data_ANIO( int  ANIO)
        {

            var jsonresult = JsonConvert.SerializeObject(OBJE_SOLO_PORYEAR( ANIO));
            JArray Areglo_JSON = JArray.Parse(jsonresult);

            return   Areglo_JSON;

        }


    }
}