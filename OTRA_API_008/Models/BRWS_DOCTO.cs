using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace OTRA_API_008.Models
{
    public class BRWS_DOCTO
    {
        public Int64 FOLIO { get; set; }

        public DateTime FECHA_CREACION { get; set; }

        public Int32 ANIO { get; set; }

        public Int32 USUARIO { get; set; }

        public String  TYPE_DOCTO  { get; set; }

        public String NAME_DOCTO { get; set;  }

    }
}