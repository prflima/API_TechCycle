using System;
using System.Net;
using System.Net.Mail;
using Microsoft.AspNetCore.Mvc;

namespace API_TechCycle.Controllers
{
    public class EmailController : ControllerBase
    {
        public bool Email(string email, string corpoEmail, string tituloEmail)
        {
            try
            {
                MailMessage _message = new MailMessage();

                _message.From = new MailAddress("TechCycle.FCode@gmail.com");

                //Constrói o MailMessage (o email)
                _message.CC.Add(email);
                _message.Subject = tituloEmail;
                _message.IsBodyHtml = true;
                _message.Body = corpoEmail;

                // Configuração com Porta
                SmtpClient _smtpCLient = new SmtpClient("smtp.gmail.com", Convert.ToInt32("587"));

                // Credencial para envio por SMTP seguro (Quando o servidor exige autenticação)
                _smtpCLient.UseDefaultCredentials = false;
                _smtpCLient.Credentials = new NetworkCredential("TechCycle.FCode@gmail.com","techcycle132" );
                _smtpCLient.EnableSsl = true;
                _smtpCLient.Send(_message);

                return true;
            }
            catch(Exception ex)
            {
                throw ex;
            }
        }
    }
}