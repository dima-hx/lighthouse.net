using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace lighthouse.net.Core
{
    internal sealed class Node : CmdBase
    {
        protected override string ExeFileName => @"C:\Program Files\nodejs\node.exe";
        public async Task<string> Run(string jsFilePath)
        {
            return await this.Execute(jsFilePath);
        }
    }

}
