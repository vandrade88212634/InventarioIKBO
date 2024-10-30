using System.Diagnostics.CodeAnalysis;

namespace Common.Utils.Utils
{
    /// <summary>
    /// This class contains all configuration necessary for the execution a micro service
    /// </summary>

    [ExcludeFromCodeCoverage]
    public class ConfigExecMicroService
    {
        #region Constructor

        public ConfigExecMicroService()
        {
            headers = new Dictionary<string, string>();
        }

        #endregion Constructor

        #region Properties

        /// <summary>
        /// Property who map the url of micro service
        /// </summary>
        public string Url { get; set; }

        /// <summary>
        /// Property who map the controller name
        /// </summary>
        public string Controller { get; set; }

        /// <summary>
        /// Property who map the method name
        /// </summary>
        public string Method { get; set; }

        /// <summary>
        /// Property that map Authorize
        /// </summary>
        public string Token { get; set; }

        /// <summary>
        /// Property who map the parameters
        /// </summary>
        public Dictionary<string, string> headers { get; set; }

        #endregion Properties

        #region Methods

        /// <summary>
        /// This method add a new value by headers
        /// </summary>
        public void AddHeaders(string value_A, string value_B)
        {
            headers.Add(value_A, value_B);
        }

        #endregion Methods
    }
}