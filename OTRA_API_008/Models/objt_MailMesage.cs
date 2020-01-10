using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Mail;
using System.Web;

namespace OTRA_API_008.Models
{
    public class objt_MailMesage
    {


        public String _STRGTO;
        public String _STRFROM;
        public String _STRASUNTO;
        public String _STRBODY;

        public MailMessage CORREO_MAIN = new MailMessage();

       

    }
}