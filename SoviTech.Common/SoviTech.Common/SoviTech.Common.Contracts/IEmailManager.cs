
namespace SoviTech.Common.Contracts
{
    /// <summary>
    /// Log Manager Interface
    /// </summary>
    public interface IEmailManager
    {
        /// <summary>
        /// 
        /// </summary>
        /// <param name="mailBody"></param>
        void SendMail(EMailBody mailBody);
    }
}
