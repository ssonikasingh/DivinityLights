
namespace SoviTech.Common.Contracts
{
    /// <summary>
    /// Email Body
    /// </summary>
    public class EMailBody
    {
        /// <summary>
        /// Comma Seprated To List
        /// </summary>
        public string To
        {
            get;
            set;
        }

        /// <summary>
        /// Comma Seprated Cc List
        /// </summary>
        public string Cc
        {
            get;
            set;
        }

        /// <summary>
        /// Comma Seprated Bcc List
        /// </summary>
        public string Bcc
        {
            get;
            set;
        }

        /// <summary>
        /// Subject of Mail
        /// </summary>
        public string Subject
        {
            get;
            set;
        }

        /// <summary>
        /// Body Text
        /// </summary>
        public string BodyText
        {
            get;
            set;
        }

        /// <summary>
        /// Path for Attachment file
        /// </summary>
        public string AttachmentPath
        {
            get;
            set;
        }

    }
}
