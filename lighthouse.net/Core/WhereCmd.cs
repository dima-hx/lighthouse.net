using System.Threading.Tasks;

namespace lighthouse.net.Core
{
    internal sealed class WhereCmd : TerminalBase
    {
        protected override string FileName => "where.exe";
        internal async Task<string> GetNodePath()
        {
            return await this.Execute("node");
        }
    }
}
