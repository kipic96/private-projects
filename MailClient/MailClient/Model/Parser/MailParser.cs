﻿using MailClient.Model.Entity;
using System.Collections;


namespace MailClient.Model.Parser
{
    class MailParser
    {
        public static Mail Parse(AE.Net.Mail.MailMessage mailMessage)
        {
            string from = "";
            string to = "";
            if (mailMessage.From != null)
                from = mailMessage.From.ToString();
            IList mailAdressesTo = mailMessage.To as IList;
            if (mailAdressesTo.Count > 0)
                to = mailAdressesTo[0].ToString();            
            return new Mail
            {
                From = from,
                To = to,
                Subject = mailMessage.Subject,
                Message = mailMessage.Body
            };
        }

        public static Mail Parse(AE.Net.Mail.MailMessage mailMessage, int mailCount)
        {
            Mail mail = Parse(mailMessage);
            mail.Id = mailCount;
            return mail;
        }
    }
}
