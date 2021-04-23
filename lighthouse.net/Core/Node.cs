using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Threading.Tasks;

namespace lighthouse.net.Core
{
    internal sealed class Node : TerminalBase
    {
        protected override string FileName => "node";
        public async Task<string> Run(string jsFilePath)
        {
            return await this.Execute(jsFilePath).ConfigureAwait(false);
        }
        protected override void OnError(string message)
        {
            throw new Exception(message);
        }
    }

}
