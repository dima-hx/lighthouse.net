using System.Diagnostics;
using System.Threading.Tasks;

namespace lighthouse.net.Core
{
    internal abstract class CmdBase
    {
        protected abstract string ExeFileName { get; }
        protected async Task<string> Execute(string arguments)
        {
            var processInfo = new ProcessStartInfo
            {
                FileName = this.ExeFileName,
                Arguments = arguments,
                RedirectStandardInput = true,
                RedirectStandardOutput = true,
                UseShellExecute = false
            };
            var process = Process.Start(processInfo);
            //process.OutputDataReceived += (sender, args) =>
            //{

            //};
            //process.BeginOutputReadLine();
            //process.StandardInput.WriteLine("npm.exe");
            if(process == null) return await Task.FromResult<string>(null);

            var a = await process.StandardOutput.ReadToEndAsync();
            process.WaitForExit();

            return a;
        }
    }
}
