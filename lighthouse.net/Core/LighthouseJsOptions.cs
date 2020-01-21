using System;
using System.Collections.Generic;
using System.Text;

namespace lighthouse.net.Core
{
    internal sealed class LighthouseJsOptions
    {
        public string[] chromeFlags { get; set; }
        public int? maxWaitForLoad { get; set; }
        public string[] blockedUrlPatterns { get; set;}
        public bool? disableStorageReset { get; set;}
        public bool? disableDeviceEmulation { get; set; }
        public string emulatedFormFactor { get; set; }

        public string[] onlyCategories { get; set; }

        public ThrottlingSettings throttling { get; set;}

        internal sealed class ThrottlingSettings
        {
            
        }
    }
}
