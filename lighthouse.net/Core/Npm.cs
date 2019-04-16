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
        protected override void OnError(string message)
        {
            throw new Exception(message);
        }
    }
}
