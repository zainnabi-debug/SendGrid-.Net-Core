﻿using Microsoft.Extensions.Configuration;
using SendGrid;
using SendGrid.Helpers.Mail;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Authorization.Services
{
    public interface IMailService
    {

        Task SendEmailAsync(string toEmail, string subject, string content);
    }

    public class SendGridMailService : IMailService
    {
        private IConfiguration _configuration;

        public SendGridMailService(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        public async Task SendEmailAsync(string toEmail, string subject, string content)
        {
            var apiKey = _configuration["SendGridKey"];
            var client = new SendGridClient(apiKey);
            var from = new EmailAddress("zainolnabi88@gmail.com", "Triton Express");
            var to = new EmailAddress(toEmail);
            var msg = MailHelper.CreateSingleEmail(from, to, subject, content, content);
            var response = await client.SendEmailAsync(msg);
        }
    }
}
