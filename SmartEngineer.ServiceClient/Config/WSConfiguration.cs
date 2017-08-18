using System.Configuration;

namespace SmartEngineer.Config
{
    /// <summary>
    /// Web Service Section object to load and handle the webServiceConfiguration section in web.config.
    /// </summary>
    public sealed class WSConfiguration : ConfigurationSection
    {
        #region Fields

        /// <summary>
        /// Web service configuration.
        /// </summary>
        private const string WS_SECTION_WEB_SERVICE_CONFIGURATION = "webServiceConfiguration";

        /// <summary>
        /// Web service select web site.
        /// </summary>
        private const string WS_SECTION_WEB_SITES = "webSites";

        #endregion Fields

        #region Properties

        /// <summary>
        /// Gets WebSite node collection.
        /// </summary>
        [ConfigurationProperty(WS_SECTION_WEB_SITES, IsRequired = true)]
        public WebSiteNodeCollection WebSites
        {
            get
            {
                return this[WS_SECTION_WEB_SITES] as WebSiteNodeCollection;
            }
        }

        #endregion Properties

        #region Methods

        /// <summary>
        /// Gets the instance of WSConfiguration class.
        /// </summary>
        /// <returns>the WSConfiguration object.</returns>
        public static WSConfiguration GetConfig()
        {
            return ConfigurationManager.GetSection(WS_SECTION_WEB_SERVICE_CONFIGURATION) as WSConfiguration;
        }

        #endregion Methods
    }
}
