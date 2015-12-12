
using System.Net.Mail;

namespace SoviTech.Common.CommunicationHelper
{

    /// <summary>
    /// Email Sender
    /// </summary>
    public class Sender
    {
        /// <summary>
        /// Mail Address of Sender
        /// </summary>
        public MailAddress MailAddress
        {
            get;
            set;
        }

        /// <summary>
        /// Password of Sender
        /// </summary>
        public string Password
        {
            get;
            set;
        }
    }
}
