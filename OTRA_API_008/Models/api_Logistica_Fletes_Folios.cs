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
    public class api_Logistica_Fletes_Folios
    {
        private SqlDataReader drd;

        public List<DataTable> _RES_TOTALES = null;

        public Newtonsoft.Json.Linq.JArray Fletes()
        {

            DataTable dtvts = new DataTable();
            try
            {
                using (SqlConnection CONECT = new SqlConnection(@"Data Source=192.168.101.154;Initial Catalog=JUPITER;User ID=sa;Password=DB@gr0V3rs@"))
                {
                    CONECT.Open();
                    using (SqlCommand COMANDO = new SqlCommand("select * from  OPENQUERY([MYSQL_SRV105],'select t1.n_remision,t2.folio, t1.entrega, t4.empresa, t3.comentarios, t3.km_prom_real, t3.flete_prov, t3.maniobras, t3.tot_peso, t3.tot_facturas, (t3.flete_prov*100)/t3.tot_facturas as gasto_flete, t3.flete_prov/t3.km_prom as costo_km, t3.envio_autoriza from pedidos.detalle_pedido t1 join pedidos.envios_det_productos_rf t2 on t1.id_detalle = t2.id_detalle join pedidos.envios_encabeza t3 on t2.folio = t3.folio join pedidos.transportes t4 on t3.n_proveedor = t4.id where t1.fecha_alta >=2021-01-01; ' )", CONECT))


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