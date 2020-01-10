using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Mail;
using System.Web;

namespace OTRA_API_008.Models
{
    public class SMT_MAIL : objt_MailMesage
    {

      private   SmtpClient smtp = new SmtpClient();


        public SMT_MAIL()
        {
            smtp.Host = "smtp.office365.com";
            smtp.Port = 587;
            smtp.EnableSsl = true ;
            smtp.UseDefaultCredentials = false;
            smtp.Credentials = new NetworkCredential("notificaciones@agroversa.mx", "S3cur3K3y");

        }
        public int  SendCorre(String _STRGTO , String _STRASUNTO , String _STRBODY)
        {
            int   output = 00; 
            CORREO_MAIN.To.Add(new MailAddress(_STRGTO));
            CORREO_MAIN.From = new MailAddress("notificaciones@agroversa.mx");
            CORREO_MAIN.Subject = _STRASUNTO;
            CORREO_MAIN.Body = _STRBODY;
            CORREO_MAIN.IsBodyHtml = true;
            CORREO_MAIN.Priority = MailPriority.Normal;

            try
            {
                smtp.Send(CORREO_MAIN);
                CORREO_MAIN.Dispose();
                output = 1357;
            }
            catch (Exception ex)
            {
                output = 111;
            }

            return output;
        }




     


    }
}