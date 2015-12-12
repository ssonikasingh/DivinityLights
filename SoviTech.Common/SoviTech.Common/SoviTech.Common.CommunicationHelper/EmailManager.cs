using System;
using System.Net;
using System.Net.Mail;
using SoviTech.Common.Contracts;

namespace SoviTech.Common.CommunicationHelper
{
    public class EmailManager : IEmailManager
    { 
        private static readonly EMailServer mailServer = null;
        private static readonly Sender mailSender = null;

        static EmailManager()
        {

            mailServer = new EMailServer()
            {
                Host = "smtp.gmail.com",
                Port = 587,
            };

            mailSender = new Sender()
            {
                MailAddress = new MailAddress("cloudfreaks26@gmail.com", "Cloud Freaks"),
                Password = "Global@123",
            };
        }

        public void SendMail(EMailBody mailBody)
        {
            try
            {
                //Get Smtp Client
                var smtp = GetSmtpCLient();

                //Create Message
                var message = new MailMessage()
                {
                    From = mailSender.MailAddress,
                    Subject = mailBody.Subject,
                    Body = mailBody.BodyText,
                };

                #region "Populate To List"
                if (!string.IsNullOrWhiteSpace(mailBody.To))
                {
                    string[] strArr = mailBody.To.Split(',');
                    for (int i = 0; i < strArr.Length; i++)
                    {
                        message.To.Add(strArr[i]);
                    }

                }

                #endregion

                #region "Populate Cc List"

                if (!string.IsNullOrWhiteSpace(mailBody.Cc))
                {
                    string[] strArrCc = mailBody.Cc.Split(',');
                    for (int i = 0; i < strArrCc.Length; i++)
                    {
                        message.CC.Add(strArrCc[i]);
                    }
                }

                #endregion

                #region "Populate Bcc List"

                if (!string.IsNullOrWhiteSpace(mailBody.Bcc))
                {
                    string[] strArrBcc = mailBody.Bcc.Split(',');
                    for (int i = 0; i < strArrBcc.Length; i++)
                    {
                        message.CC.Add(strArrBcc[i]);
                    }
                }

                #endregion

                #region "Attachement"
                if (!string.IsNullOrWhiteSpace(mailBody.AttachmentPath))
                    message.Attachments.Add(new Attachment(mailBody.AttachmentPath));

                #endregion

                //Send Mail
                smtp.Send(message);

            }
            catch (Exception ex)
            {

            }

        }

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        private static SmtpClient GetSmtpCLient()
        {
            var smtp = new SmtpClient
            {
                Host = mailServer.Host,
                Port = mailServer.Port,
                EnableSsl = true,
                DeliveryMethod = SmtpDeliveryMethod.Network,
                UseDefaultCredentials = false,
                Credentials = new NetworkCredential(mailSender.MailAddress.Address, mailSender.Password)
            };

            return smtp;
        }
    }

   


   
}
