using System;
using System.Net.Mail;
using System.Net;
using System.Threading.Tasks;

namespace Services.ExternalServices
{
    public class Smtp : ISmtp
    {
        public async Task<bool> EnviarEmailAsync(string para, string assunto, string mensagem)
        {
            try
            {
                var remetente = "ficticio@dominio.com"; 

                var smtpClient = new SmtpClient("localhost")
                {
                    Port = 25, 
                    Credentials = new NetworkCredential(remetente, ""), 
                    EnableSsl = false, 
                };

                var mailMessage = new MailMessage
                {
                    From = new MailAddress(remetente),
                    Subject = assunto,
                    Body = mensagem,
                    IsBodyHtml = true,
                };

                mailMessage.To.Add(para);

                await smtpClient.SendMailAsync(mailMessage);
                Console.WriteLine("Email enviado com sucesso!");
                return true;
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Erro ao enviar email: {ex.Message}");
                return false;
            }
        }
    }
}
