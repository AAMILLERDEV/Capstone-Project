using Microsoft.Extensions.Options;
using prs_5SAudits.lib.Interfaces;
using prs_5SAudits.lib.Models;
using System.Net.Mail;

namespace prs_5SAudits.lib.Repositories;


public class EmailRepository : IEmails

{
    private readonly IDBSQLRepository db;

    public EmailRepository(IOptionsMonitor<AppSettings> options)
    {
        db = new DBSQLRepository(options.CurrentValue.DbConn);
    }

    public async Task<bool> SendSupportEmail(Email email)
    {
        try
        {
            MailMessage message = new MailMessage()
            {
                Subject = email.Subject,
                Body = email.Body,
                IsBodyHtml = true,
                From = new MailAddress("prs5SAudits@outlook.com"),
            };

            message.To.Add("amiller8096@conestogac.on.ca, qgardin2932@conestogac.on.ca, bpower0195@conestogac.on.ca, jdelahunty5276@conestogac.on.ca");

            var eventLog = new {
                DateTime = DateTime.Now,
                EventLogType = 2,
                
            };

            return await SendMail(message);

        }
        catch (Exception ex)
        {
            return false;
        }
    }

    public async Task<bool> SendMail(MailMessage message)
    {
        try
        {
            System.Net.ServicePointManager.SecurityProtocol = System.Net.SecurityProtocolType.Tls12;
            using SmtpClient smtpClient = new SmtpClient("smtp-mail.outlook.com", 587);

            smtpClient.EnableSsl = true;
            smtpClient.DeliveryMethod = SmtpDeliveryMethod.Network;
            smtpClient.Credentials = new System.Net.NetworkCredential("prs5SAudits@outlook.com", "5saudits99!");

            smtpClient.Send(message);

            smtpClient.Dispose();

            return true;

        }
        catch (Exception ex)
        {
            return false;
        }
    }
}