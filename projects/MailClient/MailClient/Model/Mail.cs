﻿using System.Collections;

namespace MailClient.Model
{
    public class Mail
    {
        #region properties

        public int Id { get; set; }
        public string From { get; set; }
        public string To { get; set; }
        public string Subject { get; set; }
        public string Message { get; set; }

        #endregion

        #region constructors

        public Mail() { }

        public Mail(string from, string to, string subject, string message)
        { 
            From = from;
            To = to;
            Subject = subject;
            Message = message;
        }

        public Mail(int id, string from, string to, string subject, string message)
        {
            Id = id;
            From = from;
            To = to;
            Subject = subject;
            Message = message;
        }

        #endregion

        #region methods

        public static Mail Parse(AE.Net.Mail.MailMessage mailMessage)
        {
            var mail = new Mail();
            mail.From = mailMessage.From.ToString();
            IList mailAdressesTo = mailMessage.To as IList;
            if (mailAdressesTo.Count > 0)
                mail.To = mailAdressesTo[0].ToString();
            else
                mail.To = null;
            mail.Subject = mailMessage.Subject;
            mail.Message = mailMessage.Body;
            return mail;
        }

        #endregion
    }
}
