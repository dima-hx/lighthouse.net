using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;

namespace lighthouse.net.Objects
{
    public sealed class AuditRequest
    {
        public AuditRequest(string urlWithProtocol)
        {
            if (String.IsNullOrEmpty(urlWithProtocol)) throw new ArgumentNullException(nameof(urlWithProtocol));
            if (!urlWithProtocol.StartsWith("http")) throw new ArgumentException("Url must contain protocol", nameof(urlWithProtocol));

            this.Url = urlWithProtocol;
        }
        
        public string Url { get; }

        /// <summary>
        /// The maximum amount of time to wait for a page to load in ms
        /// </summary>
        public int? MaxWaitForLoad { get; set; }

        /// <summary>
        /// List of URL patterns to block
        /// </summary>
        public IEnumerable<string> BlockedUrlPatterns { get; set; }

        /// <summary>
        /// Flag indicating that the browser storage should not be reset for the audit
        /// </summary>
        public bool? DisableStorageReset { get; set; }

        /// <summary>
        /// Flag indicating that there shouldn't be any emulation during the run
        /// </summary>
        public bool? DisableDeviceEmulation { get; set;}

        /// <summary>
        /// The form factor the emulation should use
        /// </summary>
        public FormFactor? EmulatedFormFactor { get; set; }

        /// <summary>
        /// Only run the specified categories. Available categories: accessibility, best-practices, performance, pwa, seo
        /// </summary>
        public IEnumerable<Category> OnlyCategories {get; set;}

        public bool EnableLogging { get; set; }

        public enum FormFactor : byte
        {
            Mobile,
            Desktop,
            None
        }
    }
}
