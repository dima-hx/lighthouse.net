using lighthouse.net.Objects;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace lighthouse.net.Core
{
    internal sealed class Npm : TerminalBase
    {
        protected override string FileName { get; }

        private Npm()
        {
        }
        public Npm(string nodePath)
        {
            this.FileName = nodePath.Replace("node.exe", "npm.cmd");
        }

        internal async Task<string> GetNpmPath()
        {
            var rsp = await this.Execute("config get prefix");
            if (String.IsNullOrEmpty(rsp)) throw new Exception("Couldn't detect global node_modules path.");
            return rsp.Trim();
        }
        internal async Task<NpmPackageVersion> GetLighthouseVersion()
        {
            var rsp = await this.Execute("list -g --depth=0 | find \"lighthouse\"");
            var index = !String.IsNullOrEmpty(rsp) ? rsp.IndexOf("@") : -1;
            if (index == -1) throw new Exception("Couldn't detect lighthouse version.");
            return new NpmPackageVersion(rsp.Substring(index + 1).Trim());
        }
        protected override void OnError(string message)
        {
            throw new Exception(message);
        }
    }
}
