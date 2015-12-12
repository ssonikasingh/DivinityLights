namespace SoviTech.Common.Config
{
    using System;
    using System.Configuration;
    using System.Configuration.Provider;
    using System.Web.Configuration;

    /// <summary>Represents a repository to give access to the providers.</summary>
    /// <remarks>
    /// http://www.danrigsby.com/blog/index.php/2008/02/22/how-to-extend-the-provider-model-to-make-it-easy-to-use/
    /// </remarks>
    public sealed class ProviderRepository<T>
        where T : ProviderBase
    {
        #region Fields

        private string _defaultProviderName = String.Empty;
        private T _provider;
        private ProviderCollection<T> _providers;
        private readonly string _sectionName = String.Empty;
        private volatile object _syncRoot = new object();

        #endregion Fields

        #region Constructors

        /// <summary>
        /// Initializes a new instance of the <see cref="ProviderRepository&lt;T&gt;"/> class.
        /// </summary>
        public ProviderRepository(
            )
            : this(true)
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="ProviderRepository&lt;T&gt;"/> class.
        /// </summary>
        /// <param name="throwErrorIfUnableToLoadSection">if set to <c>true</c> [throw error if unable to load section].</param>
        public ProviderRepository(
            bool throwErrorIfUnableToLoadSection)
        {
            if (String.IsNullOrEmpty(_sectionName))
            {
                _sectionName = typeof(T).ToString();
            }

            LoadProviders(throwErrorIfUnableToLoadSection);
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="ProviderRepository&lt;T&gt;"/> class.
        /// </summary>
        /// <param name="sectionName">Name of the section.</param>
        public ProviderRepository(
            string sectionName)
            : this(sectionName, true)
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="ProviderRepository&lt;T&gt;"/> class.
        /// </summary>
        /// <param name="sectionName">Name of the section.</param>
        /// <param name="throwErrorIfUnableToLoadSection">if set to <c>true</c> [throw error if unable to load section].</param>
        public ProviderRepository(
            string sectionName,
            bool throwErrorIfUnableToLoadSection)
        {
            _sectionName = sectionName;
            LoadProviders(throwErrorIfUnableToLoadSection);
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="ProviderRepository&lt;T&gt;"/> class.
        /// </summary>
        /// <param name="provider">The provider.</param>
        public ProviderRepository(
            T provider)
        {
            _providers = new ProviderCollection<T> {provider};

            _provider = provider;
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="ProviderRepository&lt;T&gt;"/> class.
        /// </summary>
        /// <param name="providers">The providers.</param>
        public ProviderRepository(
            ProviderCollection<T> providers)
        {
            _providers = providers;
        }

        #endregion Constructors

        #region Properties

        public string DefaultProviderName
        {
            get
            {
                return _defaultProviderName;
            }
        }

        /// <summary>
        /// Gets the provider.
        /// </summary>
        /// <value>The provider.</value>
        public T Provider
        {
            get
            {
                if (_provider == null && _providers.Count > 0)
                {
                    _provider = _providers[0];
                }

                return _provider;
            }
        }

        /// <summary>
        /// Gets the providers.
        /// </summary>
        /// <value>The providers.</value>
        public ProviderCollection<T> Providers
        {
            get
            {
                return _providers;
            }
        }

        /// <summary>Gets the name of the configuration section.</summary>
        /// <value>The name of the section.</value>
        public string SectionName
        {
            get
            {
                return _sectionName;
            }
        }

        #endregion Properties

        #region Methods

        /// <summary>
        /// Loads the providers.
        /// </summary>
        private void LoadProviders(
            bool throwErrorIfUnableToLoadSection)
        {
            // Avoid claiming lock if providers are already loaded
            if (_providers == null)
            {
                lock (_syncRoot)
                {
                    // Do this again to make sure provider is still null
                    if (_providers != null) return;
                    // Get the providers
                    _providers = new ProviderCollection<T>();

                    // Get a reference to the section
                    ProvidersSection section;
                    try
                    {
                        section =
                            ConfigurationManager.GetSection(_sectionName) as ProvidersSection;
                    }
                    catch (Exception)
                    {
                        section = null;
                    }

                    if (section == null)
                    {
                        if (throwErrorIfUnableToLoadSection)
                        {
                            throw new ProviderException(
                                String.Format("Unable to load configuration section: '{0}'.",
                                    _sectionName));
                        }
                    }
                    else
                    {
                        ProvidersHelper.InstantiateProviders(section.Providers, _providers, typeof(T));

                        if (_providers.Count > 0)
                        {
                            // If there is a default provider specified, then grab it,
                            // else grab the first provider in the collection
                            if (!String.IsNullOrEmpty(section.DefaultProvider))
                            {
                                _defaultProviderName = section.DefaultProvider;
                                _provider = _providers[section.DefaultProvider];
                            }
                            else
                            {
                                _provider = _providers[0];
                            }
                        }

                        if (throwErrorIfUnableToLoadSection)
                        {
                            // If we have no provider, then throw an exception
                            if (_provider == null)
                            {
                                throw new ProviderException(
                                    String.Format("Unable to load default provider for section: '{0}'.",
                                        _sectionName));
                            }
                        }
                    }
                }
            }
        }

        #endregion Methods
    }
}