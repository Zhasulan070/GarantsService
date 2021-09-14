using System;
using System.Net;
using System.Net.Mail;
using System.Threading.Tasks;
using GarantsService.Interfaces;
using Microsoft.Extensions.Logging;

namespace GarantsService.Services
{
    public class RequestDeniedService: IRequestDeniedService
    {
        private readonly ILogger<RequestDeniedService> _logger;

        public RequestDeniedService(ILogger<RequestDeniedService> logger)
        {
            _logger = logger;
        }

        public async Task<string> RequestDenied()
        {
            string result;
            try
            {
                var message = new MailMessage();
                message.IsBodyHtml = true;
                message.From = new MailAddress("OperFlowRB@sberbank.kz", "OperFlowRB");
                message.To.Add("Zhasulan.Amanzhol@sberbank.kz");
                message.Subject = "api";
                message.Body = "<div style = \"color: red;\"> Request denied";

                using var smtpClient = new SmtpClient("post.sberbank.kz", 25);
                var basicCredential = new NetworkCredential("prevent", "Sber2012");
                smtpClient.UseDefaultCredentials = false;
                smtpClient.Credentials = basicCredential;
                smtpClient.DeliveryMethod = SmtpDeliveryMethod.Network;
                await smtpClient.SendMailAsync(message);

                result = "Message succesfully sended";
            }
            catch (Exception e)
            {
                result = "Some problem with message sending";
                _logger.LogError(e, result);
            }

            return result;
        }
        
    }
}