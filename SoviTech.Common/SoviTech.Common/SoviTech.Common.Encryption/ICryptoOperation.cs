
namespace SoviTech.Common.Encryption
{
    public interface ICryptoOperation
    {
        /// <summary>
        /// 
        /// </summary>
        /// <param name="value"></param>
        /// <returns></returns>
        string Encrypt(string value);

        /// <summary>
        /// 
        /// </summary>
        /// <param name="value"></param>
        /// <returns></returns>
        string Decrypt(string value);
    }
}
