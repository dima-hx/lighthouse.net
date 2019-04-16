using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace lighthouse.net.Core
{
    internal sealed class Logger : ILogger
    {
        private readonly string _tempDirectory;
        private readonly string _fileName;
        internal Logger(string name)
        {
            this._tempDirectory = Path.GetTempPath();
            this._fileName = $"{name}-{Guid.NewGuid():N}.txt";
        }


        public bool Append(string content)
        {
            try
            {
                lock (this)
                {
                    File.AppendAllText(_tempDirectory + _fileName, content);
                }
                return true;
            }
            catch
            {
            }
            return false;
        }
    }
}
