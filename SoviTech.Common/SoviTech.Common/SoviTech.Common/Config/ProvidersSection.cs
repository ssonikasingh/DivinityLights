namespace SoviTech.Common.Config
{
    using System.Configuration;

    /// <summary>
    /// A configuration section for a collection of providers.
    /// </summary>
    public class ProvidersSection : ConfigurationSection
    {
        #region Fields

        private const string DefaultProviderProperty = "defaultProvider";

        #endregion Fields

        #region Properties

        /// <summary>
        /// Gets or sets the default provider.
        /// </summary>
        /// <value>The default provider.</value>
        [ConfigurationProperty(DefaultProviderProperty, IsRequired = false)]
        public string DefaultProvider
        {
            get { return (string)base[DefaultProviderProperty]; }
            set { base[DefaultProviderProperty] = value; }
        }

        /// <summary>
        /// Gets the providers.
        /// </summary>
        /// <value>The providers.</value>
        [ConfigurationProperty("providers")]
        public ProviderSettingsCollection Providers
        {
            get { return (ProviderSettingsCollection)base["providers"]; }
        }

        [ConfigurationProperty("xmlns", IsRequired = false)]
        public string Xmlns
        {
            get { return (string)base["xmlns"]; }
        }

        #endregion Properties
    }
}