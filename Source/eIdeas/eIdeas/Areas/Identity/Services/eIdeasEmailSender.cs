using Microsoft.AspNetCore.Identity.UI.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Mail;
using System.Threading.Tasks;

namespace eIdeas.Areas.Identity.Services
{
    public class eIdeasEmailSender : IEmailSender
    {
        private string Host;
        private int PortNum;
        private bool EnableSSL;
        private string EmailAddress;
        private string Password;

        public eIdeasEmailSender(string _Host,
         int _PortNum,
         bool _EnableSSL,
         string _EmailAddress,
         string _Password)
        {
            Host =  _Host;
            PortNum = _PortNum;
            EnableSSL = _EnableSSL;
            EmailAddress = _EmailAddress;
            Password = _Password;
        }

        public Task SendEmailAsync(string email, string subject, string message)
        {
            var Client = new SmtpClient(Host, PortNum)
            {
                Credentials = new NetworkCredential(EmailAddress, Password),
                EnableSsl = EnableSSL,
                DeliveryMethod = SmtpDeliveryMethod.Network
            };
            return Client.SendMailAsync(new MailMessage(EmailAddress, email, subject, message) { IsBodyHtml = true });
        }
    }
}
