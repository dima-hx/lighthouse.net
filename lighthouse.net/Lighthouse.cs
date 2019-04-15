using System;
using System.Diagnostics;
using System.IO;
using System.Net;
using System.Threading.Tasks;
using lighthouse.net.Core;
using lighthouse.net.Objects;
using System.Runtime.Serialization;
using System.Runtime.Serialization.Json;
using System.Text;

namespace lighthouse.net
{
    public sealed class Lighthouse
    {
        public Lighthouse()
        {
        }
        public async Task<bool> check_npm_installed()
        {
            var npm = new Npm();
            var nodesPath = npm.GetNodesGlobalPath();

            var sm = new ScriptMaker($"{AppDomain.CurrentDomain.BaseDirectory}\\Node\\template.js");

            var content = sm.Produce();
            if (sm.Save(content))
            {
                try
                {
                    var node = new Node();
                    var aa = await node.Run(sm.TempFileName);
                    var obj = FromJSON(new LighthouseRsp(), aa);
                }
                finally
                {
                    sm.Delete();
                }
            }

            return await Task.FromResult(true);
        }
        public static T FromJSON<T>(T obj, string json) where T : class
        {
            using (MemoryStream stream = new MemoryStream(Encoding.Unicode.GetBytes(json)))
            {
                DataContractJsonSerializer serializer = new DataContractJsonSerializer(typeof(T));
                return serializer.ReadObject(stream) as T;
            }
        }
    }
}
