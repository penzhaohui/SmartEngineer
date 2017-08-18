using System.Configuration;

namespace SmartEngineer.Config
{
    /// <summary>
    /// Define Data Object for WebServiceNode Element According to 'webServiceConfiguration\webSites\webSite\webServices\webService' in web.config.
    /// In order to get web service node value from config file. 
    /// </summary>
    public sealed class WebServiceNode : ConfigurationElement
    {
        #region Properties

        /// <summary>
        /// Gets the web service global id 
        /// </summary>
        [ConfigurationProperty("id", IsRequired = true)]
        public string ID
        {
            get
            {
                return this["id"] as string;
            }
        }

        /// <summary>
        /// Gets the custom timeout value for this web service.
        /// </summary>
        [ConfigurationProperty("timeout", IsRequired = false)]
        public int Timeout
        {
            get
            {
                return (int)this["timeout"];
            }
        }

        /// <summary>
        /// Gets the web service url to invoke.
        /// </summary>
        [ConfigurationProperty("url", IsRequired = false)]
        public string Url
        {
            get
            {
                return this["url"] as string;
            }
        }

        #endregion Properties
    }
}
