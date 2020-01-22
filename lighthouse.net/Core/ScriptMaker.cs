using System;
using System.IO;
using lighthouse.net.Objects;
using Newtonsoft.Json;

namespace lighthouse.net.Core
{
    internal sealed class ScriptMaker
    {
        internal string TempFileName { get; private set; }
        internal ScriptMaker()
        {
        }

        internal string Produce(AuditRequest request, string npmPath)
        {
            if (request == null) return null;
            var data = this.getTemplate();

            var jsOptions = new LighthouseJsOptions()
            {
                chromeFlags = new []
                {
                    "--show-paint-rects",
                    "--headless"
                },
                maxWaitForLoad = request.MaxWaitForLoad,
                blockedUrlPatterns = request.BlockedUrlPatterns,
                disableStorageReset = request.DisableStorageReset,
                disableDeviceEmulation = request.DisableDeviceEmulation,
                OnlyCategories = request.OnlyCategories,

                emulatedFormFactor = request.EmulatedFormFactor?.ToString().ToLower()
            };

            var optionsAsJson = JsonConvert.SerializeObject(jsOptions,
                Formatting.None,
                new JsonSerializerSettings
                {
                    NullValueHandling = NullValueHandling.Ignore
                });
            
            data = data.Replace("{OPTIONS}", optionsAsJson)
                .Replace("{URL}", request.Url)
                .Replace("{NODE_MODULES}", npmPath.Replace("\\", "\\\\") + "\\\\node_modules");

            return data;
        }
        public bool Save(string content)
        {
            this.TempFileName = null;

            string tempPath = Path.GetTempPath();

            var fullPath = $"{tempPath}lighthouse-net-{Guid.NewGuid():N}.js";
            try
            {
                File.WriteAllText(fullPath, content);
                this.TempFileName = fullPath;
                return true;
            }
            catch(Exception)
            {
                return false;
            }
        }
        public bool Delete()
        {
            if (String.IsNullOrEmpty(this.TempFileName)) return false;
            try
            {
                File.Delete(this.TempFileName);
                return true;
            }
            catch (Exception)
            {

            }
            return false;
        }

        private string getTemplate()
        {
            return @"
const lighthouse = require('{NODE_MODULES}\\lighthouse');
const chromeLauncher = require('{NODE_MODULES}\\lighthouse\\node_modules\\chrome-launcher');
const Configstore = require('{NODE_MODULES}\\lighthouse\\node_modules\\configstore');

function setLighthouseConfig(){
    const configstore = new Configstore('lighthouse');
    configstore.set('isErrorReportingEnabled', true);
}

function launchChromeAndRunLighthouse(url, opts, config = null) {
    return chromeLauncher.launch({ chromeFlags: opts.chromeFlags }).then(chrome => {
        opts.port = chrome.port;
        return lighthouse(url, opts, config).then(results => {
            return chrome.kill().then(() => results.lhr);
        });
    });
}

setLighthouseConfig();

const opts = {OPTIONS};

launchChromeAndRunLighthouse('{URL}', opts).then(results => {
    console.log(JSON.stringify(results));
});";

        }
    }
}
