using System;
using System.IO;
using lighthouse.net.Objects;
using Newtonsoft.Json;

namespace lighthouse.net.Core
{
    internal sealed class ScriptMaker
    {
        private readonly string _templatePath;
        internal string TempFileName { get; private set; }
        internal ScriptMaker(string template_path)
        {
            this._templatePath = template_path;
        }

        internal string Produce(AuditRequest request, string npmPath)
        {
            if (request == null) return null;
            var data = File.ReadAllText(this._templatePath);

            var jsOptions = new LighthouseJsOptions()
            {
                chromeFlags = new []
                {
                    "--show-paint-rects"
                },
                maxWaitForLoad = request.MaxWaitForLoad,
                blockedUrlPatterns = request.BlockedUrlPatterns,
                disableStorageReset = request.DisableStorageReset,
                disableDeviceEmulation = request.DisableDeviceEmulation,
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

            var fullPath = $"{tempPath}\\lighthouse-net-{Guid.NewGuid():N}.js";
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
    }
}
