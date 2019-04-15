using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace lighthouse.net.Core
{
    internal sealed class Npm : CmdBase
    {
        protected override string ExeFileName => @"C:\Program Files\nodejs\npm.cmd";

        internal async Task<string> GetNodesGlobalPath()
        {
            var rsp = await this.Execute("config get prefix");
            if (String.IsNullOrEmpty(rsp)) throw new Exception("Couldn't detect global node_modules path.");
            return rsp.Trim();
        }
    }
}
