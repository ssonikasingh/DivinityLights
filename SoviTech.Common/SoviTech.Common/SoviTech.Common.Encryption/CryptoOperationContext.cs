namespace SoviTech.Common.Encryption
{
    public class CryptoOperationContext
    {
        public string Data { get; set; }
        public ICryptoOperation CryptoOperation { get; set; }

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public string Encrypt()
        {
            return CryptoOperation.Encrypt(Data);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public string Decrypt()
        {
            return CryptoOperation.Decrypt(Data);
        }
    }
}
