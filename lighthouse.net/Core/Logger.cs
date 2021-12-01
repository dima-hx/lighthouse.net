using System;
using System.IO;

namespace lighthouse.net.Core
{
    internal sealed class Logger : ILogger
    {
        private readonly string _tempDirectory;
        private readonly string _fileName;
        private readonly object lockObj = new object();

        internal Logger(string name)
        {
            this._tempDirectory = Path.GetTempPath();
            this._fileName = $"{name}-{Guid.NewGuid():N}.txt";
        }

        public bool Append(string content)
        {
            try
            {
                lock (lockObj)
                {
                    File.AppendAllText(_tempDirectory + _fileName, content);
                }
                return true;
            }
            catch
            {
                // ignore
            }
            return false;
        }
    }
}
