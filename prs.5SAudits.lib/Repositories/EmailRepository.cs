using Microsoft.Extensions.Options;
using prs_5SAudits.lib.Interfaces;
using prs_5SAudits.lib.Models;
using System.Net.Mail;

namespace prs_5SAudits.lib.Repositories;

public class EmailRepository : IEmail
{
    private readonly IDBSQLRepository db;
    

    public EmailRepository(IOptionsMonitor<AppSettings> options)
    {
        db = new DBSQLRepository(options.CurrentValue.DbConn);
    }

    public Task<bool> CreateEmail(EventLogs eventLogs)
    {
        try
        {
            MailMessage message = new MailMessage()
            {
                Subject = eventLogs.EventType_ID + " " + eventLogs.ShortMessage,
                Body = eventLogs.LongMessage,
                IsBodyHtml = true,
                From = new MailAddress("prs5sAuditsLogs@outlook.com")
            };

            SendMail(message);

            return Task.FromResult((true));
        }
        catch (Exception)
        {

            return Task.FromResult((false));
        }
    }

    //public async Task<bool> SendResetPasswordEmail(User user)
    //{
    //    try
    //    {
    //        const string chars = "ABCDEFGHIJKLMNOPQRSTUVWXYZ0123456789abcdefghijklmnopqrstuvwxyz!@#$%^&*()";
    //        var creds = new string(Enumerable.Repeat(chars, 14).Select(s => s[new Random().Next(s.Length)]).ToArray());

    //        var credentials = await db.GetCredentialsByID(user.Credentials_ID);
    //        int? creds_ID = 0;

    //        if (credentials == null)
    //        {
    //            return false;
    //        }

    //        var plainTextBytes = System.Text.Encoding.UTF8.GetBytes(creds);
    //        credentials.CredentialValue = Convert.ToBase64String(plainTextBytes);
    //        creds_ID = await db.UpsertCredentials(credentials);

    //        if (creds_ID == 0)
    //        {
    //            return false;
    //        }

    //        MailMessage message = new MailMessage()
    //        {
    //            Subject = "CVGS Account Management - Password Reset",
    //            Body = $"Your password has been reset to: {creds}",
    //            IsBodyHtml = true,
    //            From = new MailAddress("conestoga_CVGS_Mgmt@outlook.com")
    //        };

    //        message.To.Add(user.Email);

    //        return SendMail(message);

    //    }
    //    catch (Exception ex)
    //    {
    //        return false;
    //    }

    //}

    public bool SendMail(MailMessage message)
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