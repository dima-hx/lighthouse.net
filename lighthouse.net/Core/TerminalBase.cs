using System;
using System.Diagnostics;
using System.Text;
using System.Threading.Tasks;

namespace lighthouse.net.Core
{
    internal abstract class TerminalBase
    {
        protected abstract string FileName { get; }
        protected async Task<string> Execute(string arguments)
        {
            ILogger logger = null;
            if (this.EnableDebugging)
            {
                logger = new Logger("lighthouse-net-output-console");
            }

            var processInfo = new ProcessStartInfo
            {
                FileName = this.FileName,
                Arguments = arguments,
                RedirectStandardInput = true,
                RedirectStandardOutput = true,
                RedirectStandardError = true,
                UseShellExecute = false,
                StandardOutputEncoding = Encoding.UTF8,
                WindowStyle = ProcessWindowStyle.Hidden
            };
            var process = Process.Start(processInfo);
            if (process == null) return await Task.FromResult<string>(null);

            StringBuilder sb = new StringBuilder(), sbError = new StringBuilder();

            logger?.Append($"Command: {this.FileName} {arguments}\r\n\r\n");

            process.OutputDataReceived += (sender, args) =>
            {
                sb.Append(args.Data);
                logger?.Append(args.Data);
            };
            process.ErrorDataReceived += (sender, args) =>
            {
                sbError.Append(args.Data);
                logger?.Append(args.Data);
            };
            process.BeginOutputReadLine();
            process.BeginErrorReadLine();
            
            process.WaitForExit();

            var output = sb.ToString();
            var err = sbError.ToString();
            if (!String.IsNullOrEmpty(err))
            {
                this.OnError(err);
            }

            return output;
        }
        protected virtual void OnError(string message)
        {
        }

        internal bool EnableDebugging { get; set; }
    }
}
