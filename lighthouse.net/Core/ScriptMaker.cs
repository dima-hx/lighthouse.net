using System;
using System.IO;

namespace lighthouse.net.Core
{
    internal sealed class ScriptMaker
    {
        private readonly string _templatePath;
        internal string TempFileName { get; private set; }
        internal ScriptMaker(string template_path)
        {
            this._templatePath = template_path;
        }

        internal string Produce()
        {
            var data = File.ReadAllText(this._templatePath);
            return data;
        }
        public bool Save(string content)
        {
            this.TempFileName = null;

            string tempPath = Path.GetTempPath();

            var fullPath = $"{tempPath}\\lighthouse-net-{Guid.NewGuid():N}.js";
            try
            {
                File.WriteAllText(fullPath, content);
                this.TempFileName = fullPath;
                return true;
            }
            catch(Exception)
            {
                return false;
            }
        }
        public bool Delete()
        {
            if (String.IsNullOrEmpty(this.TempFileName)) return false;
            try
            {
                File.Delete(this.TempFileName);
                return true;
            }
            catch (Exception)
            {

            }
            return false;
        }
    }
}
